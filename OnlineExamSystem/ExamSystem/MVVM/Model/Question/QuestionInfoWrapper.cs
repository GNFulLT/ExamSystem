using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.MVVM.Model.Question
{
    public abstract class QuestionInfoWrapper
    {
        protected IntPtr _questionInfoPointer;

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern IntPtr CreateQuestionInfo();


        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern void DeleteQuestionInfo(IntPtr info);

        [DllImport("StudentInfoAnalysis.dll")]
        [return: MarshalAs(UnmanagedType.BStr)]
        protected static extern string GetQuestionText(IntPtr info);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern void SetQuestionText(IntPtr info, string text);

        [DllImport("StudentInfoAnalysis.dll")]
        [return: MarshalAs(UnmanagedType.BStr)]
        protected static extern string GetWrongAnswer0(IntPtr info);

        [DllImport("StudentInfoAnalysis.dll")]
        [return: MarshalAs(UnmanagedType.BStr)]
        protected static extern string GetWrongAnswer1(IntPtr info);

        [DllImport("StudentInfoAnalysis.dll")]
        [return: MarshalAs(UnmanagedType.BStr)]
        protected static extern string GetWrongAnswer2(IntPtr info);

        [DllImport("StudentInfoAnalysis.dll")]
        [return: MarshalAs(UnmanagedType.BStr)]
        protected static extern string GetCorrectAnswer0(IntPtr info);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern void SetWrongAnswer0(IntPtr info, string text);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern void SetWrongAnswer1(IntPtr info, string text);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern void SetWrongAnswer2(IntPtr info, string text);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern void SetCorrectAnswer0(IntPtr info, string text);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern int GetGlobalRightCount(IntPtr info);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern int GetGlobalCount(IntPtr info);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern int GetDifficulty(IntPtr info);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern void SetGlobalRightCount(IntPtr info,int value);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern void SetGlobalCount(IntPtr info,int value);

        [DllImport("StudentInfoAnalysis.dll")]
        protected static extern void SetDifficulty(IntPtr info,int value);

    }

}
