using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            uint count = 0;

            for (uint i = 0; i < 1000000000; i++)
            {
                count = count + i;
            }
            Console.WriteLine(count);


        A:
            {
                Console.WriteLine("1---------------SingleTaskCreateAndExcute:");
                Console.WriteLine("2---------------Task.WaitAll:");
                Console.WriteLine("3---------------Task.WaitAllAndGetResult:");
                Console.WriteLine("4---------------Task.TaskContinueCase:");
                Console.WriteLine("5---------------Task.ParentTaskNorlmalCase:");
                Console.WriteLine("6---------------Task.ParentTaskAttachedToParentCase:");
                Console.WriteLine("7---------------Task.TaskCancellationCase:");
                Console.WriteLine("8---------------Task.AsyncAwaitCase:");
                Console.WriteLine("请选择TaskCase:");

                try
                {
                    var item = int.Parse(Console.ReadLine());
                    switch (item)
                    {
                        case 1:
                            TaskCaseCreater.SingTaskCase();
                            break;
                        case 2:
                            TaskCaseCreater.TaskWaitCase();
                            break;
                        case 3:
                            TaskCaseCreater.TaskWaitAndGetResultCase();
                            break;
                        case 4:
                            TaskCaseCreater.TaskContinueCase();
                            break;
                        case 5:
                            TaskCaseCreater.ParentTaskNorlmalCase();
                            break;
                        case 6:
                            TaskCaseCreater.ParentTaskAttachedToParentCase();
                            break;
                        case 7:
                            TaskCaseCreater.TaskCancellationCase();
                            break;
                        case 8:
                            TaskCaseCreater.AsyncAwaitCase();
                            break;
                        default:
                            {
                                Console.WriteLine("请输入正确的选择!");
                                goto A;
                            }
                    }

                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("请输入数字!");
                    goto A;
                }
            }
        }
    }
}
