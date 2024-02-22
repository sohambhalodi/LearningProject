using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public interface IEmployee
    {
        void EmployeeMethod();
    }
    public interface ICustomer
    {
        void CustomerMethod();
    }
    //partial class can have different interface as a base class but not class
        internal partial class PartialClass :IEmployee
    {
        public void EmployeeMethod()
        {
            Console.WriteLine("Employee Method Called");
        }
        //can't give access specifire under C# 9
        //partial method must have void return type
        //partial methods are private by default
        partial void Hello();
    }
    internal partial class PartialClass:ICustomer
    {
        public void CustomerMethod()
        {
            Console.WriteLine("Customer Method Called");
        }

        partial void Hello()
        {
            Console.WriteLine("Hello Partial Method Called");
        }
    }
}
