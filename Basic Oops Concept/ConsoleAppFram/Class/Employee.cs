using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFram.Class
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public int Age { get; set; }
        public Employee()
        {
        }
        public Employee(string fName, string lName,double salary, int age)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Salary = salary;
            this.Age = age;
        }
    }
}
