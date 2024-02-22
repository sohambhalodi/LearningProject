using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    internal class ExtensionMethod
    {
        public int x = 100;
        public void Test1()
        {
            Console.WriteLine("Method one: " + this.x);
        }
        public void Test2()
        {
            Console.WriteLine("Method two: " + this.x);
        }
    }
    //new class and their methods must be static and first parameter always {this class_name object_name}
    internal static class NewClass
    {
        public static void Test3(this ExtensionMethod O)
        {
            Console.WriteLine("Method Three");
        }
        public static void Test4(this ExtensionMethod O, int x)
        {
            Console.WriteLine("Method Four: " + x);
        }
        public static void Test5(this ExtensionMethod O)
        {
            Console.WriteLine("Method Five:" + O.x);
        }
    }
}
