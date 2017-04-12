using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APMDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
        A:
            {
                Console.WriteLine("1------------------------DelegateVoidCase");
                Console.WriteLine("2------------------------DelegateParameterCase");
                Console.WriteLine("3------------------------DelegateVoidReturnCase");
                Console.WriteLine("4------------------------DelegateParameterReturnCase");
                Console.WriteLine("5------------------------DelegateVoidCase");
                Console.WriteLine("6------------------------DelegateVoidCase");
                Console.WriteLine("7------------------------DelegateVoidCase");
                Console.WriteLine("8------------------------DelegateVoidCase");
                Console.WriteLine("9------------------------DelegateVoidCase");
                Console.WriteLine("10------------------------DelegateVoidCase");
            }

            try
            {
                var number = int.Parse(Console.ReadLine());

                switch (number)
                {
                    case 1:
                        APMCase.DelegateVoidCase();
                        break;
                    case 2:
                        APMCase.DelegateParameterCase();
                        break;
                    case 3:
                        APMCase.DelegateVoidReturnCase();
                        break;
                    case 4:
                        APMCase.DelegateParameterReturnCase();
                        break;
                    default:
                        goto A;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("请输入数字!");
                goto A;
            }



            Console.ReadLine();
        }
    }
}
