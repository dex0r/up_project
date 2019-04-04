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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection cnn;
        private void Form2_Load(object sender, EventArgs e)
        {
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\scroLLeR\\Documents\\uspdb.accdb";
            cnn = new OleDbConnection(connString);
            try
            {
                cnn.Open();
                label8.Text = "Успешна";
                label8.ForeColor = System.Drawing.Color.Green;
                cnn.Close();
            }
            catch
            {
                label8.Text = "Неуспешна";
                label8.ForeColor = System.Drawing.Color.Red;
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string brand = comboBox1.SelectedIndex.ToString();
            string model = textBox2.Text;
            string camera = textBox3.Text;
            string os = comboBox2.SelectedIndex.ToString();
            string battery = textBox5.Text;
            string price = textBox4.Text;

            if (brand == "" || model == "" || camera == "" || os == "" || battery == "" || price == "")
            {
                MessageBox.Show("Всички полета са задължителни.");
            }
            else
            {
                var query = "INSERT INTO Phones (Brand, Model, Camera, OS, Battery, Price) VALUES (@brand, @model, @camera, @os, @battery, @price)";
                using (cnn)
                {
                    using (var cmd = new OleDbCommand(query, cnn))
                    {
                        cmd.Parameters.Add("@brand", OleDbType.Integer).Value = Convert.ToInt32(brand);
                        MessageBox.Show(Convert.ToInt32(brand).ToString());
                        cmd.Parameters.Add("@model", OleDbType.Char).Value = model;
                        cmd.Parameters.Add("@camera", OleDbType.Integer).Value = Convert.ToInt32(camera);
                        cmd.Parameters.Add("@os", OleDbType.Integer).Value = Convert.ToInt32(os);
                        cmd.Parameters.Add("@battery", OleDbType.Integer).Value = Convert.ToInt32(battery);
                        cmd.Parameters.Add("@price", OleDbType.Integer).Value = Convert.ToInt32(price);

                        try
                        {
                            cnn.Open();
                            cmd.ExecuteNonQuery();
                            cnn.Close();
                        }
                        catch
                        {
                            MessageBox.Show("SQL Insert failed.");
                        }
                    }
                }
            }
        }
    }
}
