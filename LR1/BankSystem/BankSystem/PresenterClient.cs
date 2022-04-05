using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class PresenterClient
    {
        private Model model;
        public PresenterClient(Model model)
        {
            this.model = model;
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
        public Model Freeze(int n, int id, ref string str)
        {
            model.Freeze(n, id, ref str);
            return model;
        }
        public Model Transfer(int n, int sum, int loggedaccountNumber, int accountNumber, string transfername, string id, string BIC_bankName, ref string str, string clientName = "")
        {
            model.Transfer(n, sum, loggedaccountNumber, accountNumber, transfername, id, BIC_bankName, ref str, clientName);
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
    }
}
