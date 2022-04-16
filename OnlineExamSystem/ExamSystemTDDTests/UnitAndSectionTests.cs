using ExamSystem;
using ExamSystem.Core.Services.DatabaseServices;
using ExamSystem.MVVM.Model.Question;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemTDDTests
{
    class UnitAndSectionTests
    {
        [SetUp]
        public void Setup()
        {

        }
        //Works great
        [Test]
        public void CreateSectionTest()
        {
            SectionService service = new SectionService();

            UnitService service2 = new UnitService();
            Task<ReadOnlyDictionary<Lesson, Dictionary<string, Unit>>> t1 = service2.GetUnitDictionary();
            ReadOnlyDictionary<Lesson, Dictionary<string, Unit>> res = t1.Result;

           
        }
        //Works
        [Test]
        public void CreateLessonTest()
        {
            LessonService service = new LessonService();
            Lesson les = new Lesson { GlobalCount = 0, GlobalRightCount = 0, LessonName = "Matematik" };
            Task<Lesson> t1 = service.Create(les);
            Lesson l = t1.Result;
            Assert.IsNotNull(l);
        }


        [Test]
        public void GetDictionaryLessonTest()
        {
            LessonService service = new LessonService();

            Task<ReadOnlyDictionary<string, Lesson>> t1 = service.GetLessonDictionary();
            ReadOnlyDictionary<string, Lesson> res = t1.Result;

            Assert.IsNotNull(res);
        }


        //Works Greatly
        [Test]
        public void GetDictionarySectionTest()
        {
            SectionService service = new SectionService();

            UnitService service2 = new UnitService();
            Task<ReadOnlyDictionary<Lesson, Dictionary<string,Unit>>> t1 = service2.GetUnitDictionary();
            ReadOnlyDictionary<Lesson, Dictionary<string, Unit>> res = t1.Result;
            Task<ReadOnlyDictionary<Unit,Dictionary<string,Section>>> t2 = service.GetSectionDictionary();
            var dict = t2.Result;
            Assert.IsNotNull(dict);
        }

        //Works Great
        [Test]
        public void GetSectionTest()
        {
            SectionService service = new SectionService();
            Task<Section> t1 = service.GetTest();
            Section u = t1.Result;
            Assert.IsNotNull(u);
        }

        [Test]
        public void CreateUnitTest()
        {
            UnitService service = new UnitService();
            LessonService s1 = new LessonService();
            Task<ReadOnlyDictionary<string, Lesson>> t1 = s1.GetLessonDictionary();
            ReadOnlyDictionary<string, Lesson> res = t1.Result;
            

            
            Unit unit = new Unit {
                Lesson = res["Matematik"],
                UnitName = "Dikdörtgen",
                GlobalCount = 0,
                GlobalRightCount = 0
            };

            Task<Unit> t2 = service.Create(unit);
            Assert.IsNotNull(t2.Result);
        }

        [Test]
        public void UnitDictionaryTest()
        {
            UnitService service = new UnitService();
            Task<ReadOnlyDictionary<Lesson,Dictionary<string,Unit>>> t1 = service.GetUnitDictionary();
            ReadOnlyDictionary<Lesson, Dictionary<string, Unit>> res = t1.Result;
            Assert.IsNotNull(res);
        }
    }
}
