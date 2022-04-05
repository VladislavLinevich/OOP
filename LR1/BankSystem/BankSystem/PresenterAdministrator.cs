using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class PresenterAdministrator
    {
        private Model model;
        public PresenterAdministrator(Model model)
        {
            this.model = model;
        }
        public Model Exit()
        {
            model.Exit();
            return model;
        }
        public Model CancellationClient(int n, string ID, ref string str)
        {
            model.CancellationClient(n, ID, ref str);
            return model;
        }
        public Model CancellationSpecialist(int n, string ID, ref string str)
        {
            model.CancellationSpecialist(n, ID, ref str);
            return model;
        }
    }
}
