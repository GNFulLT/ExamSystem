using ExamSystem.MVVM.Model.Question;
using System.Windows;


namespace ExamSystem.MVVM.View.EducatorView
{
    /// <summary>
    /// Interaction logic for EducatorQuestionWindow.xaml
    /// </summary>
    public partial class EducatorQuestionWindow : Window
    {
        public EducatorQuestionWindow()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        public delegate void QuestionCreated(Question q);

        public event QuestionCreated OnQuestionCreated;

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            

            this.Hide();
        }
    }
}
