using ExamSystem.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ExamSystem.MVVM.ViewModel
{
    public class LoginScreenRegisterPanelViewModel :ObservableObject, ILocalizable
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

        private string _usernameTextBoxText;

        public string UsernameTextBoxText
        {
            get { return _usernameTextBoxText; }
            set { _usernameTextBoxText = value;
                NotifyPropertyChanged();
            }
        }

        private string _passwordTextBoxText;

        public string PasswordTextBoxText
        {
            get { return _passwordTextBoxText; }
            set
            {
                _passwordTextBoxText = value;
                NotifyPropertyChanged();

            }
        }

        private string _emailTextBoxText;

        public string EmailTextBoxText
        {
            get { return _emailTextBoxText; }
            set { _emailTextBoxText = value;
                NotifyPropertyChanged();
            }
        }

        private string _nameSurnameTextBoxText;

        public string NameSurnameTextBoxText
        {
            get { return _nameSurnameTextBoxText; }
            set { _nameSurnameTextBoxText = value;
                NotifyPropertyChanged();
            }
        }

        private string _registerButtonText;

        public string RegisterButtonText
        {
            get { return _registerButtonText; }
            set { _registerButtonText = value;
                NotifyPropertyChanged();
            }
        }
        private string _backText;

        public string BackText
        {
            get { return _backText; }
            set { _backText = value;
                NotifyPropertyChanged();
            }

        }



        public LoginScreenRegisterPanelViewModel()
        {
            _localizationMap = Localization.GetDefaultDictionary();
            UsernameTextBoxText = _localizationMap["UsernameTextBoxText"];
            PasswordTextBoxText = _localizationMap["PasswordTextBoxText"];
            EmailTextBoxText = _localizationMap["EmailTextBoxText"];
            NameSurnameTextBoxText = _localizationMap["NameSurnameTextBoxText"];
            RegisterButtonText = _localizationMap["RegisterButtonText"];
            BackText = _localizationMap["BackText"];
        }

       
        public LoginScreenRegisterPanelViewModel(ReadOnlyDictionary<string,string> localization)
        {
            _localizationMap = localization;
        }

    }
}
