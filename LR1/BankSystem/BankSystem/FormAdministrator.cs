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
    public partial class FormAdministrator : Form
    {
        public Form1 form1;
        public PresenterAdministrator presenterAdministrator;
        public FormAdministrator(Form1 f)
        {
            InitializeComponent();
            form1 = f;
            presenterAdministrator = new PresenterAdministrator(form1.model);
        }

        private void FormAdministrator_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Logs" && form1.model.GetLoggedAdministrator() != null)
            {
                listBox1.Items.Clear();
                foreach (string st in form1.model.GetLoggedAdministrator().AdminLogs)
                {
                    listBox1.Items.Add(st);
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string str = "Cant cancellate";
            form1.model = presenterAdministrator.CancellationClient(form1.comboBox1.SelectedIndex, textBox11.Text, ref str);
            MessageBox.Show(str);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (form1.model.GetLoggedAdministrator() != null)
            {
                string str = "Cant cancellate";
                form1.model = presenterAdministrator.CancellationSpecialist(form1.comboBox1.SelectedIndex, textBox11.Text, ref str);
                MessageBox.Show(str);
            }
        }

        private void FormAdministrator_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.model = presenterAdministrator.Exit();
            listBox1.Items.Clear();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
