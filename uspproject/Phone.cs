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
    public partial class Phone : Form
    {
        public Phone()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public static string brand;
        public static string model;
        public static string frontPic = "";
        public static string backPic = "";
        public static bool isTest = false;

        public string brandLabel
        {
            get { return label9.Text; }
            set { label9.Text = value; }
        }

        public string modelLabel
        {
            get { return label10.Text; }
            set { label10.Text = value; }
        }

        public string cameraLabel
        {
            get { return label11.Text; }
            set { label11.Text = value; }
        }

        public string osLabel
        {
            get { return label12.Text; }
            set { label12.Text = value; }
        }

        public string batteryLabel
        {
            get { return label13.Text; }
            set { label13.Text = value; }
        }

        public string priceLabel
        {
            get { return label14.Text; }
            set { label14.Text = value; }
        }

        public string colorComboBox;

        private void Phone_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.Owner.Hide();
            string dbDir = AppDomain.CurrentDomain.BaseDirectory + "uspdb.accdb";
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @dbDir;
            OleDbConnection cnn = new OleDbConnection(connString);
            try
            {
                cnn.Open();
                OleDbDataReader reader = null;
                OleDbCommand command = null;
                if (!isTest)
                {

                    command = new OleDbCommand("SELECT TOP 1 b.Brand, p.Model, p.Camera, c.Color, o.OS, p.OSver, p.Battery, p.Price, p.FrontPic, p.BackPic " +
                        "FROM (((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID) LEFT JOIN Colors c on p.Color = c.ID)" +
                        " WHERE b.Brand = @brand AND p.Model = @model", cnn);
                    command.Parameters.AddWithValue("@brand", brand);
                    command.Parameters.AddWithValue("@model", model);

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        label9.Text = reader["Brand"].ToString();
                        label10.Text = reader["Model"].ToString();
                        label11.Text = reader["Camera"].ToString() + " mpx.";
                        label12.Text = reader["OS"].ToString() + " " + reader["OSver"].ToString();
                        label13.Text = reader["Battery"].ToString() + " mAh";
                        label14.Text = reader["Price"].ToString() + " лв.";
                        pictureBox1.Load(reader["FrontPic"].ToString().Replace("#", ""));
                        frontPic = reader["FrontPic"].ToString().Replace("#", "");
                        backPic = reader["BackPic"].ToString().Replace("#", "");
                    }

                    command = new OleDbCommand("SELECT c.Color FROM (((Phones p INNER JOIN Brands b on p.Brand = b.ID) " +
                        " LEFT JOIN OS o on p.OS = o.ID) LEFT JOIN Colors c on p.Color = c.ID) WHERE b.Brand = @brand AND p.Model = @model", cnn);
                    command.Parameters.AddWithValue("@brand", brand);
                    command.Parameters.AddWithValue("@model", model);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["Color"].ToString());
                    }
                    comboBox1.SelectedIndex = 0;
                }
                else
                {

                    label9.Text = brandLabel;
                    label10.Text = modelLabel;
                    label11.Text = cameraLabel + " mpx.";
                    label12.Text = osLabel;
                    label13.Text = batteryLabel + " mAh";
                    label14.Text = priceLabel + " лв.";
                    pictureBox1.Load(frontPic);
                    label15.Visible = true;
                    comboBox1.Visible = false;
                    label15.Text = colorComboBox;
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.ToString());
            }
        }
        

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (backPic != "")
            {
                pictureBox1.Load(backPic);
            }
            else
            {
                pictureBox1.Image = uspproject.Properties.Resources.NoImageFound;
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (frontPic != "")
            {
                pictureBox1.Load(frontPic);
            }
            else
            {
                pictureBox1.Image = uspproject.Properties.Resources.NoImageFound;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            string dbDir = AppDomain.CurrentDomain.BaseDirectory + "uspdb.accdb";
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @dbDir;
            OleDbConnection cnn = new OleDbConnection(connString);
            try
            {
                cnn.Open();
                OleDbDataReader reader = null;
                OleDbCommand command = null;
                command = new OleDbCommand("SELECT p.FrontPic, p.BackPic FROM (((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID)" + 
                    " LEFT JOIN Colors c on p.Color = c.ID) WHERE b.Brand = @brand AND p.Model = @model AND c.Color = @color", cnn);
                command.Parameters.AddWithValue("@brand", brand);
                command.Parameters.AddWithValue("@model", model);
                command.Parameters.AddWithValue("@color", selectedValue);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    pictureBox1.Load(reader["FrontPic"].ToString().Replace("#", ""));
                    frontPic = reader["FrontPic"].ToString().Replace("#", "");
                    backPic = reader["BackPic"].ToString().Replace("#", "");
                }

                command = new OleDbCommand("SELECT p.Price FROM (((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID)" +
                    " LEFT JOIN Colors c on p.Color = c.ID) WHERE b.Brand = @brand AND p.Model = @model AND c.Color = @color", cnn);
                command.Parameters.AddWithValue("@brand", brand);
                command.Parameters.AddWithValue("@model", model);
                command.Parameters.AddWithValue("@color", selectedValue);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    label14.Text = reader["Price"].ToString() + " лв.";
                }

                cnn.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show("Exception: " + ex.ToString());
            }

        }

        private void Phone_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
