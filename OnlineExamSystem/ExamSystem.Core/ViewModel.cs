using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamSystem.Core
{
    public class ViewModel : INotifyPropertyChanged
    {
        public static Type Parent;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string s = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }
    }
}
