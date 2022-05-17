using ExamSystem.Core.SubModels;
using ExamSystem.Core.Utilities.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Builders.Exams
{
    public class ExamDirector
    {
        private IExamBuilder _eb;

        public ExamDirector(IExamBuilder eb)
        {
            _eb = eb;
        }

        public Task  CreateExam()
        {
            return Task.Run(async () => {


                await _eb.PrepareQuestions();

               bool isExist = _eb.CheckIfExamExists();

                _eb.SetQuestions();

                _eb.SetUniqueKey();

                if (!isExist)
                {
                    _eb.SaveToDatabase();
                    StudentExamInfo info = await _eb.CreateSaveStudentExamInfo();
                    StudentProvider.TodayStudentExamInfo = info;
                }



            });
          
        }
    }
}
