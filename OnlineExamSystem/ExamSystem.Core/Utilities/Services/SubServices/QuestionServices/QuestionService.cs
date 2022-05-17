using ExamSystem.Core.Models;
using ExamSystem.Core.SubModels;
using ExamSystem.Core.Utilities.Providers;
using ExamSystem.Core.Utilities.Services.SubServices.LessonServices;
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

                var query = collection.AsQueryable();

                var list = new List<Question>();
                foreach(var item in query)
                {
                    list.Add(item);
                    item.ClearInfo();
                }
                return list;
            });
        }

        public Task UpdateWithUnitSections(Question question)
        {
            return Task.Run(async () =>
            {
                var collection = GetCollection();
                UnitService uService = new UnitService();
                SectionService sService = new SectionService();
                LessonService lService = new LessonService();

                await uService.Update(question.Unit);
                await sService.Update(question.Section);
                await lService.Update(question.Lesson);
                await Update(question);

            });
        }


        public Task<QuestionInfo> GetInfoByQuestion(Question question)
        {
            return Task.Run(async () =>
            {
                Question q = await Get(question.Id);
                return q.QuestionInfo;
            });
        }


        public Task<ReadOnlyDictionary<Section,List<Question>>> GetAllQuestionsDictionary()
        {
            return Task.Run(() =>
            {
                var dict = new Dictionary<Section, List<Question>>();

                
                foreach(var section in UnitSectionProvider.AllSections)
                {
                    dict.Add(section.Value, new List<Question>());

                }



                var collection = GetCollection();
                var list = collection.AsQueryable();
                
                foreach(var item in list)
                {
                   bool exist =  dict.TryGetValue(item.Section, out List<Question> quest);
                    if (exist == false)
                        throw new Exception("There is an error while trying to read questions");
                 
                    quest.Add(item);
                    item.ClearInfo();
                }
                return new ReadOnlyDictionary<Section, List<Question>>(dict);
            });
        }
    }
}
