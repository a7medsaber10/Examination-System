using Examination_System.Classes;
using Examination_System.Classes.Exams;
using Examination_System.Classes.Questions;
using System.Threading.Channels;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter type of exam (1 for practical | 2 for final): "); 
            int examType = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the time for the exam (from 30 min to 180 min)");
            int examTimeMinutes = int.Parse(Console.ReadLine());
            TimeOnly examTime = TimeOnly.FromDateTime(DateTime.Today.AddMinutes(examTimeMinutes));

            Console.WriteLine("Please enter number of questions:");
            int numberOfQuestions = int.Parse(Console.ReadLine());

            List<Question> questions = new List<Question>();

            for (int i = 0; i < numberOfQuestions; i++)
            {
                if (examType == 2)
                {
                    Console.WriteLine("Please enter type of question (1 for MCQ | 2 for true | false):");
                    int questionType = int.Parse(Console.ReadLine());

                    if (questionType == 2)
                    {
                        CreateTrueOrFalseQuestion(questions);
                    }
                    else
                    {
                        CreateMCQQuestion(questions);
                    }
                }
                else
                {
                    CreateTrueOrFalseQuestion(questions);
                }
            }

            Exam exam;
            if (examType == 1)
            {
                exam = new Practical_Exam(examTime, numberOfQuestions, questions.ToArray());
            }
            else
            {
                exam = new Final_Exam(examTime, numberOfQuestions, questions.ToArray());
            }

            Console.WriteLine("Do You want to start the exam (Y|N)?");
            string startExam = Console.ReadLine();

            if (startExam.ToUpper() == "Y")
            {
                int myTotalMarks = 0;
                int totalMarks = 0;

                foreach (Question question in exam.Questions) 
                {
                    Console.WriteLine(question);
                    Console.WriteLine("Choices:");
                    foreach(Answer answer in question.AnswerList)
                    {
                        Console.WriteLine(answer);
                    }

                    Console.WriteLine("Please enter the answer id: ");
                    int answerID = int.Parse(Console.ReadLine());

                    Answer selectedAnswer = Array.Find(question.AnswerList, a => a.AnswerID == answerID);

                    Console.WriteLine($"Your Answer: {selectedAnswer}");
                    Console.WriteLine($"Right Answer: {question.RightAnswer}");

                    if (selectedAnswer.AnswerID == question.RightAnswer.AnswerID)
                    {
                        myTotalMarks += question.Mark;
                    }

                    totalMarks = exam.NumberOfQuestions * question.Mark;
                }

                Console.WriteLine($"Your Grade from {totalMarks} is {myTotalMarks}");
                Console.WriteLine($"Time = {exam.Time.ToString("hh\\:mm\\:ss")}");
                Console.WriteLine("Thank You");
            }
        }

        private static void CreateMCQQuestion(List<Question> questions)
        {
            Console.WriteLine("MCQ Question: ");
            Console.WriteLine("Please question body:");
            string body = Console.ReadLine();

            Console.WriteLine("Please enter the question mark:");
            int mark = int.Parse(Console.ReadLine());

            List<Answer> answers = new List<Answer>();
            for (int j = 1; j <= 3; j++)
            {
                Console.WriteLine($"Please enter choice number {j}:");
                string answerText = Console.ReadLine();

                answers.Add(new Answer(j, answerText));
            }

            Console.WriteLine("Please enter the right answer id:");
            int rightAnswerID = int.Parse(Console.ReadLine());
            Answer rightAnswer = answers.Find(a => a.AnswerID == rightAnswerID);

            questions.Add(new MCQQuestion(body, mark, answers.ToArray(), rightAnswer));
        }
        private static void CreateTrueOrFalseQuestion(List<Question> questions)
        {
            Console.WriteLine("True | False Question:");
            Console.WriteLine("Please enter the question body:");
            string body = Console.ReadLine();

            Console.WriteLine("Please enter Question mark:");
            int mark = int.Parse(Console.ReadLine());

            Answer[] answers = { new Answer(1, "true"), new Answer(2, "false") };

            Console.WriteLine("Please enter the right answer id (1 for true | 2 for false)");
            int rightAnswerID = int.Parse(Console.ReadLine());
            Answer rightAnswer = answers[rightAnswerID - 1];

            questions.Add(new TrueOrFalseQuestion(body, mark, answers, rightAnswer));
        }
    }
}
