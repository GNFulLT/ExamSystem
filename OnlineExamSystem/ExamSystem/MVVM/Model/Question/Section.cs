using ExamSystem.Core.Services;
using ExamSystem.Core.Services.DatabaseServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.MVVM.Model.Question
{
    [BsonSerializer(typeof(SectionSerializer))]
    [BsonIgnoreExtraElements]
    public class Section:IDataBaseObject
    {
        private ObjectId _id;
        public ObjectId Id { get { return _id; } set {
                _id = value;
            } }

        
        private Unit _unit;
        public Unit Unit { get { return _unit; }
        set { _unit = value; }
        }


        private string _sectionName;

        public string SectionName
        {
            get { return  _sectionName; }
            set {  _sectionName = value; }
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
            return SectionName;
        }

        public Section()
        {
            Id = ObjectId.Empty;
        }

        public class SectionSerializer : SerializerBase<Section>, IBsonSerializer, IBsonDocumentSerializer
        {
            public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Section value)
            {
                context.Writer.WriteStartDocument();
                context.Writer.WriteName("_id");
                context.Writer.WriteObjectId(ObjectId.GenerateNewId());
                context.Writer.WriteName("_unitId");
                context.Writer.WriteObjectId(value.Unit.Id);
                context.Writer.WriteName("sectionName");
                context.Writer.WriteString(value.SectionName);
                context.Writer.WriteName("globalCount");
                context.Writer.WriteInt64(value.GlobalCount);
                context.Writer.WriteName("globalRightCount");
                context.Writer.WriteInt64(value.GlobalRightCount);
                context.Writer.WriteEndDocument();

            }

            public override Section Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
            {
                BsonDocument d = BsonSerializer.Deserialize<BsonDocument>(context.Reader);
                UnitService unitS = new UnitService();
                ObjectId id = d["_unitId"].AsObjectId;
                Task<Unit> t1 = unitS.Get(id);
                Unit unit = t1.Result;
                var section = new Section {
                    Id = d["_id"].AsObjectId,
                    Unit = unit,
                    SectionName = d["sectionName"].AsString,
                    GlobalCount = d["globalCount"].AsInt64,
                    GlobalRightCount = d["globalRightCount"].AsInt64


                        
                };

               
                return section;
            }

            public bool TryGetMemberSerializationInfo(string memberName, out BsonSerializationInfo serializationInfo)
            {
                switch (memberName)
                {
                    case ("Id"):
                        serializationInfo = new BsonSerializationInfo("_id", new ObjectIdSerializer(), typeof(ObjectId));
                        return true;
                    case ("Unit"):
                        serializationInfo = new BsonSerializationInfo("_unitId", new BsonObjectIdSerializer(), typeof(ObjectId));
                        return true;
                    case ("SectionName"):
                        serializationInfo = new BsonSerializationInfo("sectionName", new StringSerializer(), typeof(string));
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
