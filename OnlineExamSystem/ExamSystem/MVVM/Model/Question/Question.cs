using ExamSystem.Core.Services;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.MVVM.Model.Question
{
    public class Question : IDataBaseObject
    {
        public ObjectId Id { get; set; }

        public Section Section { get; set; }

        public Unit Unit { get; set; }

        public QuestionInfo QuestionInfo { get; set; }

        public Question()
        {

        }

        public async Task<ReadOnlyMemory<string>> GetImage()
        {
            return await Task.Run(() => {
               
             return new ReadOnlyMemory<string>();

            });
        }
    }
}
