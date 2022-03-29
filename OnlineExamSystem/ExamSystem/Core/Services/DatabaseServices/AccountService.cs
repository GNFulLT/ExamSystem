using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Services.AuthenticationServices
{
    public class AccountService : IAccountService
    {
        private const string COLLECTION_NAME = "Accounts";

        public Task<Account> Create(Account entity)
        {
            return Task.Run(() => {

                var collection = GetCollection();
                collection.InsertOne(entity);
                return entity;
            });
        }


        public Task<bool> Delete(ObjectId id)
        {
            return Task.Run(() =>
            {
            bool isDeleted = false;

            var collection = GetCollection();

                var filter = Builders<Account>.Filter.Eq("_id", id);

                DeleteResult deleteResult = collection.DeleteOne(filter);

                isDeleted = true;

                return isDeleted;

            });

        }


        public Task<Account> Get(ObjectId id)
        {
            return Task.Run(() =>
            {
                var collection = GetCollection();

                var filter = Builders<Account>.Filter.Eq("_id", id);

                var list =  collection.Find(filter).ToList();

                if (list.Count <= 0)
                    return null;

                return list[0];
            });
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

                var filter = Builders<Account>.Filter.Eq("username",username);

                var list = collection.Find(x => x.Username == username).ToList();

                if (list.Count <= 0)
                    return null;

                return list[0];
            });
        }

        public IMongoCollection<Account> GetCollection()
        {
            return DataBaseHandler.GetDataBase().GetCollection<Account>(COLLECTION_NAME);
        }

        public Task<Account> Update(ObjectId id, Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
