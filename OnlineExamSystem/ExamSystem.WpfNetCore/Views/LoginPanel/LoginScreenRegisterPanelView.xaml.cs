using ExamSystem.Core;
using ExamSystem.Core.Utilities.ValidationRules;
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
    /// Interaction logic for LoginScreenRegisterPanelView.xaml
    /// </summary>
    [ViewFor(typeof(LoginScreenRegisterPanelView), typeof(LoginScreenRegisterPanelViewModel))]
    public partial class LoginScreenRegisterPanelView : UserControl
    {
        public LoginScreenRegisterPanelView(LoginScreenRegisterPanelViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Username_InputHandle(object sender, TextCompositionEventArgs e)
        {
            UsernameValidationRule rule = new UsernameValidationRule();
            var res = rule.Validate(e.Text);

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
