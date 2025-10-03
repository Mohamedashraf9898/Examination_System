using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public AnswerList Answers { get; set; }
        public Question() : this("Default Header", "Default Body", 1) { }
        public Question( string header , string body , int marks)
        {
            Header = header;
            Body = body;
            Marks = marks;
            Answers = new AnswerList();
        }

        public abstract string GetQuestion();
        public override string ToString()
        {
            return $"{Header}-  {Body} ({Marks} marks)";
        }
    }
}
