using ExamSystem.Core.Models;
using ExamSystem.Core.Utilities.NavigationSource;
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

        Dictionary<StudentScreenExamPanelViewModel, object> Views = new Dictionary<StudentScreenExamPanelViewModel, object>();

        public StudentScreenExamsPanelViewModel()
        {
            Exam ex = StudentProvider.TodayExam;
            if(ex is object)
            {
                ExamCollection = new ObservableCollection<object>();

                StudentScreenExamPanelViewModel vm = new StudentScreenExamPanelViewModel(StudentProvider.TodayExam);
                vm.ExamSolvedAndAnalysed += OnExamSolvedAndAnalysed;
                object o = Activator.CreateInstance(StudentScreenExamPanelViewModel.Parent, vm);
                ExamCollection.Add(o);
                Views.Add(vm, o);
            }
           
        }

        private void OnExamSolvedAndAnalysed(Exam exam,StudentScreenExamPanelViewModel vm)
        {
            ExamCollection.Remove(Views.GetValueOrDefault(vm));
            Navigation.StackPop();
            ExamSolvedAnalysedAndRemovedFromCollection?.Invoke(exam);
        }

        public Action<Exam> ExamSolvedAnalysedAndRemovedFromCollection;

        #region Properties
        public ObservableCollection<object> ExamCollection { get; set; }
        #endregion
    }
}
