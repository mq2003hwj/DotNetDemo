using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttributeTest
{
    [MyVersion(Name="MyCode",Description="Testing",Date="2017-03-31")]
    public class MyCode
    {
        public int Id { get; set; }
    }
}
