using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Core.Utilities.Hashers
{
    public interface IPasswordHasher
    {
        string Hash(string password);

        bool Verify(string password, string hashedPassword);

    }
}
