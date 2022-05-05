using ExamSystem.Core.SubModels;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Services.SubServices.AccountService
{
    public class AccountService : DataBaseService<Account>, IAccountService
    {
        private const string COLLECTION_NAME = "Accounts";

        public override string collectionName
        {
            get { return COLLECTION_NAME; }
            set { }
        }

        public Task<Account> GetByEmail(string email)
        {
            return Task.Run(() => {

                var collection = GetCollection();

                var filter = Builders<Account>.Filter.Eq("email", email);

                var list = collection.Find(filter).ToList();

                if (list.Count <= 0)
                    return null;

                return list[0];
            });
        }

        public Task<Account> GetByUsername(string username)
        {
            return Task.Run(() =>
            {
                var collection = GetCollection();

                var filter = Builders<Account>.Filter.Eq("username", username);

                var list = collection.Find(x => x.Username == username).ToList();

                if (list.Count <= 0)
                    return null;

                return list[0];
            });
        }
    }
}
