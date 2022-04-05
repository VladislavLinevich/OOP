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
    public partial class FormOperator : Form
    {
        public Form1 form1;
        public PresenterOperator presenterOperator;
        public FormOperator()
        {
            InitializeComponent();
        }
        public FormOperator(Form1 f)
        {
            InitializeComponent();
            form1 = f;
            presenterOperator = new PresenterOperator(form1.model);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Transfer stats" && form1.model.GetLoggedOperator() != null)
            {
                listBox1.Items.Clear();
                foreach (string st in form1.model.GetLoggedOperator().OperatorLogs)
                {
                    listBox1.Items.Add(st);
                }
            }
        }

        private void FormOperator_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.model = presenterOperator.Exit();
            listBox1.Items.Clear();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            /*form1.model = form1.presenter.Exit();
            listBox1.Items.Clear();
            form1.Show();*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
