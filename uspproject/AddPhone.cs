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
    public partial class AddPhone : Form
    {
        public AddPhone()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void setLabel(Label label, String text)
        {
            label.Visible = true;
            label.Text = text;
        }

        private void removeLabel(Label label)
        {
            label.Visible = false;
        }

        private void enableAdding()
        {
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void disableAdding()
        {
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text.Any(ch => Char.IsNumber(ch)))
            {
                if (textBox1.Text == "")
                {
                    setLabel(label10, "Полето не може да бъде празно.");
                }
                else
                {
                    setLabel(label10, "Марката не може да съдържа цифри.");
                }
                disableAdding();
            }
            else
            {
                removeLabel(label10);
                enableAdding();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                setLabel(label11, "Полето не може да бъде празно.");
                disableAdding();
            }
            else
            {
                removeLabel(label11);
                enableAdding();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox3.Text.Any(ch => Char.IsLetter(ch))) 
            {
                if (textBox3.Text == "")
                {
                    setLabel(label12, "Полето не може да бъде празно.");
                }
                else
                {
                    setLabel(label12, "Камерата не може да съдържа букви.");
                }
                disableAdding();
            }
            else
            {
                removeLabel(label12);
                enableAdding();
            }
        }

        private void AddPhone_Load(object sender, EventArgs e)
        {
            this.Owner.Hide();
             string dbDir = AppDomain.CurrentDomain.BaseDirectory + "uspdb.accdb";
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @dbDir;
            OleDbConnection cnn = new OleDbConnection(connString);
            try
            {
                cnn.Open();
                OleDbDataReader reader = null;
                OleDbCommand command = null;
                command = new OleDbCommand("SELECT OS FROM OS", cnn);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox2.Items.Add(reader["OS"].ToString());
                }

                command = new OleDbCommand("SELECT Color FROM Colors", cnn);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["Color"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.ToString());
            }
        }

        private void AddPhone_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox5.Text.Any(ch => !Char.IsNumber(ch)))
            {
                if (textBox5.Text == "")
                {
                    setLabel(label14, "Полето не може да бъде празно.");
                }
                else
                {
                    setLabel(label14, "Батерията не може да съдържа букви.");
                }
                disableAdding();
            }
            else
            {
                removeLabel(label14);
                enableAdding();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox6.Text.Any(ch => !Char.IsNumber(ch)))
            {
                if (textBox6.Text == "")
                {
                    setLabel(label15, "Полето не може да бъде празно.");
                }
                else
                {
                    setLabel(label15, "Камерата не може да съдържа букви.");
                }
                disableAdding();
            }
            else
            {
                removeLabel(label15);
                enableAdding();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(textBox7.Text, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (!result || textBox7.Text == "")
            {
                if (textBox7.Text == "")
                {
                    setLabel(label16, "Полето не може да бъде празно.");
                    disableAdding();
                }
                else
                {
                    setLabel(label16, "Въведете валиден URL адрес.");
                    disableAdding();
                }
            }
            else
            {
                removeLabel(label16);
                enableAdding();
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(textBox8.Text, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (!result || textBox8.Text == "")
            {
                if (textBox8.Text == "")
                {
                    setLabel(label17, "Полето не може да бъде празно.");
                    disableAdding();
                }
                else
                {
                    setLabel(label17, "Въведете валиден URL адрес.");
                    disableAdding();
                }
            }
            else
            {
                removeLabel(label17);
                enableAdding();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                setLabel(label18, "Трябва да изберете стойност от полето.");
                disableAdding();
            }
            else
            {
                removeLabel(label18);
                enableAdding();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                setLabel(label13, "Трябва да изберете стойност от полето.");
                disableAdding();
            }
            else
            {
                removeLabel(label13);
                enableAdding();
            }
        }

        private bool validateData()
        {
            Uri uriResult;
            bool result = Uri.TryCreate(textBox7.Text, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            bool result1 = Uri.TryCreate(textBox8.Text, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if(textBox1.Text == "" || textBox1.Text.Any(ch => Char.IsNumber(ch)) ||
               textBox2.Text == "" || textBox3.Text == "" || textBox3.Text.Any(ch => Char.IsLetter(ch)) ||
               textBox5.Text == "" || textBox5.Text.Any(ch => !Char.IsNumber(ch)) ||
               textBox6.Text == "" || textBox6.Text.Any(ch => !Char.IsNumber(ch)) ||
               textBox7.Text == "" || !result || !result1 ||
               comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string brandID = "";
            string brand = textBox1.Text;
            string model = textBox2.Text;
            string camera = textBox3.Text;
            int os = comboBox2.SelectedIndex + 1;
            string osver = textBox4.Text;
            string battery = textBox5.Text;
            string price = textBox6.Text;
            string frontPic = textBox7.Text;
            string backPic = textBox8.Text;
            int color = comboBox1.SelectedIndex + 1;
            if (validateData())
            {
                string dbDir = AppDomain.CurrentDomain.BaseDirectory + "uspdb.accdb";
                string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @dbDir;
                OleDbConnection cnn = new OleDbConnection(connString);
                try
                {
                    cnn.Open();
                    OleDbDataReader reader = null;
                    OleDbCommand command = null;

                    command = new OleDbCommand("SELECT ID from Brands WHERE Brand = @brand", cnn);

                    command.Parameters.Add("@brand", OleDbType.Char).Value = brand;

                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            brandID = reader["ID"].ToString();
                        }
                    }
                    else
                    {
                        command = new OleDbCommand("INSERT INTO Brands (Brand) VALUES (@brand)", cnn);
                        command.Parameters.Add("@brand", OleDbType.Char).Value = brand;
                        command.ExecuteNonQuery();
                    }

                    command = new OleDbCommand("INSERT INTO Phones (Brand, Model, Camera, Color, OS, OSver, Battery, Price, FrontPic, BackPic)" +
                       " VALUES (@brandID, @model, @camera, @color, @os, @osver, @battery, @price, @frontpic, @backpic)", cnn);
                    command.Parameters.Add("@brandID", OleDbType.Integer).Value = Convert.ToInt32(brandID);
                    command.Parameters.Add("@model", OleDbType.Char).Value = model;
                    command.Parameters.Add("@camera", OleDbType.Char).Value = camera;
                    command.Parameters.Add("@color", OleDbType.Integer).Value = Convert.ToInt32(color);
                    command.Parameters.Add("@os", OleDbType.Integer).Value = os;
                    command.Parameters.Add("@osver", OleDbType.Char).Value = osver;
                    command.Parameters.Add("@battery", OleDbType.Integer).Value = Convert.ToInt32(battery);
                    command.Parameters.Add("@price", OleDbType.Integer).Value = Convert.ToInt32(price);
                    command.Parameters.Add("@frontpic", OleDbType.Char).Value = frontPic;
                    command.Parameters.Add("@backpic", OleDbType.Char).Value = backPic;

                    command.ExecuteNonQuery();

                    MessageBox.Show("Телефонът е добавен успешно.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception: " + ex.ToString());
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                if (textBox4.Text == "")
                {
                    setLabel(label20, "Полето не може да бъде празно.");
                }
                disableAdding();
            }
            else
            {
                removeLabel(label20);
                enableAdding();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validateData())
            {
                Phone form = new Phone();
                Phone.isTest = true;
                form.brandLabel = textBox1.Text;
                form.modelLabel = textBox2.Text;
                form.cameraLabel = textBox3.Text;
                string selected = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
                form.osLabel = selected + " " + textBox4.Text;
                form.batteryLabel = textBox5.Text;
                form.priceLabel = textBox6.Text;
                Phone.frontPic = textBox7.Text;
                Phone.backPic = textBox8.Text;
                string selectedColor = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
                form.colorComboBox = selectedColor;
                form.Owner = this;
                form.Show();
            }
        }
    }
}
