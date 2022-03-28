using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public abstract class Transfer
    {
        public string Name { get; set; }
        public void transf(Account loggedclientaccount, Account newclientaccount, int sum)
        {
            loggedclientaccount.Sum -= sum;
            newclientaccount.Sum += sum;
        }
    }

    public class SWIFTTransfer: Transfer
    {
        public SWIFTTransfer()
        {
            Name = "SWIFT";
        }  
    }
    public class WesternUnionTransfer : Transfer
    {
        public WesternUnionTransfer()
        {
            Name = "WesternUnion";
        }
    }
}
