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
    public partial class FormSpecialist : Form
    {
        public Form1 form1;
        public PresenterSpecialist presenterSpecialist;
        public FormSpecialist()
        {
            InitializeComponent();
        }
        public FormSpecialist(Form1 f)
        {
            InitializeComponent();
            form1 = f;
            presenterSpecialist = new PresenterSpecialist(form1.model);
            listBox2.Items.Add(form1.model.GetLoggedSpecialist().company.Sum);
            button3.Text = "Salary project";
            if (form1.model.GetLoggedSpecialist().company.project != null)
            {
                button3.Visible = false;
            }
            if (form1.model.GetLoggedSpecialist().company.project == null)
            {
                button3.Visible = true;
            }
        }

        private void FormSpecialist_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Salary project")
            {
                form1.model = presenterSpecialist.FormSalaryProject(form1.comboBox1.SelectedIndex);
                button3.Visible = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (form1.model.GetLoggedSpecialist() != null)
            {
                if (textBox7.Text != "")
                {
                    string str = "Enter correct info";
                    listBox2.Items.Clear();
                    form1.model = presenterSpecialist.TransferCompany(form1.comboBox1.SelectedIndex, textBox14.Text, Convert.ToInt32(textBox7.Text), ref str);
                    MessageBox.Show(str);
                    listBox2.Items.Add(form1.model.GetLoggedSpecialist().company.Sum);
                    return;
                }
                MessageBox.Show("Enter correct info");
            }
        }

        private void FormSpecialist_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.model = presenterSpecialist.Exit();
            listBox2.Items.Clear();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
