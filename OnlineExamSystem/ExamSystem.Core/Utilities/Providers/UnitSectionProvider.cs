using ExamSystem.Core.Models;
using ExamSystem.Core.Utilities.Services.SubServices.LessonServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Providers
{
    public static class UnitSectionProvider
    {
        private static Lazy<Task<ReadOnlyDictionary<string, Lesson>>> _lessonMap;


        public static ReadOnlyDictionary<string, Lesson> LessonMap
        {
            get
            {
                return _lessonMap.Value.Result;
            }

        }

        private static Lazy<Task<ReadOnlyDictionary<Lesson, Dictionary<string, Unit>>>> _unitMap;

        private static ReadOnlyDictionary<Lesson, Dictionary<string, Unit>> UnitMap
        {
            get
            {
                return _unitMap.Value.Result;
            }

        }

        private static Lazy<Task<ReadOnlyDictionary<Unit, Dictionary<string, Section>>>> _sectionMap;

        private static ReadOnlyDictionary<Unit, Dictionary<string, Section>> SectionMap
        {
            get
            {
                return _sectionMap.Value.Result;
            }

        }

        private static bool _isInitialized = false;

        public static void InitializeMaps()
        {
            if (_isInitialized)
                return;
            _lessonMap = new Lazy<Task<ReadOnlyDictionary<string, Lesson>>>(() =>
            {
                LessonService lessonService = new LessonService();
                return lessonService.GetLessonDictionary();

            });

            _unitMap = new Lazy<Task<ReadOnlyDictionary<Lesson, Dictionary<string, Unit>>>>(() =>
            {
                UnitService unitService = new UnitService();
                return unitService.GetUnitDictionary();
            });

            _sectionMap = new Lazy<Task<ReadOnlyDictionary<Unit, Dictionary<string, Section>>>>(() =>
            {
                SectionService sectionService = new SectionService();
                return sectionService.GetSectionDictionary();
            });

            _isInitialized = true;
            //For executing unitmap and sectionmap
            var a = UnitMap;
            var b = SectionMap;

        }

        public static ReadOnlyDictionary<string, Unit> GetUnitDictionary(Lesson lesson)
        {
            Checker();
            return new ReadOnlyDictionary<string, Unit>(UnitMap[lesson]);
        }

        public static ReadOnlyDictionary<string, Section> GetSectionDictionary(Unit unit)
        {
            Checker();
            return new ReadOnlyDictionary<string, Section>(SectionMap[unit]);
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
