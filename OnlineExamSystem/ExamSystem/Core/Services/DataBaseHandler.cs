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
        private static MongoClient client = new MongoClient("mongodb+srv://examsystembu:examsystembu@examsystem.7fumo.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
        private const string DATABASE_NAME = "ExamSystem";

        [ObsoleteAttribute("This method is Obsolete for getting collection use GetCollection<T> instead",false)]
        public static IMongoDatabase GetDataBase()
        {
            var db = client.GetDatabase(DATABASE_NAME);
            return db;
        }
        
        public static IMongoCollection<T> GetCollection<T>(string collectionName)
        {   
            return client.GetDatabase(DATABASE_NAME).GetCollection<T>(collectionName);
        }

    }
}
