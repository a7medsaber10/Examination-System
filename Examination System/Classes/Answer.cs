using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Classes
{
    internal class Answer
    {
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }

        public Answer(int _answerID, string _answerText)
        {
            AnswerID = _answerID;
            AnswerText = _answerText;
        }

        public override string ToString()
        {
            return $"{AnswerID} : {AnswerText}";
        }
    }
}
