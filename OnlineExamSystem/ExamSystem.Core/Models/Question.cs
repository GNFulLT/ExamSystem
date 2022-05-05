using ExamSystem.Core.SubModels;
using ExamSystem.Core.Utilities.Providers;
using ExamSystem.Core.Utilities.Services;
using ExamSystem.Core.Utilities.Services.SubServices.LessonServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ExamSystem.Core.Models
{
    [BsonSerializer(typeof(QuestionSerializer))]
    [BsonIgnoreExtraElements]
    public class Question : IDataBaseObject
    {
        public ObjectId Id { get; set; }

        public Lesson Lesson { get; set; }

        public Section Section { get; set; }

        public Unit Unit { get; set; }

        public string ImageUri { get; set; }

        public QuestionInfo QuestionInfo { get; set; }

        public Question(Section section)
        {
            Unit = section.Unit;
            Lesson = Unit.Lesson;
            Section = section;
            QuestionInfo = new QuestionInfo();
        }

        public async Task<ReadOnlyMemory<string>> GetImage()
        {
            return await Task.Run(() => {

                return new ReadOnlyMemory<string>();

            });
        }

        public class QuestionSerializer : SerializerBase<Question>, IBsonSerializer, IBsonDocumentSerializer
        {
           
            public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Question value)
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
                context.Writer.WriteName("_sectionId");
                context.Writer.WriteObjectId(value.Section.Id);
                context.Writer.WriteName("image");
                context.Writer.WriteString(string.Empty);
                context.Writer.WriteName("questionInfo");
                var json = JsonConvert.SerializeObject(value.QuestionInfo);
                var serialized = BsonSerializer.Deserialize<BsonDocument>(json);
                var bson = new RawBsonDocument(serialized.ToBson());
                context.Writer.WriteRawBsonDocument(bson.Slice);
                context.Writer.WriteEndDocument();
            }
            public override Question Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
            {
                BsonDocument d = BsonSerializer.Deserialize<BsonDocument>(context.Reader);
                SectionService s = new SectionService();

                ObjectId id = d["_sectionId"].AsObjectId;

                Task<Section> t1 = s.Get(id);
                Section section = t1.Result;

                UnitSectionProvider.InitializeMaps();

                var lesMap = UnitSectionProvider.LessonMap;

                var les = lesMap[section.Unit.Lesson.LessonName];

                var unitMap = UnitSectionProvider.GetUnitDictionary(les);

                var unit = unitMap[section.Unit.UnitName];

                var sectionMap = UnitSectionProvider.GetSectionDictionary(unit);

                var localSection = sectionMap[section.SectionName];

                var info = BsonSerializer.Deserialize<QuestionInfo>(d["questionInfo"].AsBsonDocument);
                
                Question question = new Question(localSection)
                {
                    Id = d["_id"].AsObjectId,
                    ImageUri = d["image"].AsString,
                    QuestionInfo = info
                    
                };

                return question;

            }
            public bool TryGetMemberSerializationInfo(string memberName, out BsonSerializationInfo serializationInfo)
            {
                switch (memberName)
                {
                    case ("Id"):
                        serializationInfo = new BsonSerializationInfo("_id", new ObjectIdSerializer(), typeof(ObjectId));
                        return true;
                    case ("Section"):
                        serializationInfo = new BsonSerializationInfo("_sectionId", new BsonObjectIdSerializer(), typeof(ObjectId));
                        return true;
                    case ("ImageUri"):
                        serializationInfo = new BsonSerializationInfo("image", new BsonStringSerializer(), typeof(string));
                        return true;
                    case ("QuestionInfo"):
                        serializationInfo = new BsonSerializationInfo("questionInfo", new RawBsonDocumentSerializer(), typeof(QuestionInfo));
                        return true;
                    default:
                        serializationInfo = null;
                        return false;
                }
            }
        }
    }
}
