using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PluginInterface;
using System.IO;
using System.Reflection;

namespace Painting
{
    
    public partial class Form1 : Form
    {
        private string pluginPath = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");

        public Model model;
        public Presenter presenter;

        public Form1()
        {
            model = new Model();
            presenter = new Presenter(model);
            InitializeComponent();
            comboBox1.Text = "Line";
            RefreshPlugins();

        }

        private void RefreshPlugins()
        {
            Model.plugins.Clear();

            DirectoryInfo pluginDirectory = new DirectoryInfo(pluginPath);
            if (!pluginDirectory.Exists)
            {
                pluginDirectory.Create();
            }

            var pluginFiles = Directory.GetFiles(pluginPath, "*.dll");
            foreach (var file in pluginFiles)
            {
                Assembly asm = Assembly.LoadFrom(file);
                var types = asm.GetTypes().Where(t => t.GetInterfaces().Where(i => i.FullName == typeof(IPlugin).FullName).Any());
                foreach (var type in types)
                {
                    var plugin = asm.CreateInstance(type.FullName) as IPlugin;
                    Model.plugins.Add(plugin);
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(model.IsClicked)
            {
                if (comboBox1.Text == "Line" || comboBox1.Text == "BrokenLine")
                {
                    model = presenter.MoveForLine(e.X, e.Y);
                    pictureBox1.Invalidate();
                }
                if (comboBox1.Text == "Ellipse" || comboBox1.Text == "Rectangle")
                {
                    model = presenter.MoveForOtherFigures(e.X, e.Y);
                    pictureBox1.Invalidate();
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (model.IsClicked)
            {
                button4.Enabled = true;
                button5.Enabled = false;
                button6.Enabled = false;
                button8.Enabled = false;
            }
            model = presenter.Paint(comboBox1.Text, e.Graphics);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBox1.Text == "Trapeze")
            {
                if (textBox1.Text == "" || textBox2.Text == "" || Convert.ToInt32(textBox1.Text) < 0 || Convert.ToInt32(textBox2.Text) < 0 || Convert.ToInt32(textBox2.Text) == 0 || Convert.ToInt32(textBox1.Text) == 0 ||  Convert.ToInt32(textBox2.Text) == Convert.ToInt32(textBox1.Text))
                {
                    MessageBox.Show("Enter correct length");
                    return;
                }
                button4.Enabled = true;
                button5.Enabled = false;
                button6.Enabled = false;
                button8.Enabled = false;
                model = presenter.TrapezeClick(comboBox1.Text, e.X, e.Y, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                pictureBox1.Invalidate();
            }
            else
            {
                model = presenter.Click(comboBox1.Text, e.X, e.Y);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Trapeze")
            {
                label4.Visible = true;
                label5.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
            }
            else
            {
                label4.Visible = false;
                label5.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            button1.BackColor = colorDialog1.Color;
            model.pen = new Pen(button1.BackColor);
            model.pen.Width = trackBar1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            button2.BackColor = colorDialog1.Color;
            model.brush = new SolidBrush(button2.BackColor);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Transparent;
            model.brush = new SolidBrush(button2.BackColor);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = "Width = " + trackBar1.Value;
            model.pen = new Pen(button1.BackColor);
            model.pen.Width = trackBar1.Value;
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            model = presenter.DbClick(comboBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            model = presenter.Undo();
            pictureBox1.Invalidate();
            if (model.undoRedo.figures.Count == 0)
            {
                button4.Enabled = false;
            }
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            model = presenter.Redo();
            pictureBox1.Invalidate();
            button4.Enabled = true;
            if (model.undoRedo.UndoFigures.Count == 0)
            {
                button5.Enabled = false;
                button6.Enabled = false;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            model = presenter.RedoAll();
            pictureBox1.Invalidate();
            button4.Enabled = true;
            button5.Enabled = false;
            button6.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            model = presenter.Serialize();
            MessageBox.Show("Serialize Json");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (model.undoRedo.figures.Count == 0 && model.undoRedo.UndoFigures.Count == 0)
            {
                model = presenter.Deserialize();
                pictureBox1.Invalidate();
                button8.Enabled = false;
                if (model.undoRedo.figures.Count > 0)
                {
                    button4.Enabled = true;
                    button5.Enabled = false;
                    button6.Enabled = false;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
