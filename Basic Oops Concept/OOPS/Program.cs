using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region Inheritance
            Console.WriteLine("Inheritance called");

            //Inheritance derived = new Derived();
            //Derived derived = new Inheritance();
            Derived derived = new Derived();

            derived.Name = "Test";
            derived.Add = "Testing";
            derived.Salary = 1000;

            derived.Hidden();

            ((Inheritance)derived).Hidden();
            #endregion

            #region Polymorphism

            #region CompileTimePolymorphism
            CompileTimePolymorphism polymorphism = new CompileTimePolymorphism();

            int id = 1;
            string name = "Test";

            polymorphism.PolymorphismMethod();
            polymorphism.PolymorphismMethod(id);
            polymorphism.PolymorphismMethod(name);
            polymorphism.PolymorphismMethod(name,id);
            polymorphism.PolymorphismMethod(id,name);
            #endregion

            #region RunTimePolimorphism
            Polymorphism runTimePolimorphism = new RunTimePolimorphism();

            //access derived class method from base class
            runTimePolimorphism.Run();

            #endregion

            #endregion

            #region Abstraction
            //there are two way for abtraction one is using abstract class and method and second is interface

            IBank SBI = Abstraction.GetBankObject("SBI");
            SBI.Validatecard();
            SBI.CheckBalance();
            SBI.WithdrawMoney();

            IBank HDFC = Abstraction.GetBankObject("HDFC");
            HDFC.Validatecard();
            HDFC.CheckBalance();
            HDFC.WithdrawMoney();

            #endregion

            #region Encapsulation
            try
            {
                Encapsulation obj = new Encapsulation();
                //cant access Amount Directly
                //obj.Amount = 10;

                obj._Amount = 10;
                Console.WriteLine(obj._Amount);

                obj._Amount = -10;
                Console.WriteLine(obj._Amount);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            #region Constructor

            Console.WriteLine(constructor.static_name);

            constructor first = new constructor();
            first = null;
            GC.Collect();
            constructor second = new constructor(2, "test");
            Console.WriteLine("Ctor number =" + second.number + "  Name = " + second.name);

            constructor copycon = new constructor(second);
            Console.WriteLine("Ctor number =" + copycon.number + "  Name = " + copycon.name);

            Console.WriteLine(constructor.static_name);
            #endregion

            #region Operator Overloading

            OperatorOverloading op1 =new OperatorOverloading(5,6);
            OperatorOverloading op2 =new OperatorOverloading(6,7);
            OperatorOverloading op = op1 + op2;
            Console.WriteLine($"total numer is {op.num} and age is {op.age}");

            #endregion

            #region Partial Class

            PartialClass partial = new PartialClass();
            partial.CustomerMethod();

            IEmployee _emp = new PartialClass();
            _emp.EmployeeMethod();

            #endregion

            #region ExtensionMethod
            Console.WriteLine("ExtensionMethod Called");

            ExtensionMethod extension = new ExtensionMethod();
            extension.Test1();
            extension.Test2();
            extension.Test3();
            extension.Test4(5);
            extension.Test5();

            #endregion

            #region Command Line Arguments

            //to set argument vale go to project properties then debug section
            int argument1 = Convert.ToInt32(args[0]);
            double argument2 = Convert.ToDouble(args[1]);
            string argument3 = args[2];

            Console.WriteLine($"Command Line Argument1 is {argument1}");
            Console.WriteLine($"Command Line Argument2 is {argument2}");
            Console.WriteLine($"Command Line Argument3 is {argument3}");
            Console.WriteLine($"Command Line Argument3 is {args[2]}");
            //default it gives values as string
            Console.WriteLine($"Command Line Argument2 is {args[1]}");


            #endregion

            Console.ReadKey();
        }
    }
}
