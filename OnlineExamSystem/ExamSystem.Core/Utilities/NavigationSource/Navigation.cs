using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Core.Utilities.NavigationSource
{
    public static class Navigation
    {

        private static Stack<object> _stackPushedWindows = new Stack<object>();

        private static Stack<bool> _reusabilitys = new Stack<bool>();


        private static object _currentWindow;

        public static object CurrentWindow { get => _currentWindow;
            set { _currentWindow = value; CurrentWindowChangeRequested?.Invoke(_currentWindow); } }

        public static event Action<object> CurrentWindowChangeRequested;

        public static event Action<object,bool> WindowStackPushed;

        public static event Action<object,bool> WindowStackPoped;

        public static void StackPush(object window,bool reusability = false)
        {
            if(_stackPushedWindows.Contains(window))
            {
                return;
            }
            _stackPushedWindows.Push(window);
            _reusabilitys.Push(reusability);
            WindowStackPushed?.Invoke(window,reusability);
        }

        public static void StackPop()
        {
            object poped =  _stackPushedWindows.Pop();
            bool reusability = _reusabilitys.Pop();
            WindowStackPoped?.Invoke(poped,reusability);
        }
        
        public static bool IsStackPushed(object window)
        {
            return _stackPushedWindows.Contains(window);
        } 
    }
}
