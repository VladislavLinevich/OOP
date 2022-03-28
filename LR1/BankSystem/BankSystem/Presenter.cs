using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class Presenter
    {
        private Model model;
        public Presenter(Model model)
        {
            this.model = model;
        }

        public Model Registration(int n, string phoneNumber, string passportNumber, string ID, string name, string email, string password)
        {
            phoneNumber = phoneNumber.Trim();
            passportNumber = passportNumber.Trim();
            ID = ID.Trim();
            name = name.Trim();
            email = email.Trim();
            password = password.Trim();

            model.Registration(n, phoneNumber, passportNumber, ID, name, email, password);
            return model;
        }

        public Model LogIn(int n, string ID, string password)
        {
            ID = ID.Trim();
            password = password.Trim();
            model.LogIn(n, ID, password);
            return model;
        }
        public Model Exit()
        {
            model.Exit();
            return model;
        }
        public Model OpenAccount(int n, int sum, int number, int percent)
        {
            model.OpenAccount(n, sum, number, percent);
            return model;
        }
        public Model StoredAccount(int n)
        {
            model.StoredAccount(n);
            return model;
        }
        public Model Withdraw(int n, int sum, int id)
        {
            model.Withdraw(n, sum, id);
            return model;
        }
        public Model Accumulate(int n, int sum, int id)
        {
            model.Accumulate(n, sum, id);
            return model;
        }
        public Model Block(int n, int id)
        {
            model.Block(n, id);
            return model;
        }
        public Model Freeze(int n, int id)
        {
            model.Freeze(n, id);
            return model;
        }
        public Model Transfer(int n, int sum, int loggedaccountNumber, int accountNumber, string transfername, string id, string BIC_bankName, string clientName = "")
        {
            model.Transfer(n, sum, loggedaccountNumber, accountNumber, transfername, id, BIC_bankName, clientName);
            return model;
        }
        public Model CreateCredit(int n, double sum, double bid, double time, string CreditType)
        {
            model.CreateCredit(n, sum, bid, time, CreditType);
            return model;
        }
        public Model MonthlyPayed(int n)
        {
            model.MonthlyPayed(n);
            return model;
        }
        public Model CreateInstallmentPlan(int n, double sum, double time)
        {
            model.CreateInstallmentPlan(n, sum, time);
            return model;
        }
        public Model MonthlyPayedInstllment(int n)
        {
            model.MonthlyPayedInstllment(n);
            return model;
        }
        public Model FormSalaryProject(int n)
        {
            model.FormSalaryProject(n);
            return model;
        }
        public Model AddSalary(int salary)
        {
            model.AddSalary(salary);
            return model;
        }
        public Model ClientSalaryProject(int n, string name)
        {
            model.ClientSalaryProject(n, name);
            return model;
        }
        public Model TransferCompany(int n, string name, int sum)
        {
            model.TransferCompany(n, name, sum);
            return model;
        }
        public Model CancellationClient(int n, string ID)
        {
            model.CancellationClient(n, ID);
            return model;
        }
        public Model CancellationSpecialist(int n, string ID)
        {
            model.CancellationSpecialist(n, ID);
            return model;
        }
        public Model CancellationSpecialistManager(int n, string ID)
        {
            model.CancellationSpecialistManager(n, ID);
            return model;
        }
        public Model Approve(int n, string ID)
        {
            model.Approve(n, ID);
            return model;
        }
    }
}
