using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    internal class OperatorOverloading
    {
        public int num;
        public int age;

        public OperatorOverloading()
        {
        }

        public OperatorOverloading(int num, int age)
        {
            this.num = num;
            this.age = age;
        }
        //must be static
        public static OperatorOverloading operator +(OperatorOverloading op1,OperatorOverloading op2)
        {
            OperatorOverloading op = new OperatorOverloading();
            op.num= op1.num + op2.num;
            op.age= op1.age + op2.age;
            return op;
        }
    }
}
