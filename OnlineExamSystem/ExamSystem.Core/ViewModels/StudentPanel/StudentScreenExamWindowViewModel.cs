using ExamSystem.Core.Models;
using ExamSystem.Core.Utilities.NavigationSource;
using ExamSystem.Core.Utilities.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamSystem.Core.ViewModels.StudentPanel
{
    public class StudentScreenExamWindowViewModel : ViewModel
    {
        public static Type Parent;

        private Dictionary<int, int> GivenAnswers = new Dictionary<int, int>();


        private Dictionary<string, int> HashChoises = new Dictionary<string, int>();
        public StudentScreenExamWindowViewModel(Exam exam)
        {
            _exam = exam;

            exam.LoadQuestionInfos();

            QuestionText = "";
            AnswerText0 = "";
            AnswerText1 = "";
            AnswerText2 = "";
            AnswerText3 = "";

            HashChoises.Add(nameof(ChoiceA), 0);
            HashChoises.Add(nameof(ChoiceB), 1);
            HashChoises.Add(nameof(ChoiceC), 2);
            HashChoises.Add(nameof(ChoiceD), 3);

            Index = 0;
        }

        #region Properties
        public int _index;


        public int Index { get => _index; set {
                if (value > _exam.Questions.Count - 1)
                    value = _exam.Questions.Count - 1;
                else if (value < 0)
                    value = 0;
                 _index = value;
                NotifyPropertyChanged();
                OnIndexChanged(_index);
            
            } }

        private void OnIndexChanged(int index)
        {
            MakeAllChoiceFalse();
            MakeChoiceTrueByIndex(index);
            Question q = _exam.Questions[index];
            QuestionText = _exam.Questions[index].QuestionInfo.QuestionText;
            AnswerText0 = _exam.Questions[index].QuestionInfo.WrongAnswer0;
            AnswerText1 = _exam.Questions[index].QuestionInfo.WrongAnswer1;
            AnswerText2 = _exam.Questions[index].QuestionInfo.WrongAnswer2;
            AnswerText3 = _exam.Questions[index].QuestionInfo.CorrectAnswer0;
            StudentQuestionInfo info = StudentProvider.GetStudentQuestionInfo(q);
            if(info is object)
            {
                if (info.StudentSubQuestionInfo.RightSolveCount > 0)
                    Ratio = StudentProvider.GetStudentQuestionInfo(q).StudentSubQuestionInfo.GetLastMeasureInfo();
                else
                    Ratio = 0;
            }
            else
            {
                Ratio = 0;
            }
            
        }

        public string QuestionText { get; set; }

        public string AnswerText0 { get; set; }

        public string AnswerText1 { get; set; }

        public string AnswerText2 { get; set; }

        public string AnswerText3 { get; set; }

        public int Ratio { get; set; }

        public string RatioText => $"{Ratio}%";

        private bool _choiceA;
        public bool ChoiceA { get => _choiceA; set { _choiceA = value; NotifyPropertyChanged(); if (value) { OnChoiceBecomeTrue(_index,HashChoises.GetValueOrDefault(nameof(ChoiceA))); } } }

        private bool _choiceB;
        public bool ChoiceB { get => _choiceB; set { _choiceB = value; NotifyPropertyChanged(); if (value) { OnChoiceBecomeTrue(_index, HashChoises.GetValueOrDefault(nameof(ChoiceB))); } } }

        private bool _choiceC;
        public bool ChoiceC { get => _choiceC; set { _choiceC = value; NotifyPropertyChanged(); if (value) { OnChoiceBecomeTrue(_index, HashChoises.GetValueOrDefault(nameof(ChoiceC))); } } }

        private bool _choiceD;
        public bool ChoiceD { get => _choiceD; set { _choiceD = value; NotifyPropertyChanged(); if (value) { OnChoiceBecomeTrue(_index, HashChoises.GetValueOrDefault(nameof(ChoiceD))); } } }

        public string IndexText => $"{Index+1}/{_exam.Questions.Count}";

        #endregion



        private Exam _exam;

        #region Commands
        public ICommand ExitButtonClick => new RelayCommand((sender) =>
        {
            Navigation.StackPop();
        });

        public ICommand NextButtonClickedCommand => new RelayCommand((sender) =>
        {
            Index++;
        });
        public ICommand BackButtonClickedCommand => new RelayCommand((sender) =>
        {
            Index--;
        });

        public ICommand FinisButtonClickedCommand => new RelayCommand(async (sender) =>
         {
             ExamSolved?.Invoke(_exam,GivenAnswers);
         });
        #endregion


        #region Events
        public event Action<Exam, Dictionary<int, int>> ExamSolved;
        #endregion

        #region PrivateMethods
        private void MakeAllChoiceFalse()
        {
            ChoiceA = false;
            ChoiceB = false;
            ChoiceC = false;
            ChoiceD = false;
        }

        private void MakeChoiceTrueByIndex(int index)
        {
            bool isExist = GivenAnswers.TryGetValue(index, out int val);
            if (isExist)
            {
                switch (val)
                {
                    case 0:
                        ChoiceA = true;
                        break;
                    case 1:
                        ChoiceB = true;
                        break;
                    case 2:
                        ChoiceC = true;
                        break;
                    case 3:
                        ChoiceD = true;
                        break;
                    default:
                        throw new Exception("Unexpected value in choices");
                        
                }
            }

        }

        public void OnChoiceBecomeTrue(int index,int choiseIndex)
        {
            if(GivenAnswers.TryGetValue(index,out int val))
            {
                GivenAnswers[index] = choiseIndex;
            }
            else
            {
                GivenAnswers.Add(index, choiseIndex);
            }
        }
        #endregion
    }
}
