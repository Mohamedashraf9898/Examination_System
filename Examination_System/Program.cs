namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string logFolder = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            Directory.CreateDirectory(logFolder);

            string practiceLog = Path.Combine(logFolder, "practice_log.txt");
            string finalLog = Path.Combine(logFolder, "final_log.txt");

            Subject subj = new Subject(1, "C# Programming");
            Student student = new Student("Mohamed");

            Console.WriteLine("Choose Exam Type:");
            Console.WriteLine("1- Practice Exam");
            Console.WriteLine("2- Final Exam");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            Exam exam;

            if (choice == 1)
            {
                exam = new PracticeExam(TimeSpan.FromMinutes(30), subj,
                    Path.Combine(logFolder, practiceLog));
            }
            else
            {
                exam = new FinalExam(TimeSpan.FromMinutes(30), subj,
                    Path.Combine(logFolder, practiceLog));
            }

            exam.ExamStarted += student.NotifyExamStarted;

            // إضافة 4 أسئلة
            Question q1 = new TrueOrFalse("Q1", "C# is an object-oriented language?", 5);
            Question q2 = new ChooseOne("Q2", "What is the size of int in C#?", 5,
                new AnswerList
                {
                    new Answer("2 bytes"),
                    new Answer("4 bytes", true),
                    new Answer("8 bytes")
                });
            Question q3 = new ChooseAll("Q3", "Which of the following are reference types?", 10,
                new AnswerList
                {
                    new Answer("string", true),
                    new Answer("int"),
                    new Answer("class", true),
                    new Answer("struct")
                });
            Question q4 = new TrueOrFalse("Q4", ".NET Core is cross-platform?", 5);

            exam.AddQuestion(q1);
            exam.AddQuestion(q2);
            exam.AddQuestion(q3);
            exam.AddQuestion(q4);

            exam.StartExam();

            int totalMarks = 0;
                int obtainedMarks = 0;

                foreach (var kvp in exam.Questions)
                {
                    Question question = kvp.Key;
                    AnswerList answers = kvp.Value;

                    Console.WriteLine(question.GetQuestion());

                    string userAns = "";
                    bool validInput = false;

                    while (!validInput)
                    {
                        Console.Write("Enter your answer: ");
                        userAns = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(userAns))
                        {
                            Console.WriteLine("⚠️ Please enter a valid answer!");
                            continue;
                        }

                        if (question is TrueOrFalse)
                        {
                            if (userAns == "1" || userAns == "2")
                                validInput = true;
                            else
                                Console.WriteLine("⚠️ Enter 1 or 2 only!");
                        }
                        else if (question is ChooseOne)
                        {
                            if (int.TryParse(userAns, out int ansIndex) &&
                                ansIndex >= 1 && ansIndex <= answers.Count)
                                validInput = true;
                            else
                                Console.WriteLine($"⚠️ Enter a number between 1 and {answers.Count}!");
                        }
                        else if (question is ChooseAll)
                        {
                            string[] parts = userAns.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                            bool allValid = true;
                            foreach (var p in parts)
                            {
                                if (!(int.TryParse(p, out int num) && num >= 1 && num <= answers.Count))
                                {
                                    allValid = false;
                                    break;
                                }
                            }
                            if (allValid) validInput = true;
                            else Console.WriteLine($"⚠️ Enter numbers between 1 and {answers.Count}, separated by space!");
                        }
                    }

                    totalMarks += question.Marks;
                    bool isCorrect = false;

                    if (question is TrueOrFalse)
                    {
                        if ((userAns == "1" && answers[0].IsCorrect) ||
                            (userAns == "2" && answers[1].IsCorrect))
                        {
                            isCorrect = true;
                        }
                    }
                    else if (question is ChooseOne)
                    {
                        int ansIndex = int.Parse(userAns) - 1;
                        if (answers[ansIndex].IsCorrect)
                        {
                            isCorrect = true;
                        }
                    }
                    else if (question is ChooseAll)
                    {
                        string[] parts = userAns.Split(' ');
                        bool allCorrect = true;
                        for (int i = 0; i < answers.Count; i++)
                        {
                            if (answers[i].IsCorrect && !parts.Contains((i + 1).ToString()))
                                allCorrect = false;
                            if (!answers[i].IsCorrect && parts.Contains((i + 1).ToString()))
                                allCorrect = false;
                        }
                        if (allCorrect) isCorrect = true;
                    }

                    if (isCorrect)
                    {
                        obtainedMarks += question.Marks;
                    }

                    if (exam is PracticeExam)
                    {
                        Console.WriteLine("Correct Answers:");
                        for (int i = 0; i < answers.Count; i++)
                        {
                            if (answers[i].IsCorrect)
                                Console.WriteLine($"{i + 1}- {answers[i].Text}");
                        }
                    }

                    Console.WriteLine("===========================================================");
                }

                if (exam is FinalExam)
                {
                    Console.WriteLine($"Exam Finished! You got {obtainedMarks}/{totalMarks}");
                }

                Console.WriteLine("=====================================================");
                Console.WriteLine("Thank you!");
            Console.WriteLine($"Adding question {q1.Header} to log at {logFolder}");
        }
    }
}
