using ExamSystem.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.MVVM.ViewModel
{
    public class LoginScreenForgotEmailPanelViewModel :ObservableObject,ILocalizable
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

        private string _forgotEmailButtonText;

        public string ForgotEmailButtonText
        {
            get { return _forgotEmailButtonText; }
            set { _forgotEmailButtonText = value;
                NotifyPropertyChanged();
            }
        }
        private string _backText;

        public string BackText
        {
            get { return _backText; }
            set { _backText = value; }
        }

        public LoginScreenForgotEmailPanelViewModel()
        {
            _localizationMap = Localization.GetDefaultDictionary();
            ForgotEmailButtonText = _localizationMap["ForgotEmailButtonText"];
            BackText = _localizationMap["BackText"];
        }
        public LoginScreenForgotEmailPanelViewModel(ReadOnlyDictionary<string, string> localization)
        {
            _localizationMap = localization;
        }
    }
}
