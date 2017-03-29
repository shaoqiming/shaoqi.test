using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunInAndOut
{

    delegate T MyFunc<out T>();
    class Program
    {
        static void Main(string[] args)
        {
            MyFunc<string> fun = () => "shaoqi";
            MyFunc<object> fun1 = fun;


            IMotion<teacher> x=new Run<teacher>();
            IMotion<person> y = x;
        }
    }

    public class person
    {

    }

    public class teacher : person
    {

    }

    public interface IMotion<out T>
    { 
    
    }

    public class Run<T> : IMotion<T>
    { 
    
    }
}
