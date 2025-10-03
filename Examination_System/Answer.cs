using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class Answer
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public Answer(string text , bool isCorrect = false)
        {
            Text = text;
            IsCorrect = isCorrect;
        }

        public override string ToString()
        {
            return $"{Text} {(IsCorrect ? "correctAnswer" : "")}";
        }
    }
}
