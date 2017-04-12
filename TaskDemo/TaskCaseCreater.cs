using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo
{
    public class TaskCaseCreater
    {
        public static void SingTaskCase()
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var task1 = TaskCreater.CreateTaskWithVoidMethod(token, TaskCreationOptions.None);
            task1.Start();

            var task2 = TaskCreater.CreateTaskWithParameterMethod(5, token, TaskCreationOptions.None);
            task2.Start();

            var task3 = TaskCreater.CreateTaskWithVoidAndReturnMethod();
            task3.Start();
            Console.WriteLine("线程三结束,返回值:" + task3.Result);

            var task4 = TaskCreater.CreateTaskWithParameterAndReturnMethod(5);
            task4.Start();
            Console.WriteLine("线程四结束,返回值:" + task4.Result);

        }

        public static void TaskWaitCase()
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var task1 = TaskCreater.CreateTaskWithVoidMethod(token, TaskCreationOptions.None);
            task1.Start();

            var task2 = TaskCreater.CreateTaskWithParameterMethod(5,token,TaskCreationOptions.None);
            task2.Start();

            Task.WaitAll(task1,task2);
            Console.WriteLine("全部线程执行完毕才会执行到这里");
        }

        public static void TaskWaitAndGetResultCase()
        {
            var task1 = TaskCreater.CreateTaskWithVoidAndReturnMethod();
            task1.Start();

            var task2 = TaskCreater.CreateTaskWithParameterAndReturnMethod(30);
            task2.Start();

            Task.WaitAll(task1,task2);
            Console.WriteLine("全部线程执行完毕才会执行到这里");
            Console.WriteLine("分别获取两个线程的返回值:【{0}】，【{1}】", task1.Result, task2.Result);
        }

        public static void TaskContinueCase()
        {
            var task1 = TaskCreater.CreateTaskWithParameterAndReturnMethod(30);
            task1.Start();

            task1.ContinueWith((task) =>
                {
                    Console.WriteLine("父线程执行完了才能执行到这里");
                    Console.WriteLine("获取父线程的返回值{0}",task.Result);
                });
        }

        public static void ParentTaskNorlmalCase()
        {
            var parentTask = new Task(() =>
            {
                var tokenSource = new CancellationTokenSource();
                var token = tokenSource.Token;
                var task1 = TaskCreater.CreateTaskWithVoidMethod(token, TaskCreationOptions.None);
                var task2 = TaskCreater.CreateTaskWithParameterMethod(7, token, TaskCreationOptions.None);

                task1.Start();
                task2.Start();
            });

            parentTask.Start();
            parentTask.Wait();

            Console.WriteLine("子线程后续还会执行");
        }

        public static void ParentTaskAttachedToParentCase()
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var parentTask = new Task(() =>
            {
                var task1 = TaskCreater.CreateTaskWithVoidMethod(token,TaskCreationOptions.AttachedToParent);
                var task2 = TaskCreater.CreateTaskWithParameterMethod(7,token, TaskCreationOptions.AttachedToParent);

                task1.Start();
                task2.Start();
            });

            parentTask.Start();
            parentTask.Wait();

            Console.WriteLine("所有子线程执行完才到这里");
        }

        public static void TaskCancellationCase()
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var task1 = TaskCreater.CreateTaskWithParameterMethod(100,token,TaskCreationOptions.None);
            task1.ContinueWith(_ => { Console.WriteLine("主线程监控到线程由于终止并执行ThrowIfCancellationRequested"); }, TaskContinuationOptions.OnlyOnCanceled);
            task1.Start();


            var task2 = new Task(() =>
            {
                for (int i = 1; i < 25; i++)
                {
                    Console.WriteLine("线程五运行到" + i);
                    Thread.Sleep(150);
                }
                tokenSource.Cancel();
                
            },token,TaskCreationOptions.None);

            task2.Start();
            Thread.Sleep(3000);
        }

        public static async void AsyncAwaitCase()
        {
            var t1 = BusyWork(30);
            var t2 = BusyWork(5);

            var result = await t1;
            var result2 = await t2;

            Console.WriteLine("线程执行完才会执行到这里" +result);

        }

        public static Task<int> BusyWork(int value)
        {
            var task = TaskCreater.CreateTaskWithParameterAndReturnMethod(value);
            task.Start();
            return task;
        }
    }
}
