using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnumerableyieldDemo
{
    public class MyEnumerator : IEnumerator<int>
    {
        public int[] MyArray { get; set; }
        private int Index { get; set; }

        public MyEnumerator()
        {
            Index = 0;
            MyArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

        public int Current
        {
            get
            {
                return MyArray[Index - 1];
            }
        }

        public bool MoveNext()
        {
            Index++;
            if (Index > 10)
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
            Index = -1;
        }

        public void Dispose()
        {
            MyArray = null;
        }

        object System.Collections.IEnumerator.Current
        {
            get { throw new NotImplementedException(); }
        }
    }
}
