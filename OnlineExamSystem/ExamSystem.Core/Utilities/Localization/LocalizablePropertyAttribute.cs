using System;
using System.Runtime.CompilerServices;

namespace ExamSystem.Core.Utilities.Localization
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    public class LocalizablePropertyAttribute : Attribute
    {
        public string PropertyName { get; }
        public string JsonName { get;  }
        /// <summary>
        /// Set the property be able to localize. When a class use Localization.SetLocalization the property that has this attribute automatically will be affected..
        /// </summary>
        /// <param name="jsonName">The corresponding value in json If it is same with property name don't need to touch</param>
        /// <param name="propertyName">The property name that use this attribute, dont need to change</param>
        public LocalizablePropertyAttribute([CallerMemberName]string jsonName="",[CallerMemberName]string propertyName="")
        {
            PropertyName = propertyName;
            JsonName = jsonName;
        }
    }
}
