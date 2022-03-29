using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private void LoginButtonClick(object sender,EventArgs e)
        {
            if (LoginButtonClickCmd != null)
                LoginButtonClickCmd.Execute(sender);
        }
        private void ForgotEmailClick(object sender,EventArgs e)
        {
            if (ForgotEmailClickCmd != null)
                ForgotEmailClickCmd.Execute(sender);
        }

        
    }
}
