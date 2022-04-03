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
    public class SectionService : IDataBaseService<Section>
    {
        private const string COLLECTION_NAME = "Sections";

        public Task<ReadOnlyDictionary<Unit,Dictionary<string,Section>>> GetSectionDictionary()
        {
            return Task.Run(() => {
              var dict =  new Dictionary<Unit, Dictionary<string, Section>>();

                var collection = GetCollection();
                var list = collection.AsQueryable();
                foreach (var item in list)
                {
                    Dictionary<string, Section> dict2;
                    bool exist = dict.TryGetValue(item.Unit,out dict2);
                    if (exist)
                    {
                        dict2.Add(item.SectionName, item);
                    }
                    else
                    {
                        dict2 = new Dictionary<string, Section>();
                        dict2.Add(item.SectionName, item);
                        dict.Add(item.Unit, dict2);
                    }
                }

                return new ReadOnlyDictionary<Unit, Dictionary<string, Section>>(dict);
            });
        }
        public Task<Section> GetTest()
        {
            return Task.Run(() =>
            {
                var collection = GetCollection();
                var id = new ObjectId("6249f8ffa00839ae86113213");

                var filter = Builders<Section>.Filter.Eq("_id", id);

                var list = collection.Find(filter).ToList();

                if (list.Count <= 0)
                    return null;

                return list[0];
            });
        }

        public Task<Section> Create(Section entity)
        {
            return Task.Run(() =>
            {
                var collection = GetCollection();

                List<Section> t = collection.Find(x => x.SectionName == entity.SectionName).ToList();
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

                var filter = Builders<Section>.Filter.Eq("_id", id);

                DeleteResult deleteResult = collection.DeleteOne(filter);


                return deleteResult.IsAcknowledged;
            });
        }

        public Task<Section> Get(ObjectId id)
        {
            return Task.Run(() =>
            {
                var collection = GetCollection();

                var filter = Builders<Section>.Filter.Eq("_id", id);

                var list = collection.Find(filter).ToList();

                if (list.Count <= 0)
                    return null;

                return list[0];
            });
        }

        public IMongoCollection<Section> GetCollection()
        {
            return DataBaseHandler.GetCollection<Section>(COLLECTION_NAME);
        }

        public Task<Section> Update(ObjectId id, Section entity)
        {
            throw new NotImplementedException();
        }
    }
}
