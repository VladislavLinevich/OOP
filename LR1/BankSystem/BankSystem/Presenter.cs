using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class Presenter
    {
        private Model model;
        public Presenter(Model model)
        {
            this.model = model;
        }

        public Model Registration(int n, string phoneNumber, string passportNumber, string ID, string name, string email, string password, ref string str)
        {
            phoneNumber = phoneNumber.Trim();
            passportNumber = passportNumber.Trim();
            ID = ID.Trim();
            name = name.Trim();
            email = email.Trim();
            password = password.Trim();

            model.Registration(n, phoneNumber, passportNumber, ID, name, email, password, ref str);
            return model;
        }

        public Model LogIn(int n, string ID, string password)
        {
            ID = ID.Trim();
            password = password.Trim();
            model.LogIn(n, ID, password);
            return model;
        }        
    }
}
