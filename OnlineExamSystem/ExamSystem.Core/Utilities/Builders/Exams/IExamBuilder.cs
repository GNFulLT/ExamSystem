using ExamSystem.Core.Models;
using ExamSystem.Core.SubModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Builders.Exams
{
    public abstract class IExamBuilder
    {
        protected List<Question> _questions;

        protected int _questionCount;

        protected IExamBuilder(int questionCount)
        {
            _questionCount = questionCount;
        }

        public abstract Task PrepareQuestions(List<Question> questions = null);

        public abstract bool CheckIfExamExists();

        public abstract Task<StudentExamInfo> CreateSaveStudentExamInfo();

        public abstract void SaveToDatabase();

        public abstract void SetQuestions();

        public abstract void SetUniqueKey();

        public abstract Exam GetExam();
    }
}
