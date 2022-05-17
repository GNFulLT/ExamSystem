using ExamSystem.Core.Models;
using ExamSystem.Core.Utilities.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamSystem.Core.ViewModels.StudentPanel
{
    public class StudentScreenDashBoardPanelViewModel : ViewModel
    {
        public static Type Parent;

        public StudentScreenDashBoardPanelViewModel()
        {
            UpdateInfos();
        }

        #region Properties
        public int SolvedExams { get; set; }

        public int SolvedQuestions { get; set; }

        public int SolvedCorrectQuestions { get; set; }

        public int SolvedQuestionRatio { get; set; }

        public string SolvedQuestionRatioText => $"{SolvedQuestionRatio}%";

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
        #endregion


        #region MethodForEvents
        public void OnExamSolved(Exam exam)
        {
            UpdateInfos();
        }
        #endregion


        #region PrivateMethods
        private void UpdateInfos()
        {
            SolvedExams = 0;
            StudentProvider.GetStudentExamInfos().ForEach(inf => {
                if (inf.IsSolved)
                {
                    SolvedExams++;
                }
            
            
            } );

            SolvedQuestions = 0;
            SolvedCorrectQuestions = 0;
            foreach (var info in StudentProvider.GetStudentQuestionInfos())
            {
                SolvedQuestions += info.StudentSubQuestionInfo.TotalSolveCount;
                SolvedCorrectQuestions += info.StudentSubQuestionInfo.RightSolveCount;
            }

            

            if (SolvedQuestions == 0)
                SolvedQuestionRatio = 0;
            else
            {
                float ratio = ((float)SolvedCorrectQuestions) / ((float)SolvedQuestions);
                SolvedQuestionRatio = (int)(ratio * 100);

            }

            Name = StudentProvider.LoginedStudent.Account._AccountInfo.Name;

            Surname = StudentProvider.LoginedStudent.Account._AccountInfo.Surname;

            Email = StudentProvider.LoginedStudent.Account.Email;
        }
        #endregion
    }
}
