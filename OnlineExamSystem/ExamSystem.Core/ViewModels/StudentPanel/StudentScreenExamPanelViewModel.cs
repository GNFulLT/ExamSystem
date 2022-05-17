using ExamSystem.Core.Models;
using ExamSystem.Core.Utilities.NavigationSource;
using ExamSystem.Core.Utilities.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ExamSystem.Core.ViewModels.StudentPanel
{
    public class StudentScreenExamPanelViewModel : ViewModel
    {
        public static Type Parent;

        public StudentScreenExamPanelViewModel(Exam exam)
        {
            _exam = exam;
            QuestionCount = exam.Questions.Count;

            CreatedDate = exam.Info.CreateDateAsSimpleString;

            _isSolved = exam.Info.IsSolved;
         }


        #region Properties
        public int QuestionCount { get; set; }
        public string CreatedDate { get; set; }
        #endregion

        #region LocalizableProperties
        #endregion

        #region Commands
        public ICommand QuestionClickedCommand => new RelayCommand((sender) => {
            if (!_isSolved)
            {
                _examWindowViewModel = new StudentScreenExamWindowViewModel(_exam);
                _examWindowView = Activator.CreateInstance(StudentScreenExamWindowViewModel.Parent, _examWindowViewModel);
                Navigation.StackPush(_examWindowView);
            }
        });

       
        #endregion

        #region PrivateFields
        private Exam _exam;
        private bool _isSolved;
        private object _examWindowView;
        private StudentScreenExamWindowViewModel _examWindowViewModel;
        #endregion

        #region Events
        public event Action<Exam> OnExamSolved; 
        #endregion

    }
}
