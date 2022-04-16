using ExamSystem.Core;
using ExamSystem.MVVM.Model.Question;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamSystem.MVVM.ViewModel.EducatorViewModel
{
    public class EducatorQuestionWindowViewModel : ObservableObject
    {
        private ICommand _clearInsideCommand;

        public ICommand ClearInsideCommand
        {
            get { return _clearInsideCommand; }
            set { _clearInsideCommand = value;
                NotifyPropertyChanged();
            }
        }

        private ICommand _createQuestionCommand;

        public ICommand CreateQuestionCommand
        {
            get { return _createQuestionCommand; }
            set { _createQuestionCommand = value;
                NotifyPropertyChanged();
            }
        }


        private string _questionText;

        public string QuestionText
        {
            get { return _questionText; }
            set { _questionText = value;
                NotifyPropertyChanged();
            }
        }

        private string _wrongAnswer0;

        public string WrongAnswer0
        {
            get { return _wrongAnswer0; }
            set { _wrongAnswer0 = value;
                NotifyPropertyChanged();
            }
        }

        private string _wrongAnswer1;

        public string WrongAnswer1
        {
            get { return _wrongAnswer1; }
            set
            {
                _wrongAnswer1 = value;
                NotifyPropertyChanged();
            }
        }

        private string _wrongAnswer2;

        public string WrongAnswer2
        {
            get { return _wrongAnswer2; }
            set
            {
                _wrongAnswer2 = value;
                NotifyPropertyChanged();
            }
        }

        private string _correctAnswer0;

        public string CorrectAnswer0
        {
            get { return _correctAnswer0; }
            set
            {
                _correctAnswer0 = value;
                NotifyPropertyChanged();
            }
        }

        private Lesson _lesson;

        public Lesson Lesson
        {
            get { return _lesson; }
            set { _lesson = value;
                NotifyPropertyChanged();
                OnLessonChange(_lesson);
            }
        }
        private Unit _unit;
            
        public Unit Unit
        {
            get { return _unit; }
            set { _unit = value;
                NotifyPropertyChanged();
                OnUnitChange(_unit);
            }
        }

        private Section _section;

        public Section Section
        {
            get { return _section; }
            set { _section = value;
                NotifyPropertyChanged();
            }
        }
       
        private string _imageUri;

        public string ImageUri
        {
            get { return _imageUri; }
            set { _imageUri = value;
                NotifyPropertyChanged();
            }
        }

        private ReadOnlyDictionary<string, Lesson> _lessonMap;

        public ReadOnlyDictionary<string, Lesson> LessonMap
        {
            get { return _lessonMap; }
            set { _lessonMap = value;
                NotifyPropertyChanged();      
            }
        }

        private ReadOnlyDictionary<string, Unit> _unitMap;

        public ReadOnlyDictionary<string, Unit> UnitMap
        {
            get { return _unitMap; }
            set
            {
                _unitMap = value;
                NotifyPropertyChanged();
            }
        }

        public EducatorQuestionWindowViewModel()
        {
            ClearInsideCommand = new RelayCommand(OnClearInside);
            CreateQuestionCommand = new RelayCommand(OnCreatedQuestion);
            if (LicenseUsageMode.Designtime != LicenseManager.UsageMode)
            {
                UnitSectionProvider.InitializeMaps();
                LessonMap = UnitSectionProvider.LessonMap;
            }


        }

        private void OnLessonChange(Lesson lesson)
        {
            if (lesson == null)
            {
                UnitMap = null;
                return;
            }
            UnitMap = UnitSectionProvider.GetUnitDictionary(Lesson);
        }

        private void OnUnitChange(Unit unit)
        {
            if(unit == null)
            {
                return;
            }
        }
        


        public void OnClearInside(object sender)
        {
            QuestionText = string.Empty;
            WrongAnswer0 = string.Empty;
            WrongAnswer1 = string.Empty;
            WrongAnswer2 = string.Empty;
            CorrectAnswer0 = string.Empty;
            Lesson = null;
            Unit = null;
            Section = null;
            ImageUri = string.Empty;

        }
        public void OnCreatedQuestion(object sender)
        {

        }

    }
}
