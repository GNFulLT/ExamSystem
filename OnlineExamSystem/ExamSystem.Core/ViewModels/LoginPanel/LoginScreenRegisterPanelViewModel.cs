using ExamSystem.Core.SubModels;
using ExamSystem.Core.Utilities.Localization;
using ExamSystem.Core.Utilities.NavigationSource;
using ExamSystem.Core.Utilities.Services.AuthenticationServices;
using ExamSystem.Core.Utilities.ValidationRules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows.Input;

namespace ExamSystem.Core.ViewModels.LoginPanel
{
    public class LoginScreenRegisterPanelViewModel : ViewModel
    {
        public static Type Parent;

        public LoginScreenRegisterPanelViewModel()
        {
            
            Localization.SetDefaultLocalization(this);
        }

        #region Privates
        private bool isRegisterExecuting = false;

        private double globalTimerInterval = 1000;
        #endregion

        #region Timers and TimersEnabledMethods
        Timer t1 = new Timer();
        private void ShowNameSurnameHelperText(string s)
        {
            CurrentNameSurnameHelperText = s;
            if (t1.Enabled)
                t1.Stop();
            t1.Elapsed += t1_Tick;
            t1.Interval = globalTimerInterval;
            t1.Start();
        }
        Timer t2 = new Timer();
        private void ShowEmailHelperText(string s)
        {
            CurrentEmailHelperText = s;
            if (t2.Enabled)
                t2.Stop();
            t2.Elapsed += t2_Tick;
            t2.Interval = globalTimerInterval;
            t2.Start();
        }
        Timer t3 = new Timer();
        private void ShowUsernameHelperText(string s)
        {
            CurrentUsernameHelperText = s;
            if (t3.Enabled)
                t3.Stop();
            t3.Elapsed += t3_Tick;
            t3.Interval = globalTimerInterval;
            t3.Start();
        }
        Timer t4 = new Timer();
        private void ShowPasswordHelperText(string s)
        {
            CurrentPasswordHelperText = s;
            if (t4.Enabled)
                t4.Stop();
            t4.Elapsed += t4_Tick;
            t4.Interval = globalTimerInterval;
            t4.Start();
        }
        #endregion

        #region Timer Tick Methods
        public void t1_Tick(object sender, EventArgs e)
        {
            CurrentNameSurnameHelperText = string.Empty;
        }
        public void t2_Tick(object sender, EventArgs e)
        {
            CurrentEmailHelperText = string.Empty;
        }
        public void t3_Tick(object sender, EventArgs e)
        {
            CurrentUsernameHelperText = string.Empty;
        }
        public void t4_Tick(object sender, EventArgs e)
        {
            CurrentPasswordHelperText = string.Empty;
        }
        #endregion

        #region Properties

        public string NameSurnameTextBoxText { get; set; }

        public string EmailTextBoxText { get; set; }

        public string UsernameTextBoxText { get; set; }
        
        public string PasswordTextBoxText { get; set; }

        public string CurrentNameSurnameHelperText { get; set; }

        public string CurrentEmailHelperText { get; set; }

        public string CurrentUsernameHelperText { get; set; }

        public string CurrentPasswordHelperText { get; set; }

        public bool IsCycleShow { get; set; }
        #endregion

        #region LocalizableProperties
        [LocalizableProperty]
        public string NameSurnameHintText { get; set; }

        [LocalizableProperty]
        public string EmailHintText { get; set; }

        [LocalizableProperty]
        public string UsernameHintText { get; set; }

        [LocalizableProperty]
        public string PasswordHintText { get; set; }

        [LocalizableProperty]
        public string BackText { get; set; }

        [LocalizableProperty]
        public string RegisterText { get; set; }

        [LocalizableProperty]
        public string TextBoxCanNotBeEmptyText { get; set; }

        [LocalizableProperty]
        public string NameSurnameHelperText { get; set; }

        [LocalizableProperty]
        public string EmailHelperText { get; set; }

        [LocalizableProperty]
        public string EmailHelperText2 { get; set; }

        [LocalizableProperty]
        public string UsernameHelperText { get; set; }

        [LocalizableProperty]
        public string PasswordHelperText { get; set; }
        #endregion


        #region Commands
        public ICommand BackLabelClickedCommand => new RelayCommand((sender) =>
        {

            BackLabelClicked?.Invoke(sender);
        });
        public ICommand RegisterButtonClickedCommand => new RelayCommand(async (sender) =>
        {
            if (isRegisterExecuting)
                return;
            isRegisterExecuting = true;
            IsCycleShow = true;
            //Register Process
            CanNotBeEmptyValidationRule rule = new CanNotBeEmptyValidationRule();
            var resNameSurname = rule.Validate(NameSurnameTextBoxText);
            var resEmail = rule.Validate(EmailTextBoxText);
            var resUsername = rule.Validate(UsernameTextBoxText);
            var resPassword = rule.Validate(PasswordTextBoxText);
            bool canTryRegister = true;
            string[] name_surname;
            //Checks is any box empty
            if (!resNameSurname.IsValid)
            {
                ShowNameSurnameHelperText(TextBoxCanNotBeEmptyText);
                canTryRegister = false;
            }
            else
            {
                name_surname = NameSurnameTextBoxText.Split(' ');
                if (name_surname.Length < 2)
                {
                    ShowNameSurnameHelperText(NameSurnameHelperText);
                    canTryRegister = false;
                }
            }
            if (!resEmail.IsValid)
            {
                ShowEmailHelperText(TextBoxCanNotBeEmptyText);
                canTryRegister = false;
            }
            if (!resUsername.IsValid)
            {
                ShowUsernameHelperText(TextBoxCanNotBeEmptyText);
                canTryRegister = false;
            }
            if (!resPassword.IsValid)
            {
                ShowPasswordHelperText(TextBoxCanNotBeEmptyText);
                canTryRegister = false;
            }
            //If any textbox is not empty
            if (canTryRegister)
            {
                //Check for validation rules, are inputs valid
                bool canRegister = true;
                EmailValidationRule emailValidationRule = new EmailValidationRule();
                PasswordValidationRule passwordValidationRule = new PasswordValidationRule();
                var resPass = passwordValidationRule.Validate(PasswordTextBoxText);
                var resEmailRegex = emailValidationRule.Validate(EmailTextBoxText);
                if (!resEmailRegex.IsValid)
                {
                    ShowEmailHelperText(EmailHelperText);
                    canRegister = false;
                }
                if (!resPass.IsValid)
                {
                    ShowPasswordHelperText(PasswordHelperText+passwordValidationRule.MIN_LENGTH.ToString());
                    canRegister = false;
                }
                //Register Process
                if (canRegister)
                {
                    IAuthenticationService authentication = Resolver.Resolve<IAuthenticationService>();
                    name_surname = NameSurnameTextBoxText.Split(' ');
                    string surname = "";
                    for (int i = 1; i < name_surname.Length; i++)
                    {
                        surname += name_surname[i];
                    }
                    AccountInfo accInfo = new AccountInfo()
                    {
                        Name = name_surname[0],
                        Surname = surname
                    };
                    bool couldRegister = true;
                    RegistrationResult res = await authentication.Register(EmailTextBoxText, UsernameTextBoxText, PasswordTextBoxText, accInfo);
                    if ((res & RegistrationResult.EmailAlreadyExists) == RegistrationResult.EmailAlreadyExists)
                    {
                        ShowEmailHelperText(EmailHelperText2);
                        couldRegister = false;
                    }
                    if ((res & RegistrationResult.UsernameAlreadyExists) == RegistrationResult.UsernameAlreadyExists)
                    {
                        ShowUsernameHelperText(UsernameHelperText);
                        couldRegister = false;
                    }
                    if (couldRegister)
                    {
                        //Clear inside and invoke the event
                        NameSurnameTextBoxText = string.Empty;
                        EmailTextBoxText = string.Empty;
                        UsernameTextBoxText = string.Empty;
                        PasswordTextBoxText = string.Empty;

                        RegisteredSuccesfully?.Invoke(sender);
                    }
                }
               
            }
            

            //Finish
            IsCycleShow = false;
            isRegisterExecuting = false;
        });
        #endregion

        #region Events
        public event Action<object> BackLabelClicked;
        public event Action<object> RegisteredSuccesfully;

        #endregion
    }
}
