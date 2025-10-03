using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class TrueOrFalse : Question
    {
      
      
        public TrueOrFalse(string header , string body , int marks): base(header , body , marks)
        {
            Answers = new AnswerList
            {
                new Answer("true" , true),
                new Answer ("false" , false)
            };
        }
        public override string GetQuestion()
        {
            return $"{Header} \n {Body} \n 1.True \n 2.False";
        }
    }
}
