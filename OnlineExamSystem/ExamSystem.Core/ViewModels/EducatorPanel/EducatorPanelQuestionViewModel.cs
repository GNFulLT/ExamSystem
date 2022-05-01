using ExamSystem.Core.Models;
using ExamSystem.Core.SubModels;
using ExamSystem.Core.Utilities.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Core.ViewModels.EducatorPanel
{
    public class EducatorPanelQuestionViewModel : ViewModel
    {
        public static Type Parent;

        public EducatorPanelQuestionViewModel(Question question)
        {
            Localization.SetDefaultLocalization(this);
            Question = question;
        }



        #region Properties
        public string LessonName { get; set; }

        public string UnitName { get; set; }

        public string SectionName { get; set; }

        public string Hard { get; set; }

        public string Summary { get; set; }
        #endregion

        #region LocalizableProperties
        [LocalizableProperty]
        public string LessonText { get; set; }
        [LocalizableProperty]
        public string UnitText { get; set; }
        [LocalizableProperty]
        public string SectionText { get; set; }
        [LocalizableProperty]
        public string HardText { get; set; }
        [LocalizableProperty]
        public string SummaryText { get; set; }
        #endregion
        #region NotBindedProperties
        Question _question;
        Question Question { get { return _question; }
            set { _question = value; OnQuestionChanged(_question); } }
        #endregion

        #region PrivateMethods
        private void OnQuestionChanged(Question question)
        {
            LessonName = question.Lesson.LessonName;

            UnitName = question.Unit.UnitName;

            SectionName = question.Section.SectionName;
            Hard = question.QuestionInfo.DifficultyMultiplier.ToString();

            Summary = question.QuestionInfo.QuestionText.Substring(0, Math.Min(10,question.QuestionInfo.QuestionText.Length));

        }
        #endregion
    }
}
