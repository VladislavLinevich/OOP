using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
     class SnapshotClient: ICloneable
    {
        public int SumOnCard { get; set; }
        public int Salary { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PassportNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public List<Account> accounts { get; set; }
        public List<Credit> credits { get; set; }
        public List<InstallmentPlan> InstallmentPlans { get; set; }

        public SnapshotClient( int SumOnCard, int Salary, string FullName, string PhoneNumber, string Password, string Email, string PassportNumber, string IdentificationNumber, List<Account> accounts, List<Credit> credits, List<InstallmentPlan> InstallmentPlans)
        {
            this.SumOnCard = SumOnCard;
            this.Salary = Salary;
            this.FullName = FullName;
            this.PhoneNumber = PhoneNumber;
            this.Password = Password;
            this.Email = Email;
            this.PassportNumber = PassportNumber;
            this.IdentificationNumber = IdentificationNumber;
            this.accounts = new List<Account>();
            for (int i = 0; i < accounts.Count; i++ )
            {
                this.accounts.Add(accounts[i].Clone() as Account);
            }
            this.credits = new List<Credit>();
            for (int i = 0; i < credits.Count; i++)
            {
                this.credits.Add(credits[i].Clone() as Credit);
            }
            this.InstallmentPlans = new List<InstallmentPlan>();
            for (int i = 0; i < InstallmentPlans.Count; i++)
            {
                this.InstallmentPlans.Add(InstallmentPlans[i].Clone() as InstallmentPlan);
            }
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
    class CaretakerClients
    {
        private List<Stack<SnapshotClient>> snapshots = new List<Stack<SnapshotClient>>();
        public CaretakerClients()
        {
            for (int i = 0; i < 100; i++)
            {
                snapshots.Add(new Stack<SnapshotClient>());
            }
        }
        public void Save(SnapshotClient snapshot, int k)
        {
            snapshots[k].Push(snapshot);
        }
        public SnapshotClient Restore(int k)
        {
            var result = snapshots[k].Pop();
            return result.Clone() as SnapshotClient;
        }
    }

    class SnapshotSpecialist: ICloneable
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string IdentificationNumber { get; set; }
        public Company company { get; set; }
        public SnapshotSpecialist(string FullName, string PhoneNumber, string Password, string IdentificationNumber, Company company)
        {
            this.FullName = FullName;
            this.PhoneNumber = PhoneNumber;
            this.Password = Password;
            this.IdentificationNumber = IdentificationNumber;
            this.company = company.Clone() as Company;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
    class CaretakerSpecialists
    {
        private List<Stack<SnapshotSpecialist>> snapshots = new List<Stack<SnapshotSpecialist>>();
        public CaretakerSpecialists()
        {
            for (int i = 0; i < 5; i++)
            {
                snapshots.Add(new Stack<SnapshotSpecialist>());
            }
        }
        public void Save(SnapshotSpecialist snapshot, int k)
        {
            snapshots[k].Push(snapshot);
        }
        public SnapshotSpecialist Restore(int k)
        {
            var result = snapshots[k].Pop();
            return result.Clone() as SnapshotSpecialist;
        }
    }
}
