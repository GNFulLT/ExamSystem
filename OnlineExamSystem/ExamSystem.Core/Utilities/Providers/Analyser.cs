using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ExamSystem.Core.Utilities.Providers
{
    public static class Analyser
    {




        [DllImport("StudentInfoAnalysis.dll")]
        public static extern void StartAnalysis();

        [DllImport("StudentInfoAnalysis.dll")]
        public static extern void EndAnalysis();

        [DllImport("StudentInfoAnalysis.dll")]
        public static extern void Add(IntPtr questionInfo,IntPtr studentQuestionSubInfo);

        [DllImport("StudentInfoAnalysis.dll")]
        public static extern void Analysis();

     

        //Wrapper
        [DllImport("StudentInfoAnalysis.dll")]
        public static extern float MixRate(float value1, float value2);

        [return: MarshalAs(UnmanagedType.BStr)]
        [DllImport("StudentInfoAnalysis.dll")]
        public static extern string GetCurrentDate();
    }
}
