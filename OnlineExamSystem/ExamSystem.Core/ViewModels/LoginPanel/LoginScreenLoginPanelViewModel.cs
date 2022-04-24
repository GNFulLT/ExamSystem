using ExamSystem.Core.SubModels;
using ExamSystem.Core.Utilities.Localization;
using ExamSystem.Core.Utilities.Services.AuthenticationServices;
using ExamSystem.Core.Utilities.ValidationRules;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Timers;
using System.Windows.Input;

namespace ExamSystem.Core.ViewModels.LoginPanel
{
    public class LoginScreenLoginPanelViewModel : ViewModel
    {
        public static Type Parent;

        public LoginScreenLoginPanelViewModel()
        {
            Localization.SetDefaultLocalization(this);
           
        }

        #region Privates
        private bool isLoginExecuting = false;

        private double globalTimerInterval = 1000;
        #endregion

        #region Timers and TimersEnabledMethods
        Timer t1 = new Timer();
        private void ShowCurentErrorInfoText(string s)
        {
            CurrentErrorInfoText = s;
            if (t1.Enabled)
                t1.Stop();
            t1.Elapsed += t1_Tick;
            t1.Interval = globalTimerInterval;
            t1.Start();
        }
        Timer t2 = new Timer();
        private void ShowCurrentSuccessInfoText(string s)
        {
            CurrentSuccessInfoText = s;
            if (t2.Enabled)
                t2.Stop();
            t2.Elapsed += t2_Tick;
            t2.Interval = globalTimerInterval;
            t2.Start();
        }
        #endregion

        #region Timer Tick Methods
        public void t1_Tick(object sender,EventArgs e)
        {
            CurrentErrorInfoText = string.Empty;
        }
        public void t2_Tick(object sender, EventArgs e)
        {
            CurrentSuccessInfoText = string.Empty;
        }
        #endregion

        #region Properties
        public string UsernameTextBoxText { get; set; }

        public string PasswordTextBoxText { get; set; }

        public string CurrentErrorInfoText { get; set; }

        public string CurrentSuccessInfoText { get; set; }

        public bool IsCycleShow { get; set; }
        #endregion

        #region LocalizableProperties
        [LocalizableProperty]
        public string UsernameHintText { get; set; }

        [LocalizableProperty]
        public string PasswordHintText { get; set; }

        [LocalizableProperty]
        public string LoginButtonText { get; set; }

        [LocalizableProperty]
        public string CreateAccountText { get; set; }

        [LocalizableProperty]
        public string ForgotEmailText{get;set;}

        [LocalizableProperty]
        public string RegisteredText { get; set; }

        [LocalizableProperty]
        public string TextBoxCanNotBeEmptyText { get; set; }

        [LocalizableProperty]
        public string LoginErrorText { get; set; }
        #endregion

        #region BindedCommands
        public ICommand LoginButtonClickedCommand => new RelayCommand(async (sender) =>
        {
            if (isLoginExecuting)
                return;
            isLoginExecuting = true;

            IsCycleShow = true;

            //Process of validating inputs
            bool canTryLogin = true;
            CanNotBeEmptyValidationRule rule1 = new CanNotBeEmptyValidationRule();
            string username = UsernameTextBoxText;
            string pass = PasswordTextBoxText;
            var usernameRes = rule1.Validate(UsernameTextBoxText);
            var passwordRes = rule1.Validate(PasswordTextBoxText);
            if (!usernameRes.IsValid || !passwordRes.IsValid)
            {
                ShowCurentErrorInfoText(TextBoxCanNotBeEmptyText);
                canTryLogin = false;
            }
            if (canTryLogin)
            {
                bool canLogin = true;
                IAuthenticationService authentication = Resolver.Resolve<IAuthenticationService>();
                Account acc = await authentication.Login(username, pass);
               
                if (acc == null)
                {
                    ShowCurentErrorInfoText(LoginErrorText);
                    canLogin = false;
                }
                if (canLogin)
                {
                    //When Loginned
                }
            }
            IsCycleShow = false;
            isLoginExecuting = false;
        });
        public ICommand RegisterLabelClickCommand => new RelayCommand((sender) =>
        {
            RegisterLabelClicked?.Invoke(sender);
        });
        public ICommand ForgotLabelClickCommand => new RelayCommand((sender) =>
        {
           ForgotLabelClicked?.Invoke(sender);
        });
        #endregion

        #region NotBindedCommands
        public ICommand RegisteredSuccesfullyCommand => new RelayCommand((sender) =>
        {
            ShowCurrentSuccessInfoText(RegisteredText);
        });
        #endregion

        #region Events
        public event Action<object> RegisterLabelClicked;
        public event Action<object> ForgotLabelClicked;
        #endregion


    }
}
