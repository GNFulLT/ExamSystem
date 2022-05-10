using ExamSystem.Core.Utilities.Providers;
using ExamSystem.Core.Utilities.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ExamSystem.Core.Models
{
    public class Exam : IDataBaseObject
    {

        private const string HASH_STR = "/X/";


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

                var json = JsonConvert.SerializeObject(ids);
                var serialized = BsonSerializer.Deserialize<BsonDocument>(json);
                var bson = new RawBsonDocument(serialized.ToBson());

                context.Writer.WriteRawBsonDocument(bson.Slice);


                context.Writer.WriteName("_uniqueKey");
                context.Writer.WriteString(GetUniqueKey(ids));

                context.Writer.WriteEndDocument();

            }
            public override Exam Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
            {
                BsonDocument d = BsonSerializer.Deserialize<BsonDocument>(context.Reader);
                List<Question> questions = QuestionProvider.QuestionDateMap.Where(q => q.Id.CompareTo(d["_id"].AsObjectId) == 0).ToList();
                if(questions.Count == 10)
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
                        serializationInfo = new BsonSerializationInfo("_questionIds", new RawBsonDocumentSerializer(), typeof(List<Question>));
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
