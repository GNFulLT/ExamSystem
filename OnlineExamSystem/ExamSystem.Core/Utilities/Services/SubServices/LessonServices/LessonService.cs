using ExamSystem.Core.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Services.SubServices.LessonServices
{
    public class LessonService : DataBaseService<Lesson>
    {
        private const string COLLECTION_NAME = "Lessons";
        public override string collectionName { get => COLLECTION_NAME; set { } }

        public Task<ReadOnlyDictionary<string, Lesson>> GetLessonDictionary()
        {
            return Task.Run(() =>
            {
                var dict = new Dictionary<string, Lesson>();
                var collection = GetCollection();
                var list = collection.AsQueryable();
                foreach (var item in list)
                {
                    dict.Add(item.LessonName, item);
                }
                return new ReadOnlyDictionary<string, Lesson>(dict);
            });
        }
    }
}
