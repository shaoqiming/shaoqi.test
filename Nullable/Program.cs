using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullable
{
    class Program
    {
        static void Main(string[] args)
        {
            Nullable<int> x = 5;
            x=new Nullable<int>(5);
            Console.WriteLine("with value:");
            Dispaly(x);

            x = new Nullable<int>();
            Console.WriteLine("without value:");
            Dispaly(x);

            Console.ReadKey();
        }


        static void Dispaly(Nullable<int> x)
        {

            int? a = 4;
            int b = 3;
            int c = a.Value - b;
            Console.WriteLine("HasValue:{0}", x.HasValue);
            if (x.HasValue)
            {
                Console.WriteLine("Value:{0}", x.Value);
                Console.WriteLine("转化成int：{0}", (int)x);
            }

            Console.WriteLine("GetValueOrDefaule:{0}", x.GetValueOrDefault());
            Console.WriteLine("GetValueOrDefaule(10):{0}", x.GetValueOrDefault(10));
            Console.WriteLine("Tostring():{0}", x.ToString());
            Console.WriteLine("GetHasCode():{0}", x.GetHashCode());
            Console.WriteLine();
        }


    }
}
