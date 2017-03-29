using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
          
        }


        public void LinqDemo()
        {
            string[] KeysWords = { "dd", "ss*", "for", "if*", "ddd", "sdafd*" };


            IEnumerable<IGrouping<bool, string>> selections = from word in KeysWords
                                                              group word by word.Contains("*");


            var selection = from groups in selections
                            select new
                            {
                                Iskey = groups.Key,
                                Items = groups
                            };


            foreach (var item in selection)
            {
                Console.WriteLine(Environment.NewLine + "{0}:", item.Iskey ? "contextual KeyWords" : "Keywords");

                foreach (var items in item.Items)
                {
                    Console.WriteLine(" " + (item.Iskey ? items.Replace("*", null) : items));
                }
            }

            Console.ReadKey();
        }

        /// <summary>
        /// 优先级demo
        /// </summary>
    }
}
