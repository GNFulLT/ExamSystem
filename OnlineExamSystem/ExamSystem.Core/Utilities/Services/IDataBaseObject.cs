using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Core.Utilities.Services
{
    public interface IDataBaseObject
    {
        [BsonId]
        ObjectId Id { get; set; }
    }
}
