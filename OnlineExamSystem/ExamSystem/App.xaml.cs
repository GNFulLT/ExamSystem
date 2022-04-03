using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ExamSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            StartupUri = new Uri("/ExamSystem;component/MVVM/View/EducatorView/EducatorMainWindow.xaml",UriKind.Relative);
            base.OnStartup(e);
        }
    }
}
