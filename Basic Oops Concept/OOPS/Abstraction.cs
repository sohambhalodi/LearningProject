using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class Abstraction
    {
        public static IBank GetBankObject(string BankType)
        {
            IBank bankObject= null;
            if (BankType == Constant.SBI)
            {
                bankObject = new SBI();
            }
            else if(BankType == Constant.HDFC){
                bankObject = new HDFC();
            }

            return bankObject;
        }
    }

    public abstract class IBank
    {
        public abstract void Validatecard();
        public abstract void CheckBalance();
        public abstract void WithdrawMoney();
    }
    public class SBI : IBank
    {
        public override void CheckBalance()
        {
            Console.WriteLine("SBI CheckBalance");
        }

        public override void Validatecard()
        {
            Console.WriteLine("SBI Validatecard");
        }

        public override void WithdrawMoney()
        {
            Console.WriteLine("SBI WithdrawMoney");
        }
    }
    public class HDFC : IBank
    {
        public override void CheckBalance()
        {
            Console.WriteLine("HDFC CheckBalance");
        }

        public override void Validatecard()
        {
            Console.WriteLine("HDFC Validatecard");
        }

        public override void WithdrawMoney()
        {
            Console.WriteLine("HDFC WithdrawMoney");
        }
    }
}
