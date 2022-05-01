using ExamSystem.Core.Utilities.NavigationSource;
using ExamSystem.WpfNetCore.Views;
using ExamSystem.WpfNetCore.Views.EducatorPanel;
using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace ExamSystem.WpfNetCore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            Bootstrapper strapper = new Bootstrapper(Assembly.GetExecutingAssembly(),typeof(Window));

            Current.MainWindow = strapper.Resolve<LoginScreenView>();
            

            Current.MainWindow.Show();
            Navigation.CurrentWindow = MainWindow;
            Navigation.CurrentWindowChangeRequested += OnCurrentWindowChangedRequest;
            Navigation.WindowStackPushed += OnWindowStackPushed;
            Navigation.WindowStackPoped += OnWindowStackPoped;
        }

        private void OnCurrentWindowChangedRequest(object newWindow)
        {
            if (newWindow is not Window)
                throw new Exception("Requested object is not a window");
            Window dump = Current.MainWindow;
            Current.MainWindow = newWindow as Window;
            Current.MainWindow.Show();
            dump.Close();
        }

        private void OnWindowStackPushed(object stackPushedWindow,bool reusability)
        {
            Window window = stackPushedWindow as Window;
            window.ShowInTaskbar = false;
            window.ShowDialog();
            
        }
        private void OnWindowStackPoped(object stackPushedWindow, bool reusability)
        {
            Window window = stackPushedWindow as Window;
            if (reusability)
            {
                window.Hide();
            }
            else
            {
                window.Close();
            }
        }


    }
}
