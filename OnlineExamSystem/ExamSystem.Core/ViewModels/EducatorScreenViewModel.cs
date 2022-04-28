using ExamSystem.Core.Utilities.Localization;
using ExamSystem.Core.Utilities.NavigationSource;
using ExamSystem.Core.ViewModels.EducatorPanel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ExamSystem.Core.ViewModels
{
    public class EducatorScreenViewModel : ViewModel
    {
        public static Type Parent;


        public EducatorScreenViewModel()
        {
            Localization.SetDefaultLocalization(this);
            QuestionWindowViewModel = new EducatorPanelQuestionWindowViewModel();

            QuestionWindowViewModel.ExitButtonClicked += OnQuestionWindowClosed;

            QuestionWindowView = Activator.CreateInstance(EducatorPanelQuestionWindowViewModel.Parent, QuestionWindowViewModel);
        }

        #region Properties
        public int Count { get; set; }

        public int CountPerPage { get; set; }   

        public int Current { get; set; }

        #endregion

        #region LocalizableProperties
        [LocalizableProperty]
        public string CountText { get; set; }

        [LocalizableProperty]
        public string JumpText { get; set; }
        #endregion

        #region NotBindedProperties
        public EducatorPanelQuestionWindowViewModel QuestionWindowViewModel { get; set; }

        public object QuestionWindowView { get; set; }
        #endregion

        #region Commands
        public ICommand CreateQuestionClickedCommand => new RelayCommand((sender) =>
        {
           if(!Navigation.IsStackPushed(QuestionWindowView)){
                Navigation.StackPush(QuestionWindowView, true);
            }
        });
        #endregion

        #region MethodsForEvents
        public void OnQuestionWindowClosed()
        {
            Navigation.StackPop();
        }
        public void OnQuestionCreated(object sender)
        {

        }
        #endregion
    }
}
