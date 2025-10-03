using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Subject(int id , string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return $"Subject : {Name} (ID: {Id})";
        }
    }
}
