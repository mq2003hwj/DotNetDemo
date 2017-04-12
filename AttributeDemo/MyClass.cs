using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttributeDemo
{
    [MyAttribute(Name="Test",Date="2016-10-31",Description="Test Description")]
    public class MyClass
    {
        public int value { get; set; }
    }
}
