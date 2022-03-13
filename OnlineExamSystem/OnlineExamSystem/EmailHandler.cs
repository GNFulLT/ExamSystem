using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlineExamSystem
{
    public class EmailHandler
    {
        private Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public bool EmailVerify(string email)
        {
            return emailRegex.IsMatch(email);
        }
    }
}
