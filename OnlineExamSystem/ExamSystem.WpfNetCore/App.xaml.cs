using ExamSystem.Core.Utilities.NavigationSource;
using ExamSystem.WpfNetCore.Views;
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
            
        }

        private void OnCurrentWindowChangedRequest(object newWindow)
        {
            if (newWindow is not Window)
                throw new Exception("Changed Window Requested is not window type");
            Window dump = Current.MainWindow;
            Current.MainWindow = newWindow as Window;
            Current.MainWindow.Show();
            dump.Close();
        }

        
    }
}
