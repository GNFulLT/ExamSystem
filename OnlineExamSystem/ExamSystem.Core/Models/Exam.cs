using ExamSystem.Core.SubModels;
using ExamSystem.Core.Utilities.Providers;
using ExamSystem.Core.Utilities.Services;
using ExamSystem.Core.Utilities.Services.SubServices.QuestionServices;
using ExamSystem.Core.Utilities.Services.SubServices.StudentServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Models
{
    [BsonSerializer(typeof(ExamSerializer))]
    [BsonIgnoreExtraElements]
    public class Exam : IDataBaseObject
    {

        private const string HASH_STR = "/X/";

        public Exam()
        {
            _id = ObjectId.GenerateNewId();
        }

        private ObjectId _id;
        public ObjectId Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        private List<Question> _questions;
        public List<Question> Questions
        {
            get => _questions;
            set => _questions = value;
        }

        private string _examUniqueKey;
        public string ExamUniqueKey
        {
            get => _examUniqueKey;
            set => _examUniqueKey = value;
        }

        public static string GetUniqueKey(List<ObjectId> ids)
        {
            
            List<BigInteger> ints = new List<BigInteger>();
            for(int i = 0; i < ids.Count; i++)
            {
                int val = ids[i].GetHashCode();

                int x = ints.BinarySearch(val);

                ints.Insert((x >= 0) ? x : ~x, val);
            }
            StringBuilder sb = new StringBuilder();
            foreach(var item in ints)
            {
                sb.Append(item.ToString());
                sb.Append(HASH_STR);
            }

            return sb.ToString();
        }

        public StudentExamInfo Info { get; set; }

        public void LoadQuestionInfos()
        {
            Lazy<Task> questions = new Lazy<Task>(() =>
            {
                return Task.Run(async () => { 
                    
                        foreach(var q in _questions)
                    {
                       await q.LoadInfo();
                    }    
                });
            });
            questions.Value.Wait();
        }

        public void ClearQuestionInfos()
        {
            Lazy<Task> questions = new Lazy<Task>(() =>
            {
                return Task.Run(() =>
                {
                    foreach(var q in _questions)
                    {
                        q.ClearInfo();
                    }
                });
            });
            questions.Value.Wait();
        }

        public static Task AnalyseExam(Exam exam, Dictionary<int, int> givenAnswers)
        {
            return Task.Run(async () =>
            {
                List<StudentQuestionInfo> infos = new List<StudentQuestionInfo>();
                for (int i = 0; i < exam.Questions.Count; i++)
                {
                    if (!givenAnswers.ContainsKey(i))
                    {
                        await QuestionSolvedWrongly(exam, i);
                    }
                    else
                    {
                        int answerIndex = givenAnswers.GetValueOrDefault(i);
                        if (answerIndex != 3)
                        {
                           await QuestionSolvedWrongly(exam, i);
                        }
                        else
                        {
                            QuestionSolvedCorrectly(exam, i, ref infos);
                        }
                    }
                }

                foreach(var q in exam.Questions)
                {
                    QuestionService service2 = new QuestionService();
                    await service2.UpdateWithUnitSections(q);
                }

                AnalyseExamDLL(infos);
                StudentQuestionInfoService service = new StudentQuestionInfoService();
                
                foreach (var info in infos)
                {
                   int createdOrUpdated = await service.CreateOrUpdate(info);
                }
            });
           
        }

        private static void AnalyseExamDLL(List<StudentQuestionInfo> infos)
        {
            Analyser.StartAnalysis();
            foreach(var info in infos)
            {
                Analyser.Add(info.Question.QuestionInfo.AsPtr(),info.StudentSubQuestionInfo.AsPtr());
            }
            Analyser.Analysis();
            Analyser.EndAnalysis();

        }
        private static void QuestionSolvedCorrectly(Exam exam,int index,ref List<StudentQuestionInfo> infos)
        {
            Question q = exam.Questions[index];
            StudentQuestionInfo info = StudentProvider.GetStudentQuestionInfos().Find(q2 => q2.Question.Id.CompareTo(q.Id) == 0);
            if (info is null)
            {
                info = new StudentQuestionInfo();
                info.Question = q;
                info.Student = StudentProvider.LoginedStudent;
                info.StudentSubQuestionInfo = new StudentQuestionSubInfo();
                info.StudentSubQuestionInfo.TotalSolveCount = 1;
                info.StudentSubQuestionInfo.RightSolveInARowCount = 1;
                info.StudentSubQuestionInfo.RightSolveCount = 1;
                info.StudentSubQuestionInfo.LastDate = Analyser.GetCurrentDate();
                StudentProvider.GetStudentQuestionInfos().Add(info);
            }
            else
            {
                info.StudentSubQuestionInfo.RightSolveCount++;
                info.StudentSubQuestionInfo.RightSolveInARowCount++;
                info.StudentSubQuestionInfo.TotalSolveCount++;
                info.StudentSubQuestionInfo.LastDate = Analyser.GetCurrentDate();

            }


            q.QuestionInfo.GlobalCount++;
            q.Section.GlobalCount++;
            q.Unit.GlobalCount++;
            q.Lesson.GlobalCount++;



            q.QuestionInfo.GlobalRightCount++;
            q.Section.GlobalRightCount++;
            q.Unit.GlobalRightCount++;
            q.Lesson.GlobalRightCount++;

            infos.Add(info);
            exam.Info.CorrectAnsweredQuestionIndexs.Add(index);
       
        }

        private static Task QuestionSolvedWrongly(Exam exam,int index)
        {
            return Task.Run(async () =>
            {
                Question q = exam.Questions[index];
                StudentQuestionInfoService service = new StudentQuestionInfoService();
                StudentQuestionInfo info = StudentProvider.GetStudentQuestionInfos().Find(q2 => q2.Question.Id.CompareTo(q.Id) == 0);
                if (info is null)
                {
                    info = new StudentQuestionInfo();
                    info.Question = q;
                    info.Student = StudentProvider.LoginedStudent;
                    info.StudentSubQuestionInfo = new StudentQuestionSubInfo();
                    info.StudentSubQuestionInfo.TotalSolveCount = 1;
                    info.StudentSubQuestionInfo.LastDate = Analyser.GetCurrentDate();
                }
                else
                {
                    info.StudentSubQuestionInfo.LastDate = Analyser.GetCurrentDate();
                    
                    info.StudentSubQuestionInfo.TotalSolveCount++;
                    info.StudentSubQuestionInfo.RightSolveInARowCount = 0;
                }

                q.QuestionInfo.GlobalCount++;
                q.Section.GlobalCount++;
                q.Unit.GlobalCount++;
                q.Lesson.GlobalCount++;

               

                int createdOrUpdated = await service.CreateOrUpdate(info);
            });
          
        }

        public static Task SetStudentExamInfo(Exam exam)
        {
            return Task.Run(async () => {

                
                    exam.Info.IsSolved = true;
                    StudentExamInfoService service = new StudentExamInfoService();
                    int createdOrUpdated = await service.CreateOrUpdate(exam.Info);
                 
            });
        }

        public class ExamSerializer : SerializerBase<Exam>, IBsonSerializer, IBsonDocumentSerializer
        {
            public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Exam value)
            {
                context.Writer.WriteStartDocument();
                context.Writer.WriteName("_id");
                if (value.Id == ObjectId.Empty)
                {
                    context.Writer.WriteObjectId(ObjectId.GenerateNewId());
                }
                else
                {
                    context.Writer.WriteObjectId(value.Id);

                }
                context.Writer.WriteName("_createdByAccountId");
                context.Writer.WriteObjectId(AccountProvider.LoginedAccount.Id);

                context.Writer.WriteName("_questionIds");
                List<ObjectId> ids = value.Questions.Select(q => q.Id).ToList();

                context.Writer.WriteStartArray();
                foreach(var item in ids)
                {
                    context.Writer.WriteObjectId(item);
                }
                context.Writer.WriteEndArray();

                context.Writer.WriteName("_uniqueKey");
                context.Writer.WriteString(GetUniqueKey(ids));


                context.Writer.WriteEndDocument();

            }
            public override Exam Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
            {
                BsonDocument d = BsonSerializer.Deserialize<BsonDocument>(context.Reader);
                List<Question> questions = QuestionProvider.QuestionDateMap.Where(q => d["_questionIds"].AsBsonArray.Contains(q.Id)).ToList();
                if(questions.Count != d["_questionIds"].AsBsonArray.Count)
                {
                    throw new Exception("Cant found questions");
                }
                return new Exam()
                {
                    Id = d["_id"].AsObjectId,
                    Questions = questions,
                    ExamUniqueKey = d["_uniqueKey"].AsString
                    
                };
            }

            public bool TryGetMemberSerializationInfo(string memberName, out BsonSerializationInfo serializationInfo)
            {
                switch (memberName)
                {
                    case ("Id"):
                        serializationInfo = new BsonSerializationInfo("_id", new ObjectIdSerializer(), typeof(ObjectId));
                        return true;
                    case ("Questions"):
                        serializationInfo = new BsonSerializationInfo("_questionIds", new BsonArraySerializer(), typeof(List<Question>));
                        return true;
                    case ("ExamUniqueKey"):
                        serializationInfo = new BsonSerializationInfo("_uniqueKey", new StringSerializer(), typeof(string));
                        return true;
                    default:
                        serializationInfo = null;
                        return false;
                }
            }
        }



    }
}
