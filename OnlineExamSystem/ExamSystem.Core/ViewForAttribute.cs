using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExamSystem.Core
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple =false)]
    public class ViewForAttribute : Attribute
    {
        Type _view;
        Type _viewModelType;
        [DebuggerStepThrough()]
        public ViewForAttribute(Type view,Type viewModelType)
        {
            _view = view;
            _viewModelType = viewModelType;

        }
        public void LinkViewAndViewModel()
        {
            if (!_viewModelType.IsSubclassOf(typeof(ViewModel)))
            {
                throw new Exception("ViewModelType Paramater is not a ViewModel");
            }

            _viewModelType.GetField("Parent", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).SetValue(null, _view);
        }
    }
}
