using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Core.Utilities.Builders.Exams
{
    public class ExamDirector
    {
        private IExamBuilder _eb;

        public ExamDirector(IExamBuilder eb)
        {
            _eb = eb;
        }

        public void CreateExam()
        {
            _eb.CheckIfExamExists();

            _eb.SetQuestions();

            _eb.SetUniqueKey();
        }
    }
}
