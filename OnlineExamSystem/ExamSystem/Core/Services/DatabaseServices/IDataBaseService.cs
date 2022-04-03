using ExamSystem.Core.Services.AuthenticationServices;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ExamSystem.Core.Services.DatabaseServices
{
    public interface IDataBaseService<T> where T:IDataBaseObject
    {
            
        Task<T> Get(ObjectId id);

        Task<T> Create(T entity);

        Task<T> Update(ObjectId id, T entity);

        Task<bool> Delete(ObjectId id);

        IMongoCollection<T> GetCollection();

    }
}
