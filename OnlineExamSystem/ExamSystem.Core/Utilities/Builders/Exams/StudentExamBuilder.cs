using ExamSystem.Core.Models;
using ExamSystem.Core.SubModels;
using ExamSystem.Core.Utilities.Providers;
using ExamSystem.Core.Utilities.Services.SubServices.ExamServices;
using ExamSystem.Core.Utilities.Services.SubServices.QuestionServices;
using ExamSystem.Core.Utilities.Services.SubServices.StudentServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Builders.Exams
{
    public class StudentExamBuilder : IExamBuilder
    {
        private Exam _exam = new Exam();

        private string _uniqueKey;
        private ExamService service;

        public StudentExamBuilder(int questionCount) : base(questionCount)
        {
            service = new ExamService();
            
        }

        public static Task<bool> CheckDailyExamCreated()
        {
            return Task.Run(async () =>{
                StudentExamInfoService service = new StudentExamInfoService();
                StudentExamInfo info = await service.GetDailyInfoIfExist(StudentProvider.LoginedStudent);
                if (info == null)
                    return false;

                ExamService service2 = new ExamService();

                StudentProvider.TodayExam = service2.GetByInfo(info).Result;
                StudentProvider.TodayStudentExamInfo = info;

                StudentProvider.TodayExam.Info = info;
                return true;
            });
           
        }

        public override bool CheckIfExamExists()
        {
       

            _uniqueKey = Exam.GetUniqueKey(_questions.Select(q => q.Id).ToList());

            Task<bool> t1 = service.CheckExamExist(_uniqueKey);
            bool res = t1.Result;

            

            return res;
        }

        public override Task<StudentExamInfo> CreateSaveStudentExamInfo()
        {
            return Task.Run(async () =>
            {
                StudentExamInfo info = new StudentExamInfo();
                info.Exam = _exam;
                info.IsSolved = false;
                info.Student = StudentProvider.LoginedStudent;

                StudentExamInfoService service = new StudentExamInfoService();

                info = await service.Create(info);



                return info;
            });
            
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
                if (infos is object)
                {
                    foreach (var item in infos)
                    {
                        int questStudentInfo = item.StudentSubQuestionInfo.MeasureInfo;
                        float sectionBasicRate = (item.Question.Section.GlobalRightCount + 1) / (item.Question.Section.GlobalCount + 1);
                        float sectionGlobalRate = Analyser.MixRate((1 - sectionBasicRate), questStudentInfo);
                        sectionRates.Add(item.Question.Section, 1 - sectionGlobalRate);

                        float unitBasicRate = (item.Question.Unit.GlobalRightCount + 1) / (item.Question.Unit.GlobalCount + 1);
                        float unitGlobalRate = Analyser.MixRate(1 - unitBasicRate, sectionGlobalRate);

                        unitRates.Add(item.Question.Unit, 1 - unitGlobalRate);

                        float lessonBasicRate = (item.Question.Lesson.GlobalRightCount + 1) / (item.Question.Lesson.GlobalRightCount + 1);
                        float lessonGlobalRate = Analyser.MixRate(1 - lessonBasicRate, unitGlobalRate);

                        lessonRates.Add(item.Question.Lesson, 1 - lessonGlobalRate);

                        if (item.StudentSubQuestionInfo.NowDate.CompareTo(item.StudentSubQuestionInfo.NextDate) == 0)
                        {
                            lastQuestions.Add(item.Question);
                        }
                    }
                }
                float totalCount = 0;
                foreach(var item in lessonRates)
                {
                    lessonRates[item.Key] = (item.Value * _questionCount);
                    totalCount += lessonRates[item.Key];
                }
                int totalCountLesson =  (int) totalCount;
                int countDivison = 0;
                while(totalCountLesson > _questionCount)
                {
                    totalCountLesson /= 2;
                    countDivison++;
                }

                foreach(var item in lessonRates)
                {
                    for(int i = 0;i < countDivison; i++)
                    {
                        lessonRates[item.Key] = (int) (item.Value) / 2;
                    }
                }

                int needsAddCount = _questionCount - totalCountLesson;

                if(needsAddCount > 0)
                {
                    List<Lesson> lessons = UnitSectionProvider.LessonMap.Select(q => q.Value ).Where(q => !lessonRates.ContainsKey(q)).ToList();
                    if(lessons.Count() > 0)
                    {
                        float add = needsAddCount / lessons.Count();
                        foreach(var item in lessons)
                        {
                            if (needsAddCount == 0)
                                break;
                            int val = (int)Math.Ceiling(add);
                            if (val > needsAddCount)
                                val = needsAddCount;
                            lessonRates.Add(item, val);
                            needsAddCount -= val;

                        }
                        if (needsAddCount > 0)
                        {
                            foreach (var lesson in lessonRates)
                            {
                                lessonRates[lesson.Key] = (int)lesson.Value + needsAddCount;

                                break;

                            }
                        }
                    }
                    else
                    {
                        float add = needsAddCount / lessonRates.Count();
                        foreach(var lesson in lessonRates)
                        {
                            if (needsAddCount == 0)
                                break;
                            int val = (int)Math.Ceiling(add);
                            if (val > needsAddCount)
                                val = needsAddCount;
                            lessonRates[lesson.Key] += val;
                            needsAddCount -= val;
                        }
                        if(needsAddCount > 0)
                        {
                            foreach (var lesson in lessonRates)
                            {
                                lessonRates[lesson.Key] = (int)lesson.Value + needsAddCount;

                                break;

                            }
                        }
                    }
                }

                float totalCount2 = 0;
                foreach(var item in unitRates)
                {
                    unitRates[item.Key] = (item.Value * _questionCount);
                    totalCount2 += unitRates[item.Key];
                }

                int totalCountUnit = (int) totalCount2;

                int countDivisonUnit = 0;
                while (totalCountUnit > _questionCount)
                {
                    totalCountUnit /= 2;
                    countDivisonUnit++;
                }

                foreach (var item in unitRates)
                {
                    for(int i = 0; i < unitRates.Count; i++)
                    {
                        unitRates[item.Key] = (item.Value / 2);
                    }
                }

                int needsAddUnitCount = _questionCount - totalCountUnit;

                if (needsAddUnitCount > 0)
                {
                    List<Unit> unitsToAdd = new List<Unit>();
                    foreach (var lesson in lessonRates)
                    {
                        List<Unit> unitsAdd = UnitSectionProvider.GetUnitDictionary(lesson.Key).Select(q => q.Value).
                        Where(q => !unitRates.ContainsKey(q)).ToList();

                        unitsToAdd.AddRange(unitsAdd);

                    }

                    if(unitsToAdd.Count > 0)
                    {
                        float add = (float)needsAddUnitCount / (float)unitsToAdd.Count;
                        foreach(var unit in unitsToAdd)
                        {

                            if (needsAddUnitCount == 0)
                                break;
                            int val = (int)Math.Ceiling(add);
                            if (val > needsAddUnitCount)
                                val = needsAddUnitCount;
                            unitRates.Add(unit, val);
                            needsAddUnitCount -= val;
                        }
                        if (needsAddUnitCount > 0)
                        {
                            foreach (var unit in unitRates)
                            {
                                unitRates[unit.Key] = (int)unit.Value + needsAddCount;

                                break;

                            }
                        }

                    }
                    else
                    {

                        
                        float add = needsAddUnitCount / unitRates.Count;
                        foreach(var unit in unitRates)
                        {

                            if (needsAddUnitCount == 0)
                                break;
                            int val = (int)Math.Ceiling(add);
                            if (val > needsAddUnitCount)
                                val  = needsAddUnitCount;
                            unitRates[unit.Key] += val;
                            needsAddUnitCount -= val;
                        }
                        if (needsAddCount > 0)
                        {
                            foreach (var unit in unitRates)
                            {
                                unitRates[unit.Key] = (int)unit.Value + needsAddCount;

                                break;

                            }
                        }
                    }
                }

                int cantAdded = 0;

               foreach(var unit in unitRates)
                {
                    List<Question> unitQuestion = QuestionProvider.QuestionDateMap.Where(q => q.Unit == unit.Key && !lastQuestions.Contains(q)).ToList();
                    if(unitQuestion.Count > unit.Value)
                    {
                        HashSet<int> prevIndexs = new HashSet<int>();
                        Random rand = new Random();
                        for (int i = 0; i < unit.Value; i++)
                        {
                            int val = rand.Next(0, unitQuestion.Count - 1);
                            if (prevIndexs.Contains(val))
                            {
                                i--;
                                continue;
                            }
                            prevIndexs.Add(val);
                            _questions.Add(unitQuestion[val]);
                        }
                    }
                    else if (unitQuestion.Count == unit.Value)
                    {
                        _questions.AddRange(unitQuestion);
                    }
                    else
                    {
                        cantAdded += (int)unit.Value - unitQuestion.Count;
                        if(unitQuestion.Count != 0)
                            _questions.AddRange(unitQuestion);

                    }
                }
               if(cantAdded > 0)
                {
                    List<Question> questions = QuestionProvider.QuestionDateMap;
                    for(int i = 0; i < cantAdded; i++)
                    {
                    if (!_questions.Contains(questions[i]))
                        {
                            _questions.Add(questions[i]);
                        }
                    }
                }

                _questions.AddRange(lastQuestions);



            });

            
      
        }

        public override void SaveToDatabase()
        {
            service.Create(_exam);
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
