using ExamSystem.Core.Models;
using ExamSystem.Core.Utilities.Localization;
using ExamSystem.Core.Utilities.Providers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace ExamSystem.Core.ViewModels.EducatorPanel
{
    public class EducatorPanelQuestionWindowViewModel : ViewModel
    {
        public static Type Parent;

        public EducatorPanelQuestionWindowViewModel()
        {
            UnitSectionProvider.InitializeMaps();
            Localization.SetDefaultLocalization(this);
            LessonMap = UnitSectionProvider.LessonMap;

           
        }

        #region Properties
        public string QuestionText { get; set; }
        
        public string WrongAnswer0 { get; set; }

        public string WrongAnswer1 { get; set; }

        public string WrongAnswer2 { get; set; }
        
        public string CorrectAnswer0 { get; set; }

        public string ImageUri { get; set; }

        public ReadOnlyDictionary<string, Lesson> LessonMap { get; set; }

        public ReadOnlyDictionary<string, Unit> UnitMap { get; set; }

        private Lesson _lesson;

        public Lesson Lesson
        {
            get { return _lesson; }
            set
            {
                _lesson = value;
                NotifyPropertyChanged();
                OnLessonChange(_lesson);
            }
        }
        private Unit _unit;

        public Unit Unit
        {
            get { return _unit; }
            set
            {
                _unit = value;
                NotifyPropertyChanged();
                OnUnitChange(_unit);
            }
        }

        private Section _section;

        public Section Section
        {
            get { return _section; }
            set
            {
                _section = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region LocalizableProperties
        [LocalizableProperty]
        public string ConfirmQuestionTextButtonText { get; set; }

        [LocalizableProperty]
        public string AddPictureTextBoxText { get; set; }

        [LocalizableProperty]
        public string WrongAnswersHeaderText { get; set; }

        [LocalizableProperty]
        public string CorrectAnswerHeaderText { get; set; }
        #endregion

        #region Private Methods
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
            if (unit == null)
            {
                return;
            }
        }
        #endregion

        #region Commands
        public ICommand ExitButtonClickedCommand => new RelayCommand((sender) =>
        {
            ExitButtonClicked?.Invoke();
        });
        #endregion

        #region Events
        public event Action ExitButtonClicked;

        public event Action<Question> QuestionCreated;
        #endregion
    }
}
