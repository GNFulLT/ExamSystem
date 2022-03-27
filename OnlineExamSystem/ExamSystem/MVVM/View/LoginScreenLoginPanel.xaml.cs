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
    }
}
