using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Core.SubModels
{
    public class StudentQuestionSubInfo : StudentQuestionSubInfoWrapper
    {
        public string LastDate
        {
            get => GetLastDate(_studentQuestionInfoPointer);
            set => SetLastDate(_studentQuestionInfoPointer, value);
        }

        public string NextDate
        {
            get => GetNextDate(_studentQuestionInfoPointer);
            set => SetNextDate(_studentQuestionInfoPointer, value);
        }

        public IntPtr AsPtr()
        {
            return _studentQuestionInfoPointer;
            
        }

        public string NowDate
        {
            get => GetNowDate(_studentQuestionInfoPointer);
            set => SetNowDate(_studentQuestionInfoPointer, value);
        }

        public int TotalSolveCount
        {
            get => GetTotalSolveCount(_studentQuestionInfoPointer);
            set => SetTotalSolveCount(_studentQuestionInfoPointer, value);
        }

        public int RightSolveCount
        {
            get => GetRightSolveCount(_studentQuestionInfoPointer);
            set => SetRightSolveCount(_studentQuestionInfoPointer,value);
        }

        public int RightSolveInARowCount
        {
            get => GetRightSolveInARowCount(_studentQuestionInfoPointer);
            set => SetRightSolveInARowCount(_studentQuestionInfoPointer, value);
        }


        private bool _isMeasured;


        public int GetLastMeasureInfo()
        {
            return _measureInfo;
        }

        public bool IsMeasured
        {
            get => GetIsMeasured(_studentQuestionInfoPointer);
            set => _isMeasured = value;
        }

        private int _measureInfo;
        public int MeasureInfo
        {
            get
            {
                if (!IsMeasured)
                    return _measureInfo;
                return GetMeasureInfo(_studentQuestionInfoPointer);
            }
            set => _measureInfo = value;
        }

        public StudentQuestionSubInfo()
        {
            _studentQuestionInfoPointer = CreateStudentQuestionSubInfo();
            
        }
        ~StudentQuestionSubInfo()
        {
            DeleteStudentQuestionSubInfo(_studentQuestionInfoPointer);

        }
    }
}
