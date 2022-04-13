using BenchmarkDotNet.Attributes;
using ExamSystem.Core.Hashers;
using ExamSystem.Core.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemBenchmark
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class GettingDataBenchmarks
    {
        [Benchmark]
        public async Task GetAccountNullTask()
        {
            AccountService service = new AccountService();
            PasswordHasher_HMACSHA512 psw = new PasswordHasher_HMACSHA512();
            AuthenticationService s = new AuthenticationService(service, psw);
            Account ac = await s.Login("m","s");
        }
        [Benchmark]
        public async ValueTask GetAccountNullValueTask()
        {
            AccountService service = new AccountService();
            PasswordHasher_HMACSHA512 psw = new PasswordHasher_HMACSHA512();
            FakeAuth s = new FakeAuth(service, psw);
            Account ac = await s.Login("m", "s");
        }

        [Benchmark]
        public async Task GetAccountTask()
        {
            AccountService service = new AccountService();
            PasswordHasher_HMACSHA512 psw = new PasswordHasher_HMACSHA512();
            AuthenticationService s = new AuthenticationService(service, psw);
            Account ac = await s.Login("as", "12345");
        }
        [Benchmark]
        public async ValueTask GetAccountValueTask()
        {
            AccountService service = new AccountService();
            PasswordHasher_HMACSHA512 psw = new PasswordHasher_HMACSHA512();
            FakeAuth s = new FakeAuth(service, psw);
            Account ac = await s.Login("as", "12345");
        }

        public class FakeAuth
        {
            private readonly IAccountService _accountService;
            private readonly IPasswordHasher _passwordHasher;

            public FakeAuth(IAccountService accountService, IPasswordHasher passwordHasher)
            {
                _accountService = accountService;
                _passwordHasher = passwordHasher;
            }

            /// <summary>
            /// Try to Access Acount if there is,If there is not any account return null
            /// </summary>
            /// <param name="username"></param>
            /// <param name="password"></param>
            /// <returns></returns>
            public async ValueTask<Account> Login(string username, string password)
            {
                Account accountByUsername = await _accountService.GetByUsername(username);
                if (accountByUsername == null)
                    return null;

                bool passwordVerify = _passwordHasher.Verify(password, accountByUsername.Password);

                if (passwordVerify)
                    return accountByUsername;

                return null;
            }

            /// <summary>
            /// Create an account and save it in database
            /// </summary>
            /// <param name="email"></param>
            /// <param name="username"></param>
            /// <param name="password"></param>
            /// <param name="accountInfo"></param>
            /// <returns></returns>
            public async ValueTask<RegistrationResult> Register(string email, string username, string password, AccountInfo accountInfo)
            {
                RegistrationResult result = RegistrationResult.Success;

                Account emailAcc = await _accountService.GetByEmail(email);
                if (emailAcc != null)
                {
                    result = result | RegistrationResult.EmailAlreadyExists;
                }

                Account usernameAcc = await _accountService.GetByUsername(username);

                if (usernameAcc != null)
                {
                    result = result | RegistrationResult.UsernameAlreadyExists;
                }

                if ((result & RegistrationResult.EmailAlreadyExists) != RegistrationResult.EmailAlreadyExists &&
                    (result & RegistrationResult.UsernameAlreadyExists) != RegistrationResult.UsernameAlreadyExists)
                {
                    string hashPass = _passwordHasher.Hash(password);
                    Account newAccount = new Account()
                    {
                        Email = email,
                        Username = username,
                        Password = hashPass,
                        _AccountInfo = accountInfo,
                        _AccountType = Account.AccountType.Student
                    };
                    await _accountService.Create(newAccount);
                }
                return result;
            }
        }
    }
}
