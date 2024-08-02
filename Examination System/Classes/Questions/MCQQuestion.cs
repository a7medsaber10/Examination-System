using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Classes.Questions
{
    internal class MCQQuestion : Question
    {
        public MCQQuestion(string body, int mark, Answer[] answers, Answer rightAnswer) : base("MCQ", body, mark, answers, rightAnswer) { }
    }
}
