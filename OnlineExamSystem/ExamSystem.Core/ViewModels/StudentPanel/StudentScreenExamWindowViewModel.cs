using ExamSystem.Core.Models;
using ExamSystem.Core.Utilities.NavigationSource;
using ExamSystem.Core.Utilities.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ExamSystem.Core.ViewModels.StudentPanel
{
    public class StudentScreenExamWindowViewModel : ViewModel
    {
        public static Type Parent;

        public StudentScreenExamWindowViewModel(Exam exam)
        {
            _exam = exam;
            QuestionText = "";
            AnswerText0 = "";
            AnswerText1 = "";
            AnswerText2 = "";
            AnswerText3 = "";

            Index = 0;
        }

        #region Properties
        public int _index;

        public int Index { get => _index; set {
                _index = value;
                NotifyPropertyChanged();
                OnIndexChanged(_index);
            
            } }

        private void OnIndexChanged(int index)
        {
            QuestionText = QuestionProvider.QuestionDateMap[130].QuestionInfo.QuestionText;
            /*AnswerText0 = _exam.Questions[index].QuestionInfo.WrongAnswer0;
            AnswerText1 = _exam.Questions[index].QuestionInfo.WrongAnswer1;
            AnswerText2 = _exam.Questions[index].QuestionInfo.WrongAnswer2;
            AnswerText3 = _exam.Questions[index].QuestionInfo.CorrectAnswer0;*/
        }

        public string QuestionText { get; set; }

        public string AnswerText0 { get; set; }

        public string AnswerText1 { get; set; }

        public string AnswerText2 { get; set; }

        public string AnswerText3 { get; set; }
        #endregion



        private Exam _exam;

        public ICommand ExitButtonClick => new RelayCommand((sender) =>
        {
            Navigation.StackPop();
        });

        public ICommand NextButtonClicked => new RelayCommand((sender) =>
        {
            Index++;
        });
    }
}
