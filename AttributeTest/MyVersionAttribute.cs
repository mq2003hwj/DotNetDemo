using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttributeTest
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MyVersionAttribute:Attribute
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}
