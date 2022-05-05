using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExamSystem.Core.Utilities.Localization
{
    public interface ILocalizable
    {
        public ReadOnlyDictionary<string, string> LocalizationMap { get; }

    }
}
