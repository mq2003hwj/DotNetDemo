using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerableyieldDemo
{
    public class MyEnumerable : IEnumerable<int>
    {
        public List<int> MyList = new List<int> { 100, 1000, 10000, 100000, 10000000 };

        public IEnumerator<int> GetEnumerator()
        {
            int value = MyList[0] + MyList[1];
            yield return GetResult(value);
            value = MyList[1] + MyList[2];
            yield return value;
            value = MyList.Sum();
            yield return GetResult(value);      
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private int GetResult(int value)
        {
            return value + 50;
        }
    }
}
