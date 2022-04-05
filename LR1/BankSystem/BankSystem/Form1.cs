using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BankSystem
{
    public partial class Form1 : Form
    {
        public Model model;
        public Presenter presenter;
       
        public Form1()
        {
            InitializeComponent();

            model = new Model();
            presenter = new Presenter(model);
            comboBox1.DataSource = model.GetBanks();
            comboBox1.DisplayMember = "LegalName";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                button1.Text = "Register";
            }
            else
            {
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                button1.Text = "Log in";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                {
                    string str = "This user exists";
                    model = presenter.Registration(comboBox1.SelectedIndex, textBox4.Text, textBox6.Text, textBox1.Text, textBox3.Text, textBox5.Text, textBox2.Text, ref str);
                    MessageBox.Show(str);
                    return;
                }
                MessageBox.Show("Enter correct info");
            }
            if (radioButton1.Checked == true)
            {
                model = presenter.LogIn(comboBox1.SelectedIndex, textBox1.Text, textBox2.Text);
                if (model.GetLoggedClient() != null)
                {
                    
                    FormClient formClient = new FormClient(this);
                    formClient.Show();
                    this.Hide();
                    
                }
                if (model.GetLoggedSpecialist() != null)
                {
                    FormSpecialist formSpecialist = new FormSpecialist(this);
                    formSpecialist.Show();
                    this.Hide();

                }
                if (model.GetLoggedAdministrator() != null)
                {
                    FormAdministrator formAdministrator = new FormAdministrator(this);
                    formAdministrator.Show();
                    this.Hide();
                }
                if (model.GetLoggedOperator() != null)
                {
                    FormOperator formOperator = new FormOperator(this);
                    formOperator.Show();
                    this.Hide();
                }
                if (model.GetLoggedManager() != null)
                {
                    FormManager formManager = new FormManager(this);
                    formManager.Show();
                    this.Hide();

                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        

       

        

        

       

        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
    
}
