using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Services
{
    public abstract class DataBaseService<T> : IDataBaseService<T> where T : IDataBaseObject
    {
        public abstract string collectionName { get; set; }

        public Task<T> Get(ObjectId id)
        {
            return Task.Run(() =>
            {
                var collection = GetCollection();

                var filter = Builders<T>.Filter.Eq("_id", id);

                var list = collection.Find(filter).ToList();

                if (list.Count <= 0)
                    return default(T);

                return list[0];
            });
        }

        public Task<T> Create(T entity)
        {
            return Task.Run(() => {
                var collection = GetCollection();
                collection.InsertOne(entity);
                return entity;
            });
        }

        public Task<T> Update(ObjectId id, T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(ObjectId id)
        {
            return Task.Run(() =>
            {

                var collection = GetCollection();

                var filter = Builders<T>.Filter.Eq("_id", id);

                DeleteResult deleteResult = collection.DeleteOne(filter);


                return deleteResult.IsAcknowledged;
            });
        }

        public IMongoCollection<T> GetCollection()
        {
            return DataBaseHelper.GetCollection<T>(collectionName);
        }

    }
}
