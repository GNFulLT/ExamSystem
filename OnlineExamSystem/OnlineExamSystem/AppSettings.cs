using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace OnlineExamSystem
{
    //Jsona serilize edilebileceğini gösteren  attribute.
    [Serializable]
    
    public class AppSettings
    {
        private const string FILE_NAME = "settings.json";


       public enum Language {Turkish,English}

       public bool IsLight { get; set; }
       public Language LanguageOption  { get; set; }  
       
        
       
        /// <summary>
        /// Check json existed
        /// </summary>
        /// <returns></returns>
        internal bool IsJsonExisted()
        {
            return File.Exists(GetPath());
            
        }
        /// <summary>
        /// Update Json file
        /// </summary>
        internal void SetJsonFile()
        {
            DeleteJsonFile();
            CreateJsonFile(false);
        }
        /// <summary>
        /// Fetch setting in Json File 
        /// </summary>
        internal void GetSettings()
        {
            try
            {
                AppSettings settings = JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(GetPath()));
                if (!Enum.IsDefined(typeof(Language), settings.LanguageOption))
                {
                    settings.LanguageOption = 0;
                    this.Equalize(settings);
                }
                else
                {
                this.Equalize(settings);    

                }

            }
            catch(Exception e)
            {
                if (e is JsonReaderException)
                {
                    DeleteJsonFile();
                    CreateJsonFile();
                }
                else
                {
                    throw e;
                }

            }
        }
        /// <summary>
        /// Create a Json File
        /// </summary>
        /// <param name="setDefault">If you don't want to reset properties to default set it false</param>
        internal void CreateJsonFile(bool setDefault = true)
        {
            if (setDefault)
            {
                SetDefaults();
            }
            string jsonString = JsonConvert.SerializeObject(this,Formatting.None);
            File.WriteAllText(GetPath(), jsonString);

        }
       
        private void DeleteJsonFile()
        {
            if (File.Exists(GetPath()))
            {
                File.Delete(GetPath());
            }
        }


        private void Equalize(AppSettings settings)
        {
            this.IsLight = settings.IsLight;
            this.LanguageOption = settings.LanguageOption;
        }
        
        private void SetDefaults()
        {
            this.IsLight = true;
            this.LanguageOption = Language.Turkish;
        }
        private string GetPath()
        {
            return $@".\{FILE_NAME}";
        }

        

    }
}
