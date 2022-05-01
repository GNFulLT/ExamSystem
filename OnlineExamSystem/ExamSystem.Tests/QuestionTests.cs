using ExamSystem.Core.Models;
using ExamSystem.Core.Utilities.Providers;
using ExamSystem.Core.Utilities.Services.SubServices.QuestionServices;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Tests
{
    public class QuestionTests
    {
        [SetUp]
        public void Setup()
        {
            Bootstrapper strapper = new Bootstrapper(Assembly.GetExecutingAssembly(), null);
        }
        [Test]
        public void AddQuestionTest()
        {
            UnitSectionProvider.InitializeMaps();
            var lesson = UnitSectionProvider.LessonMap;
            var unitmap = UnitSectionProvider.GetUnitDictionary(lesson["Fen Bilimleri"]);
            var unit = unitmap["Elektrik Yükleri ve Elektrik Enerjisi"];
            var sectionmap = UnitSectionProvider.GetSectionDictionary(unit);
            var section = sectionmap["Elektrik Yükleri ve Elektriklenme"];

            Question q = new Question(section);

            q.QuestionInfo.CorrectAnswer0 = "ZAAAAAA";
            q.QuestionInfo.QuestionText = "ZAAAAAAAAAA";
            q.QuestionInfo.WrongAnswer0 = "AAAAA";
            q.QuestionInfo.WrongAnswer1 = "AAAAhjgkA";
            q.QuestionInfo.WrongAnswer2 = "AAAAasdA";

            QuestionService service = new QuestionService();
            Task<Question> t1 = service.Create(q);
            var quest = t1.Result;

            Assert.IsNotNull(quest);
        }

        [Test]
        public void ReadQuestionTest()
        {
            UnitSectionProvider.InitializeMaps();

            QuestionService service = new QuestionService();
            Task<List<Question>> t1 = service.GetAllQuestionsList();
            var quests = t1.Result;

            Assert.IsNotNull(quests);
        }

    }
}
