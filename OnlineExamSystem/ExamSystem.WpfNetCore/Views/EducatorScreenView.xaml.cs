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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private bool _isMouseDown = false;
        private Point _lastLocation;
        private void Window_MouseDownEvent(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = true;
            this.Opacity = 0.7;
            _lastLocation = e.GetPosition(this);
        }
        private void Window_MouseUpEvent(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
            this.Opacity = 1;

        }
        private void Window_MouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                Point mousePosition = e.GetPosition(this);
                Left += mousePosition.X - _lastLocation.X;
                Top += mousePosition.Y - _lastLocation.Y;
            }
        }

        
    }
}
