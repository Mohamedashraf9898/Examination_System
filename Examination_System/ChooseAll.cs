using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class ChooseAll : Question
    {

        public ChooseAll(string header , string body , int marks , AnswerList answers) : base(header , body , marks) 
        {
            Answers = answers;
        }
        public override string GetQuestion()
        {
            string result = $"{Header} \n {Body} \n ";
            int i = 1;
            foreach (var answer in Answers)
            {
                result += $"{i}- {answer.Text} \n";
                i++;
            }
            return result;

        }
    }
}
