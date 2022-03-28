using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public abstract class Account
    {
        public int Sum { get; set; }
        public int Number { get; set; }
        public bool Freeze { get; set; }
        public Account (int sum, int number)
        {
            Sum = sum;
            Number = number;
            Freeze = false;
        }
        public abstract object Clone();
    }

    public class DepositAccount: Account, ICloneable
    {
        public int Percent { get; set; }
        public DepositAccount(int sum, int number, int percent): base(sum, number)
        {
            Percent = percent;
        }
        public override object Clone()
        {
            return MemberwiseClone();
        }
    }
}
