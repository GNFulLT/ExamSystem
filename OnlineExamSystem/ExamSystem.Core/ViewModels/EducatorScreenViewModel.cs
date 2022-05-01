using ExamSystem.Core.Models;
using ExamSystem.Core.Utilities.Localization;
using ExamSystem.Core.Utilities.NavigationSource;
using ExamSystem.Core.Utilities.Providers;
using ExamSystem.Core.Utilities.Services.SubServices.QuestionServices;
using ExamSystem.Core.ViewModels.EducatorPanel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

            

            QuestionCollection = new ObservableCollection<object>();

            UnseenQuestions = new ObservableCollection<object>();

            QuestionWindowViewModel = new EducatorPanelQuestionWindowViewModel();

            QuestionWindowViewModel.ExitButtonClicked += OnQuestionWindowClosed;

            QuestionWindowViewModel.QuestionCreated += OnQuestionCreated;

            QuestionWindowView = Activator.CreateInstance(EducatorPanelQuestionWindowViewModel.Parent, QuestionWindowViewModel);


            LoadQuestions(QuestionProvider.QuestionDateMap);

            _service = new QuestionService();

            NameSurname = AccountProvider.LoginedAccount._AccountInfo.Name + " " + AccountProvider.LoginedAccount._AccountInfo.Surname;
        }

        #region Properties

        public string NameSurname { get; set; }

        private int _count = 0;

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                NotifyPropertyChanged();
                RefreshPage();
            }
        }

        private int _current = 1;

        public int Current
        {
            get { return _current; }
            set
            {
                _current = value;
                NotifyPropertyChanged();
                RefreshPage();
            }
        }

        private int _countPerPage = 5;

        public int CountPerPage
        {
            get { return _countPerPage; }
            set
            {
                _countPerPage = value;
                NotifyPropertyChanged();
                RefreshPage();
            }
        }

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

        public ObservableCollection<object> QuestionCollection { get; set; }

        public ObservableCollection<object> UnseenQuestions { get; set; }

        private QuestionService _service;
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
        public void OnQuestionCreated(Question question)
        {
            _service.Create(question);
            AddQuestion(question);
            OnQuestionWindowClosed();
        }
        #endregion

        #region PrivateMethods
        private void RefreshPage()
        {
            UnseenQuestions.Clear();

            int min = (Count - 1 - CountPerPage);
            if(min < -1)
            {
                min = -1;
            }
            for (int i = Count - 1; i > min ; i--)
            {
                UnseenQuestions.Add(QuestionCollection[i]);
            }
        }

        private void LoadQuestions(List<Question> questions)
        {
            foreach(var question in questions)
            {
                AddQuestion(question);
            }
        }

        private void AddQuestion(Question question)
        {

            Type t = EducatorPanelQuestionViewModel.Parent;
            var model = new EducatorPanelQuestionViewModel(question);
            
            var view = Activator.CreateInstance(t, model);
            QuestionCollection.Add(view);

            Count++;

        }
        #endregion
    }
}
