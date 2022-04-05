using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class FormManager : Form
    {
        public Form1 form1;
        public PresenterManager presenterManager;
        public FormManager()
        {
            InitializeComponent();
        }
        public FormManager(Form1 f)
        {
            InitializeComponent();
            form1 = f;
            presenterManager = new PresenterManager(form1.model);
            foreach (Client client in form1.model.GetLoggedManager().ApproveClient)
            {
                listBox3.Items.Add(client.IdentificationNumber);
            }
            foreach (string id in form1.model.GetLoggedManager().ClientIDCredits)
            {
                listBox2.Items.Add($"Create credit for client({id})");
            }
            foreach (string id in form1.model.GetLoggedManager().ClientIDInstallment)
            {
                listBox4.Items.Add($"Create installment for client({id})");
            }
        }

        private void FormManager_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Transfer stats" && form1.model.GetLoggedManager() != null)
            {
                listBox1.Items.Clear();
                foreach (string st in form1.model.GetLoggedManager().ManagerLogs)
                {
                    listBox1.Items.Add(st);
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (form1.model.GetLoggedManager() != null)
            {
                string str = "Cant cancellate";
                form1.model = presenterManager.CancellationSpecialistManager(form1.comboBox1.SelectedIndex, textBox11.Text, ref str);
                MessageBox.Show(str);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            form1.model = presenterManager.Approve(form1.comboBox1.SelectedIndex, listBox3.Text);
            listBox3.Items.Clear();
            foreach (Client client in form1.model.GetLoggedManager().ApproveClient)
            {
                listBox3.Items.Add(client.IdentificationNumber);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            /*form1.model = form1.presenter.Exit();
            listBox3.Items.Clear();
            form1.Show();*/
        }

        private void FormManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.model = presenterManager.Exit();
            listBox3.Items.Clear();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                form1.model = presenterManager.ApproveCredits(form1.comboBox1.SelectedIndex, listBox2.SelectedIndex);
                listBox2.Items.Clear();
                foreach (string id in form1.model.GetLoggedManager().ClientIDCredits)
                {
                    listBox2.Items.Add($"Create credit for client({id})");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex >= 0)
            {
                form1.model = presenterManager.ApproveInstallments(form1.comboBox1.SelectedIndex, listBox4.SelectedIndex);
                listBox4.Items.Clear();
                foreach (string id in form1.model.GetLoggedManager().ClientIDInstallment)
                {
                    listBox4.Items.Add($"Create installment for client({id})");
                }
            }
        }
    }
}
