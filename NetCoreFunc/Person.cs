using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreFunc
{
    internal class Person
    {
        public string Name { get; set; }
        public string Sex { get; set; }

        public Person(string name, string sex)
        {
            Name = name;
            Sex = sex;
        }
        public override string ToString()
        {
            return $"PersonName:{this.Name},Sex:{this.Sex}";

        }
    }
}
