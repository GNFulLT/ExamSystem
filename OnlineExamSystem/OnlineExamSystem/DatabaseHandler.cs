using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamSystem
{
    public class DatabaseHandler
    {
        private static MongoClient client = new MongoClient(System.Configuration.ConfigurationManager.ConnectionStrings["MongoDBCS"].ConnectionString);
        private const string DATABASE_NAME = "ExamSystem";
        private const string COLLECTION_NAME = "Users";


        public DatabaseHandler()
        {
          
       
        }

        internal async Task<List<User>> GetUser(string username)
        {
            
            return await Sync_GetUser(username);

        }

        private Task<List<User>> Sync_GetUser(string username)
        {
            return Task.Run(() => { 
            
            var myDataBase = client.GetDatabase(DATABASE_NAME);
            var myCollection = myDataBase.GetCollection<User>(COLLECTION_NAME);
            return myCollection.Find(x => x.Username == username).ToList();
            
            });
        }

        internal async Task<List<User>> GetUserWithEmail(string email)
        {
           
            return await Sync_GetUserWithEmail(email);
        }

        private Task<List<User>> Sync_GetUserWithEmail(string email)
        {
            return Task.Run(() => {

                var myDataBase = client.GetDatabase(DATABASE_NAME);
                var myCollection = myDataBase.GetCollection<User>(COLLECTION_NAME);
                return myCollection.Find(x => x.Email == email).ToList();

            });
        }

        internal async void InsertUser(User user)
        {
           await Sync_InsertUser(user);
        }

        private Task Sync_InsertUser(User user)
        {
            return Task.Run(() =>
            {

                var myDataBase = client.GetDatabase(DATABASE_NAME);
                var myCollection = myDataBase.GetCollection<User>(COLLECTION_NAME);
                myCollection.InsertOne(user);

            });
        }

       
    }
}
