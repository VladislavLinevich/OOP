using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class PresenterOperator
    {
        private Model model;
        public PresenterOperator(Model model)
        {
            this.model = model;
        }
        public Model Exit()
        {
            model.Exit();
            return model;
        }
    }
}
