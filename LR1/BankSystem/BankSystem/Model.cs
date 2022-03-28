using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankSystem
{
    class Model
    {
        private List<Bank> banks;
        private Client loggedClient;
        private Specialist loggedSpecialist;
        private Administrator loggedAdministrator;
        private Operator loggedOperator;
        private Manager loggedManager;
        public Model()
        {
            loggedClient = null;
            loggedSpecialist = null;
            loggedAdministrator = null;
            loggedOperator = null;
            loggedManager = null;
            banks = new List<Bank>()
            {
            new BelarusBank(),
            new BelinvestBank(),
            new AlphaBank()
            };
            banks[0].specialists.Add(new("Fer", "1", "Vlad", "3535", new Company("OOO", "Moto", "234829452", banks[0].BankBIC, "adress", 100000)));
            banks[0].specialists.Add(new("Fer", "2", "Vadim", "5323", new Company("IP", "Gaz", "346245678", banks[0].BankBIC, "adress2", 250000)));
            banks[0].specialists.Add(new("Fer", "3", "Henadz", "3523", new Company("OOO", "Verno", "593023456", banks[0].BankBIC, "adress3", 123000)));
            banks[1].specialists.Add(new("Fer", "123", "Joe", "2342", new Company("ZAO", "BerANDGer", "654829412", banks[1].BankBIC, "Minsk", 560000)));
            banks[1].specialists.Add(new("Fer", "4523", "Jack", "5433", new Company("OOO", "FTH", "642958375", banks[1].BankBIC, "Madrid", 453000)));
            banks[1].specialists.Add(new("Fer", "5342", "Jake", "54362", new Company("OOO", "GP", "496034572", banks[1].BankBIC, "London", 432000)));
            banks[1].specialists.Add(new("Fer", "6433", "Ben", "6433", new Company("OOO", "Totro", "684329546", banks[1].BankBIC, "Moscow", 765000)));
            banks[2].specialists.Add(new("Fer", "7534", "Yak", "6434", new Company("IP", "Chokobo", "568234854", banks[2].BankBIC, "Tokyo", 1230000)));
            banks[2].specialists.Add(new("Fer", "8653", "Kevin", "8634", new Company("IP", "Kerniks", "245249652", banks[2].BankBIC, "London", 430000)));
            banks[2].specialists.Add(new("Fer", "5467", "John", "8634", new Company("OOO", "Regaliya", "345195432", banks[2].BankBIC, "Paris", 230000)));
            banks[0].administrator = new Administrator("Fer", "324", "Jorge", "43525");
            banks[1].administrator = new Administrator("Fer", "5432", "Mike", "6342432");
            banks[2].administrator = new Administrator("Fer", "6432", "Chris", "543232");
            banks[0]._operator = new Operator("Fer", "234", "Josh", "346643");
            banks[1]._operator = new Operator("Fer", "231", "Sam", "346436");
            banks[2]._operator = new Operator("Fer", "6423532", "Matt", "3634633");
            banks[0].manager = new Manager("Fer", "23", "Jess", "32445");
            banks[1].manager = new Manager("Fer", "563", "Ashley", "54345");
            banks[2].manager = new Manager("Fer", "24", "Bruce", "3252");
            List<string> database = File.ReadAllLines(@"C:\БД\database.txt").ToList();
            database.RemoveAt(0);
            foreach (string line in database)
            {
                string[] parts = line.Split(';');
                if (parts[0] == RomanCipher("BelarusBank"))
                {
                    banks[0].Register(DeRomanCipher(parts[1]), DeRomanCipher(parts[2]), DeRomanCipher(parts[6]), DeRomanCipher(parts[3]), DeRomanCipher(parts[4]), DeRomanCipher(parts[5]));
                }
                if (parts[0] == RomanCipher("BelinvestBank"))
                {
                    banks[1].Register(DeRomanCipher(parts[1]), DeRomanCipher(parts[2]), DeRomanCipher(parts[6]), DeRomanCipher(parts[3]), DeRomanCipher(parts[4]), DeRomanCipher(parts[5]));
                }
                if (parts[0] == RomanCipher("AlphaBank"))
                {
                    banks[2].Register(DeRomanCipher(parts[1]), DeRomanCipher(parts[2]), DeRomanCipher(parts[6]), DeRomanCipher(parts[3]), DeRomanCipher(parts[4]), DeRomanCipher(parts[5]));
                }
            }
        }
        public List<Bank> GetBanks()
        {
            return banks;
        }
        public Client GetLoggedClient()
        {
            return loggedClient;
        }
        public Specialist GetLoggedSpecialist()
        {
            return loggedSpecialist;
        }
        public Administrator GetLoggedAdministrator()
        {
            return loggedAdministrator;
        }
        public Manager GetLoggedManager()
        {
            return loggedManager;
        }
        public Operator GetLoggedOperator()
        {
            return loggedOperator;
        }
        public string RomanCipher(string text)
        {
            int n, temp;
            int key = 4;
            string cipher = "";
            string[] Alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string[] UpperAlphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            for (int i = 0; i < text.Length; i++)
            {
                string k = text[i].ToString();
                for (int j = 0; j <= 25; j++)
                {
                    if (k == Alphabet[j])
                    {
                        n = j;
                        temp = (n + key) % 26;
                        cipher += Alphabet[temp];
                        break;
                    }
                    if (k == UpperAlphabet[j])
                    {
                        n = j;
                        temp = (n + key) % 26;
                        cipher += UpperAlphabet[temp];
                        break;
                    }
                    if (j == 25)
                    {
                        cipher += k;
                    }
                }
            }
            return cipher;
        }
        public string DeRomanCipher(string text)
        {
            int n, temp;
            int key = 4;
            string deCipher = "";
            string[] Alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string[] UpperAlphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            for (int i = 0; i < text.Length; i++)
            {
                string k = text[i].ToString();
                for (int j = 0; j <= 25; j++)
                {
                    if (k == Alphabet[j])
                    {
                        n = j;
                        temp = n - key;
                        if (temp < 0)
                        {
                            temp += 26;
                        }
                        deCipher += Alphabet[temp];
                        break;
                    }
                    if (k == UpperAlphabet[j])
                    {
                        n = j;
                        temp = n - key;
                        if (temp < 0)
                        {
                            temp += 26;
                        }
                        deCipher += UpperAlphabet[temp];
                        break;
                    }
                    if (j == 25)
                    {
                        deCipher += k;
                    }
                }
            }
            return deCipher;
        }
        public void Registration(int n, string phoneNumber, string passportNumber, string ID, string name, string email, string password)
        {
            //bool contains = false;
            for (int i = 0; i < banks[n].clients.Count(); i++)
            {
                if (/*banks[n].clients[i].PhoneNumber == phoneNumber || banks[n].clients[i].PassportNumber == passportNumber ||*/ banks[n].clients[i].IdentificationNumber == ID)
                {
                    //contains = true;
                    return;
                }
            }
            if (banks[n]._operator.IdentificationNumber == ID)
            {
                return;
            }
            if (banks[n].manager.IdentificationNumber == ID)
            {
                return;
            }
            if (banks[n].administrator.IdentificationNumber == ID)
            {
                return;
            }
            for (int i = 0; i < banks[n].specialists.Count(); i++)
            {
                if (/*banks[n].clients[i].PhoneNumber == phoneNumber || banks[n].clients[i].PassportNumber == passportNumber ||*/ banks[n].specialists[i].IdentificationNumber == ID)
                {
                    return;
                }
            }
            //if (contains == false)
            //{
                banks[n].manager.ApproveClient.Add(new Client(name, phoneNumber, password, email, passportNumber, ID));
            //}
        }
        public void LogIn(int n, string ID, string password)
        {
                foreach (Client client in banks[n].clients)
                {
                    if (client.IdentificationNumber == ID && client.Password == password)
                    {
                        loggedClient = client;
                        banks[n].administrator.AdminLogs.Add($"Client {loggedClient.FullName} with ID({ID}) was LogIn");
                        return;
                    }
                }

                if (banks[n]._operator.IdentificationNumber == ID && banks[n]._operator.Password == password)
                {
                    loggedOperator = banks[n]._operator;
                    banks[n].administrator.AdminLogs.Add($"Operator {loggedOperator.FullName} with ID({ID}) was LogIn");
                    return;
                }
                if (banks[n].manager.IdentificationNumber == ID && banks[n].manager.Password == password)
                {
                    loggedManager = banks[n].manager;
                    banks[n].administrator.AdminLogs.Add($"Manager {loggedManager.FullName} with ID({ID}) was LogIn");
                    return;
                }

                foreach (Specialist specialist in banks[n].specialists)
                {
                    if (specialist.IdentificationNumber == ID && specialist.Password == password)
                    {
                        loggedSpecialist = specialist;
                        banks[n].administrator.AdminLogs.Add($"Specialist {loggedSpecialist.FullName} with ID({ID}) was LogIn");
                        return;
                    }
                }

                if (banks[n].administrator.IdentificationNumber == ID && banks[n].administrator.Password == password)
                {
                    loggedAdministrator = banks[n].administrator;
                    banks[n].administrator.AdminLogs.Add($"Administrator {loggedAdministrator.FullName} with ID({ID}) was LogIn");
                    return;
                }                                          
        }
        public void Exit()
        {
            loggedClient = null;
            loggedSpecialist = null;
            loggedAdministrator = null;
            loggedOperator = null;
            loggedManager = null;
        }

        public void OpenAccount(int n, int sum, int number, int percent)
        {
            bool contains = false;
            for (int i = 0; i < loggedClient.accounts.Count(); i++)
            {
                if (loggedClient.accounts[i].Number == number)
                {
                    contains = true;
                    break;
                }
            }
            if (contains == false)
            {
                int k = 0;
                foreach (Client client in banks[n].clients)
                {
                    if (client == loggedClient)
                    {
                        break;
                    }
                    k++;
                }
                var snap = loggedClient.CreateSnapshot();
                banks[n].administrator.caretakerClients.Save(snap, k);
                banks[n].OpenAccount(new DepositAccount(sum, number, percent), loggedClient);
                banks[n].administrator.AdminLogs.Add($"Client {loggedClient.FullName} with ID({loggedClient.IdentificationNumber}) opened account");
            }
        }
        public void StoredAccount(int n)
        {
            int k = 0;
            foreach (Client client in banks[n].clients)
            {
                if (client.IdentificationNumber == loggedClient.IdentificationNumber)
                {
                    break;
                }
                k++;
            }
            var snap = loggedClient.CreateSnapshot();
            banks[n].administrator.caretakerClients.Save(snap, k);
            banks[n].StoredAccount(loggedClient);
            banks[n].administrator.AdminLogs.Add($"Client {loggedClient.FullName} with ID({loggedClient.IdentificationNumber}) stored account");
        }
        public void Withdraw(int n, int sum, int id)
        {
            int k = 0;
            foreach (Client client in banks[n].clients)
            {
                if (client.IdentificationNumber == loggedClient.IdentificationNumber)
                {
                    break;
                }
                k++;
            }
            var snap = loggedClient.CreateSnapshot();
            banks[n].administrator.caretakerClients.Save(snap, k);
            banks[n].Withdraw(loggedClient, sum, id);
            banks[n].administrator.AdminLogs.Add($"Client {loggedClient.FullName} with ID({loggedClient.IdentificationNumber}) withdraw account");
        }
        public void Accumulate(int n, int sum, int id)
        {
            int k = 0;
            foreach (Client client in banks[n].clients)
            {
                if (client == loggedClient)
                {
                    break;
                }
                k++;
            }
            var snap = loggedClient.CreateSnapshot();
            banks[n].administrator.caretakerClients.Save(snap, k);
            banks[n].Accumulation(loggedClient, sum, id);
            banks[n].administrator.AdminLogs.Add($"Client {loggedClient.FullName} with ID({loggedClient.IdentificationNumber}) added on account");
        }
        public void Block(int n, int id)
        {
            int k = 0;
            foreach (Client client in banks[n].clients)
            {
                if (client == loggedClient)
                {
                    break;
                }
                k++;
            }
            var snap = loggedClient.CreateSnapshot();
            banks[n].administrator.caretakerClients.Save(snap, k);
            banks[n].Block(loggedClient, id);
            banks[n].administrator.AdminLogs.Add($"Client {loggedClient.FullName} with ID({loggedClient.IdentificationNumber}) block account");
        }
        public void Freeze(int n, int id)
        {
            int k = 0;
            foreach (Client client in banks[n].clients)
            {
                if (client == loggedClient)
                {
                    break;
                }
                k++;
            }
            var snap = loggedClient.CreateSnapshot();
            banks[n].administrator.caretakerClients.Save(snap, k);
            banks[n].Freeze(loggedClient, id);
            banks[n].administrator.AdminLogs.Add($"Client {loggedClient.FullName} with ID({loggedClient.IdentificationNumber}) freeze account");
        }
        public void Transfer(int n, int sum, int loggedaccountNumber, int accountNumber, string transfername, string id, string BIC_bankName, string clientName = "")
        {
            Account account1 = null;
            foreach (Account account in loggedClient.accounts)
            {
                if (account.Number == loggedaccountNumber)
                {
                    account1 = account;
                    break;
                }
            }
            if (transfername == "WestUn")
            {
                int k = 0;
                foreach (Bank bank in banks)
                {
                    if (bank.LegalName == BIC_bankName)
                    {
                        break;
                    }
                    k++;
                }
                if (k < 3)
                {
                    foreach (Client client in banks[k].clients)
                    {
                        if (client.FullName == clientName && client.IdentificationNumber == id)
                        {
                            foreach (Account account in client.accounts)
                            {
                                if (account.Number == accountNumber)
                                {
                                    banks[n].Transfer(new WesternUnionTransfer(), account1, account, sum);
                                    banks[n]._operator.OperatorLogs.Add($"Client {loggedClient.FullName} use Western Union, transfer {sum} moneys to {banks[k].LegalName} to client {client.FullName}");
                                    banks[n].manager.ManagerLogs.Add($"Client {loggedClient.FullName} use Western Union, transfer {sum} moneys to {banks[k].LegalName} to client {client.FullName}");
                                    banks[n].administrator.AdminLogs.Add($"Client {loggedClient.FullName} with ID({loggedClient.IdentificationNumber}) Western Union transfer account to {banks[k]} to client {client.FullName}");
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            if (transfername == "SWIFT")
            {
                int k = 0;
                foreach (Bank bank in banks)
                {
                    if (bank.BankBIC == BIC_bankName)
                    {
                        break;
                    }
                    k++;
                }
                if (k < 3)
                {
                    foreach (Client client in banks[k].clients)
                    {
                        if (client.IdentificationNumber == id)
                        {
                            foreach (Account account in client.accounts)
                            {
                                if (account.Number == accountNumber)
                                {
                                    banks[n].Transfer(new SWIFTTransfer(), account1, account, sum);
                                    banks[n]._operator.OperatorLogs.Add($"Client {loggedClient.FullName} use SWIFT, transfer {sum} moneys to {banks[k].LegalName} to client {client.FullName}");
                                    banks[n].manager.ManagerLogs.Add($"Client {loggedClient.FullName} use SWIFT, transfer {sum} moneys to {banks[k].LegalName} to client {client.FullName}");
                                    banks[n].administrator.AdminLogs.Add($"Client {loggedClient.FullName} with ID({loggedClient.IdentificationNumber}) SWIFT transfer account in {banks[k]} to client {client.FullName}");
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }
        public void CreateCredit(int n, double sum, double bid, double time, string CreditType) 
        {
            int k = 0;
            foreach (Client client in banks[n].clients)
            {
                if (client == loggedClient)
                {
                    break;
                }
                k++;
            }
            var snap = loggedClient.CreateSnapshot();
            banks[n].administrator.caretakerClients.Save(snap, k);
            if (CreditType == "Annuity")
            {
                loggedClient.CreateCredit(new AnnuityCredit(sum, bid, time));
                banks[n].administrator.AdminLogs.Add($"Client {loggedClient.FullName} with ID({loggedClient.IdentificationNumber}) create Annuity credit");
            }
            if (CreditType == "Differentiated")
            {
                loggedClient.CreateCredit(new DifferentiatedCredit(sum, bid, time));
                banks[n].administrator.AdminLogs.Add($"Client {loggedClient.FullName} with ID({loggedClient.IdentificationNumber}) create differentiated credit");
            }
        }
        public void MonthlyPayed(int n)
        {
            int k = 0;
            foreach (Client client in banks[n].clients)
            {
                if (client == loggedClient)
                {
                    break;
                }
                k++;
            }
            var snap = loggedClient.CreateSnapshot();
            banks[n].administrator.caretakerClients.Save(snap, k);
            Credit credit = null;
            for (int i = 0; i < loggedClient.credits.Count; i++)
            {
                credit = loggedClient.credits[i];
                credit.MonthlyPayment();
                if (credit.Time == 0)
                {
                    loggedClient.credits.Remove(credit);
                    continue;
                }
            }
            banks[n].administrator.AdminLogs.Add($"Client {loggedClient.FullName} with ID({loggedClient.IdentificationNumber}) monthly payed credits");
        }
        public void CreateInstallmentPlan(int n, double sum, double time)
        {
            int k = 0;
            foreach (Client client in banks[n].clients)
            {
                if (client == loggedClient)
                {
                    break;
                }
                k++;
            }
            var snap = loggedClient.CreateSnapshot();
            banks[n].administrator.caretakerClients.Save(snap, k);
            loggedClient.CreateInstallmentPlan(new InterestFreeInstallment(sum, time));
            banks[n].administrator.AdminLogs.Add($"Client {loggedClient.FullName} with ID({loggedClient.IdentificationNumber}) create installment plan");
        }
        public void MonthlyPayedInstllment(int n)
        {
            int k = 0;
            foreach (Client client in banks[n].clients)
            {
                if (client == loggedClient)
                {
                    break;
                }
                k++;
            }
            var snap = loggedClient.CreateSnapshot();
            banks[n].administrator.caretakerClients.Save(snap, k);
            InstallmentPlan installment = null;
            for (int i = 0; i < loggedClient.InstallmentPlans.Count; i++)
            {
                installment = loggedClient.InstallmentPlans[i];
                installment.MonthlyPayment();
                if (installment.Time == 0)
                {
                    loggedClient.InstallmentPlans.Remove(installment);
                    continue;
                }
            }
            banks[n].administrator.AdminLogs.Add($"Client {loggedClient.FullName} with ID({loggedClient.IdentificationNumber}) monthly payed installment plan");
        }
        public void FormSalaryProject(int n)
        {
            int k = 0;
            foreach (Specialist specialist in banks[n].specialists)
            {
                if (specialist == loggedSpecialist)
                {
                    break;
                }
                k++;
            }
            var snap = loggedSpecialist.CreateSnapshot();
            banks[n].administrator.caretakerSpecialists.Save(snap, k);
            loggedSpecialist.company.AddSalaryProject(banks[n]);
            banks[n].administrator.AdminLogs.Add($"Specialist {loggedSpecialist.FullName} with ID({loggedSpecialist.IdentificationNumber}) form salary project in {loggedSpecialist.company.LegalName}");
        }
        public void AddSalary(int salary)
        {
            loggedClient.Salary = salary;
        }
        public void ClientSalaryProject(int n, string name)
        {
            int k = 0;
            foreach (Client client in banks[n].clients)
            {
                if (client == loggedClient)
                {
                    break;
                }
                k++;
            }
            var snap = loggedClient.CreateSnapshot();
            banks[n].administrator.caretakerClients.Save(snap, k);
            foreach (Specialist specialist in banks[n].specialists)
            {
                if (specialist.company.LegalName == name && specialist.company.project != null)
                {
                    specialist.company.project(ref loggedClient.SumOnCard, loggedClient.Salary);
                    break;
                }
            }
            banks[n].administrator.AdminLogs.Add($"Specialist {loggedClient.FullName} with ID({loggedClient.IdentificationNumber}) add salary project");
        }
        public void TransferCompany(int n, string name, int sum)
        {
            foreach (Bank bank in banks)
            { 
                foreach (Specialist specialist in bank.specialists)
                {
                    if (specialist.company.LegalName == name)
                    {
                        loggedSpecialist.Transfer(specialist.company, sum);
                        banks[n]._operator.OperatorLogs.Add($"Specialist {loggedSpecialist.FullName} transfer {loggedSpecialist.company.LegalName}Company{sum} monyes to {specialist.company.LegalName}Company");
                        banks[n].manager.ManagerLogs.Add($"Specialist {loggedSpecialist.FullName} transfer {loggedSpecialist.company.LegalName}Company {sum} monyes to {specialist.company.LegalName}Company");
                        banks[n].administrator.AdminLogs.Add($"Specialist {loggedSpecialist.FullName} with ID({loggedSpecialist.IdentificationNumber}) transfer {loggedSpecialist.company.LegalName}Company monyes to {specialist.company.LegalName}Company ");
                        break;
                    }
                } 
            }
        }
        public void CancellationClient(int n, string ID)
        {
            int k = 0;
            foreach (Client client in banks[n].clients)
            {
                if (client.IdentificationNumber == ID)
                {
                    var snapshot = loggedAdministrator.caretakerClients.Restore(k);
                    if (snapshot == null)
                    {
                        return;
                    }
                    //if (snapshot != null)
                    //{ 
                        client.Restore(snapshot); 
                    //}
                    break;
                }
                k++;
            }
        }
        public void CancellationSpecialist(int n, string ID)
        {
            int k = 0;
            foreach (Specialist specialist in banks[n].specialists)
            {
                if (specialist.IdentificationNumber == ID)
                {
                    var snapshot = loggedAdministrator.caretakerSpecialists.Restore(k);
                    if (snapshot == null)
                    {
                        return;
                    }
                    specialist.Restore(snapshot);
                    break;
                }
                k++;
            }            
        }
        public void CancellationSpecialistManager(int n, string ID)
        {
            int k = 0;
            foreach (Specialist specialist in banks[n].specialists)
            {
                if (specialist.IdentificationNumber == ID)
                {
                    var snapshot = banks[n].administrator.caretakerSpecialists.Restore(k);
                    if (snapshot == null)
                    {
                        return;
                    }
                    specialist.Restore(snapshot);
                    break;
                }
                k++;
            }
        }
        public void Approve(int n, string ID)
        {
            foreach (Client client in loggedManager.ApproveClient)
            {
                if (client.IdentificationNumber == ID)
                {
                    string path = @"C:\БД\database.txt";
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine(RomanCipher(banks[n].LegalName) + ";" + RomanCipher(client.FullName) + ";" + RomanCipher(client.PhoneNumber) + ";" + RomanCipher(client.Email) + ";" + RomanCipher(client.PassportNumber) + ";" + RomanCipher(client.IdentificationNumber) + ";" + RomanCipher(client.Password) + ";");
                    }
                    banks[n].Register(client.FullName, client.PhoneNumber, client.Password, client.Email, client.PassportNumber, client.IdentificationNumber);
                    banks[n].administrator.AdminLogs.Add($"Client {client.FullName} with ID({client.IdentificationNumber}) was registered");
                    loggedManager.ApproveClient.Remove(client);
                    break;
                }
            }
        }
    }  
}
