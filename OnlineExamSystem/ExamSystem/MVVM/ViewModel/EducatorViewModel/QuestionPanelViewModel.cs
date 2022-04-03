using ExamSystem.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.MVVM.ViewModel.EducatorViewModel
{
    public class QuestionPanelViewModel : ObservableObject, ILocalizable
    {
        private ReadOnlyDictionary<string, string> _localizationMap;

        public ReadOnlyDictionary<string, string> LocalizationMap
        {
            get => this._localizationMap;
            set
            {
                this._localizationMap = value;
                NotifyPropertyChanged();
            }
        }

        private string _unitText;

        public string UnitText
        {
            get { return _unitText; }
            set
            {
                _unitText = value;
                NotifyPropertyChanged();
            }
        }


        public QuestionPanelViewModel()
        {
            _localizationMap = Localization.GetDefaultDictionary();
        }
    }
}
