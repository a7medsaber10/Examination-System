using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Classes.Questions
{
    internal abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }

        public int Mark { get; set; }

        public Answer[] AnswerList { get; set; }

        public Answer RightAnswer { get; set; }
        protected Question(string _header, string _body, int _mark, Answer[] answers, Answer _rightAnswer)
        {
            Header = _header;
            Body = _body;
            Mark = _mark;
            AnswerList = answers;
            RightAnswer = _rightAnswer;
        }

        public override string ToString()
        {
            return $"{Header}: {Body}  (Mark: {Mark})";
        }
    }
}
