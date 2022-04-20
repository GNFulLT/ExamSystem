using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Hashers
{
    public class PasswordHasher_HMACSHA512 : IPasswordHasher
    {

        public string Hash(string password)
        {
            byte[] hashedPassword;
            byte[] salt = Encoding.UTF8.GetBytes("EXAMSYSTEMGNF");
            using (var hmac = new HMACSHA512(salt))
            {
                hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            return Encoding.UTF8.GetString(hashedPassword);
        }

        public bool Verify(string password,string hashedPassword)
        {
            string hashedPass = Hash(password);
            if (hashedPass.Equals(hashedPassword))
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
