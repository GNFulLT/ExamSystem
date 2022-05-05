using ExamSystem.Core.SubModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Core.Utilities.Providers
{
    public static class AccountProvider
    {
        private static Account _loginedAccount;

        public static Account LoginedAccount { get => _loginedAccount; set => _loginedAccount = value; }

        private static bool _isInitialized = false;

        public static void InitializeInfos()
        {
            if (_isInitialized)
                return;
            _isInitialized = true;
        }
    }
}
