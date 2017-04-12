using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnumerableyieldDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyEnumerable a = new MyEnumerable();
            foreach (var value in a)
            {
                Console.WriteLine(value);
            }
        }
    }
}
