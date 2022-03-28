using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public abstract class Credit
    {
        public double Sum { get; set; }
        public double Bid { get; set; }
        public double Time { get; set; }
        public double platezh { get; set; }
        public abstract void MonthlyPayment();
        public Credit (double sum, double bid, double time)
        {
            Sum = sum;
            Bid = bid;
            Time = time;
        }
        public abstract object Clone();
    }
    public class AnnuityCredit: Credit, ICloneable
    {
        private double firstsum;
        public AnnuityCredit(double sum, double bid, double time) : base(sum, bid, time)
        {
            firstsum = sum;
            double P = Bid / 100.0 / 12;
            platezh = (firstsum * (P + P / (Math.Pow((1 + P), Time) - 1)));
        }
        public override void MonthlyPayment()
        {
            if (Time > 0)
            {
                double I = Sum * Bid / 100.0 / 12;
                Sum = Sum - (platezh - I);
                Time--;
            }
        }
        public override object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class DifferentiatedCredit : Credit, ICloneable
    {
        private double firstsum;
        private double firstTime;
        public DifferentiatedCredit(double sum, double bid, double time) : base(sum, bid, time)
        {
            firstsum = sum;
            firstTime = time;
            platezh = sum * bid / 100.0 / 12 + sum / time;
        }
        public override void MonthlyPayment()
        {
            if (Time > 0)
            {
                double P = Bid / 100.0 / 12;
                double b = firstsum / firstTime;
                double p = Sum * P;
                platezh = p + b;
                Sum = Sum - b;
                Time--;
            }
        }
        public override object Clone()
        {
            return MemberwiseClone();
        }
    }
}
