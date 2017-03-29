using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverringTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Son son = new Son();
            //son.Name = "sss";
            Console.WriteLine(son.Name);
            Console.Write(son.say("ddd"));
            Console.ReadKey();
        }
    }


    public abstract class father
    {
        public abstract string Name { get; }

        //public abstract string talk(string content);
        public virtual string say(string content)
        {
            return content + "father";
        }

    }

    public class Son : father
    {

        public override string say(string content)
        {
            content = content + "son";
            return content;//base.say(content);
        }



        public override string Name
        {
            get { return "dd"; }
        }
    }
}
