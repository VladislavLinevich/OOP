using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class PresenterSpecialist
    {
        private Model model;
        public PresenterSpecialist(Model model)
        {
            this.model = model;
        }
        public Model Exit()
        {
            model.Exit();
            return model;
        }
        public Model FormSalaryProject(int n)
        {
            model.FormSalaryProject(n);
            return model;
        }
        public Model TransferCompany(int n, string name, int sum, ref string str)
        {
            model.TransferCompany(n, name, sum, ref str);
            return model;
        }
    }
}
