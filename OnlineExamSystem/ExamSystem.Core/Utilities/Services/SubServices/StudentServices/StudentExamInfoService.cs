using ExamSystem.Core.Models;
using ExamSystem.Core.SubModels;
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


        public Task<StudentExamInfo> GetDailyInfoIfExist(Student st)
        {
            return Task.Run(() =>
            {
                var collection = GetCollection();
                var list1 = collection.AsQueryable().ToList();
                StudentExamInfo examinfo = null;
                foreach(var item in list1)
                {
                    if(item.IsSolved == false && (item.Student.Id.CompareTo(st.Id) == 0))
                    {
                        examinfo = item;
                    }
                }
                //var list = collection.Find(q => ((q.Student.Id.CompareTo(st.Id) == 0) &&  q.IsSolved == false)).ToList();
               /* if (list.Count == 0 && list.Count > 1)
                    return default(StudentExamInfo);*/

                return examinfo;
            });
        }
    }
}
