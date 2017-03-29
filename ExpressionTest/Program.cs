using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Student, bool> fun = t => t.Name == "shaoqi";

            Expression<Func<Student, bool>> expression = t => t.Name == "shaoqi";
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string sex { get; set; }
    }
}
