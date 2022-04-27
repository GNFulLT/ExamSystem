using ExamSystem.Core.SubModels;
using ExamSystem.Core.Utilities.Services;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace ExamSystem.Core.Models
{
    public class Question : IDataBaseObject
    {
        public ObjectId Id { get; set; }

        public Lesson Lesson { get; set; }

        public Section Section { get; set; }

        public Unit Unit { get; set; }

        public string ImageUri { get; set; }

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
