using ExamSystem.Core;
using ExamSystem.Core.SubModels;
using ExamSystem.Core.Utilities.Services.AuthenticationServices;
using ExamSystem.Core.Utilities.Services.SubServices.AccountService;
using NUnit.Framework;
using System.Reflection;
using System.Threading.Tasks;

namespace ExamSystem.Tests
{
    public class AuthenticatorTests
    {
        [SetUp]
        public void Setup()
        {
            Bootstrapper strapper = new Bootstrapper(Assembly.GetExecutingAssembly(), null);
        }

        //Works
        [Test]
        public void AccountServiceGetByUsernameTests()
        {
            AccountService ac = new AccountService();
            Task<Account> t1 = ac.GetByUsername("ugurTR35");

            Account acc = t1.Result;

            Assert.IsNotNull(acc);

        }
        [Test]
        public void AuthRegisterTest()
        {

            IAuthenticationService service = Resolver.Resolve<IAuthenticationService>();

            Task<RegistrationResult> t1 = service.Register("merhababayim@hotmail.com","merhababayim","123",new AccountInfo() { Name="Uður",Surname="Öztürk" });
            RegistrationResult res = t1.Result;
            Assert.AreEqual(RegistrationResult.Success, res);
        }
        [Test]
        public void AuthRegisterLogin()
        {
            Bootstrapper strapper = new Bootstrapper(Assembly.GetExecutingAssembly(), null);
            IAuthenticationService service = Resolver.Resolve<IAuthenticationService>();

            Task<Account> t1 = service.Login("merhababayim","123");
            Account res = t1.Result;
            Assert.IsNotNull(res);
        }

    }
}