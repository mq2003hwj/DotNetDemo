using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace APMDemo
{
    public class BusyWork
    {
        public static void WorkVoid()
        {
            for (int i = 1; i < 20; i++)
            {
                Console.WriteLine("线程WorkVoid执行到"+i);
                Thread.Sleep(100);
            }
        }

        public static int WorkVoidReturn()
        {
            int i = 1;
            for (i = 1; i < 20; i++)
            {
                Console.WriteLine("线程WorkVoidReturn执行到" + i);
                Thread.Sleep(100);
            }

            return i;
        }

        public static void WorkParameter(int count)
        {
            for (int i = 1; i < count; i++)
            {
                Console.WriteLine("线程WorkParameter执行到" + i);
                Thread.Sleep(100);
            }
        }

        public static int WorkParameterReturn(int count)
        {
            int i = 1;
            for (i = 1; i < count; i++)
            {
                Console.WriteLine("线程WorkParameterReturn执行到" + i);
                Thread.Sleep(100);
            }

            return count;
        }
    }
}
