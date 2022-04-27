using ExamSystem.Core.Models;
using ExamSystem.Core.Utilities.Providers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Services.SubServices.LessonServices
{
    public class UnitService : DataBaseService<Unit>
    {
        private const string COLLECTION_NAME = "Units";

        public override string collectionName { get => COLLECTION_NAME; set { } }

        public Task<ReadOnlyDictionary<Lesson, Dictionary<string, Unit>>> GetUnitDictionary()
        {
            return Task.Run(() =>
            {

                var dict = new Dictionary<Lesson, Dictionary<string, Unit>>();
                UnitSectionProvider.InitializeMaps();
                var lesDict = UnitSectionProvider.LessonMap;
                var collection = GetCollection();
                var list = collection.AsQueryable();
                foreach (var item in lesDict)
                {
                    dict.Add(item.Value, new Dictionary<string, Unit>());
                }
                foreach (var item in list)
                {
                    Dictionary<string, Unit> dict2;
                    bool exist = dict.TryGetValue(item.Lesson, out dict2);
                    if (exist)
                    {
                        dict2.Add(item.UnitName, item);
                    }
                    else
                    {
                        throw new Exception("There is no stable connection with database");

                    }
                }

                return new ReadOnlyDictionary<Lesson, Dictionary<string, Unit>>(dict);
            });
        }
    }
}
