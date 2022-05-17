using ExamSystem.Core.Utilities.Providers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExamSystem.Core.ViewModels.StudentPanel
{
    public class StudentScreenExamsPanelViewModel : ViewModel
    {
        public static Type Parent;

        public StudentScreenExamsPanelViewModel()
        {
            ExamCollection = new ObservableCollection<object>();

            StudentScreenExamPanelViewModel vm = new StudentScreenExamPanelViewModel(StudentProvider.TodayExam);
            object o = Activator.CreateInstance(StudentScreenExamPanelViewModel.Parent, vm);
            ExamCollection.Add(o);

        }

        

        #region Properties
        public ObservableCollection<object> ExamCollection { get; set; }
        #endregion
    }
}
