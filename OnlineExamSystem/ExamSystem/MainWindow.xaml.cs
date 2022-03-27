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
        private bool _isMouseDown = false;
        private Point _lastLocation;
        private void Window_MouseDownEvent(object sender,MouseEventArgs e)
        {
            _isMouseDown = true;
            Opacity = 0.7;
            _lastLocation = e.GetPosition(this);
        }
        private void Window_MouseUpEvent(object sender,MouseEventArgs e)
        {
            _isMouseDown = false;  
            Opacity = 1;

        }
        private void Window_MouseMoveEvent(object sender,MouseEventArgs e)
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
