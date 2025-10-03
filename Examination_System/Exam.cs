using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public enum ExamMode 
    {
        Queued,
        Starting,
        Finished
    }
    public abstract class Exam : ICloneable , IComparable<Exam>
    {
        public TimeSpan Time { get; set; }
        public QuestionList Questions { get; set; }
        public int NumberOfQuestion => Questions.Count;
        public Subject Subj {  get; set; }
        public ExamMode Mode { get; set; }
        public Exam(TimeSpan time , Subject subj, string logFile)
        {
            Time = time;
            Subj = subj;
            Questions = new QuestionList(logFile);
            Mode = ExamMode.Queued;
        }
        public event EventHandler ExamStarted;
        public abstract void ShowExam();
        public void StartExam()
        {
            Mode= ExamMode.Starting;
            ExamStarted?.Invoke(this, EventArgs.Empty);
        }
        public void AddQuestion(Question ques)
        {
            //Questions[ques] = ques.Answers;
            Questions.Add(ques, ques.Answers);
        }

        public override string ToString()
        {
            return $"Exam for {Subj.Name} | Duration: {Time} | Questions: {NumberOfQuestion}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(Exam? other)
        {
            return this.Time.CompareTo(other?.Time);
        }


        public override bool Equals(object? obj)
        {
            if (obj is Exam e)
            {
                return Subj.Id == e.Subj.Id && Time == e.Time;
            }
            else 
                return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Subj.Id, Time);
        }
    }
}
