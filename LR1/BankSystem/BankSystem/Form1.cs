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
        private Model model;
        private Presenter presenter;
       
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
                    model = presenter.Registration(comboBox1.SelectedIndex, textBox4.Text, textBox6.Text, textBox1.Text, textBox3.Text, textBox5.Text, textBox2.Text);
                }
            }
            if (radioButton1.Checked == true)
            {
                model = presenter.LogIn(comboBox1.SelectedIndex, textBox1.Text, textBox2.Text);
                if (model.GetLoggedClient() != null)
                {
                    label19.Text = "Client";
                    label19.Visible = true;
                    button1.Visible = false;
                    button2.Visible = true;
                    comboBox1.Enabled = false;
                    //comboBox2.Enabled = false;
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    button3.Visible = true;
                    button4.Visible = true;
                    button5.Visible = true;
                    button6.Visible = true;
                    button7.Visible = true;
                    button8.Visible = true;
                    button9.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    label10.Visible = true;
                    label11.Visible = true;
                    label12.Visible = true;
                    label13.Visible = true;
                    label14.Visible = true;
                    label15.Visible = true;
                    label16.Visible = true;
                    textBox7.Visible = true;
                    textBox8.Visible = true;
                    textBox9.Visible = true;
                    textBox10.Visible = true;
                    textBox11.Visible = true;
                    textBox12.Visible = true;
                    textBox13.Visible = true;
                    listBox1.Visible = true;
                    listBox2.Visible = true;
                    radioButton3.Visible = true;
                    radioButton4.Visible = true;
                    radioButton5.Visible = true;
                    radioButton6.Visible = true;
                    radioButton7.Visible = true;
                    radioButton8.Visible = true;
                    radioButton5.Checked = true;
                    button3.Text = "Open";
                    foreach (Account account in model.GetLoggedClient().accounts)
                    {
                        listBox1.Items.Add(account.Number);
                    }
                    foreach (Account account in model.GetLoggedClient().accounts)
                    {
                        listBox2.Items.Add(account.Sum);
                    }
                }
                if (model.GetLoggedSpecialist() != null)
                {
                    label19.Text = "Specialist";
                    label19.Visible = true;
                    button1.Visible = false;
                    button2.Visible = true;
                    comboBox1.Enabled = false;
                   // comboBox2.Enabled = false;
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    label8.Visible = true;
                    label18.Visible = true;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    textBox7.Visible = true;
                    textBox14.Visible = true;
                    button3.Visible = true;
                    button9.Visible = true;
                    listBox2.Visible = true;
                    listBox2.Items.Add(model.GetLoggedSpecialist().company.Sum); 
                    button3.Text = "Salary project";
                    if (model.GetLoggedSpecialist().company.project != null)
                    {
                        button3.Visible = false;
                    }
                    if (model.GetLoggedSpecialist().company.project == null)
                    {
                        button3.Visible = true;
                    }
                }
                if (model.GetLoggedAdministrator() != null)
                {
                    label19.Text = "Administrator";
                    label19.Visible = true;
                    button1.Visible = false;
                    button2.Visible = true;
                    button13.Visible = true;
                    button14.Visible = true;
                    comboBox1.Enabled = false;
                   // comboBox2.Enabled = false;
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    label14.Visible = true;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    textBox11.Visible = true;
                    button3.Visible = true;
                    button3.Text = "Logs";
                    listBox1.Visible = true;
                }
                if (model.GetLoggedOperator() != null)
                {
                    label19.Text = "Operator";
                    label19.Visible = true;
                    button1.Visible = false;
                    button2.Visible = true;
                    comboBox1.Enabled = false;
                   // comboBox2.Enabled = false;
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    button3.Visible = true;
                    button3.Text = "Transfer stats";
                    listBox1.Visible = true;
                }
                if (model.GetLoggedManager() != null)
                {
                    label19.Text = "Manager";
                    label19.Visible = true;
                    button1.Visible = false;
                    button2.Visible = true;
                    comboBox1.Enabled = false;
                    //comboBox2.Enabled = false;
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    label14.Visible = true;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    textBox11.Visible = true;
                    button3.Visible = true;
                    button3.Text = "Transfer stats";
                    listBox1.Visible = true;
                    button14.Visible = true;
                    button15.Visible = true;
                    listBox3.Visible = true;
                    listBox3.Items.Clear();
                    foreach (Client client in model.GetLoggedManager().ApproveClient)
                    {
                        listBox3.Items.Add(client.IdentificationNumber);
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            model = presenter.Exit();
            label19.Visible = false;
            button1.Visible = true;
            button2.Visible = false;
            comboBox1.Enabled = true;
            //comboBox2.Enabled = true;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            radioButton1.Visible = true;
            //if (comboBox2.Text == "Client")
            //{ 
                radioButton2.Visible = true; 
            //}
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox12.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
            listBox1.Visible = false;
            listBox2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;
            radioButton7.Visible = false;
            radioButton8.Visible = false;
            button15.Visible = false;
            listBox3.Visible = false;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Open")
            {
                if (textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
                {
                    model = presenter.OpenAccount(comboBox1.SelectedIndex, Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text));
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    foreach (Account account in model.GetLoggedClient().accounts)
                    {
                        listBox1.Items.Add(account.Number);
                        listBox2.Items.Add(account.Sum);
                    }
                }
            }
            if (button3.Text == "Salary project")
            {
                model = presenter.FormSalaryProject(comboBox1.SelectedIndex);
                button3.Visible = false;
            }
            if (button3.Text == "Salary")
            {
                if (textBox8.Text != "")
                { 
                    model = presenter.AddSalary(Convert.ToInt32(textBox8.Text)); 
                }
            }
            if (button3.Text == "Transfer stats" && model.GetLoggedOperator() != null)
            {
                listBox1.Items.Clear();
                foreach (string st in model.GetLoggedOperator().OperatorLogs)
                {
                    listBox1.Items.Add(st);
                }
            }
            if (button3.Text == "Transfer stats" && model.GetLoggedManager() != null)
            {
                listBox1.Items.Clear();
                foreach (string st in model.GetLoggedManager().ManagerLogs)
                {
                    listBox1.Items.Add(st);
                }
            }
            if (button3.Text == "Logs" && model.GetLoggedAdministrator() != null)
            {
                listBox1.Items.Clear();
                foreach (string st in model.GetLoggedAdministrator().AdminLogs)
                {
                    listBox1.Items.Add(st);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            model = presenter.StoredAccount(comboBox1.SelectedIndex);
            listBox2.Items.Clear();
            foreach (Account account in model.GetLoggedClient().accounts)
            {
                listBox2.Items.Add(account.Sum);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "" && textBox8.Text != "")
            {
                model = presenter.Withdraw(comboBox1.SelectedIndex, Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text));
                listBox2.Items.Clear();
                foreach (Account account in model.GetLoggedClient().accounts)
                {
                    listBox2.Items.Add(account.Sum);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "" && textBox8.Text != "")
            {
                model = presenter.Accumulate(comboBox1.SelectedIndex, Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text));
                listBox2.Items.Clear();
                foreach (Account account in model.GetLoggedClient().accounts)
                {
                    listBox2.Items.Add(account.Sum);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                model = presenter.Freeze(comboBox1.SelectedIndex, Convert.ToInt32(textBox8.Text));
                listBox2.Items.Clear();
                foreach (Account account in model.GetLoggedClient().accounts)
                {
                    listBox2.Items.Add(account.Sum);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                model = presenter.Block(comboBox1.SelectedIndex, Convert.ToInt32(textBox8.Text));
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (Account account in model.GetLoggedClient().accounts)
                {
                    listBox2.Items.Add(account.Sum);
                    listBox1.Items.Add(account.Number);
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                label13.Text = "BIC";
                label16.Visible = false;
                textBox13.Visible = false;
            }
            else
            {
                label13.Text = "Bank Name";
                label16.Visible = true;
                textBox13.Visible = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (model.GetLoggedClient() != null)
            {
                if (textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && model.GetLoggedClient().accounts.Count != 0)
                {
                    if (radioButton4.Checked == true)
                    {
                        model = presenter.Transfer(comboBox1.SelectedIndex, Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox12.Text), radioButton4.Text, textBox11.Text, textBox10.Text, textBox13.Text);
                    }
                    if (radioButton3.Checked == true)
                    {
                        model = presenter.Transfer(comboBox1.SelectedIndex, Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox12.Text), radioButton3.Text, textBox11.Text, textBox10.Text);
                    }
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    foreach (Account account in model.GetLoggedClient().accounts)
                    {
                        listBox2.Items.Add(account.Sum);
                        listBox1.Items.Add(account.Number);
                    }
                }
            }
            if (model.GetLoggedSpecialist() != null)
            {
                if (textBox7.Text != "")
                {
                    listBox2.Items.Clear();
                    model = presenter.TransferCompany(comboBox1.SelectedIndex, textBox14.Text, Convert.ToInt32(textBox7.Text));
                    listBox2.Items.Add(model.GetLoggedSpecialist().company.Sum);
                }
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                label9.Text = "Bid";
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = false;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label7.Visible = true;
                label11.Text = "platezh";
                label12.Text = "sum";
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                textBox14.Visible = false;
                button10.Visible = true;
                button11.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button12.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                listBox1.Visible = true;
                listBox2.Visible = true;
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (Credit account in model.GetLoggedClient().credits)
                {
                    listBox1.Items.Add((int)account.platezh);
                    listBox2.Items.Add((int)account.Sum);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                if (textBox7.Text != "" && textBox8.Text != "" && comboBox3.Text != "" && comboBox4.Text != "")
                {
                    model.CreateCredit(comboBox1.SelectedIndex, double.Parse(textBox7.Text), double.Parse(textBox8.Text), double.Parse(comboBox3.Text), comboBox4.Text);
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    foreach (Credit account in model.GetLoggedClient().credits)
                    {
                        listBox1.Items.Add((int)account.platezh);
                        listBox2.Items.Add((int)account.Sum);
                    } 
                }
            }
            if (radioButton7.Checked == true)
            {
                if (textBox7.Text != "" && comboBox3.Text != "")
                {
                    model.CreateInstallmentPlan(comboBox1.SelectedIndex, double.Parse(textBox7.Text), double.Parse(comboBox3.Text));
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    foreach (InstallmentPlan account in model.GetLoggedClient().InstallmentPlans)
                    {
                        listBox1.Items.Add((int)account.platezh);
                        listBox2.Items.Add((int)account.Sum);
                    }
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                model.MonthlyPayed(comboBox1.SelectedIndex);
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (Credit account in model.GetLoggedClient().credits)
                {
                    listBox1.Items.Add((int)account.platezh);
                    listBox2.Items.Add((int)account.Sum);
                }
            }
            if (radioButton7.Checked == true)
            {
                model.MonthlyPayedInstllment(comboBox1.SelectedIndex);
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (InstallmentPlan account in model.GetLoggedClient().InstallmentPlans)
                {
                    listBox1.Items.Add((int)account.platezh);
                    listBox2.Items.Add((int)account.Sum);
                }
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
            {
                label8.Visible = true;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                label7.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label11.Text = "platezh";
                label12.Text = "sum";
                textBox7.Visible = true;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                textBox14.Visible = false;
                button10.Visible = true;
                button11.Visible = true;
                button12.Visible = false;
                comboBox3.Visible = true;
                comboBox4.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                listBox1.Visible = true;
                listBox2.Visible = true;
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (InstallmentPlan account in model.GetLoggedClient().InstallmentPlans)
                {
                    listBox1.Items.Add((int)account.platezh);
                    listBox2.Items.Add((int)account.Sum);
                }
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                button3.Text = "Open";
                label9.Text = "Number";
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = true;
                label16.Visible = true;
                label17.Visible = false;
                label18.Visible = false;
                label7.Visible = false;
                label11.Text = "Accounts ID";
                label12.Text = "Accounts sum";
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;
                textBox12.Visible = true;
                textBox13.Visible = true;
                textBox14.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                button8.Visible = true;
                button9.Visible = true;
                button12.Visible = false;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                listBox1.Visible = true;
                listBox2.Visible = true;
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (Account account in model.GetLoggedClient().accounts)
                {
                    listBox1.Items.Add(account.Number);
                    listBox2.Items.Add(account.Sum);
                }
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked == true)
            {
                label9.Text = "Salary";
                label17.Text = $"Sum on card = {model.GetLoggedClient().SumOnCard}";
                button3.Text = "Salary";
                label8.Visible = false;
                label9.Visible = true;
                label10.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                label17.Visible = true;
                label7.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label18.Visible = true;
                textBox7.Visible = false;
                textBox8.Visible = true;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                textBox14.Visible = true;
                button10.Visible = false;
                button11.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                button3.Visible = true;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button12.Visible = true;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                listBox1.Visible = false;
                listBox2.Visible = false;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            model = presenter.ClientSalaryProject(comboBox1.SelectedIndex, textBox14.Text);
            label17.Text = $"Sum on card = {model.GetLoggedClient().SumOnCard}";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            model = presenter.CancellationClient(comboBox1.SelectedIndex, textBox11.Text);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (model.GetLoggedAdministrator() != null)
            {
                model = presenter.CancellationSpecialist(comboBox1.SelectedIndex, textBox11.Text);
            }

            if (model.GetLoggedManager() != null)
            {
                model = presenter.CancellationSpecialistManager(comboBox1.SelectedIndex, textBox11.Text);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            model = presenter.Approve(comboBox1.SelectedIndex, listBox3.Text);
            listBox3.Items.Clear();
            foreach (Client client in model.GetLoggedManager().ApproveClient)
            {
                listBox3.Items.Add(client.IdentificationNumber);
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
    
}
