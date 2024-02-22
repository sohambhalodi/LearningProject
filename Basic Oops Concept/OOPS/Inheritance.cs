using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class Inheritance
    {
        public string Name { get; set; }
        public string Add { get; set; }
        public void Hidden()
        {
            Console.WriteLine("Inheritance Hidden");
        }
    }
    public class Derived:Inheritance
    {
        public double Salary { get; set; }
        public new void Hidden()
        {
            Console.WriteLine("Derived Hidden");
        }
    }
}
