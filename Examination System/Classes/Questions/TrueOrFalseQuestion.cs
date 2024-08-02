using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Classes.Questions
{
    internal class TrueOrFalseQuestion : Question
    {
        public TrueOrFalseQuestion(string body, int mark, Answer[] answers, Answer rightAnswer): base("True or False", body, mark, answers, rightAnswer) { }

    }
}
