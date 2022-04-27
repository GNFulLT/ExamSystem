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
            QuestionWindowViewModel = new EducatorPanelQuestionWindowViewModel();

            QuestionWindowViewModel.ExitButtonClicked += OnQuestionWindowClosed;

            QuestionWindowView = Activator.CreateInstance(EducatorPanelQuestionWindowViewModel.Parent, QuestionWindowViewModel);

           
        }

        #region NotBindedProperties
        public EducatorPanelQuestionWindowViewModel QuestionWindowViewModel { get; set; }

        public object QuestionWindowView { get; set; }
        #endregion
        #region Command
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
