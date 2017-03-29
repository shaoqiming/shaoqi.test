using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttrubuteTest
{
    class Program
    {
        static void Main(string[] args)
        {
              Output(typeof(MyClass1));
              Output(typeof(MyClass2));
              Output(typeof(MyClass3));

              Console.ReadKey();
        }


        static void Output(Type t)
        {
            Console.WriteLine("Class:" + t.ToString());

            var Attributes = t.GetCustomAttributes(true);

            foreach (var item in Attributes)
            {
                var attr = item as RoleAttribute;

                if (attr == null)
                {
                    return;
                }

                Console.WriteLine("    Name: {0}, IsEnable: {1}", attr.GetName(), attr.IsEnable);

            }

        }
    }

    class MyClass1
    {

    }
    [Role("Me2")]
    class MyClass2
    {

    }

    [Role("Me3"), Role("You", IsEnable = true)]
    class MyClass3
    {

    }
}
