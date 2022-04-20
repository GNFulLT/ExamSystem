using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystem.Core;

namespace ExamSystem.MVVM.ViewModel
{
    class LoadingContentBarViewModel : ObservableObject,ILocalizable
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set {
                _message = value;
                NotifyPropertyChanged();
            }
        }
      

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
        public LoadingContentBarViewModel()
        {
            
        }
    }
}
