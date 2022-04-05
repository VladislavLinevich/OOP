using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public abstract class Bank
    {
        protected string legalName;
        public string BankBIC { get; set; }
        public List<Client> clients { get; set; }
        //public List<Company> companies { get; set; }
        public Operator _operator { get; set; }
        public Manager manager { get; set; }
        public List<Specialist> specialists { get; set; }
        public Administrator administrator { get; set; }
        public Bank()
        {
            clients = new List<Client>();
            //companies = new List<Company>();
            specialists = new List<Specialist>();
        }
        public string LegalName
        {
            get
            {
                return legalName;
            }
        }
        public void Register(string fullName, string phoneNumber, string password, string email, string passportNumber, string identificationNumber)
        {
            clients.Add(new Client(fullName, phoneNumber, password, email, passportNumber, identificationNumber));
        }
        public void OpenAccount(Account account, Client client)
        {
            client.accounts.Add(account);
        }
        public void StoredAccount(Client client)
        {
            foreach (DepositAccount account in client.accounts)
            {
                if (account.Freeze == false)
                {
                    account.Sum = account.Sum + (int)(((float)account.Percent / 100.0) * (float)account.Sum);
                }    
            }
        }
        public void Withdraw(Client client, int sum, int id)
        {
            foreach (Account account in client.accounts)
            {
                if (sum < account.Sum && account.Number == id)
                {
                    account.Sum -= sum;
                }
            }
        }
        public void Transfer(Transfer transfer, Account loggedclientaccount, Account newclientaccount, int sum)
        { 
            transfer.transf(loggedclientaccount, newclientaccount, sum);         
        }
        public void Accumulation(Client client, int sum, int id)
        {
            foreach (Account account in client.accounts)
            {
                if (account.Freeze == false && account.Number == id)
                {
                    account.Sum += sum;
                }
            }
        }
        public void Block(Client client, int ID)
        {
            foreach (Account account in client.accounts)
            {
                if (account.Number == ID)
                {
                    client.accounts.Remove(account);
                    break;
                }
            }
        }
        public void Freeze(Client client, int ID, ref string str)
        {
            foreach (Account account in client.accounts)
            {
                if (account.Number == ID)
                {
                    account.Freeze = true;
                    str = $"Account with number {account.Number} freeze";
                }
            }
        }
        public abstract void SalaryProject(ref int sum, int salary);
    }

    public class BelarusBank : Bank
    {
        public BelarusBank(): base()
        {
            legalName = "BelarusBank";
            BankBIC = "AKBBBY2X";
        }
        public override void SalaryProject(ref int sum, int salary)
        {
            sum += salary - (int)(0.003 * (double)salary);
        }
    }

    public class BelinvestBank : Bank
    {
        public BelinvestBank(): base()
        {
            legalName = "BelinvestBank";
            BankBIC = "BLBBBY2X";
        }
        public override void SalaryProject(ref int sum, int salary)
        {
            sum += salary - (int)(0.005 * (double)salary);
        }
    }

    public class AlphaBank : Bank
    {
        public AlphaBank(): base()
        {
            legalName = "AlphaBank";
            BankBIC = "ALFABY2X";
        }
        public override void SalaryProject(ref int sum, int salary)
        {
            sum += salary - (int)(0.001 * (double)salary);
        }
    }
}

