using ExamSystem.Core.Hashers;
using ExamSystem.Core.Services.AuthenticationServices;
using ExamSystem.Core.Services.ValidationRules;
using ExamSystem.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for LoginScreenRegisterPanel.xaml
    /// </summary>
    public partial class LoginScreenRegisterPanel : UserControl
    {
        public ICommand BackLabelClickCmd;
        public ICommand RegisteredSuccesfullyCmd;

        public LoginScreenRegisterPanel()
        {
            InitializeComponent();
            LoadingBar.StopCycling();
        }
        private void BackLabelClick(object sender,MouseButtonEventArgs e)
        {
            if (BackLabelClickCmd != null)
                BackLabelClickCmd.Execute(sender);
        }
        private async void RegisterButtonClick(object sender,EventArgs e)
        {
            LoadingBar.EnableCycling();
            CanNotBeEmptyValidationRule rule = new CanNotBeEmptyValidationRule();

            ValidationResult resNameSurname = rule.Validate(NameSurnameTextBox.Text, CultureInfo.DefaultThreadCurrentCulture);           
            var resEmail = rule.Validate(EmailTextBox.Text, CultureInfo.DefaultThreadCurrentCulture);
            var resUsername =  rule.Validate(UsernameTextBox.Text,CultureInfo.DefaultThreadCurrentCulture);
            var resPassword = rule.Validate(PasswordTextBox.Password,CultureInfo.DefaultThreadCurrentCulture);
            LoginScreenRegisterPanelViewModel viewModel = DataContext as LoginScreenRegisterPanelViewModel;
            bool canTryRegister = true;
            string[] name_surname;
            if (!resNameSurname.IsValid)
            {
                viewModel.NameSurnameTextBoxCanNotBeEmpty();
                canTryRegister = false;
            }
            else
            {
                name_surname = NameSurnameTextBox.Text.Split(' ');
                if(name_surname.Length < 2)
                {
                    viewModel.NameSurnameTextBoxCanNotBeEmpty();
                    canTryRegister = false;
                }
            }
            if (!resEmail.IsValid)
            {
                viewModel.EmailTextBoxCanNotBeEmpty();
                canTryRegister = false;
            }
            if (!resUsername.IsValid)
            {           
                viewModel.UsernameTextBoxCanNotBeEmpty();
                canTryRegister = false;
            }
            if (!resPassword.IsValid)
            {
                viewModel.PasswordTextBoxCanNotBeEmpty();
                canTryRegister = false;
            }
            if (canTryRegister)
            {
                bool canRegister = true;
                EmailValidationRule emailValidationRule = new EmailValidationRule();
                PasswordValidationRule passwordValidationRule = new PasswordValidationRule();
                var resPass = passwordValidationRule.Validate(PasswordTextBox.Password,CultureInfo.DefaultThreadCurrentCulture);
                var resEmailRegex = emailValidationRule.Validate(EmailTextBox.Text, CultureInfo.DefaultThreadCurrentCulture);

                if (!resEmailRegex.IsValid)
                {
                    viewModel.EmailIsNotValid();
                    canRegister = false;
                }
                if (!resPass.IsValid)
                {               
                    viewModel.PasswordIsNotValid(passwordValidationRule.MIN_LENGTH);
                    canRegister = false;
                }
                if (canRegister)
                {
                    AccountService accService = new AccountService();
                    PasswordHasher_HMACSHA512 passHasher = new PasswordHasher_HMACSHA512();
                    AuthenticationService authentication = new AuthenticationService(accService,passHasher);
                    name_surname = NameSurnameTextBox.Text.Split(' ');
                    string surname = "";
                    for(int i = 1; i < name_surname.Length; i++)
                    {
                        surname += name_surname[i];
                    }
                    AccountInfo accInfo = new AccountInfo()
                    {
                        Name = name_surname[0],
                        Surname = surname
                    };
                    bool couldRegister = true;
                    RegistrationResult res = await authentication.Register(EmailTextBox.Text, UsernameTextBox.Text, PasswordTextBox.Password,accInfo);
                    if((res & RegistrationResult.EmailAlreadyExists) == RegistrationResult.EmailAlreadyExists)
                    {
                        viewModel.EmailAlreadyInUse();
                        couldRegister = false;
                    }
                    if((res & RegistrationResult.UsernameAlreadyExists) == RegistrationResult.UsernameAlreadyExists)
                    {
                        viewModel.UsernameAlreadyInUse();
                        couldRegister = false;
                    }
                    if (couldRegister)
                    {
#if DEBUG
                        if (RegisteredSuccesfullyCmd == null)
                            throw new Exception("LoginSuccesfullCmd can not be null!");
#endif          
                        RegisteredSuccesfullyCmd.Execute(this);
                        ClearAllTextBoxes();
                    }
                }
            }
            //Long Process
           
            LoadingBar.StopCycling();

        }

        private void ClearAllTextBoxes()
        {
            UsernameTextBox.ClearValue(TextBox.TextProperty);
            EmailTextBox.ClearValue(TextBox.TextProperty);
            NameSurnameTextBox.ClearValue(TextBox.TextProperty);
            PasswordTextBox.Password = "";

        }



        private void Username_InputHandle(object sender, TextCompositionEventArgs e)
        {
           UsernameValidationRule rule = new UsernameValidationRule();
           ValidationResult res =   rule.Validate(e.Text, CultureInfo.DefaultThreadCurrentCulture);

            if (!res.IsValid)
                e.Handled = true;
           

        }

        private void UsernameTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;

        }
    }
}
