using System.Collections.ObjectModel;


namespace ExamSystem.MVVM
{
    public interface ILocalizable
    {
       ReadOnlyDictionary<string, string> LocalizationMap { get; }
    }
}
