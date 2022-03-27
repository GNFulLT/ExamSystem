using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core
{
    public static class Config
    {
        public const string CONFIG_FILE = "config.json";
        private static readonly Dictionary<string, object> _defaultConfig = new Dictionary<string, object>
        {
            { "Localization", "English" },
            { "IsDarkMode", false }
        };

        private static bool _isloaded = false;

        private static Dictionary<string, object> _config = new Dictionary<string, object>();

        
        public static T Get<T>(string key)
        {
            CheckUsability();
            if (!_config.ContainsKey(key))
            {
                return GetDefault<T>(key);
            }
            else
            {
                return (T)_config[key];
            }
            
        }

        public static T GetDefault<T>(string key)
        {
            return (T)_defaultConfig[key];
        }
        public static void Load()
        {
            if (File.Exists(CONFIG_FILE))
            {
                Deserialize(File.ReadAllText(CONFIG_FILE));

                foreach (KeyValuePair<string, object> configEntry in _defaultConfig)
                {
                    if (!_config.ContainsKey(configEntry.Key))
                    {
                        _config.Add(configEntry.Key, configEntry.Value);
                    }
                }
            }
            _isloaded = true;
        }

        private static void Deserialize(string json)
        {
            _config = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        }

        public static void Write()
        {
            File.WriteAllText(CONFIG_FILE, Serialize());
        }

        private static string Serialize()
        {
            return JsonConvert.SerializeObject(_config, Formatting.Indented);
        }

        public static void Set(string key, object value)
        {
            if (_config.ContainsKey(key))
            {
                _config[key] = value;
            }
            else
            {
                _config.Add(key, value);
            }

            Write();
        }

        private static void CheckUsability()
        {
            if (!_isloaded)
                throw new ConfigurationFileDidNotLoadedException();
        }

        private class ConfigurationFileDidNotLoadedException : Exception
        {
    
            public ConfigurationFileDidNotLoadedException([CallerMemberName] string name = "") : base($"Error while try to use {name}, did not load configuration file.") { 

            }
        }
    }
}
