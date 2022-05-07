using ExamSystem.MVVM.Model.Question;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Services.DatabaseServices
{
    public class UnitService : IDataBaseService<Unit>
    {
        private const string COLLECTION_NAME = "Units";
#if DEBUG
        int count = 0;
#endif
        public Task<ReadOnlyDictionary<Lesson,Dictionary<string,Unit>>> GetUnitDictionary()
        {
            return Task.Run(() =>
            {
#if DEBUG
                if (count == 1)
                {
                    throw new Exception("GetLessonDictionary used two times?");
                }
                count++;
#endif
                var dict = new Dictionary<Lesson, Dictionary<string, Unit>>();
                UnitSectionProvider.InitializeMaps();
                var lesDict = UnitSectionProvider.LessonMap;
                var collection = GetCollection();
                var list = collection.AsQueryable();
                foreach(var item in lesDict)
                {
                    dict.Add(item.Value, new Dictionary<string, Unit>());
                }
                foreach(var item in list)
                {
                    Dictionary<string, Unit> dict2;
                    bool exist = dict.TryGetValue(item.Lesson, out dict2);
                    if (exist)
                    {
                        dict2.Add(item.UnitName, item);
                    }
                    else
                    {
                        dict2 = new Dictionary<string, Unit>();
                        dict2.Add(item.UnitName, item);
                        dict.Add(item.Lesson, dict2);
                    }
                }

                return new ReadOnlyDictionary<Lesson, Dictionary<string, Unit>>(dict);
            });
        }

        public Task<Unit> Create(Unit entity)
        {
            return Task.Run(() =>
            {
                var collection = GetCollection();
                
                List<Unit> t = collection.Find(x => x.UnitName == entity.UnitName).ToList();
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

                var filter = Builders<Unit>.Filter.Eq("_id", id);

                DeleteResult deleteResult = collection.DeleteOne(filter);
               

                return deleteResult.IsAcknowledged;
            });
        }

        public Task<Unit> Get(ObjectId id)
        {
            return Task.Run(() =>
            {
                var collection = GetCollection();

                var filter = Builders<Unit>.Filter.Eq("_id", id);

                var list = collection.Find(filter).ToList();

                if (list.Count <= 0)
                    return null;

                return list[0];
            });
        }
       
        public IMongoCollection<Unit> GetCollection()
        {
            return DataBaseHandler.GetCollection<Unit>(COLLECTION_NAME);
        }

        public Task<Unit> Update(ObjectId id, Unit entity)
        {
            throw new NotImplementedException();
        }
    }
}
