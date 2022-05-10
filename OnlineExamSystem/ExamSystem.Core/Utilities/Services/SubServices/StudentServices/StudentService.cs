using ExamSystem.Core.Models;
using ExamSystem.Core.SubModels;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Services.SubServices.StudentServices
{
    public class StudentService : DataBaseService<Student>
    {
        private const string COLLECTION_NAME = "Students";

        public override string collectionName { get => COLLECTION_NAME; set { } }

        public Task<Student> GetStudentByAccount(Account account)
        {
            return Task.Run(() =>
            {
                var collection = GetCollection();

                var filter = Builders<Student>.Filter.Eq("_accountId", account.Id);

                var list = collection.Find(filter).ToList();

                if (list.Count > 1)
                    return default(Student);

                if(list.Count <= 0)
                {
                    Student st = new Student();
                    st.Account = account;
                    Create(st);
                    list.Add(st);
                }
                return list[0];

            });
        }
    }
}
