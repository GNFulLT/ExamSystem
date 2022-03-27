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
    /// Interaction logic for LoginScreenForgotEmailPanel.xaml
    /// </summary>
    public partial class LoginScreenForgotEmailPanel : UserControl
    {
        public ICommand BackLabelClickCmd;
        public LoginScreenForgotEmailPanel()
        {
            InitializeComponent();
        }
        private void ForgotEmailButtonClick(object sender,EventArgs e)
        {
            MessageBox.Show("Non Initiliazed");
        }
        private void BackLabelClick(object sender,EventArgs e)
        {
            if (BackLabelClickCmd != null)
                BackLabelClickCmd.Execute(sender);
        }
    }
}
