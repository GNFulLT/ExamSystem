using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ExamSystem.Core.Utilities.Localization
{
    public static class Localization
    {
        public const string LOCALIZATION_FOLDER = "Localization";
        public const string DEFAULT_LOCALIZATION = "English";

        private static Dictionary<string, string> _localization;
        private static Dictionary<string, string> _defaultLocalization;


        static Localization()
        {
            _defaultLocalization = LoadDefaultLocalization();
        }

        private static Dictionary<string, string> LoadDefaultLocalization()
        {
            //Get Stream of the resource english.json
            Stream defaultLocalizationStream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"ExamSystem.Core.Resources.{DEFAULT_LOCALIZATION}.locale.json");
            if (defaultLocalizationStream == null)
            {
                throw new Exception("Failed to load default localization");
            }
            byte[] defaultLocalizationBuffer = new byte[defaultLocalizationStream.Length];
            defaultLocalizationStream.Read(defaultLocalizationBuffer, 0, defaultLocalizationBuffer.Length);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(Encoding.UTF8.GetString(defaultLocalizationBuffer));


        }

        public static void SetDefaultLocalization<T>(T viewModel) where T: ViewModel
        {
            var type = typeof(T);

            foreach(var item in type.GetProperties())
            {
                if(item.PropertyType == typeof(string))
                {
                    object[] attrs = item.GetCustomAttributes(true);

                    foreach (var attr in attrs)
                    {
                        if(attr.GetType() == typeof(LocalizablePropertyAttribute))
                        {
                            var localizationAttr = attr as LocalizablePropertyAttribute;
                            string propName = localizationAttr.PropertyName;
                            string jsonName = localizationAttr.JsonName;
                            type.GetProperty(propName).SetValue(viewModel, _defaultLocalization[jsonName]);
                        }
                    }
                }
            }
        }


    }
}
