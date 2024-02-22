using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class Polymorphism
    {
        public virtual void Run()
        {
            Console.WriteLine("Polymorphism Base Class");
        }
    }
    public class RunTimePolimorphism:Polymorphism
    {
        public sealed override void Run()
        {
            Console.WriteLine("RunTimePolimorphism");

            //base.Run();
        }
    }
    //public class Preventaccess: RunTimePolimorphism
    //{
    //    public override void Run()
    //    {
    //        Console.WriteLine("Preventaccess Class");
    //    }
    //}
    public class CompileTimePolymorphism
    {
        public void PolymorphismMethod()
        {
            Console.WriteLine("Polymorphism");
        }
        public void PolymorphismMethod(string name)
        {
            Console.WriteLine("Name = " + name);
        }
        public void PolymorphismMethod(int id)
        {
            Console.WriteLine("ID = " + id);
        }
        public void PolymorphismMethod(string name, int id)
        {
            Console.WriteLine("Name = " + name + " And ID = " + id);
        }
        public void PolymorphismMethod(int id, string name)
        {
            Console.WriteLine("ID = " + id + " And Name = " + name);
        }
    }
}
