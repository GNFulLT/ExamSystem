using ExamSystem.Core;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Animation;

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
        


        private string _textBoxCanNotBeEmpty;

        public string TextBoxCanNotBeEmptyText
        {
            get { return _textBoxCanNotBeEmpty; }
            set
            {
                _textBoxCanNotBeEmpty = value;
                NotifyPropertyChanged();
            }
        }

        private string _emailAlreadyInUseText;

        public string EmailAlreadyInUseText
        {
            get { return _emailAlreadyInUseText; }
            set { _emailAlreadyInUseText = value;
                NotifyPropertyChanged();
            }
        }

        private string _usernameAlreadyInUseText;

        public string UsernameAlreadyInUseText
        {
            get { return _usernameAlreadyInUseText; }
            set { _usernameAlreadyInUseText = value;
                NotifyPropertyChanged();
            }
        }


        private string _nameSurnameBoxErrorText;

        public string NameSurnameBoxErrorText
        {
            get { return _nameSurnameBoxErrorText; }
            set { _nameSurnameBoxErrorText = value;
                NotifyPropertyChanged();
            }
        }

        private string _emailBoxErrorText;

        public string EmailBoxErrorText
        {
            get { return _emailBoxErrorText; }
            set
            {
                _emailBoxErrorText = value;
                NotifyPropertyChanged();
            }
        }
        private string _usernameBoxErrorText;

        public string UsernameBoxErrorText
        {
            get { return _usernameBoxErrorText; }
            set
            {
                _usernameBoxErrorText = value;
                NotifyPropertyChanged();
            }
        }
        private string _passwordBoxErrorText;

        public string PasswordBoxErrorText
        {
            get { return _passwordBoxErrorText; }
            set
            {
                _passwordBoxErrorText = value;
                NotifyPropertyChanged();
            }
        }
        private string _emailRegexText;

        public string EmailRegexInvalid
        {
            get { return _emailRegexText; }
            set { _emailRegexText = value;
                NotifyPropertyChanged();
            }
        }
        private string _passwordInvalid;

        public string PasswordInvalid
        {
            get { return _passwordInvalid; }
            set { _passwordInvalid = value; }
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
            TextBoxCanNotBeEmptyText = _localizationMap["TextBoxCanNotBeEmptyText"];
            EmailAlreadyInUseText = _localizationMap["EmailAlreadyInUseText"];
            UsernameAlreadyInUseText = _localizationMap["UsernameAlreadyInUseText"];
            EmailRegexInvalid = _localizationMap["EmailRegexInvalid"];
            PasswordInvalid = _localizationMap["PasswordInvalid"];
        }

       
        public LoginScreenRegisterPanelViewModel(ReadOnlyDictionary<string,string> localization)
        {
            _localizationMap = localization;
        }
        Timer t1 = new Timer();
        public void UsernameTextBoxCanNotBeEmpty()
        {
            if (t1.Enabled)
                t1.Stop();
            t1.Interval = 1000;
            t1.Tick += UsernameTextBoxHint_Tick;
            UsernameBoxErrorText = TextBoxCanNotBeEmptyText;
            t1.Start();
        }
        private  void UsernameTextBoxHint_Tick(object sender, EventArgs e)
        {
            UsernameBoxErrorText = "";
            t1.Stop();
        }
        Timer t2 = new Timer();
        public void NameSurnameTextBoxCanNotBeEmpty()
        {
            if (t2.Enabled)
                t2.Stop();
            t2.Interval = 1000;
            t2.Tick += NameSurnameTextBoxHint_Tick;
            NameSurnameBoxErrorText = TextBoxCanNotBeEmptyText;
            t2.Start();
        }
        private void NameSurnameTextBoxHint_Tick(object sender, EventArgs e)
        {
            NameSurnameBoxErrorText = "";
            t2.Stop();
        }
        Timer t3 = new Timer();
        public void EmailTextBoxCanNotBeEmpty()
        {
            if (t3.Enabled)
                t3.Stop();
            t3.Interval = 1000;
            t3.Tick += EmailTextBoxHint_Tick;
            EmailBoxErrorText = TextBoxCanNotBeEmptyText;
            t3.Start();
        }
        private void EmailTextBoxHint_Tick(object sender, EventArgs e)
        {
            EmailBoxErrorText = "";
            t3.Stop();
        }
        Timer t4 = new Timer();
        public void PasswordTextBoxCanNotBeEmpty()
        {
            if (t4.Enabled)
                t4.Stop();
            t4.Interval = 1000;
            t4.Tick += PasswordTextBoxHint_Tick;
            PasswordBoxErrorText = TextBoxCanNotBeEmptyText;
            t4.Start();
        }
        private void PasswordTextBoxHint_Tick(object sender, EventArgs e)
        {
            PasswordBoxErrorText = "";
            t4.Stop();
        }

        Timer t5 = new Timer();
        public void EmailIsNotValid()
        {
            if (t5.Enabled)
                t5.Stop();
            t5.Interval = 1000;
            t5.Tick += EmailRegex_Tick;
            EmailBoxErrorText = EmailRegexInvalid;
            t5.Start();
        }
        private void EmailRegex_Tick(object sender, EventArgs e)
        {
            EmailBoxErrorText = "";
            t5.Stop();
        }

        Timer t6 = new Timer();
        public void PasswordIsNotValid(int min_length)
        {
            if (t6.Enabled)
                t6.Stop();
            t6.Interval = 1000;
            t6.Tick += PasswordInvalid_Tick;
            PasswordBoxErrorText = PasswordInvalid+$" Minimum Length : {min_length}";
            t6.Start();
        }
        private void PasswordInvalid_Tick(object sender, EventArgs e)
        {
            PasswordBoxErrorText = "";
            t6.Stop();
        }
        Timer t7 = new Timer();
        public void UsernameAlreadyInUse()
        {
            if (t7.Enabled)
                t7.Stop();
            t7.Interval = 1000;
            t7.Tick += UsernameAlreadyInUse_Tick;
            UsernameBoxErrorText = UsernameAlreadyInUseText;
            t7.Start();
        }
        private void UsernameAlreadyInUse_Tick(object sender, EventArgs e)
        {
            UsernameBoxErrorText = "";
            t7.Stop();
        }
        Timer t8 = new Timer();
        public void EmailAlreadyInUse()
        {
            if (t8.Enabled)
             t8.Stop();
            t8.Interval = 1000;
            t8.Tick += EmaileAlreadyInUse_Tick;
            EmailBoxErrorText = EmailAlreadyInUseText;
            t8.Start();
        }
        private void EmaileAlreadyInUse_Tick(object sender, EventArgs e)
        {
            EmailBoxErrorText = "";
            t8.Stop();
        }
    }
}
