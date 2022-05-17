using ExamSystem.Core.Models;
using ExamSystem.Core.SubModels;
using ExamSystem.Core.Utilities.Providers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Services.SubServices.StudentServices
{
    public class StudentExamInfoService : DataBaseService<StudentExamInfo>
    {
        private const string COLLECTION_NAME = "StudentExamInfos";

        public override string collectionName { get => COLLECTION_NAME; set { } }

        public Task<List<StudentExamInfo>> GetAllByStudent(Student student)
        {
            return Task.Run(() =>
            {
                var collection = GetCollection();
                var filter = Builders<StudentExamInfo>.Filter.Eq("_studentId", student.Id);

                var list = collection.Find(filter).ToList();

                if (list == null)
                    return default(List<StudentExamInfo>);
                else
                    return list;

            });
        }


        public Task<int> CreateOrUpdate(StudentExamInfo info)
        {
            return Task.Run(async () =>
            {
                var collection = GetCollection();
                if(info.Id.CompareTo(MongoDB.Bson.ObjectId.Empty) == 0)
                {
                    await Create(info);
                    return 0;
                }
                else
                {
                    var filter = Builders<StudentExamInfo>.Filter.Eq(q => q.Id,info.Id);
                    collection.ReplaceOne(filter, info);
                    return 1;
                }
            });
        }

        public Task<StudentExamInfo> GetDailyInfoIfExist(Student st)
        {
            return Task.Run(() =>
            {
                var collection = GetCollection();
                var list1 = collection.AsQueryable().ToList();
                StudentExamInfo examinfo = null;
                foreach(var item in list1)
                {
                    //Çözülmeyen sınav varmı kontrolü yapar
                    if(item.IsSolved == false && (item.Student.Id.CompareTo(st.Id) == 0))
                    {
                        examinfo = item;
                    }
                }
                return examinfo;
            });
        }
    }
}
