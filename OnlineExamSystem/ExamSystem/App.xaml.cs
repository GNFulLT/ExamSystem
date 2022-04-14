using ExamSystem.MVVM.Model.Question;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
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
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            /*StartupUri = new Uri("/ExamSystem;component/MVVM/View/EducatorView/EducatorMainWindow.xaml",UriKind.Relative);*/
            /*StartupUri = new Uri("/ExamSystem;component/MainWindow.xaml", UriKind.Relative);
            StartupUri = new Uri("/ExamSystem;component/Controls/Window1.xaml", UriKind.Relative);*/
            StartupUri = new Uri("/ExamSystem;component/MVVM/View/EducatorView/EducatorMainWindow.xaml", UriKind.Relative);
            base.OnStartup(e);
        }
    }
}
