using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Core.SubModels
{
    public class AccountInfo
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _surname;

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public class AccountInfoSerializer : SerializerBase<AccountInfo>, IBsonDocumentSerializer, IBsonSerializer
        {
            public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, AccountInfo value)
            {

                context.Writer.WriteStartDocument();

                context.Writer.WriteName("name");
                context.Writer.WriteString(value.Name);

                context.Writer.WriteName("surname");
                context.Writer.WriteString(value.Surname);

                context.Writer.WriteEndDocument();

            }




            public override AccountInfo Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
            {
                BsonDocument d = BsonSerializer.Deserialize<BsonDocument>(context.Reader);


                AccountInfo accountInfo = new AccountInfo()
                {
                    Name = d["name"].AsString,
                    Surname = d["surname"].AsString
                };
                return accountInfo;

            }
            public bool TryGetMemberSerializationInfo(string memberName, out BsonSerializationInfo serializationInfo)
            {
                switch (memberName)
                {
                    case "Name":
                        serializationInfo = new BsonSerializationInfo("name", new StringSerializer(), typeof(string));
                        return true;
                    case "Surname":
                        serializationInfo = new BsonSerializationInfo("surname", new StringSerializer(), typeof(string));
                        return true;
                    default:
                        serializationInfo = null;
                        return false;
                }
            }
        }
    }
}
