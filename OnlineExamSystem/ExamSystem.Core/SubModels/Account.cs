using ExamSystem.Core.Utilities.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using static ExamSystem.Core.SubModels.AccountInfo;

namespace ExamSystem.Core.SubModels
{
    [BsonIgnoreExtraElements]
    public class Account : IDataBaseObject
    {
        public enum AccountType { Student, Teacher, Admin }
        private ObjectId _id;
        [BsonId]
        public ObjectId Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _email;
        [BsonElement("email")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _username;
        [BsonElement("username")]
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;
        [BsonElement("password")]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private AccountInfo _accInfo;

        [BsonSerializer(typeof(AccountInfoSerializer))]
        [BsonElement("AccountInfo")]
        public AccountInfo _AccountInfo
        {
            get { return _accInfo; }
            set { _accInfo = value; }
        }
        private AccountType _accountType;
        [BsonElement("accountType")]
        public AccountType _AccountType
        {
            get { return _accountType; }
            set { _accountType = value; }
        }
    }
}
