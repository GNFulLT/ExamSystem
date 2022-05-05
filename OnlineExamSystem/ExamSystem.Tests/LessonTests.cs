using ExamSystem.Core.Models;
using ExamSystem.Core.Utilities.Providers;
using ExamSystem.Core.Utilities.Services.SubServices.LessonServices;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Tests
{
    public class LessonTests
    {
        [SetUp]
        public void Setup()
        {
            Bootstrapper strapper = new Bootstrapper(Assembly.GetExecutingAssembly(), null);
        }
        [Test]
        public void LessonAddTest()
        {
            Lesson l = new Lesson();
            l.LessonName = "Fen Bilimleri";
            LessonService service = new LessonService();
            
            Task<Lesson> t1 = service.Create(l);
            var les = t1.Result;
        }
        [Test]
        public void UnitAddTest()
        {
            UnitSectionProvider.InitializeMaps();
            var lesson = UnitSectionProvider.LessonMap;
            Unit unit = new Unit();
            UnitService service = new UnitService();
            unit.UnitName = "Elektrik Yükleri ve Elektrik Enerjisi";
            unit.Lesson = lesson["Fen Bilimleri"];
            Task<Unit> t1 = service.Create(unit);

            var s = t1.Result;
            
        }
        [Test]
        public void SectionAddTest()
        {
            UnitSectionProvider.InitializeMaps();
            var lesson = UnitSectionProvider.LessonMap;
            var unitmap = UnitSectionProvider.GetUnitDictionary(lesson["Fen Bilimleri"]);
            var unit = unitmap["Elektrik Yükleri ve Elektrik Enerjisi"];
            SectionService service = new SectionService();
            Section s = new Section();
            s.Unit = unit;
            s.SectionName = "Elektrik Enerjisinin Dönüşümü";
            Task<Section> t1 = service.Create(s);
            var s2 = t1.Result;
        }
    }
}
