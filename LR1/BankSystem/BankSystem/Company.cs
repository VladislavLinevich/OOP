using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class Company: ICloneable
    {
        public string Type { get; set; }
        public string LegalName { get; set; }
        public string PAN { get; set; }
        public string BancBIC { get; set; }
        public string LegalAdress { get; set; }
        public int Sum { get; set; }
        public Company(string type, string legalName, string pan, string bancBIC, string legalAdress, int sum)
        {
            Type = type;
            LegalName = legalName;
            PAN = pan;
            BancBIC = bancBIC;
            LegalAdress = legalAdress;
            Sum = sum;
        }
        public delegate void SalaryProject(ref int sum, int salary);
        public SalaryProject project;
        public void AddSalaryProject(Bank bank)
        {
            project = bank.SalaryProject;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
