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
        private ICommand _createAccountClickCmd;
        private ICommand _backLabelClickCmd;
        private ICommand _loginButtonClickCmd;
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

            //Main Panel Command Handlers Created
            _createAccountClickCmd = new RelayCommand(OnCreateAccountClick);
            _backLabelClickCmd = new RelayCommand(OnBackLabelClick);
            _loginButtonClickCmd = new RelayCommand(OnLoginButtonClick);

            //UserControls Command Handler gives commands to main command handlers
            registerPanel.BackLabelClickCmd = _backLabelClickCmd;
            loginPanel.CreateAccountClickCmd = _createAccountClickCmd;
            loginPanel.LoginButtonClickCmd = _loginButtonClickCmd;

            _currentPanel = loginPanel;
        }

        private void OnLoginButtonClick(object obj)
        {
            loginPanel.ShowLoadingBar();
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
    }
}
