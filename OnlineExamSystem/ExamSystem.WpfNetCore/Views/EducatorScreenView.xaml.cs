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
    /// Interaction logic for EducatorScreenView.xaml
    /// </summary>
    [ViewFor(typeof(EducatorScreenView),typeof(EducatorScreenViewModel))]
    public partial class EducatorScreenView : Window
    {
        public EducatorScreenView(EducatorScreenViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
