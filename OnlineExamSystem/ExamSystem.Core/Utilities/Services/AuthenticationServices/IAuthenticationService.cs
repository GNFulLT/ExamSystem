using ExamSystem.Core.SubModels;
using System;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Services.AuthenticationServices
{
    [Flags]
    public enum RegistrationResult
    {
        Success = 1,//               01
        EmailAlreadyExists = 2,    // 10 
        UsernameAlreadyExists = 4     // 100
    }

    public interface IAuthenticationService
    {
        Task<RegistrationResult> Register(string email, string username, string password, AccountInfo accountInfo);

        Task<Account> Login(string username, string password);
    }
}
