using Examination_System.Classes.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Classes.Exams
{
    internal abstract class Exam
    {
        public TimeOnly Time { get; set; }

        public int NumberOfQuestions { get; set; }

        public Question[] Questions { get; set; }

        protected Exam(TimeOnly _time, int _numOfQuestions, Question[] _questions)
        {
            Time = _time;
            NumberOfQuestions = _numOfQuestions;
            Questions = _questions;
        }

        public abstract void ShowExam();
        public override string ToString()
        {
            return $"Exam: {GetType().Name}, Time: {Time}, Number Of Questions: {NumberOfQuestions}";
        }
    }
}
