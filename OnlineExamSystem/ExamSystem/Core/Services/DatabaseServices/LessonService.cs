using ExamSystem.MVVM.Model.Question;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Services.DatabaseServices
{
    public class LessonService : IDataBaseService<Lesson>
    {
        private const string COLLECTION_NAME = "Lessons";
#if DEBUG
        int count = 0;
#endif
        public Task<ReadOnlyDictionary<string,Lesson>> GetLessonDictionary()
        {
            return Task.Run(() =>
            {
#if DEBUG
                if(count == 1)
                {
                    throw new Exception("GetLessonDictionary used two times?");
                }
                count++;
#endif
               
                var dict = new Dictionary<string, Lesson>();
                var collection = GetCollection();
                var list = collection.AsQueryable();
                foreach(var item in list)
                {
                    dict.Add(item.LessonName,item);
                }

                return new ReadOnlyDictionary<string, Lesson>(dict);
            });
        }


        public Task<Lesson> Create(Lesson entity)
        {
            return Task.Run(() =>
            {
                var collection = GetCollection();

                List<Lesson> t = collection.Find(x => x.LessonName == entity.LessonName).ToList();
                if (t.Count > 0)
                    return entity;

                collection.InsertOne(entity);

                return entity;
            });
        }

        public Task<bool> Delete(ObjectId id)
        {
            return Task.Run(() =>
            {
                var collection = GetCollection();

                var filter = Builders<Lesson>.Filter.Eq("_id", id);

                DeleteResult deleteResult = collection.DeleteOne(filter);


                return deleteResult.IsAcknowledged;
            });
        }

        public Task<Lesson> Get(ObjectId id)
        {
            return Task.Run(() =>
            {
                var collection = GetCollection();

                var filter = Builders<Lesson>.Filter.Eq("_id", id);

                var list = collection.Find(filter).ToList();

                if (list.Count <= 0)
                    return null;

                return list[0];

            });
        }

        public IMongoCollection<Lesson> GetCollection()
        {
            return DataBaseHandler.GetCollection<Lesson>(COLLECTION_NAME);
        }

        public Task<Lesson> Update(ObjectId id, Lesson entity)
        {
            throw new NotImplementedException();
        }
    }
}
