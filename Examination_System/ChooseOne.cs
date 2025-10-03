using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class ChooseOne : Question
    {

        public ChooseOne(string header , string body , int marks , AnswerList answers) : base(header , body , marks)
        {
            Answers = answers;
        }
        public override string GetQuestion()
        {
            string result = $"{Header} \n {Body} \n";
            int i = 1;
            foreach(var answer in Answers)
            {
                result += $"{i}-{answer.Text}";
                i++;
            }
            return result;
        }
    }
}
