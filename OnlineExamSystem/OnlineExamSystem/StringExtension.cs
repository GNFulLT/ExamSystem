using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamSystem
{
    public static class StringExtension
    {
        /// <summary>
        /// Just First letter will be Upper
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToUpperFirstLetter(this string s)
        {
            return s.Substring(0, 1).ToUpper() + s.Substring(1).ToLower();
        }
    }
}
