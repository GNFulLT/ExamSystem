using ExamSystem.Core.SubModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Services.SubServices.AccountService
{
    public interface IAccountService : IDataBaseService<Account>
    {
        public Task<Account> GetByUsername(string username);
        public Task<Account> GetByEmail(string email);
    }
}
