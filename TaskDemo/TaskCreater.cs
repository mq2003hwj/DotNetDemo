using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo
{
    public class TaskCreater
    {
        public static Task CreateTaskWithVoidMethod(CancellationToken token, TaskCreationOptions creationOptions)
        {
            var a = new Task(() => 
            {
                for (int i =1; i <= 3; i++)
                {
                    Console.WriteLine("线程一运行至:" + i);

                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("外部通知线程取消");
                        token.ThrowIfCancellationRequested();
                        return;
                    }

                    Thread.Sleep(100);
                }
            }, token, creationOptions);

            return a;
        }

        public static Task CreateTaskWithParameterMethod(int max, CancellationToken token, TaskCreationOptions creationOptions)
        {
            var a = new Task((m) =>
            {
                for (int i = 1; i <= (int)m; i++)
                {
                    Console.WriteLine("线程二运行至:" + i);
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("外部通知线程取消");
                        token.ThrowIfCancellationRequested();
                        return;
                    }
                    Thread.Sleep(100);
                }
            }, max, token,creationOptions);

            return a;
        }

        public static Task<int> CreateTaskWithVoidAndReturnMethod()
        {
            var a = new Task<int>(() =>
            {
                for (int i = 1; i <= 3; i++)
                {
                    Console.WriteLine("线程三运行至:" + i);
                    Thread.Sleep(100);
                }
                return 200;
            });

            return a;
        }

        public static Task<int> CreateTaskWithParameterAndReturnMethod(int max)
        {
            var a = new Task<int>((m) =>
            {
                for (int i = 1; i <= (int)m; i++)
                {
                    Console.WriteLine("线程四运行至:" + i);
                    Thread.Sleep(100);
                }
                return 500;

            }, max, TaskCreationOptions.None);

            return a;
        }

    }
}
