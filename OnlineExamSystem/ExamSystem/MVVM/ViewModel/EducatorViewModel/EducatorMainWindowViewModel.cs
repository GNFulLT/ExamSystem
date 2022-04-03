using ExamSystem.Core;
using ExamSystem.MVVM.View.EducatorView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.MVVM.ViewModel.EducatorViewModel
{
    public class EducatorMainWindowViewModel : ObservableObject, ILocalizable
    {
        public ReadOnlyDictionary<string, string> LocalizationMap => throw new NotImplementedException();

        ObservableCollection<QuestionPanel> _questionCollection = new ObservableCollection<QuestionPanel>();

        public ObservableCollection<QuestionPanel> QuestionCollection { get { return _questionCollection; } set
            {
                _questionCollection = value;
                NotifyPropertyChanged();


            } }
        public EducatorMainWindowViewModel()
        {
            _questionCollection.CollectionChanged += (_questionCollection, e) =>
            {
                NotifyPropertyChanged();
            };
        }

       
    }
}
