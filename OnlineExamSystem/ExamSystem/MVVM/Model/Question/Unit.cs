using ExamSystem.Core.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.MVVM.Model.Question
{
    [BsonIgnoreExtraElements]
    public class Unit :IDataBaseObject
    {
        private ObjectId _id;

        [BsonId]
        public ObjectId Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        

        private string _unitName;
        [BsonElement("unitName")]
        public string UnitName
        {
            get { return _unitName; }
            set { _unitName = value; }
        }

        private ulong _globalCount;
        [BsonElement("globalCount")]

        public ulong GlobalCount
        {
            get { return _globalCount; }
            set { _globalCount = value; }
        }

        private  ulong _globalRightCount;

        [BsonElement("globalRightCount")]
        public ulong GlobalRightCount
        {
            get { return _globalRightCount; }
            set { _globalRightCount = value; }
        }
        
        public override string ToString()
        {
            return UnitName;
        }
    }
}
