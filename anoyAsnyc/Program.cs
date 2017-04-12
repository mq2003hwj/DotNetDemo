using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anoyAsnyc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Test();
        }

        public static async void Test()
        {
            Func<Task> a = () =>
            {
                return new TaskFactory().StartNew(() => { });
            };

            await a();
        }
    }
}
