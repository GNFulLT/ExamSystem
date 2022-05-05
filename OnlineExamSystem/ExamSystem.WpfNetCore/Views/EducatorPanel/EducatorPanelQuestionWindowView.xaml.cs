using ExamSystem.Core;
using ExamSystem.Core.ViewModels.EducatorPanel;
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

namespace ExamSystem.WpfNetCore.Views.EducatorPanel
{
    /// <summary>
    /// Interaction logic for EducatorPanelQuestionWindowView.xaml
    /// </summary>
    [ViewFor(typeof(EducatorPanelQuestionWindowView),typeof(EducatorPanelQuestionWindowViewModel))]
    public partial class EducatorPanelQuestionWindowView : Window
    {
        public EducatorPanelQuestionWindowView(EducatorPanelQuestionWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
