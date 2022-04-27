using ExamSystem.Core.Utilities.Providers;
using ExamSystem.Core.Utilities.Services;
using ExamSystem.Core.Utilities.Services.SubServices.LessonServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Models
{
    [BsonIgnoreExtraElements]
    [BsonSerializer(typeof(UnitSerializer))]
    public class Unit : IDataBaseObject, IComparable<Unit>
    {
        private ObjectId _id;

        [BsonId]
        public ObjectId Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        private Lesson _lesson;
        public Lesson Lesson
        {
            get { return _lesson; }
            set { _lesson = value; }
        }

        private string _unitName;
        public string UnitName
        {
            get { return _unitName; }
            set { _unitName = value; }
        }

        private long _globalCount;
        public long GlobalCount
        {
            get { return _globalCount; }
            set { _globalCount = value; }
        }

        private long _globalRightCount;

        public long GlobalRightCount
        {
            get { return _globalRightCount; }
            set { _globalRightCount = value; }
        }

        public override string ToString()
        {
            return UnitName;
        }

        public int CompareTo(Unit other)
        {
            if (this.Id == other.Id)
            {
                return 0;
            }
            else if (this.Id < other.Id)
            {
                return -1;
            }
            return 1;

        }

        public class UnitSerializer : SerializerBase<Unit>, IBsonSerializer, IBsonDocumentSerializer
        {

            public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Unit value)
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
                context.Writer.WriteName("_lessonId");
                context.Writer.WriteObjectId(value.Lesson.Id);
                context.Writer.WriteName("unitName");
                context.Writer.WriteString(value.UnitName);
                context.Writer.WriteName("globalCount");
                context.Writer.WriteInt64(value.GlobalCount);
                context.Writer.WriteName("globalRightCount");
                context.Writer.WriteInt64(value.GlobalRightCount);
                context.Writer.WriteEndDocument();
            }

            public override Unit Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
            {
                BsonDocument d = BsonSerializer.Deserialize<BsonDocument>(context.Reader);
                LessonService service = new LessonService();
                var lesDict = UnitSectionProvider.LessonMap;
                ObjectId id = d["_lessonId"].AsObjectId;
                //Gets just lesson name and pass it to dictionary and take the lesson that is already allocated in ram. 
                Task<Lesson> t1 = service.Get(id);
                string res = t1.Result.LessonName;

                var unit = new Unit
                {
                    Id = d["_id"].AsObjectId,
                    Lesson = lesDict[res],
                    UnitName = d["unitName"].AsString,
                    GlobalCount = d["globalCount"].AsInt64,
                    GlobalRightCount = d["globalRightCount"].AsInt64

                };

                return unit;
            }

            public bool TryGetMemberSerializationInfo(string memberName, out BsonSerializationInfo serializationInfo)
            {
                switch (memberName)
                {
                    case ("Id"):
                        serializationInfo = new BsonSerializationInfo("_id", new ObjectIdSerializer(), typeof(ObjectId));
                        return true;
                    case ("Lesson"):
                        serializationInfo = new BsonSerializationInfo("_lessonId", new BsonObjectIdSerializer(), typeof(ObjectId));
                        return true;
                    case ("UnitName"):
                        serializationInfo = new BsonSerializationInfo("unitName", new StringSerializer(), typeof(string));
                        return true;
                    case ("globalCount"):
                        serializationInfo = new BsonSerializationInfo("globalCount", new Int64Serializer(), typeof(ulong));
                        return true;
                    case ("globalRightCount"):
                        serializationInfo = new BsonSerializationInfo("globalRightCount", new Int64Serializer(), typeof(ulong));
                        return true;
                    default:
                        serializationInfo = null;
                        return false;
                }
            }
        }
    }
}
