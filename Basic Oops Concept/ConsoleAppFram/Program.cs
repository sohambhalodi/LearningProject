using ConsoleAppFram.Class;
using ConsoleAppFram.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegate = ConsoleAppFram.Functions.Delegate;

namespace ConsoleAppFram
{
    internal class Program
    {
        public delegate void MyDelegate(int x, int y);
        public delegate Employee EmpDelegate();
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Deligate
            Delegate.ClassAdd(4, 3);

            Console.ReadLine();
        }
        public class MyClass
        {
            public static void Add(int x, int y)
            {
                Console.WriteLine(x + y);
            }
            public static void Multiply(int x, int y)
            {
                Console.WriteLine(x * y);
            }
        }
    }
}
