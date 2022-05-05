using ExamSystem.Core.Models;
using ExamSystem.Core.Utilities.Providers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Services.SubServices.QuestionServices
{
    public class QuestionService : DataBaseService<Question>
    {
        private const string COLLECTION_NAME = "Questions";
        public override string collectionName { get => COLLECTION_NAME; set { } }

        public Task<List<Question>> GetAllQuestionsList()
        {
            return Task.Run(() =>
            {

                var collection = GetCollection();
                

                return new List<Question>(collection.AsQueryable());
            });
        }
        public Task<ReadOnlyDictionary<Section,List<Question>>> GetAllQuestionsDictionary()
        {
            return Task.Run(() =>
            {
                var dict = new Dictionary<Section, List<Question>>();

                var lesmap = UnitSectionProvider.LessonMap;
                //Use local units sections
                foreach(var les in lesmap)
                {
                    var unitmap = UnitSectionProvider.GetUnitDictionary(les.Value);
                    foreach(var unit in unitmap)
                    {
                        var sectionmap = UnitSectionProvider.GetSectionDictionary(unit.Value);
                        foreach(var section in sectionmap)
                        {
                            dict.Add(section.Value, new List<Question>());
                        }
                    }

                }

                var collection = GetCollection();
                var list = collection.AsQueryable();
                
                foreach(var item in list)
                {
                   bool exist =  dict.TryGetValue(item.Section, out List<Question> quest);
                    if (exist == false)
                        throw new Exception("There is an error while trying to read questions");
                    quest.Add(item);
                }
                return new ReadOnlyDictionary<Section, List<Question>>(dict);
            });
        }
    }
}
