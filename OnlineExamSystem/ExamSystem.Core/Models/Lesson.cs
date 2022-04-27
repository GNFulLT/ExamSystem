using ExamSystem.Core.Utilities.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Core.Models
{
    public class Lesson : IDataBaseObject, IEqualityComparer<Lesson>
    {
        private ObjectId _id;
        public ObjectId Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }
        private string _lessonName;
        [BsonElement("lessonName")]
        public string LessonName
        {
            get { return _lessonName; }
            set { _lessonName = value; }
        }
        private long _globalCount;
        [BsonElement("globalCount")]

        public long GlobalCount
        {
            get { return _globalCount; }
            set { _globalCount = value; }
        }

        private long _globalRightCount;

        [BsonElement("globalRightCount")]
        public long GlobalRightCount
        {
            get { return _globalRightCount; }
            set { _globalRightCount = value; }
        }
        public override string ToString()
        {
            return LessonName;
        }
        public bool Equals(Lesson x, Lesson y)
        {
            return x.LessonName == y.LessonName;
        }

        public int GetHashCode(Lesson obj)
        {
            return obj.GetHashCode();
        }

    }
}
