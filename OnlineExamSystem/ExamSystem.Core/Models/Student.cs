using ExamSystem.Core.SubModels;
using ExamSystem.Core.Utilities.Providers;
using ExamSystem.Core.Utilities.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;

namespace ExamSystem.Core.Models
{

    
    [BsonSerializer(typeof(StudentSerializer))]
    [BsonIgnoreExtraElements]
    public class Student : IDataBaseObject
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

        private Account _account;

        public Account Account
        {
            get { return _account; }
            set { _account = value; }
        }

        public class StudentSerializer : SerializerBase<Student>, IBsonSerializer, IBsonDocumentSerializer
        {
            public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Student value)
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

                context.Writer.WriteName("_accountId");
                context.Writer.WriteObjectId(value.Account.Id);
                context.Writer.WriteEndDocument();
            }

            public override Student Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
            {
                BsonDocument d = BsonSerializer.Deserialize<BsonDocument>(context.Reader);

                if (AccountProvider.LoginedAccount.Id.CompareTo(d["_accountId"].AsObjectId) != 0)
                {
                    throw new System.Exception("Don't have access to the student that is not logined");
                }

                return new Student()
                {
                    Account = AccountProvider.LoginedAccount,
                    Id = d["_id"].AsObjectId
                };
            }

            public bool TryGetMemberSerializationInfo(string memberName, out BsonSerializationInfo serializationInfo)
            {
                switch (memberName)
                {
                    case ("Id"):
                        serializationInfo = new BsonSerializationInfo("_id", new ObjectIdSerializer(), typeof(ObjectId));
                        return true;
                    case ("Account"):
                        serializationInfo = new BsonSerializationInfo("_accountId", new BsonObjectIdSerializer(), typeof(ObjectId));
                        return true;
                    default:
                        serializationInfo = null;
                        return false;

                }
            }
        }



    }
}
