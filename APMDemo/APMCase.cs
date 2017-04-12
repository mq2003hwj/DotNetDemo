using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace APMDemo
{
    public class APMCase
    {
        delegate void DelWorkVoid();
        delegate void DelWorkParameter(int count);
        delegate int DelWorkVoidReturn();
        delegate int DelWorkParameterReturn(int count);

        public static void DelegateVoidCase()
        {
            var workVoid = new DelWorkVoid(BusyWork.WorkVoid);
            workVoid.BeginInvoke(null, null);

            Console.WriteLine("主线程运行到这里了");
        }

        public static void DelegateParameterCase()
        {
            var workParameter = new DelWorkParameter(BusyWork.WorkParameter);
            workParameter.BeginInvoke(30,null, null);

            Console.WriteLine("主线程运行到这里了");
        }

        public static void DelegateVoidReturnCase()
        {
            var workVoidReturn = new DelWorkVoidReturn(BusyWork.WorkVoidReturn);
            workVoidReturn.BeginInvoke((ar) =>
            {
                var sourceDel = (DelWorkVoidReturn)ar.AsyncState;
                var result = sourceDel.EndInvoke(ar);
                //var sourceDel = (DelWorkVoidReturn)((AsyncResult)ar.AsyncState).AsyncDelegate;
                //var result = workVoidReturn.EndInvoke(ar);

                Console.WriteLine("EndInvoke结束执行，并把结果拿到" + result);
            }, workVoidReturn);

            Console.WriteLine("主线程运行到这里了");
        }

        public static void DelegateParameterReturnCase()
        {
            var workParameterReturn = new DelWorkParameterReturn(BusyWork.WorkParameterReturn);
            workParameterReturn.BeginInvoke(35, (ar) =>
                {
                    var sourceDel = (DelWorkParameterReturn)ar.AsyncState;
                    var result = sourceDel.EndInvoke(ar);

                    Console.WriteLine("EndInvoke结束执行，并把结果拿到" + result);
                },workParameterReturn);

            Console.WriteLine("主线程运行到这里了");
        }

    }
}
