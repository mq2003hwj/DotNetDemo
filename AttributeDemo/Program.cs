using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttributeDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass
            {
                value = 1
            };

            var classAttribute = (MyAttribute)Attribute.GetCustomAttribute(typeof(MyClass), typeof(MyAttribute));
            Console.WriteLine(classAttribute.Name);
            Console.WriteLine(classAttribute.Date);
            Console.WriteLine(classAttribute.Description);
        }
    }
}
