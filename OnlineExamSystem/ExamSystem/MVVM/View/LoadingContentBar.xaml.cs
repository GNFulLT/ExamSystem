using System;
using System.Windows;
using System.Windows.Media.Animation;
using UserControl = System.Windows.Controls.UserControl;

namespace ExamSystem.MVVM.View
{
    /// <summary>
    /// Interaction logic for LoadingContentBar.xaml
    /// </summary>
    public partial class LoadingContentBar : UserControl
    {

        public LoadingContentBar()
        {
            InitializeComponent();
            
        }

        public void StopCycling()
        {
            ProgressBar.IsIndeterminate = false;
        }
        public void EnableCycling()
        {
            ProgressBar.IsIndeterminate = true;
        }




    }
}
