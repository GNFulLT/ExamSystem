using ExamSystem.Core.SubModels;
using ExamSystem.Core.Utilities.Providers;
using ExamSystem.Core.Utilities.Services;
using ExamSystem.Core.Utilities.Services.SubServices.StudentServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Models
{
    [BsonSerializer(typeof(StudentQuestionInfoSerializer))]
    [BsonIgnoreExtraElements]
    public class StudentQuestionInfo : IDataBaseObject
    {
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
            set { _student = value; }
        }

        private Question _question;

        public Question Question
        {
            get { return _question; }
            set { _question = value; }
        }

        private StudentQuestionSubInfo studentSubQuestionInfo;

        public StudentQuestionSubInfo StudentSubQuestionInfo
        {
            get { return studentSubQuestionInfo; }
            set { studentSubQuestionInfo = value; }
        }

        public class StudentQuestionInfoSerializer : SerializerBase<StudentQuestionInfo>, IBsonSerializer, IBsonDocumentSerializer
        {
            public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, StudentQuestionInfo value)
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

                context.Writer.WriteName("_questionId");
                context.Writer.WriteObjectId(value.Question.Id);

                context.Writer.WriteName("studentQuestionSubInfo");
                var json = JsonConvert.SerializeObject(value.StudentSubQuestionInfo);
                var serialized = BsonSerializer.Deserialize<BsonDocument>(json);
                var bson = new RawBsonDocument(serialized.ToBson());
                context.Writer.WriteRawBsonDocument(bson.Slice);
                context.Writer.WriteEndDocument();

            }

            public override StudentQuestionInfo Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
            {

                BsonDocument d = BsonSerializer.Deserialize<BsonDocument>(context.Reader);

                if (StudentProvider.LoginedStudent.Id.CompareTo(d["_id"].AsObjectId) != 0)
                    throw new Exception("Don't have access to student that is not logined");

                List<Question> qList = QuestionProvider.QuestionDateMap;

                Question question = qList.Where(q => q.Id == d["_questionId"].AsObjectId).First();

                var info = BsonSerializer.Deserialize<StudentQuestionSubInfo>(d["studentQuestionSubInfo"].AsBsonDocument);

                StudentService service = new StudentService();

                return new StudentQuestionInfo()
                {
                    Student = StudentProvider.LoginedStudent,
                    Id = d["_id"].AsObjectId,
                    Question = question,
                    StudentSubQuestionInfo = info
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
                        serializationInfo = new BsonSerializationInfo("_studentId", new ObjectIdSerializer(), typeof(ObjectId));
                        return true;
                    case ("Question"):
                        serializationInfo = new BsonSerializationInfo("_questionId", new ObjectIdSerializer(), typeof(ObjectId));
                        return true;
                    case ("studentQuestionSubInfo"):
                        serializationInfo = new BsonSerializationInfo("StudentSubQuestionInfo", new RawBsonDocumentSerializer(), typeof(StudentQuestionSubInfo));
                        return true;
                    default:
                        serializationInfo = null;
                        return false;
                }
            }
        }
    }
}
