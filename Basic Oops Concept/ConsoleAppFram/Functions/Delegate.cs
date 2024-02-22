using ConsoleAppFram.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleAppFram.Program;

namespace ConsoleAppFram.Functions
{
    public class Delegate
    {
        public static void ClassAdd(int x, int y)
        {
            MyDelegate Delegate1 = new MyDelegate(MyClass.Add);
            //MyDelegate Delegate1 = MyClass.Add;
            Delegate1 += MyClass.Multiply;
            Delegate1(x, y);
        }
        public static Employee GetEmployee()
        {
            return new Employee();
        }
    }
}
