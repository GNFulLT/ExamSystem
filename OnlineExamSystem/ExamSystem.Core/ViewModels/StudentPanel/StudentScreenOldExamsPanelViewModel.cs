using ExamSystem.Core.Models;
using ExamSystem.Core.Utilities.Providers;
using ExamSystem.Core.Utilities.Services.SubServices.StudentServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExamSystem.Core.ViewModels.StudentPanel
{
    public class StudentScreenOldExamsPanelViewModel : ViewModel
    {
        public static Type Parent;

        Dictionary<StudentScreenExamPanelViewModel, object> Views = new Dictionary<StudentScreenExamPanelViewModel, object>();


        public StudentScreenOldExamsPanelViewModel()
        {
            List<Exam> exams = new List<Exam>();
            ExamCollection = new ObservableCollection<object>();
            foreach (var info in StudentProvider.GetStudentExamInfos())
            {
                if (info.IsSolved)
                {
                    exams.Add(info.Exam);
                    info.Exam.Info = info;
                }
                
            }
            for(int i = exams.Count - 1; i > -1; i--)
            {
                StudentScreenExamPanelViewModel vm = new StudentScreenExamPanelViewModel(exams[i]); 
                object o = Activator.CreateInstance(StudentScreenExamPanelViewModel.Parent, vm);
                ExamCollection.Add(o);
                Views.Add(vm, o);
            }
        }



        #region Properties
        public ObservableCollection<object> ExamCollection { get; set; }
        #endregion
    }
}
