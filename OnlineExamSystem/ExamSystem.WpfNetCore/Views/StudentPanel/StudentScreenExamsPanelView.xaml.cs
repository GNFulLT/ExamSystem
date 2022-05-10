using ExamSystem.Core;
using ExamSystem.Core.ViewModels.StudentPanel;
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

namespace ExamSystem.WpfNetCore.Views.StudentPanel
{
    /// <summary>
    /// Interaction logic for StudentScreenExamsPanelView.xaml
    /// </summary>
    [ViewFor(typeof(StudentScreenExamsPanelView),typeof(StudentScreenExamsPanelViewModel))]
    public partial class StudentScreenExamsPanelView : UserControl
    {
        public StudentScreenExamsPanelView(StudentScreenExamsPanelViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
