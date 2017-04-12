using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AwaitTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            DisplayValue();

            Console.WriteLine("Main thread is over");

            Console.ReadKey();
        }

        public static Task<int> GetValueAsync(int num1, int num2,int count)
        {
            return Task.Run(()=>
                {
                    for (int i = 0; i < count; i++)
                    {
                        num1 = num1 + i + num2;
                    }

                    return num1;
                });
        }

        public static async void DisplayValue()
        {
            double result = await GetValueAsync(1,1,100);
            double result2 = await GetValueAsync(55, 32, 100000000);

            Console.WriteLine("value is " + result);
            Console.WriteLine("value is " + result2);
        }

        
    }
}
