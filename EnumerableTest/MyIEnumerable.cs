using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerableTest
{
    public class MyIEnumerable : IEnumerable
    {
        private string[] strList;

        public MyIEnumerable(string[] strlist)
        {
            this.strList = strlist;
        }


        public IEnumerator GetEnumerator()
        {
            //return new MyIEnumerator(strList);
            for (int i = 0; i < this.strList.Length; i++)
            {
                yield return this.strList[i];
            }
        }

        public IEnumerable<string> MyWhere(Func<string, bool> func)
        {
            foreach (var item in this.strList)
            {
                if (func(item))
                {
                    yield return item;
                }
            }
        }
    }


    public class MyIEnumerator : IEnumerator
    {
        private string[] strList;
        private int position;

        public MyIEnumerator(string[] _strList)
        {
            this.strList = _strList;
            position = -1;
        }

        public object Current
        {
            get { return this.strList[position]; }
        }

        public bool MoveNext()
        {
            position++;
            if (position < strList.Length)
                return true;
            else return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
