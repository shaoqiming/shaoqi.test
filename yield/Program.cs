using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yield
{
    class Program
    {
        static void Main(string[] args)
        {

            //var test1 = test();

            object[] values = { "a", "b", "c", "d", "e" };
            IterationSample collection = new IterationSample(values, 3);
            //foreach (var item in collection)
            //{
            //    Console.WriteLine(item);
            //}
            var tst=collection.GetEnumerator();
            while (tst.MoveNext())
            {
                Console.WriteLine(tst.Current);
            }


            Console.ReadKey();
        }

        public static bool test()
        {
            
            var i = 0;
            while (i < 9)
            {
                Console.WriteLine(i);
                if (i == 5) return true;
                i++;
            }

            return false;
        }
    }



    public class IterationSample : IEnumerable
    {
        public object[] values;
        public int startingPoint;

        public IterationSample(object[] values, int startingPoint)
        {
            this.values = values;
            this.startingPoint = startingPoint;
        }

        public IEnumerator GetEnumerator()
        {
            //return new IterationSampleIterator(this);

            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine(i);
                yield return values[(i + startingPoint) % values.Length];
                Console.WriteLine(i);
            }
        }
    }

    public class IterationSampleIterator : IEnumerator
    {
        IterationSample parent;
        int position;
        internal IterationSampleIterator(IterationSample parent)
        {
            this.parent = parent;
            this.position = -1;
        }
        public object Current
        {
            get
            {
                if (position == -1 || position == this.parent.values.Length)
                {
                    throw new InvalidOperationException();
                }
                int index = position + parent.startingPoint;
                index = index % parent.values.Length;
                return parent.values[index];
            }
        }

        public bool MoveNext()
        {
            if (this.position != parent.values.Length)
            {
                position++;
            }

            return position < this.parent.values.Length;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
