using ExamSystem.Core.SubModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Core.Utilities.Providers
{
    public static class AccountProvider
    {
        private static Account _loginedAccount;

        public static Account LoginedAccount { get { Checker(); return _loginedAccount; } set => _loginedAccount = value; }

        private static bool _isInitialized = false;

        public static void InitializeInfos(Account account)
        {
            if (_isInitialized)
                return;

            LoginedAccount = account;

            _isInitialized = true;

        }

        private static void Checker()
        {
            if (!_isInitialized)
            {
                throw new Exception("Account doesn't initialized");
            }
        }
    }
}
