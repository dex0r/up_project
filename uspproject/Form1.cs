using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace uspproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string searchText;
        public static int selectedIndex;

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedIndex = comboBox1.SelectedIndex;
            searchText = textBox1.Text;
            if (searchText == "")
            {
                MessageBox.Show("Полето за търсене е задължително.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form3 form3 = new Form3();
                form3.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    label3.Text = "Въведете марка за търсене:";
                    label3.Visible = true;
                    textBox1.Visible = true;
                    button2.Visible = true;
                    break;
                case 1:
                    label3.Text = "Въведете модел за търсене:";
                    label3.Visible = true;
                    textBox1.Visible = true;
                    button2.Visible = true;
                    break;
                case 2:
                    label3.Text = "Въведете камера за търсене\n (в mpx):";
                    label3.Visible = true;
                    textBox1.Visible = true;
                    button2.Visible = true;
                    break;
                case 3:
                    label3.Text = "Въведете ОС за търсене:";
                    label3.Visible = true;
                    textBox1.Visible = true;
                    button2.Visible = true;
                    break;
                case 4:
                    label3.Text = "Въведете батерия за търсене:";
                    label3.Visible = true;
                    textBox1.Visible = true;
                    button2.Visible = true;
                    break;
                case 5:
                    label3.Text = "Въведете цена за търсене (в лв):";
                    label3.Visible = true;
                    textBox1.Visible = true;
                    button2.Visible = true;
                    break;
            }
        }
    }
}
