using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Core.SubModels
{
    public class QuestionInfo : QuestionInfoWrapper
    {
        public enum Difficulty { VeryEasy = 0, Easy, Medium, Hard, Extreme }

        public string QuestionText
        {
            get
            {
                return GetQuestionText(_questionInfoPointer);
            }
            set
            {
                SetQuestionText(_questionInfoPointer, value);
            }
        }

        public string WrongAnswer0
        {
            get
            {
                return GetWrongAnswer0(_questionInfoPointer);
            }
            set
            {
                SetWrongAnswer0(_questionInfoPointer, value);
            }
        }

        public string WrongAnswer1
        {
            get
            {
                return GetWrongAnswer1(_questionInfoPointer);
            }
            set
            {
                SetWrongAnswer1(_questionInfoPointer, value);
            }
        }

        public string WrongAnswer2
        {
            get
            {
                return GetWrongAnswer2(_questionInfoPointer);
            }
            set
            {
                SetWrongAnswer2(_questionInfoPointer, value);
            }
        }

        public string CorrectAnswer0
        {
            get
            {
                return GetCorrectAnswer0(_questionInfoPointer);
            }
            set
            {
                SetCorrectAnswer0(_questionInfoPointer, value);
            }
        }

        public int GlobalRightCount
        {
            get
            {
                return GetGlobalRightCount(_questionInfoPointer);
            }
            set
            {
                SetGlobalRightCount(_questionInfoPointer, value);
            }
        }

        public int GlobalCount
        {
            get
            {
                return GetGlobalCount(_questionInfoPointer);
            }
            set
            {
                SetGlobalCount(_questionInfoPointer, value);
            }
        }

        public Difficulty DifficultyMultiplier
        {
            get
            {
                return (Difficulty)GetDifficulty(_questionInfoPointer);
            }
            set
            {
                SetDifficulty(_questionInfoPointer, (int)value);
            }
        }
        public QuestionInfo()
        {
            _questionInfoPointer = CreateQuestionInfo();
            DifficultyMultiplier = 0;
            GlobalCount = 0;
            GlobalRightCount = 0;

        }

        ~QuestionInfo()
        {
            DeleteQuestionInfo(_questionInfoPointer);
        }
    }
}
