using ExamSystem.Core;
using ExamSystem.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExamSystem.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        LoginScreenLoginPanel loginPanel;
        LoginScreenRegisterPanel registerPanel;
        LoginScreenForgotEmailPanel forgotEmailPanel;
        private ICommand _createAccountClickCmd;
        private ICommand _backLabelClickCmd;
        private ICommand _forgotEmailClickCmd;
        private ICommand _registeredSuccesfullyCmd;
        private object _currentPanel;

        public object CurrentPanel
        {
            get { return _currentPanel; }
            set { _currentPanel = value;
                NotifyPropertyChanged();
            }
        }
        public MainViewModel()
        {
            //Panel Create
            loginPanel = new LoginScreenLoginPanel();
            registerPanel = new LoginScreenRegisterPanel();
            forgotEmailPanel = new LoginScreenForgotEmailPanel();
            
            //Main Panel Command Handlers Created
            _createAccountClickCmd = new RelayCommand(OnCreateAccountClick);
            _backLabelClickCmd = new RelayCommand(OnBackLabelClick);
            _forgotEmailClickCmd = new RelayCommand(OnForgotEmailLabelClick);
            _registeredSuccesfullyCmd = new RelayCommand(OnRegisteredSuccesfully);

            //UserControls Command Handler gives commands to main command handlers
            registerPanel.BackLabelClickCmd = _backLabelClickCmd;
            loginPanel.CreateAccountClickCmd = _createAccountClickCmd;
            loginPanel.ForgotEmailClickCmd = _forgotEmailClickCmd;
            forgotEmailPanel.BackLabelClickCmd = _backLabelClickCmd;
            registerPanel.RegisteredSuccesfullyCmd = _registeredSuccesfullyCmd;

            _currentPanel = loginPanel;
        }

       
        private void OnBackLabelClick(object sender)
        {
            UserControl control = (UserControl)_currentPanel;
            control.Visibility = Visibility.Hidden;
            CurrentPanel = loginPanel;
            control = (UserControl)_currentPanel;
            control.Visibility = Visibility.Visible;
        }
        private void OnCreateAccountClick(object sender)
        {
            UserControl control = (UserControl)_currentPanel;
            control.Visibility = Visibility.Hidden;
            CurrentPanel = registerPanel;
            control = (UserControl)_currentPanel;
            control.Visibility = Visibility.Visible;
        }
       
        private void OnForgotEmailLabelClick(object sender)
        {
            UserControl control = (UserControl)_currentPanel;
            control.Visibility = Visibility.Hidden;
            CurrentPanel = forgotEmailPanel;
            control = (UserControl)_currentPanel;
            control.Visibility = Visibility.Visible;
        }

        private void OnRegisteredSuccesfully(object sender)
        {
            _backLabelClickCmd.Execute(sender);
            loginPanel.RegisteredTextCmd.Execute(sender);
        }
       
    }
}
