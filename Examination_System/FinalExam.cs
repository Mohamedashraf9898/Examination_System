using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class FinalExam : Exam
    {
        public FinalExam(TimeSpan time, Subject subj, string logFile) : base(time, subj, logFile) { }
    
        public override void ShowExam()
        {
            Console.WriteLine("==== Final Exam ====");
            foreach(var keyvaluepair in Questions)
            {
                keyvaluepair.Key.GetQuestion();
                Console.WriteLine("==========================================================");
            }
        }

    }
}
