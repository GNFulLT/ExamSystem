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

            LeftText = "Günün Sınavı";

            if (_isSolved)
                LeftText = "Çözülmüş Sınav";
         }


        #region Properties
        public int QuestionCount { get; set; }
        public string CreatedDate { get; set; }
        #endregion

        #region LocalizableProperties
        public string LeftText { get; set; }
        #endregion

        #region Commands
        public ICommand QuestionClickedCommand => new RelayCommand((sender) => {
            if (!_isSolved)
            {
                //Eğer soru çözülmemişse sınavı çözüm ekranını açar
                _examWindowViewModel = new StudentScreenExamWindowViewModel(_exam);
                _examWindowView = Activator.CreateInstance(StudentScreenExamWindowViewModel.Parent, _examWindowViewModel);
                _examWindowViewModel.ExamSolved += OnExamSolved;
                Navigation.StackPush(_examWindowView);
            }
        });

        private async void OnExamSolved(Exam exam, Dictionary<int, int> givenAnswers)
        {
            //Sınav çözüldüğünde sınavı analiz eder sınavı çözüldü olarak kaydedip exam solved ve analysed eventlerini çalıştırır
            await  Exam.AnalyseExam(exam, givenAnswers);
            await  Exam.SetStudentExamInfo(exam);
            ExamSolvedAndAnalysed?.Invoke(exam,this);
        }


        #endregion

        #region PrivateFields
        private Exam _exam;
        private bool _isSolved;
        private object _examWindowView;
        private StudentScreenExamWindowViewModel _examWindowViewModel;
        #endregion

        #region Events
        public event Action<Exam, StudentScreenExamPanelViewModel> ExamSolvedAndAnalysed; 
        #endregion

    }
}
