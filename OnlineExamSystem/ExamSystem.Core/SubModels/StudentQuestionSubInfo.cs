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

        public string NowDate
        {
            get => GetNextDate(_studentQuestionInfoPointer);
            set => SetNextDate(_studentQuestionInfoPointer, value);
        }

        public string NextDate
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

        public bool IsMeasured
        {
            get => GetIsMeasured(_studentQuestionInfoPointer);
        }

        public int MeasureInfo
        {
            get
            {
                if (!IsMeasured)
                    throw new Exception("Info is not measured");
                return GetMeasureInfo(_studentQuestionInfoPointer);
            }
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
