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
using System.Timers;
using System.Text.RegularExpressions;

namespace uspproject
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TransparencyKey = Color.Gray;
            this.BackColor = Color.Gray;
        }

        public static string searchText;
        public static int selectedIndex;
        private string keyword = "";

        private void showSearchField()
        {
            label3.Visible = true;
            textBox1.Visible = true;
            comboBox2.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    label3.Text = "Въведете марка за търсене:";
                    showSearchField();
                    break;
                case 1:
                    label3.Text = "Въведете модел за търсене:";
                    showSearchField();
                    break;
                case 2:
                    label3.Text = "Въведете камера за търсене\n (в mpx):";
                    showSearchField();
                    break;
                case 3:
                    label3.Text = "Въведете ОС за търсене:";
                    showSearchField();
                    break;
                case 4:
                    label3.Text = "Въведете батерия за търсене:";
                    showSearchField();
                    break;
                case 5:
                    label3.Text = "Изберете цена за търсене:";
                    textBox1.Visible = false;
                    label3.Visible = true;
                    comboBox2.Visible = true;
                    break;
            }  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.White;
            pictureBox4.BackColor = Color.White;
            label2.BackColor = Color.White;
            label3.BackColor = Color.White;
            label1.BackColor = Color.White;
            comboBox1.DropDownWidth = 135;

            label1.Text = (DateTime.Now).ToString(@"HH\:mm");

            var timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timer.Tick += (o, args) =>
            {
                label1.Text = (DateTime.Now).ToString(@"HH\:mm");
            };
            timer.Start();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Наистина ли желаете да напуснете приложението?", "Изход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Owner = this;
            form.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string search = textBox1.Text;
            
            dataGridView1.Rows.Clear();
            string dbDir = AppDomain.CurrentDomain.BaseDirectory + "uspdb.accdb";
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @dbDir;
            OleDbConnection cnn = new OleDbConnection(connString);
            try
            {
                cnn.Open();
                OleDbDataReader reader = null;
                OleDbCommand command = null;
                switch (comboBox1.SelectedIndex)
                {
                    case 0: keyword = "Brand";
                        command = new OleDbCommand("SELECT DISTINCT b.Brand, p.Model, p.Camera, o.OS, p.Battery FROM (((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID) LEFT JOIN Colors c on p.Color = c.ID) WHERE (b.Brand LIKE ?)", cnn);
                        break;
                    case 1: keyword = "Model";
                        command = new OleDbCommand("SELECT DISTINCT b.Brand, p.Model, p.Camera, o.OS, p.Battery FROM (((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID) LEFT JOIN Colors c on p.Color = c.ID) WHERE (p." + keyword + " LIKE ?)", cnn);
                        break;
                    case 2: keyword = "Camera";
                        command = new OleDbCommand("SELECT DISTINCT b.Brand, p.Model, p.Camera, o.OS, p.Battery FROM (((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID) LEFT JOIN Colors c on p.Color = c.ID) WHERE (p." + keyword + " LIKE ?)", cnn);
                        break;
                    case 3: keyword = "OS";
                        command = new OleDbCommand("SELECT DISTINCT b.Brand, p.Model, p.Camera, o.OS, p.Battery FROM ((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID) WHERE (o.OS LIKE ?)", cnn);
                        break;
                    case 4: keyword = "Battery";
                        command = new OleDbCommand("SELECT DISTINCT b.Brand, p.Model, p.Camera, o.OS, p.Battery FROM (((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID) LEFT JOIN Colors c on p.Color = c.ID) WHERE (p." + keyword + " LIKE ?)", cnn);
                        break;
                    case 5: keyword = "Price";
                        break;
                    default:
                        command = new OleDbCommand("SELECT DISTINCT b.Brand, p.Model, p.Camera, o.OS, p.Battery FROM (((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID) LEFT JOIN Colors c on p.Color = c.ID) WHERE (p." + keyword + " LIKE ?)", cnn);
                        break;
                }
                search = String.Concat(search.Where(c => c >= '0' && c <= '9' || c>='a' && c<='z' || c>='A' && c<='Z'));

                command.Parameters.AddWithValue("@searchValue", "%" + search + "%"); 
                reader = command.ExecuteReader();
                dataGridView1.ColumnCount = 2;
                dataGridView1.Columns[0].Name = "Марка";
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Name = "Модел";
                dataGridView1.Columns[1].Width = 135;
                while (reader.Read())
                {
                    string[] row = new string[] { reader["Brand"].ToString(), reader["Model"].ToString()};
                    dataGridView1.Rows.Add(row);
                }
                cnn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception" + ex.ToString());
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Phone form = new Phone();
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            Phone.brand = Convert.ToString(selectedRow.Cells["Марка"].Value);
            Phone.model = Convert.ToString(selectedRow.Cells["Модел"].Value);
            form.Owner = this;
            form.Text = "Телефон";
            form.Show();
            Phone.isTest = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string dbDir = AppDomain.CurrentDomain.BaseDirectory + "uspdb.accdb";
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @dbDir;
            OleDbConnection cnn = new OleDbConnection(connString);
            try
            {
                cnn.Open();
                OleDbDataReader reader = null;
                OleDbCommand command = null;
                keyword = "Price";
                switch (comboBox2.SelectedIndex)
                {
                    case 0: command = new OleDbCommand("SELECT DISTINCT b.Brand, p.Model, p.Camera, o.OS, p.Battery FROM (((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID) LEFT JOIN Colors c on p.Color = c.ID) WHERE (p." + keyword + " < 50)", cnn);
                        break;
                    case 1: command = new OleDbCommand("SELECT DISTINCT b.Brand, p.Model, p.Camera, o.OS, p.Battery FROM (((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID) LEFT JOIN Colors c on p.Color = c.ID) WHERE (p." + keyword + " >= 51) AND (p." + keyword + " < 200)", cnn);
                        break;
                    case 2: command = new OleDbCommand("SELECT DISTINCT b.Brand, p.Model, p.Camera, o.OS, p.Battery FROM (((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID) LEFT JOIN Colors c on p.Color = c.ID) WHERE (p." + keyword + " >= 201) AND (p." + keyword + " < 500)", cnn);
                        break;
                    case 3: command = new OleDbCommand("SELECT DISTINCT b.Brand, p.Model, p.Camera, o.OS, p.Battery FROM (((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID) LEFT JOIN Colors c on p.Color = c.ID) WHERE (p." + keyword + " >= 501) AND (p." + keyword + " < 1000)", cnn);
                        break;
                    case 4: command = new OleDbCommand("SELECT DISTINCT b.Brand, p.Model, p.Camera, o.OS, p.Battery FROM (((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID) LEFT JOIN Colors c on p.Color = c.ID) WHERE p." + keyword + " > 1000", cnn);
                        break;
                }

                reader = command.ExecuteReader();
                dataGridView1.ColumnCount = 2;
                dataGridView1.Columns[0].Name = "Brand";
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Name = "Model";
                dataGridView1.Columns[1].Width = 145;
                while (reader.Read())
                {
                    string[] row = new string[] { reader["Brand"].ToString(), reader["Model"].ToString() };
                    dataGridView1.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.ToString());
            }
        }
    }
}
