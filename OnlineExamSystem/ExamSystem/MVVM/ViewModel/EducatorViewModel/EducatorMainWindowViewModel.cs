using ExamSystem.Core;
using ExamSystem.MVVM.Model.Question;
using ExamSystem.MVVM.View.EducatorView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamSystem.MVVM.ViewModel.EducatorViewModel
{
    public class EducatorMainWindowViewModel : ObservableObject, ILocalizable
    {
        private ReadOnlyDictionary<string, string> _localization;


        public ReadOnlyDictionary<string, string> LocalizationMap
        {
            get { return _localization; }
            set { _localization = value; }
        }

        ObservableCollection<QuestionPanel> _questionCollection = new ObservableCollection<QuestionPanel>();

        public ObservableCollection<QuestionPanel> QuestionCollection { get { return _questionCollection; } set
            {
                _questionCollection = value;
                NotifyPropertyChanged();


            } }

        ObservableCollection<QuestionPanel> _unseenQuestions = new ObservableCollection<QuestionPanel>();

        public ObservableCollection<QuestionPanel> UnseenQuestions
        {
            get { return _unseenQuestions; }
            set
            {
                _unseenQuestions = value;
                NotifyPropertyChanged();


            }
        }

        private int _count = 0;

        public int Count
        {
            get { return _count; }
            set { _count = value;
                NotifyPropertyChanged();
                RefreshPage();
            }
        }

        private int _current = 1;

        public int Current
        {
            get { return _current; }
            set { _current = value;
                NotifyPropertyChanged();
                RefreshPage();
            }
        }

        private int _countPerPage = 5;

        public int CountPerPage
        {
            get { return _countPerPage; }
            set { _countPerPage = value;
                NotifyPropertyChanged();
                RefreshPage();
            }
        }

        private string _countText;

        public string CountText
        {
            get { return _countText; }
            set {
                _countText = value;
                NotifyPropertyChanged();
            
            }
        }

        private string _jumpText;

        public string JumpText
        {
            get { return _jumpText; }
            set { _jumpText = value;
                NotifyPropertyChanged();
            }
        }

        private ICommand _createQuestionClickCommand;

        public ICommand CreateQuestionClickCommand
        {
            get { return _createQuestionClickCommand; }
            set { _createQuestionClickCommand = value;
                NotifyPropertyChanged();
            
            }
        }

        private bool _isQuestionWindowOpen = false;

        public bool IsQuestionWindowOpen
        {
            get { return _isQuestionWindowOpen; }
            set{ _isQuestionWindowOpen = value; }
        }

        private EducatorQuestionWindow questionWindow = new EducatorQuestionWindow();

        public EducatorMainWindowViewModel()
        {
            _questionCollection.CollectionChanged += (_questionCollection, e) =>
            {
                NotifyPropertyChanged();
            };
            _unseenQuestions.CollectionChanged += (_unseenQuestions, e) =>
            {
                NotifyPropertyChanged();
            };
            LocalizationMap = Localization.GetDefaultDictionary();

            CountText = _localization["EW"+nameof(CountText)];
            JumpText = _localization["EW" + nameof(JumpText)];
            CreateQuestionClickCommand = new RelayCommand(OnCreateQuestionButtonClick);
            questionWindow.OnQuestionCreated += OnQuestionCreated;
        }

        private void OnCreateQuestionButtonClick(object sender)
        {
            if (IsQuestionWindowOpen)
                return;
            questionWindow.Show();
        }


        private void OnQuestionCreated(Question q)
        {
            //When Question Created 
            Question a = q;
        }

        private void RefreshPage()
        {
            UnseenQuestions.Clear();

            foreach(var item in QuestionCollection.Skip((Current - 1) * CountPerPage).Take(CountPerPage))
            {
                UnseenQuestions.Add(item);
            }
        }
       
    }
}
