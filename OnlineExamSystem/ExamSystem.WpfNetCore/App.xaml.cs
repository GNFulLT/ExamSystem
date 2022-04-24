using ExamSystem.WpfNetCore.Views;
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
            Application.Current.MainWindow = strapper.Resolve<LoginScreenView>();
            Application.Current.MainWindow.Show();
        }
    }
}
