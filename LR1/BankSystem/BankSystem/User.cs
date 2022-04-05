using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public abstract class User
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public string Password { get; set; }
    }

    public class Client: User
    {
        public string Email { get; set; } 
        public string PassportNumber { get; set; }
        public int SumOnCard;
        public int Salary { get; set; }
        public List<Account> accounts { get; set; }
        public List<Credit> credits { get; set; }
        public List<InstallmentPlan> InstallmentPlans { get; set; }
        public Client(string fullName, string phoneNumber, string password, string email, string passportNumber, string identificationNumber)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Password = password;
            Email = email;
            PassportNumber = passportNumber;
            IdentificationNumber = identificationNumber;
            accounts = new List<Account>();
            credits = new List<Credit>();
            InstallmentPlans = new List<InstallmentPlan>();
            SumOnCard = 0;
        }
        public void CreateCredit(Credit credit)
        {
            credits.Add(credit);
        }
        public void CreateInstallmentPlan(InstallmentPlan installmentPlan)
        {
            InstallmentPlans.Add(installmentPlan);
        }
        public SnapshotClient CreateSnapshot()
        {
            var snapshot = new SnapshotClient(SumOnCard, Salary, FullName, PhoneNumber, Password, Email, PassportNumber, IdentificationNumber, accounts, credits, InstallmentPlans);
            return snapshot;
        }
        public void Restore(SnapshotClient snapshot)
        {
            SumOnCard = snapshot.SumOnCard;
            Salary = snapshot.Salary;
            FullName = snapshot.FullName;
            PhoneNumber = snapshot.PhoneNumber;
            Password = snapshot.Password;
            Email = snapshot.Email;
            PassportNumber = snapshot.PassportNumber;
            IdentificationNumber = snapshot.IdentificationNumber;
            accounts.Clear();
            for (int i = 0; i < snapshot.accounts.Count; i++)
            {
                accounts.Add(snapshot.accounts[i]);
            }
            credits.Clear();
            for (int i = 0; i < snapshot.credits.Count; i++)
            {
                credits.Add(snapshot.credits[i]);
            }
            InstallmentPlans.Clear();
            for (int i = 0; i < snapshot.InstallmentPlans.Count; i++)
            {
                InstallmentPlans.Add(snapshot.InstallmentPlans[i]);
            }
        }
    }

    public class Operator : User
    {
        public List<string> OperatorLogs { get; set; }
        public Operator(string password, string id, string fullName, string phoneNumber)
        {
            Password = password;
            IdentificationNumber = id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            OperatorLogs = new List<string>();
        }
    }

    public class Manager : User
    {
        public List<string> ManagerLogs { get; set; }
        public List<Client> ApproveClient { get; set; }
        public List<Credit> ApproveCredits { get; set; }
        public List<InstallmentPlan> ApproveInstallment { get; set; }
        public List<string> ClientIDCredits { get; set; }
        public List<string> ClientIDInstallment { get; set; }
        public Manager(string password, string id, string fullName, string phoneNumber)
        {
            Password = password;
            IdentificationNumber = id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            ManagerLogs = new List<string>();
            ApproveClient = new List<Client>();
            ApproveCredits = new List<Credit>();
            ClientIDCredits = new List<string>();
            ClientIDInstallment = new List<string>();
            ApproveInstallment = new List<InstallmentPlan>();
        }
    }

    public class Specialist : User
    {
        public Company company { get; set; }
        public Specialist(string password, string id, string fullName, string phoneNumber, Company company)
        {
            Password = password;
            IdentificationNumber = id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            this.company = company;
        }
        public void Transfer(Company company, int sum)
        {
            if (this.company.Sum - sum > 0)
            {
                company.Sum += sum;
                this.company.Sum -= sum;
            }
        }
        public SnapshotSpecialist CreateSnapshot()
        {
            var snapshot = new SnapshotSpecialist(FullName, PhoneNumber, Password, IdentificationNumber, company);
            return snapshot;
        }
        public void Restore(SnapshotSpecialist snapshot)
        {
            FullName = snapshot.FullName;
            PhoneNumber = snapshot.PhoneNumber;
            Password = snapshot.Password;
            company = snapshot.company;
            IdentificationNumber = snapshot.IdentificationNumber;
        }
    }

    public class Administrator : User
    {
        public List<string> AdminLogs { get; set; }
        public CaretakerClients caretakerClients { get; set; }
        public CaretakerSpecialists caretakerSpecialists { get; set; }
        public Administrator(string password, string id, string fullName, string phoneNumber)
        {
            Password = password;
            IdentificationNumber = id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            AdminLogs = new List<string>();
            caretakerClients = new CaretakerClients();
            caretakerSpecialists = new CaretakerSpecialists();
        }
    }

}
