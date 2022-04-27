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
    public class SectionService : DataBaseService<Section>
    {
        private const string COLLECTION_NAME = "Sections";

        public override string collectionName { get => COLLECTION_NAME; set { } }

        public Task<ReadOnlyDictionary<Unit, Dictionary<string, Section>>> GetSectionDictionary()
        {
            return Task.Run(() => {
  
                var dict = new Dictionary<Unit, Dictionary<string, Section>>();
                UnitSectionProvider.InitializeMaps();
                var lesDict = UnitSectionProvider.LessonMap;
                foreach(var item in lesDict)
                {
                    var unitDict = UnitSectionProvider.GetUnitDictionary(item.Value);
                    foreach(var unit in unitDict)
                    {
                        dict.Add(unit.Value, new Dictionary<string, Section>());
                    }
                }

                var collection = GetCollection();
                var list = collection.AsQueryable();
                foreach (var item in list)
                {
                    Dictionary<string, Section> dict2;
                    bool exist = dict.TryGetValue(item.Unit, out dict2);
                    if (exist)
                    {
                        dict2.Add(item.SectionName, item);
                    }
                    else
                    {
                        throw new Exception("There is no stable connection with database");
                    }
                }

                return new ReadOnlyDictionary<Unit, Dictionary<string, Section>>(dict);
            });
        }
    }
}
