using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExamSystem.Core
{
    public static class Localization
    {
        public const string LOCALIZATION_FOLDER = "Localization";
        public const string DEFAULT_LOCALIZATION = "English";

        private static Dictionary<string, string> _localization;

        private static bool _isLoaded = false;


        public static void Load()
        {
            string localization = Config.Get<string>("Localization");
            List<string> availableLocalizations = GetAvailableLocalizations();
            if (!availableLocalizations.Any(x => x == localization))
            {
                //There is no available localization, we create and implement the default localization
                _localization = ReadDefaultLocalization();
                Config.Set("Localization", DEFAULT_LOCALIZATION);
            }
            else
            {
                _localization = ReadLocalization(File.OpenRead(Path.Combine(LOCALIZATION_FOLDER, localization + ".locale.json")));
                Dictionary<string, string> defaultLocalization = ReadDefaultLocalization();
                foreach (var defaultLocalizationEntry in defaultLocalization)
                {
                    //If current localization doesn't have this entry, we add it from the default localization
                    if (!_localization.ContainsKey(defaultLocalizationEntry.Key))
                    {
                        _localization.Add(defaultLocalizationEntry.Key, defaultLocalizationEntry.Value);
                    }
                }
            }
            _isLoaded = true;
        }

        //Read Localization Stream
        private static Dictionary<string, string> ReadLocalization(Stream localizationStream)
        {
            byte[] defaultLocalizationBuffer = new byte[localizationStream.Length];
            localizationStream.Read(defaultLocalizationBuffer, 0, defaultLocalizationBuffer.Length);

            return JsonConvert.DeserializeObject<Dictionary<string, string>>(Encoding.UTF8.GetString(defaultLocalizationBuffer));
        }



        private static Dictionary<string, string> ReadDefaultLocalization()
        {
            //Gets embedded resources
            Stream defaultLocalizationStream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"ExamSystem.Resources.{DEFAULT_LOCALIZATION}.locale.json");
            if (defaultLocalizationStream == null)
            {
                throw new Exception("Failed to load default localization");
            }

            return ReadLocalization(defaultLocalizationStream);
        }

        //Get Localization files in localization folder
        private static List<string> GetAvailableLocalizations()
        {
            if (Directory.Exists(LOCALIZATION_FOLDER))
            {
                List<string> localizations = Directory.EnumerateFiles(LOCALIZATION_FOLDER, "*.locale.json")
                   .Select(x => Path.GetFileNameWithoutExtension(x))
                   .Select(x => Path.GetFileNameWithoutExtension(x))
                   .ToList();
                if (!localizations.Contains(DEFAULT_LOCALIZATION))
                {
                    localizations.Add(DEFAULT_LOCALIZATION);
                }
                return localizations;
            }
            else
            {
                Directory.CreateDirectory(LOCALIZATION_FOLDER);

                return new List<string>();
            }
        }

        public static string Get(string entry)
        {
            if (_localization is null || !_localization.ContainsKey(entry))
            {
                return entry;
            }
            else
            {
                return _localization[entry];
            }
        }
        public static string GetDefault(string entry)
        {
            return Config.GetDefault<string>(entry);
        }
        private static void CheckUsability()
        {
            if (!_isLoaded)
                throw new LocalizationFilesDidNotLoadedException();
        }
        public static ReadOnlyDictionary<string, string> GetDictionary()
        {
            CheckUsability();
            return new ReadOnlyDictionary<string, string>(_localization);
        }
        public static ReadOnlyDictionary<string, string> GetDefaultDictionary()
        {
            return new ReadOnlyDictionary<string, string>(ReadDefaultLocalization());
        }
        private class LocalizationFilesDidNotLoadedException : Exception
        {
            public LocalizationFilesDidNotLoadedException([CallerMemberName] string name = "") : base($"Error while try to use {name}, did not load localization file.")
            {

            }
        }
    }
}
