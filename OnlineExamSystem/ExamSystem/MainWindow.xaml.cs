using ExamSystem.MVVM;
using ExamSystem.MVVM.View;
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

namespace ExamSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            InitializeComponent();
        }

        private void MinimizeButtonClick(object sender,EventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        
        private void ExitButtonClick(object sender,EventArgs e)
        {
            Application.Current.Shutdown();
        }
        
    }
}
