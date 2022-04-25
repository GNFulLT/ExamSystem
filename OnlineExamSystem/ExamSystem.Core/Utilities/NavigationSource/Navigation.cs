using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Core.Utilities.NavigationSource
{
    public static class Navigation
    {
        private static object _currentWindow;

        public static object CurrentWindow { get => _currentWindow;
            set { _currentWindow = value; CurrentWindowChangeRequested?.Invoke(_currentWindow); } }

        public static event Action<object> CurrentWindowChangeRequested;
        
        
         
    }
}
