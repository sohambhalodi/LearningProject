using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    internal class constructor
    {
        public int number;
        public string name;
        public static string static_name;
        public constructor()
        {
            Console.WriteLine("Default Ctor");
        }

        //private constructor
        //it can't called outside of class
        //private constructor()
        //{
        //    Console.WriteLine("private");
        //}

        public constructor(int num, string uname)
        {
            number = num;
            name = uname;
            Console.WriteLine("Param Ctor");
        }

        //static ctor called as soon as class refranced its called one in life time
        //static constructor()
        //{
        //    static_name = "Static Name";
        //    Console.WriteLine("Static Ctor");
        //}

        public constructor(constructor obj) { 
            number = obj.number;
            name = obj.name;
        }

        ~constructor()
        {
            string type = GetType().Name;
            Console.WriteLine($"Destructor called for {type}");
        }
    }
}
