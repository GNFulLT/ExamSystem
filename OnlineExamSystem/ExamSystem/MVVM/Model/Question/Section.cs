using ExamSystem.Core.Services;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.MVVM.Model.Question
{
    public class Section:IDataBaseObject
    {
        private ObjectId _id;

        public ObjectId Id { get { return _id; } set {
                _id = value;
            } }

        private string _sectionName;

        public string SectionName
        {
            get { return  _sectionName; }
            set {  _sectionName = value; }
        }

        private int _globalCount;

        public int GlobalCount
        {
            get { return _globalCount; }
            set { _globalCount = value; }
        }

        private int _globalRightCount;

        public int GlobalRightCount
        {
            get { return _globalRightCount; }
            set { _globalRightCount = value; }
        }

        public override string ToString()
        {
            return SectionName;
        }

    }
}
