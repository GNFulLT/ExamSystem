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

        public LoginScreenLoginPanel()
        {

            InitializeComponent();
            HiddenLoadingBar();
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
