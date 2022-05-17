using ExamSystem.Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Services.SubServices.StudentServices
{
    public class StudentQuestionInfoService : DataBaseService<StudentQuestionInfo>
    {
        private const string COLLECTION_NAME = "StudentQuestionInfos";
        public override string collectionName { get => COLLECTION_NAME; set { } }

        public Task<int> CreateOrUpdate(StudentQuestionInfo info)
        {
            return Task.Run(async () =>
            {
                var collection = GetCollection();

                if(info.Id.CompareTo(ObjectId.Empty) == 0)
                {
                    await Create(info);
                    return 0;
                }
                else
                {
                    var filter = Builders<StudentQuestionInfo>.Filter.Eq("_id",info.Id);
                    collection.ReplaceOne(filter, info);
                    return 1;
                }
            });
        }

        public Task<List<StudentQuestionInfo>> GetAllByStudent(Student student)
        {
            return Task.Run(() =>
            {
                var collection = GetCollection();

                var filter = Builders<StudentQuestionInfo>.Filter.Eq("_studentId", student.Id);

                var list = collection.Find(filter).ToList();

                if (list.Count <= 0)
                    return default(List<StudentQuestionInfo>);

                return list;

            });
        }
    }
}
