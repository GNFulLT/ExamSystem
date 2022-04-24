using ExamSystem.Core;
using ExamSystem.Core.ViewModels.LoginPanel;
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

namespace ExamSystem.WpfNetCore.Views.LoginPanel
{
    /// <summary>
    /// Interaction logic for LoginScreenForgotPanelView.xaml
    /// </summary>
    [ViewFor(typeof(LoginScreenForgotPanelView),typeof(LoginScreenForgotPanelViewModel))]
    public partial class LoginScreenForgotPanelView : UserControl
    {
        public LoginScreenForgotPanelView(LoginScreenForgotPanelViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
