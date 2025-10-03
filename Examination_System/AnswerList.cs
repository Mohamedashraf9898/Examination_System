using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class AnswerList : List<Answer>
    {
        public override string ToString()
        {
            string result = "";
            foreach (var answer in this)
            { 
                result += answer.ToString()+ Environment.NewLine;//Environment.NewLine == "\n"
            }
            return result;
        }
    }
}
