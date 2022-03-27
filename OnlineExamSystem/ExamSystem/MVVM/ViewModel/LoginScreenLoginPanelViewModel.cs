using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ExamSystem.Core;
namespace ExamSystem.MVVM.ViewModel
{
    public class LoginScreenLoginPanelViewModel : ObservableObject, ILocalizable
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
        private string _loginButtonText;


        public string LoginButtonText
        {
            get { return _loginButtonText; }
            set { _loginButtonText = value; NotifyPropertyChanged(); }

        }
        private string _usernameTextBoxText;

        public string UsernameTextBoxText
        {
            get { return _usernameTextBoxText; }
            set
            {
                _usernameTextBoxText = value;
                NotifyPropertyChanged();
            }
        }
        private string _passwordTextBoxText;

        public string PasswordTextBoxText
        {
            get { return _passwordTextBoxText; }
            set { _passwordTextBoxText = value;
                NotifyPropertyChanged();

            }
        }
        private string _createAccountText;

        public string CreateAccountText
        {
            get { return _createAccountText; }
            set { _createAccountText = value;
                NotifyPropertyChanged();
            }
        }

        public LoginScreenLoginPanelViewModel()
        {
            _localizationMap = Localization.GetDefaultDictionary();
            LoginButtonText = _localizationMap["LoginButtonText"];
            UsernameTextBoxText = _localizationMap["UsernameTextBoxText"];
            PasswordTextBoxText = _localizationMap["PasswordTextBoxText"];
            CreateAccountText = _localizationMap["CreateAccountText"];
        }

        
        public LoginScreenLoginPanelViewModel(ReadOnlyDictionary<string, string> localization)
        {
                _localizationMap = localization;
        }
       
    }
}
