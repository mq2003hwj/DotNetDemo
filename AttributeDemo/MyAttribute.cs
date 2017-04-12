using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttributeDemo
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MyAttribute : Attribute
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }

        public MyAttribute(string name, string date, string description)
        {
            this.Name = name;
            this.Date = date;
            this.Description = description;
        }

        public MyAttribute() { }
    }
}
