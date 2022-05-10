using ExamSystem.Core.Models;
using ExamSystem.Core.Utilities.Providers;
using ExamSystem.Core.Utilities.Services.SubServices.ExamServices;
using ExamSystem.Core.Utilities.Services.SubServices.QuestionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Builders.Exams
{
    public class StudentExamBuilder : IExamBuilder
    {
        private Exam _exam;

        private string _uniqueKey;

        public StudentExamBuilder(int questionCount) : base(questionCount)
        {
        }

        public override bool CheckIfExamExists()
        {
            ExamService service = new ExamService();

            _uniqueKey = Exam.GetUniqueKey(_questions.Select(q => q.Id).ToList());

            Task<bool> t1 = service.CheckExamExist(_uniqueKey);
            bool res = t1.Result;

            return res;
        }

        public override Exam GetExam()
        {
            return _exam;
        }

        public override Task PrepareQuestions(List<Question> questions = null)
        {
            return Task.Run(() =>
            {
                if (questions is object)
                    throw new Exception("StudentExamBuilder is not accept prepared questions!");

                _questions = new List<Question>();
                List<Question> lastQuestions = new List<Question>();
                List<StudentQuestionInfo> infos = StudentProvider.GetStudentQuestionInfos();
                Dictionary<Section, float> sectionRates = new Dictionary<Section, float>();
                Dictionary<Unit, float> unitRates = new Dictionary<Unit, float>();
                Dictionary<Lesson, float> lessonRates = new Dictionary<Lesson, float>();

                foreach (var item in infos)
                {
                    int questStudentInfo = item.StudentSubQuestionInfo.MeasureInfo;
                    float sectionBasicRate = (item.Question.Section.GlobalRightCount + 1) / (item.Question.Section.GlobalCount + 1);
                    float sectionGlobalRate = Analyser.MixRate(sectionBasicRate, questStudentInfo);
                    sectionRates.Add(item.Question.Section, sectionGlobalRate);

                    float unitBasicRate = (item.Question.Unit.GlobalRightCount + 1) / (item.Question.Unit.GlobalCount + 1);
                    float unitGlobalRate = Analyser.MixRate(unitBasicRate, sectionGlobalRate);

                    unitRates.Add(item.Question.Unit, unitGlobalRate);

                    float lessonBasicRate = (item.Question.Lesson.GlobalRightCount + 1) / (item.Question.Lesson.GlobalRightCount + 1);
                    float lessonGlobalRate = Analyser.MixRate(lessonBasicRate, unitGlobalRate);

                    lessonRates.Add(item.Question.Lesson, lessonGlobalRate);

                    if(item.StudentSubQuestionInfo.NowDate.CompareTo(item.StudentSubQuestionInfo.NextDate) == 0)
                    {
                        lastQuestions.Add(item.Question);
                    }
                }




                
            });
      
        }

        public override void SetQuestions()
        {
            _exam.Questions = _questions;
        }

        public override void SetUniqueKey()
        {
            _exam.ExamUniqueKey = _uniqueKey;
        }
    }
}
