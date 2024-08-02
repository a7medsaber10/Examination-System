using Examination_System.Classes.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Classes
{
    internal class Subject
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        public Exam SubjectExam { get; set; }

        public Subject(int _subID, string _subName, Exam _subExam) 
        {
            SubjectID = _subID;
            SubjectName = _subName;
            SubjectExam = _subExam;
        }

        public void CreateExam()
        {
            SubjectExam.ShowExam();
        }

        public override string ToString()
        {
            return $"Subject ID: {SubjectID}, Subject Name: {SubjectName}, Exam: {SubjectExam.GetType().Name}";
        }
    }
}
