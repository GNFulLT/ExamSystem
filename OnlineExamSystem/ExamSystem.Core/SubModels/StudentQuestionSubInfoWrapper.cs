using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ExamSystem.Core.SubModels
{
    public abstract class StudentQuestionSubInfoWrapper
    {
        protected IntPtr _studentQuestionInfoPointer;

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern IntPtr CreateStudentQuestionSubInfo();

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern void DeleteStudentQuestionSubInfo(IntPtr info);

        [DllImport("StudentInfoAnalysis.dll")]
        [return: MarshalAs(UnmanagedType.BStr)]
        protected static extern string GetLastDate(IntPtr info);

        [DllImport("StudentInfoAnalysis.dll")]
        [return: MarshalAs(UnmanagedType.BStr)]
        protected static extern string GetNowDate(IntPtr info);

        [DllImport("StudentInfoAnalysis.dll")]
        [return: MarshalAs(UnmanagedType.BStr)]
        protected static extern string GetNextDate(IntPtr info);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern int GetRightSolveCount(IntPtr info);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern int GetRightSolveInARowCount(IntPtr info);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern int GetTotalSolveCount(IntPtr info);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern int GetMeasureInfo(IntPtr info);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern bool GetIsMeasured(IntPtr info);


        //Setters

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern void SetLastDate(IntPtr info, string text);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern void SetNowDate(IntPtr info, string text);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern void SetNextDate(IntPtr info, string text);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern void SetRightSolveCount(IntPtr info, int value);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern void SetRightSolveInARowCount(IntPtr info, int value);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern void SetTotalSolveCount(IntPtr info, int value);
        
    }
}
