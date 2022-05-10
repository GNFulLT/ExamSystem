using ExamSystem.Core;
using ExamSystem.Core.ViewModels;
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
using System.Windows.Shapes;

namespace ExamSystem.WpfNetCore.Views
{
    /// <summary>
    /// Interaction logic for StudentScreenView.xaml
    /// </summary>
    [ViewFor(typeof(StudentScreenView), typeof(StudentScreenViewModel))]
    public partial class StudentScreenView : Window
    {
        public StudentScreenView(StudentScreenViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
