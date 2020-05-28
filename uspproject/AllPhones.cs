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
    public partial class AllPhones : Form
    {
        public AllPhones()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public static bool isDelete = false;

        private void AllPhones_Load(object sender, EventArgs e)
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
                command = new OleDbCommand("SELECT b.Brand, p.Model, p.Camera, c.Color, o.OS, p.OSver, p.Battery, p.Price FROM"+ 
                    " (((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID)" + 
                    " LEFT JOIN Colors c on p.Color = c.ID)", cnn);
                reader = command.ExecuteReader();

                dataGridView1.ColumnCount = 7;
                dataGridView1.Columns[0].Name = "Марка";
                dataGridView1.Columns[1].Name = "Модел";
                dataGridView1.Columns[2].Name = "Камера";
                dataGridView1.Columns[3].Name = "Цвят";
                dataGridView1.Columns[4].Name = "Операционна система";
                dataGridView1.Columns[4].Width = 200;
                dataGridView1.Columns[5].Name = "Батерия";
                dataGridView1.Columns[6].Name = "Цена";

                while (reader.Read())
                {
                    string[] row = new string[] { reader["Brand"].ToString(), 
                                                  reader["Model"].ToString(),
                                                  reader["Camera"].ToString() + " mpx.",
                                                  reader["Color"].ToString(),
                                                  reader["OS"].ToString() + " " + reader["OSver"].ToString(),
                                                  reader["Battery"].ToString() + " mAh",
                                                  reader["Price"].ToString() + " лв."};
                    dataGridView1.Rows.Add(row);
                }
                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.ToString());
            }

            if (isDelete)
            {
                button1.Visible = true;
                this.Height = 580;
            }
            else
            {
                this.Height = 524;
            }
        }

        private void AllPhones_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
            string brand = Convert.ToString(selectedRow.Cells["Марка"].Value);
            string model = Convert.ToString(selectedRow.Cells["Модел"].Value);
            string camera = Convert.ToString(selectedRow.Cells["Камера"].Value);
            string color = Convert.ToString(selectedRow.Cells["Цвят"].Value);
            string os = Convert.ToString(selectedRow.Cells["Операционна система"].Value);
            string battery = Convert.ToString(selectedRow.Cells["Батерия"].Value);
            string price = Convert.ToString(selectedRow.Cells["Цена"].Value);

            string searchOS = "";
            string dbDir = AppDomain.CurrentDomain.BaseDirectory + "uspdb.accdb";
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @dbDir;
            OleDbConnection cnn = new OleDbConnection(connString);
            try
            {
                cnn.Open();

                OleDbCommand command = new OleDbCommand("DELETE p.* FROM " +
                    "(((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID)" +
                    " LEFT JOIN Colors c on p.Color = c.ID) WHERE" + 
                    " b.Brand = @brand AND p.Model = @model AND p.Camera = @camera AND" + 
                    " c.Color = @color AND o.OS = @os AND p.Battery = @battery AND" +
                    " p.Price = @price", cnn);
                command.Parameters.Add("@brand", OleDbType.Char).Value = brand;
                command.Parameters.Add("@model", OleDbType.Char).Value = model;
                command.Parameters.Add("@camera", OleDbType.Char).Value = camera.Replace("mpx.", "").Trim();
                command.Parameters.Add("@color", OleDbType.Char).Value = color;
                if(os.Contains("iOS"))
                {
                    searchOS = os.Substring(0, 3);
                }
                else
                {
                    searchOS = os.Substring(0, 7);
                }
                command.Parameters.Add("@os", OleDbType.Char).Value = searchOS;
                command.Parameters.Add("@battery", OleDbType.Integer).Value = Convert.ToInt32(battery.Replace("mAh", "").Trim());
                command.Parameters.Add("@price", OleDbType.Integer).Value = Convert.ToInt32(price.Replace("лв.", "").Trim());

                DialogResult res = MessageBox.Show("Потвърждавате ли изтриването?", "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Операцията е успешна.");
                    cnn.Close();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.ToString());
            }
        }
    }
}
