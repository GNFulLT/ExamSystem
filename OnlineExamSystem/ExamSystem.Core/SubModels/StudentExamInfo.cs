using ExamSystem.Core.Models;
using ExamSystem.Core.Utilities.Providers;
using ExamSystem.Core.Utilities.Services;
using ExamSystem.Core.Utilities.Services.SubServices.ExamServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static ExamSystem.Core.Models.Question;

namespace ExamSystem.Core.SubModels
{
    [BsonSerializer(typeof(StudentExamInfoSerializer))]
    [BsonIgnoreExtraElements]
    public class StudentExamInfo : IDataBaseObject
    {

        public StudentExamInfo()
        {
            _createdDate = Analyser.GetCurrentDate();
            _correctAnsweredQuestionIndexs = new List<int>();
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

        private Student _student;
        public Student Student
        {
            get { return _student; }
            set
            {
                _student = value;
            }
        }

        private Exam _exam;
        public Exam Exam
        {
            get { return _exam; }
            set
            {
                _exam = value;
            }
        }

        private string _createdDate;
        public string CreatedDate
        {
            get => _createdDate;
            set => _createdDate = value;
        }

        public string CreateDateAsSimpleString => CreatedDate.Substring(0, 4) + "-" + CreatedDate.Substring(4, 2) + "-" + CreatedDate.Substring(6, 2);

        private bool _isSolved;
        public bool IsSolved
        {
            get => _isSolved;
            set => _isSolved = value;
        }

        private List<int> _correctAnsweredQuestionIndexs;
        public List<int> CorrectAnsweredQuestionIndexs
        {
            get=> _correctAnsweredQuestionIndexs;
            set => _correctAnsweredQuestionIndexs = value;
        }

        public class StudentExamInfoSerializer : SerializerBase<StudentExamInfo>, IBsonSerializer, IBsonDocumentSerializer
        {
            public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, StudentExamInfo value)
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
                context.Writer.WriteName("_studentId");
                context.Writer.WriteObjectId(value.Student.Id);
                context.Writer.WriteName("_examId");
                context.Writer.WriteObjectId(value.Exam.Id);
                context.Writer.WriteName("createdDate");
                context.Writer.WriteString(value.CreatedDate);
                context.Writer.WriteName("isSolved");
                context.Writer.WriteBoolean(value.IsSolved);
               
                    context.Writer.WriteName("correctAnsweredIndexes");
                    context.Writer.WriteStartArray();
                    foreach(var item in value.CorrectAnsweredQuestionIndexs)
                    {
                        context.Writer.WriteInt32(item);
                    }
                    context.Writer.WriteEndArray();
                
                context.Writer.WriteEndDocument();
            }

            public override StudentExamInfo Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
            {
                BsonDocument d = BsonSerializer.Deserialize<BsonDocument>(context.Reader);

             

                ExamService service = new ExamService();
                Task<Exam> task = service.Get(d["_examId"].AsObjectId);
                Exam ex = task.Result;
                return new StudentExamInfo()
                {
                    Id = d["_id"].AsObjectId,
                    CreatedDate = d["createdDate"].AsString,
                    Exam = ex,
                    IsSolved = d["isSolved"].AsBoolean,
                    Student = StudentProvider.LoginedStudent,
                    CorrectAnsweredQuestionIndexs = JsonConvert.DeserializeObject<List<int>>(d["correctAnsweredIndexes"].ToJson())
                        
                    };
                
                
            }

            public bool TryGetMemberSerializationInfo(string memberName, out BsonSerializationInfo serializationInfo)
            {
                switch (memberName)
                {
                    case ("Id"):
                        serializationInfo = new BsonSerializationInfo("_id", new ObjectIdSerializer(), typeof(ObjectId));
                        return true;
                    case ("Student"):
                        serializationInfo = new BsonSerializationInfo("_studentId", new BsonObjectIdSerializer(), typeof(ObjectId));
                        return true;
                    case ("Exam"):
                        serializationInfo = new BsonSerializationInfo("_examId", new BsonObjectIdSerializer(), typeof(ObjectId));
                        return true;
                    case ("CreatedDate"):
                        serializationInfo = new BsonSerializationInfo("createdDate", new BsonStringSerializer(), typeof(string));
                        return true;
                    case ("IsSolved"):
                        serializationInfo = new BsonSerializationInfo("isSolved", new BooleanSerializer(), typeof(bool));
                        return true;
                    default:
                        serializationInfo = null;
                        return false;
                }
            }
        }

    }
}
