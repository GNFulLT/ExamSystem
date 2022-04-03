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
            Task<ReadOnlyDictionary<string, Unit>> t1 = service2.GetUnitDictionary();
            ReadOnlyDictionary<string, Unit> res = t1.Result;

            Unit unit = res["Biyoloji"];

            Section section = new Section {
                Unit = unit,
            SectionName = "Sinirsel Sistem",
            GlobalCount = 0,
            GlobalRightCount = 0
            };
            Task<Section> t2 = service.Create(section);
            Section sc = t2.Result;
            Assert.IsNotNull(sc);
        }
        //Works Greatly
        [Test]
        public void GetDictionarySectionTest()
        {
            SectionService service = new SectionService();

            UnitService service2 = new UnitService();
            Task<ReadOnlyDictionary<string, Unit>> t1 = service2.GetUnitDictionary();
            ReadOnlyDictionary<string, Unit> res = t1.Result;
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
            Unit unit = new Unit {
                UnitName = "Matematik",
                GlobalCount = 0,
                GlobalRightCount = 0
            };
            Task<Unit> t1 = service.Create(unit);
            Assert.IsNotNull(t1.Result);
        }

        [Test]
        public void UnitDictionaryTest()
        {
            UnitService service = new UnitService();
            Task<ReadOnlyDictionary<string, Unit>> t1 = service.GetUnitDictionary();
            ReadOnlyDictionary<string, Unit> res = t1.Result;
            Assert.IsNotNull(res);
        }
    }
}
