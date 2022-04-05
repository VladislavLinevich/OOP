using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class PresenterManager
    {
        private Model model;
        public PresenterManager(Model model)
        {
            this.model = model;
        }
        public Model Exit()
        {
            model.Exit();
            return model;
        }
        public Model CancellationSpecialistManager(int n, string ID, ref string str)
        {
            model.CancellationSpecialistManager(n, ID, ref str);
            return model;
        }
        public Model Approve(int n, string ID)
        {
            model.Approve(n, ID);
            return model;
        }
        public Model ApproveCredits(int n, int index)
        {
            model.ApproveCredits(n, index);
            return model;
        }
        public Model ApproveInstallments(int n, int index)
        {
            model.ApproveInstallments(n, index);
            return model;
        }
    }
}
