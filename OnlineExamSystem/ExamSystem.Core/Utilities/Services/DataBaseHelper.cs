using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Core.Utilities.Services
{
    public static class DataBaseHelper
    {
        private static MongoClient client = new MongoClient("mongodb+srv://examsystembu:examsystembu@examsystem.7fumo.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
        private const string DATABASE_NAME = "ExamSystem";

        public static IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return client.GetDatabase(DATABASE_NAME).GetCollection<T>(collectionName);
        }
    }
}
