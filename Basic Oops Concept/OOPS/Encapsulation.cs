using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    internal class Encapsulation
    {
        private double Amount;
        public double _Amount {
            get 
            { 
                return Amount;
            }
            set 
            {
                if (value < 0)
                {
                    throw new Exception("Please Pass a Positive Value");
                }
                else
                {
                    Amount = value;
                }
            }
        }
    }
}
