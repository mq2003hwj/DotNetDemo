using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttributeTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var info =typeof(MyCode);
            var classAttribute = (MyVersionAttribute)Attribute.GetCustomAttribute(info, typeof(MyVersionAttribute));
            Console.WriteLine(classAttribute.Name+" "+classAttribute.Description+" "+classAttribute.Date);

            Console.Read();
        }
    }
}
