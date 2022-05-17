using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Services
{
    public interface IDataBaseService<T> where T : IDataBaseObject
    {

        public Task<T> Get(ObjectId id);

        public Task<T> Create(T entity);

        public Task<T> Update(T entity);

        public Task<bool> Delete(ObjectId id);

        public IMongoCollection<T> GetCollection();

    }
}
