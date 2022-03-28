using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Services
{
    public static class DataBaseHandler
    {
        private static MongoClient client = new MongoClient(System.Configuration.ConfigurationManager.ConnectionStrings["MongoDBCS"].ConnectionString);
        private const string DATABASE_NAME = "ExamSystem";

        public static IMongoDatabase GetDataBase()
        {
            return client.GetDatabase(DATABASE_NAME);
        }

        public static IMongoCollection<T> GetCollection<T>(string collectionName)
        {   
            return client.GetDatabase(DATABASE_NAME).GetCollection<T>(collectionName);
        }

    }
}
