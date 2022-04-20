using ExamSystem.Core.Services.DatabaseServices;
using System.Threading.Tasks;

namespace ExamSystem.Core.Services.AuthenticationServices
{
    public interface IAccountService : IDataBaseService<Account>
    {
        Task<Account> GetByUsername(string username);
        Task<Account> GetByEmail(string email);
    }
}
