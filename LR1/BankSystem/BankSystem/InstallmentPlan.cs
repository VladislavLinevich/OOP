using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public abstract class InstallmentPlan
    {
        public double Sum { get; set; }
        public double Time { get; set; }
        public double platezh { get; set; }
        public abstract void MonthlyPayment();
        public InstallmentPlan(double sum, double time)
        {
            Sum = sum;
            Time = time;
        }
        public abstract object Clone();
    }

    public class InterestFreeInstallment: InstallmentPlan, ICloneable
    {
        public InterestFreeInstallment(double sum, double time) : base(sum, time)
        {
            platezh = sum / time;
        }
        public override void MonthlyPayment()
        {
            if (Time > 0)
            {
                Sum = Sum - platezh;
                Time--;
            }
        }
        public override object Clone()
        {
            return MemberwiseClone();
        }
    }
}

