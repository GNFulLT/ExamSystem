using ExamSystem.Core.SubModels;
using ExamSystem.Core.Utilities.Hashers;
using ExamSystem.Core.Utilities.Services.SubServices.AccountService;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher)
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
        public async Task<Account> Login(string username, string password)
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
        public async Task<RegistrationResult> Register(string email, string username, string password, AccountInfo accountInfo)
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
