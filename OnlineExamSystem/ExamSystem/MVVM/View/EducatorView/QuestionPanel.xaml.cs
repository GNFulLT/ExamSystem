using ExamSystem.MVVM.Model.Question;
using ExamSystem.MVVM.ViewModel.EducatorViewModel;
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

namespace ExamSystem.MVVM.View.EducatorView
{
    /// <summary>
    /// Interaction logic for QuestionPanel.xaml
    /// </summary>
    public partial class QuestionPanel : UserControl
    {
        QuestionPanelViewModel _viewModel;

        
        Question question;

        public QuestionPanel()
        {
            InitializeComponent();          

        }
        public QuestionPanel(Question question) : this()
        {
            _viewModel = DataContext as QuestionPanelViewModel;
            this.question = question;
            _viewModel.UnitText = question.Unit.UnitName;

        }

        private void DataContext_Changed(object sender, DependencyPropertyChangedEventArgs e)
        {
            _viewModel = DataContext as QuestionPanelViewModel;
            _viewModel.UnitText = question.Unit.UnitName;

        }
    }
}
