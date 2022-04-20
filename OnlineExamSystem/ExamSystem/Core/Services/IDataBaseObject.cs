using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Services
{
    public interface IDataBaseObject
    {
        [BsonId]
        ObjectId Id { get; set; }
    }
}
