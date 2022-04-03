using ExamSystem.Core.Hashers;
using ExamSystem.Core.Services.AuthenticationServices;
using ExamSystem.Core.Services.ValidationRules;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamSystem.MVVM.View
{
    /// <summary>
    /// Interaction logic for LoginScreenLoginPanel.xaml
    /// </summary>
    public partial class LoginScreenLoginPanel : UserControl
    {
        public ICommand CreateAccountClickCmd;
        public ICommand LoginButtonClickCmd;
        public ICommand ForgotEmailClickCmd;
        public ICommand RegisteredTextCmd;

        public LoginScreenLoginPanel()
        {

            InitializeComponent();
            HiddenLoadingBar();
            RegisteredTextCmd = new RelayCommand(RegisteredTextAnimation);
        }

        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
        private void RegisteredTextAnimation(object sender)
        {
            if (t1.Enabled)
                t1.Stop();
            var viewModel = DataContext as ExamSystem.MVVM.ViewModel.LoginScreenLoginPanelViewModel;
            viewModel.SetRegisteredText();
            t1.Interval = Globals.GlobalHintAssistTime;
            t1.Tick += RegisteredText_Tick;
            t1.Start();
        }
        private void RegisteredText_Tick(object sender,EventArgs e)
        {
            t1.Stop();
            var viewModel = DataContext as ExamSystem.MVVM.ViewModel.LoginScreenLoginPanelViewModel;
            viewModel.ClearRegisteredText();
        }

        public void ShowLoadingBar()
        {
            LoadingBar.EnableCycling();
            LoadingBar.Visibility = Visibility.Visible;
        }
        public void HiddenLoadingBar()
        {
            LoadingBar.StopCycling();
            LoadingBar.Visibility = Visibility.Hidden;
        }
        private void CreateAccountClick(object sender,RoutedEventArgs e)
        {
            if (CreateAccountClickCmd != null)
                CreateAccountClickCmd.Execute(sender);
        }
        private async void LoginButtonClick(object sender,EventArgs e)
        {
            ShowLoadingBar();
            bool canTryLogin = true;
            CanNotBeEmptyValidationRule rule1 = new CanNotBeEmptyValidationRule();
            var usernameRes = rule1.Validate(UsernameTextBox.Text, CultureInfo.DefaultThreadCurrentCulture);
            var passwordRes = rule1.Validate(PasswordTextBox.Password, CultureInfo.DefaultThreadCurrentCulture);
            if (!usernameRes.IsValid || !passwordRes.IsValid)
            {
                TextBoxCanNotBeEmpty();
                canTryLogin = false;
            }
            if (canTryLogin)
            {
                bool canLogin = true;
                string username = UsernameTextBox.Text;
                string pass = PasswordTextBox.Password;

                AccountService accService = new AccountService();
                PasswordHasher_HMACSHA512 passHasher = new PasswordHasher_HMACSHA512();
                AuthenticationService authentication = new AuthenticationService(accService, passHasher);

                Account acc =  await authentication.Login(username, pass);
                if (acc == null)
                {
                    UsernameOrPasswordWrong();
                    canLogin = false;
                }
                if (canLogin)
                {
                  if (LoginButtonClickCmd != null)
                  {
                     Globals.SetLoginedAccount(acc);
                     LoginButtonClickCmd.Execute(sender);

                    }
                }
                   
            }
          

            HiddenLoadingBar();
           
        }
        System.Windows.Forms.Timer t3 = new System.Windows.Forms.Timer();
        private void UsernameOrPasswordWrong()
        {
            if (t3.Enabled)
                t3.Stop();
            t3.Interval = Globals.GlobalHintAssistTime;
            t3.Tick += UsernameOrPasswordWrong_Tick;
            ErrorLabel2.Visibility = Visibility.Visible;
            t3.Start();
        }
        private void UsernameOrPasswordWrong_Tick(object sender,EventArgs e)
        {
            ErrorLabel2.Visibility = Visibility.Hidden;
            t3.Stop();
        }
        private void ForgotEmailClick(object sender,EventArgs e)
        {
            if (ForgotEmailClickCmd != null)
                ForgotEmailClickCmd.Execute(sender);
        }
 
        private void UsernameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            UsernameValidationRule rule = new UsernameValidationRule();
            ValidationResult res = rule.Validate(e.Text, CultureInfo.DefaultThreadCurrentCulture);

            if (!res.IsValid)
                e.Handled = true;
        }

        private void UsernameTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        System.Windows.Forms.Timer t2 = new System.Windows.Forms.Timer();
        public void TextBoxCanNotBeEmpty()
        {
            if (t2.Enabled)
                t2.Stop();
            t2.Interval = Globals.GlobalHintAssistTime;
            ErrorLabel.Visibility = Visibility.Visible;
            t2.Tick += TextBoxCanNotBeEmpty_Tick;
            t2.Start();
        }
        private void TextBoxCanNotBeEmpty_Tick(object sender, EventArgs e)
        {
            ErrorLabel.Visibility = Visibility.Hidden;
            t2.Stop();
        }
    }
}
