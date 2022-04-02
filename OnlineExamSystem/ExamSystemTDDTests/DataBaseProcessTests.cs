using NUnit.Framework;
using ExamSystem.Core.Services.AuthenticationServices;
using ExamSystem.Core.Hashers;
using System.Threading.Tasks;
using System.Configuration;

namespace ExamSystemTDDTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        //Works Fine
        //Registering with non taken email and non taken username 
        [Test]
        public  void RegisterDataBaseSaveTest()
        {
            var accountService = new AccountService();
            var passwordHasher = new PasswordHasher_HMACSHA512();
            AuthenticationService authenticationService = new AuthenticationService(accountService, passwordHasher);
            Task<RegistrationResult> t1 = authenticationService.Register("merhaba@hotmail.com", "sa", "qwejrwqkwq", new AccountInfo() { Name = "Uður", Surname = "Öztürk" });
            var result = t1.Result;
            Assert.AreEqual(result,RegistrationResult.Success);
        }

        //Works Fine
        [Test]
        public void RegisterDataBaseEmailAlreadyTaken()
        {
            var accountService = new AccountService();
            var passwordHasher = new PasswordHasher_HMACSHA512();
            AuthenticationService authenticationService = new AuthenticationService(accountService, passwordHasher);
            Task<RegistrationResult> t1 = authenticationService.Register("merhaba@hotmail.com", "sa", "qwejrwqkwq", new AccountInfo() { Name = "Uður", Surname = "Öztürk" });
            var result = t1.Result;
            var resultEmailTaken = result & RegistrationResult.EmailAlreadyExists;
            Assert.AreEqual(resultEmailTaken, RegistrationResult.EmailAlreadyExists);
        }

        //Works Fine
        [Test]
        public void RegisterDataBaseUsernameAlreadyTaken()
        {
            var accountService = new AccountService();
            var passwordHasher = new PasswordHasher_HMACSHA512();
            AuthenticationService authenticationService = new AuthenticationService(accountService, passwordHasher);
            Task<RegistrationResult> t1 = authenticationService.Register("merhaba@hotmail.com", "sa", "qwejrwqkwq", new AccountInfo() { Name = "Uður", Surname = "Öztürk" });
            var result = t1.Result;
            var resultEmailTaken = result & RegistrationResult.UsernameAlreadyExists;
            Assert.AreEqual(resultEmailTaken, RegistrationResult.UsernameAlreadyExists);
        }
        //Works Fine
        [Test]
        public void LoginWithTruePassword()
        {
            var accountService = new AccountService();
            var passwordHasher = new PasswordHasher_HMACSHA512();
            AuthenticationService authenticationService = new AuthenticationService(accountService, passwordHasher);
            Task<Account> t1 = authenticationService.Login("sa", "qwejrwqkwq");
            Account result = t1.Result;

            Assert.IsNotNull(result);

        }
        //Works Fine
        [Test]
        public void LoginWithBadPassword()
        {
            var accountService = new AccountService();
            var passwordHasher = new PasswordHasher_HMACSHA512();
            AuthenticationService authenticationService = new AuthenticationService(accountService, passwordHasher);
            Task<Account> t1 = authenticationService.Login("sa", "badpassword");
            Account result = t1.Result;

            Assert.IsNull(result);

        }
    }
}