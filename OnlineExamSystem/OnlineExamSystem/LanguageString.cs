using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineExamSystem
{
    public class LanguageString
    {
        private Dictionary<AppSettings.Language,string> strings;

        public LanguageString()
        {
            strings = new Dictionary<AppSettings.Language, string>();
        }

        public void AddString(string s,AppSettings.Language language)
        {
            strings.Add(language, s);
        }

        public string GetString(AppSettings.Language language)
        {
            string s;
            strings.TryGetValue(language,out s);
            if(s == null)
            {
                string s2;
                strings.TryGetValue(AppSettings.Language.Turkish,out s2);
                return s2;
            }
            else
            {
                return s;
            }
        }
    }
}
