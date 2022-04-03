using ExamSystem.Core.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    public static class Globals
    {
        public static int GlobalHintAssistTime = 1500;
        private static Account _loginedAccount;
        public static void SetLoginedAccount(Account acc)
        {
            _loginedAccount = acc;
        }
        public static Account GetLoginedAccount()
        {
#if DEBUG
            if (_loginedAccount == null)
                throw new NullReferenceException("_loginedAccount can not be null");
#endif
            return _loginedAccount;
        }
    }
}
