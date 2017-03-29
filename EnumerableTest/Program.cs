using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerableTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = { "dd", "ss", "bb", "tt" };

            MyIEnumerable my = new MyIEnumerable(str);

            var func = my.MyWhere(a => a.Contains("d"));

            var list = func.ToList();

            var tt = my.GetEnumerator();
            while (tt.MoveNext())
            {
                Console.WriteLine(tt.Current);
            }

            Console.WriteLine("=======================");

            foreach (var item in str)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
