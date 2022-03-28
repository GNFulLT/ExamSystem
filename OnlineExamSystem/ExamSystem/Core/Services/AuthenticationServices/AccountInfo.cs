using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Services.AuthenticationServices
{
    [BsonIgnoreExtraElements]
    public class AccountInfo
    {
        private string _name;

        [BsonElement("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _surname;

        [BsonElement("surname")]
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

    }
}
