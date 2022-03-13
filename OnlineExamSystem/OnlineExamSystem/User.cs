using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OnlineExamSystem
{
    [BsonIgnoreExtraElements]
    internal class User
    {
        internal enum UserTypes {ADMIN=0,TEACHER,STUDENT }

        [BsonId]
        private ObjectId UserID { get; set; }
        
        [BsonElement("email")]
        internal string Email { get; set; }

        [BsonElement("username")]
        internal string Username { get; set; }

        [BsonElement("password")]
        internal string Password { get; private set; }

        [BsonElement("name")]
        internal string Name { get; set; }

        [BsonElement("surname")]
        internal string Surname { get; set; }

        [BsonElement("userType")]
        internal UserTypes UserType { get; set; }

        public User()
        {
            this.UserType = UserTypes.STUDENT;
        }

        public string GetPassword()
        {
            return this.Password;
        }
        public void SetPassword(string s)
        {
            this.Password = s;
        }

        public bool CheckUserType()
        {
            if (Enum.IsDefined(typeof(UserTypes), this.UserType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        

    }
}
