using ExamSystem.Core.Models;
using ExamSystem.Core.Utilities.Services.SubServices.QuestionServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Providers
{
    public static class QuestionProvider
    {
        private static bool _isInitialized = false;

        private static Lazy<Task<ReadOnlyDictionary<Section, List<Question>>>> _questionSectionMap;

        private static Lazy<Task<List<Question>>> _questionDateMap;

        public static List<Question> QuestionDateMap
        {
            get => _questionDateMap.Value.Result;
        }

        public static void InitializeMaps()
        {
            if (_isInitialized)
                return;
            _questionSectionMap = new Lazy<Task<ReadOnlyDictionary<Section, List<Question>>>>(() =>
            {
                QuestionService s = new QuestionService();
                return s.GetAllQuestionsDictionary();
            });

            _questionDateMap = new Lazy<Task<List<Question>>>(() =>
            {
                QuestionService s = new QuestionService();
                return s.GetAllQuestionsList();
            });
            _isInitialized = true;
        }

        private static void Checker()
        {
            if (!_isInitialized)
            {
                throw new Exception("Unit Sections doesn't initialized");
            }
        }
    }
}
