using ExamSystem.MVVM.Model.Question;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemTDDTests
{
    class WrapperTests
    {
        [SetUp]
        public void Setup()
        {

        }
        //Works Fine
        [Test]
        public void BasicQuestionInfoWrapperTest()
        {
            QuestionInfo quest = new QuestionInfo();
            quest.QuestionText = "Merhaba*+%ĞÜŞİÖöş";
            Assert.AreEqual(quest.QuestionText, "Merhaba*+%ĞÜŞİÖöş");
        }

        //Works Fine
        [Test]
        public void MoreComplexQuestionInfoWrapperTest()
        {
            QuestionInfo quest = new QuestionInfo();
            quest.QuestionText = "Merhaba*+%ĞÜŞİÖöş";
            quest.CorrectAnswer0 = "+*%*SA1";
            quest.WrongAnswer0 = "ASADSA";
            quest.WrongAnswer1 = "QW3EUWQ";
            quest.WrongAnswer2 = "qwejwqüişğp+*71237123912";
            string s1 = quest.QuestionText + quest.CorrectAnswer0 + quest.WrongAnswer0 + quest.WrongAnswer1 + quest.WrongAnswer2;
            string s2 = "Merhaba*+%ĞÜŞİÖöş+*%*SA1ASADSAQW3EUWQqwejwqüişğp+*71237123912";
            Assert.AreEqual(s1,s2);
        }
        //Works Fine
        [Test]
        public void FullQuestionInfoWrapperTest()
        {
            QuestionInfo quest = new QuestionInfo();
            quest.QuestionText = "Merhaba*+%ĞÜŞİÖöş";
            quest.CorrectAnswer0 = "+*%*SA1";
            quest.WrongAnswer0 = "ASADSA";
            quest.WrongAnswer1 = "QW3EUWQ";
            quest.WrongAnswer2 = "qwejwqüişğp+*71237123912";
            quest.GlobalCount = 5;
            quest.DifficultyMultiplier = QuestionInfo.Difficulty.Medium;
            string s1 = quest.QuestionText + quest.CorrectAnswer0 + quest.WrongAnswer0 + quest.WrongAnswer1 + quest.WrongAnswer2 + quest.GlobalCount+ ((int)quest.DifficultyMultiplier);
            string s2 = "Merhaba*+%ĞÜŞİÖöş+*%*SA1ASADSAQW3EUWQqwejwqüişğp+*7123712391253";
            Assert.AreEqual(s1, s2);
        }

    }
}
