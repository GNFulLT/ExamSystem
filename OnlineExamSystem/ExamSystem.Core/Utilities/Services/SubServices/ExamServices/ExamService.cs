using ExamSystem.Core.Models;
using ExamSystem.Core.SubModels;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Services.SubServices.ExamServices
{
    public class ExamService : DataBaseService<Exam>
    {
        private const string COLLECTION_NAME = "Exams";

        public override string collectionName { get => COLLECTION_NAME; set { } }

        public Task<Exam> GetByInfo(StudentExamInfo info)
        {
            return Task.Run(() =>
            {
                var collection = GetCollection();

                var list = collection.Find(q => (q.Id.CompareTo(info.Exam.Id) == 0)).ToList();

                if (list.Count > 1 && list.Count == 0)
                    return default(Exam);

                return list[0];
            });
        }


        public Task<bool> CheckExamExist(string key)
        {
            return Task.Run(() =>
            {
                var collection = GetCollection();

                var filter = Builders<Exam>.Filter.Eq("_uniqueKey", key);

                var list = collection.Find(filter).ToList();

                if (list.Count == 1)
                    return true;
                else if (list.Count == 0)
                    return false;
                else
                    throw new Exception("While trying to get exam there was occured an error");
            });
        }


        public override Task<Exam> Create(Exam entity)
        {
            return Task.Run(async () => {
                bool res = await CheckExamExist(Exam.GetUniqueKey(entity.Questions.Select(q => q.Id).ToList()));
                if (res)
                {
                    return entity;
                }
                var collection = GetCollection();
                collection.InsertOne(entity);
                return entity;
            });
        }
    }
}
