using Examination_System.Classes.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Classes.Exams
{
    internal class Final_Exam : Exam
    {
        public Final_Exam(TimeOnly _time, int _numOfQuestions, Question[] questions) : base(_time, _numOfQuestions, questions) { }

        public override void ShowExam()
        {
            foreach (Question question in Questions)
            {
                Console.WriteLine($"{question.Header} : {question.Body} (Mark: {question.Mark})");
                foreach (Answer answer in question.AnswerList)
                {
                    Console.WriteLine(answer);
                }
            }
        }
    }
}
