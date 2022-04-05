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
    public partial class FormClient : Form
    {
        public Form1 form1;
        public PresenterClient presenterClient;
        public FormClient()
        {
            InitializeComponent();
        }
        public FormClient(Form1 f)
        {
            InitializeComponent();
            form1 = f;
            presenterClient = new PresenterClient(form1.model);
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (Account account in form1.model.GetLoggedClient().accounts)
            {
                listBox1.Items.Add(account.Number);
            }
            foreach (Account account in form1.model.GetLoggedClient().accounts)
            {
                listBox2.Items.Add(account.Sum);
            }
            
        }

        private void FormClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.model = presenterClient.Exit();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            form1.Show();
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
                radioButton4.Checked = true;
                listBox1.Visible = true;
                listBox2.Visible = true;
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (Account account in form1.model.GetLoggedClient().accounts)
                {
                    listBox1.Items.Add(account.Number);
                    listBox2.Items.Add(account.Sum);
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
                foreach (Credit account in form1.model.GetLoggedClient().credits)
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
                foreach (InstallmentPlan account in form1.model.GetLoggedClient().InstallmentPlans)
                {
                    listBox1.Items.Add((int)account.platezh);
                    listBox2.Items.Add((int)account.Sum);
                }
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked == true)
            {
                label9.Text = "Salary";
                label17.Text = $"Sum on card = {form1.model.GetLoggedClient().SumOnCard}";
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Open")
            {
                if (textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
                {
                    form1.model = presenterClient.OpenAccount(form1.comboBox1.SelectedIndex, Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text));
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    foreach (Account account in form1.model.GetLoggedClient().accounts)
                    {
                        listBox1.Items.Add(account.Number);
                        listBox2.Items.Add(account.Sum);
                    }
                }
            }
            if (button3.Text == "Salary")
            {
                if (textBox8.Text != "")
                {
                    form1.model = presenterClient.AddSalary(Convert.ToInt32(textBox8.Text));
                    MessageBox.Show($"Your new salary = {textBox8.Text}");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            form1.model = presenterClient.StoredAccount(form1.comboBox1.SelectedIndex);
            listBox2.Items.Clear();
            foreach (Account account in form1.model.GetLoggedClient().accounts)
            {
                listBox2.Items.Add(account.Sum);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "" && textBox8.Text != "")
            {
                form1.model = presenterClient.Withdraw(form1.comboBox1.SelectedIndex, Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text));
                listBox2.Items.Clear();
                foreach (Account account in form1.model.GetLoggedClient().accounts)
                {
                    listBox2.Items.Add(account.Sum);
                }
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "" && textBox8.Text != "")
            {
                form1.model = presenterClient.Accumulate(form1.comboBox1.SelectedIndex, Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text));
                listBox2.Items.Clear();
                foreach (Account account in form1.model.GetLoggedClient().accounts)
                {
                    listBox2.Items.Add(account.Sum);
                }
                return;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                string str = "Cant freeze this account";
                form1.model = presenterClient.Freeze(form1.comboBox1.SelectedIndex, Convert.ToInt32(textBox8.Text), ref str);
                MessageBox.Show(str);
                listBox2.Items.Clear();
                foreach (Account account in form1.model.GetLoggedClient().accounts)
                {
                    listBox2.Items.Add(account.Sum);
                }
                return;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                form1.model = presenterClient.Block(form1.comboBox1.SelectedIndex, Convert.ToInt32(textBox8.Text));
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (Account account in form1.model.GetLoggedClient().accounts)
                {
                    listBox2.Items.Add(account.Sum);
                    listBox1.Items.Add(account.Number);
                }
                return;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (form1.model.GetLoggedClient() != null && form1.model.GetLoggedClient().accounts.Count != 0)
            {
                //if (model.GetLoggedClient() != null  && model.GetLoggedClient().accounts.Count != 0)
                //{
                if (radioButton4.Checked == true)
                {
                    if (textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "")
                    {
                        string str = "Enter correct transfer info";
                        form1.model = presenterClient.Transfer(form1.comboBox1.SelectedIndex, Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox12.Text), radioButton4.Text, textBox11.Text, textBox10.Text, ref str, textBox13.Text);
                        MessageBox.Show(str);
                        listBox1.Items.Clear();
                        listBox2.Items.Clear();
                        foreach (Account account in form1.model.GetLoggedClient().accounts)
                        {
                            listBox2.Items.Add(account.Sum);
                            listBox1.Items.Add(account.Number);
                        }
                        return;
                    }
                    MessageBox.Show("Enter correct transfer info");
                    return;
                }
                if (radioButton3.Checked == true)
                {
                    if (textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "")
                    {
                        string str = "Enter correct transfer info";
                        form1.model = presenterClient.Transfer(form1.comboBox1.SelectedIndex, Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox12.Text), radioButton3.Text, textBox11.Text, textBox10.Text, ref str);
                        MessageBox.Show(str);
                        listBox1.Items.Clear();
                        listBox2.Items.Clear();
                        foreach (Account account in form1.model.GetLoggedClient().accounts)
                        {
                            listBox2.Items.Add(account.Sum);
                            listBox1.Items.Add(account.Number);
                        }
                        return;
                    }
                    MessageBox.Show("Enter correct transfer info");
                    return;
                }

                //}
            }
            MessageBox.Show("Enter correct info");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                if (textBox7.Text != "" && textBox8.Text != "" && comboBox3.Text != "" && comboBox4.Text != "")
                {
                    form1.model = presenterClient.CreateCredit(form1.comboBox1.SelectedIndex, double.Parse(textBox7.Text), double.Parse(textBox8.Text), double.Parse(comboBox3.Text), comboBox4.Text);
                    MessageBox.Show("Loan application sent");
                    return;
                }
                MessageBox.Show("Enter correct info");
            }
            if (radioButton7.Checked == true)
            {
                if (textBox7.Text != "" && comboBox3.Text != "")
                {
                    form1.model = presenterClient.CreateInstallmentPlan(form1.comboBox1.SelectedIndex, double.Parse(textBox7.Text), double.Parse(comboBox3.Text));
                    MessageBox.Show("Installment request sent");
                    return;
                    /*listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    foreach (InstallmentPlan account in form1.model.GetLoggedClient().InstallmentPlans)
                    {
                        listBox1.Items.Add((int)account.platezh);
                        listBox2.Items.Add((int)account.Sum);
                    }*/
                }
                MessageBox.Show("Enter correct info");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                form1.model = presenterClient.MonthlyPayed(form1.comboBox1.SelectedIndex);
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (Credit account in form1.model.GetLoggedClient().credits)
                {
                    listBox1.Items.Add((int)account.platezh);
                    listBox2.Items.Add((int)account.Sum);
                }
            }
            if (radioButton7.Checked == true)
            {
                form1.model = presenterClient.MonthlyPayedInstllment(form1.comboBox1.SelectedIndex);
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (InstallmentPlan account in form1.model.GetLoggedClient().InstallmentPlans)
                {
                    listBox1.Items.Add((int)account.platezh);
                    listBox2.Items.Add((int)account.Sum);
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int sum = form1.model.GetLoggedClient().SumOnCard;
            form1.model = presenterClient.ClientSalaryProject(form1.comboBox1.SelectedIndex, textBox14.Text);
            if (sum == form1.model.GetLoggedClient().SumOnCard)
            {
                MessageBox.Show("This salary project doesnt exist");
            }

            label17.Text = $"Sum on card = {form1.model.GetLoggedClient().SumOnCard}";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                label13.Text = "BIC";
                label16.Visible = false;
                textBox13.Visible = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            /*form1.model = form1.presenter.Exit();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            form1.Show();*/
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton4.Checked == true)
            {
                label13.Text = "Bank Name";
                label16.Visible = true;
                textBox13.Visible = true;
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
