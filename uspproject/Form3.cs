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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection cnn;
        private void Form3_Load(object sender, EventArgs e)
        {
            string dbDir = AppDomain.CurrentDomain.BaseDirectory + "uspdb.accdb";
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbDir.Replace("\\", "\\\\");
            cnn = new OleDbConnection(connString);
            try
            {
                cnn.Open();
                label2.Text = "Успешна";
                label2.ForeColor = System.Drawing.Color.Green;
                string searchText = Form1.searchText;
                string keyword = "";
                switch (Form1.selectedIndex)
                {
                    case 0: keyword = "Brand";
                        break;
                    case 1: keyword = "Model";
                        break;
                    case 2: keyword = "Camera";
                        break;
                    case 3: keyword = "OS";
                        break;
                    case 4: keyword = "Battery";
                        break;
                    case 5: keyword = "Price";
                        break;

                }

                OleDbDataReader reader = null;
                OleDbCommand command = null;

                if(keyword == "Brand")
                {
                    command = new OleDbCommand("SELECT b.Brand, p.Model, p.Camera, o.OS, p.Battery, p.Price FROM ((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID) WHERE b.Brand = ?", cnn);
                }else if(keyword == "OS"){
                    command = new OleDbCommand("SELECT b.Brand, p.Model, p.Camera, o.OS, p.Battery, p.Price FROM ((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID) WHERE o.OS = ?", cnn);
                }else{
                    command = new OleDbCommand("SELECT b.Brand, p.Model, p.Camera, o.OS, p.Battery, p.Price FROM ((Phones p INNER JOIN Brands b on p.Brand = b.ID) LEFT JOIN OS o on p.OS = o.ID) WHERE p." + keyword + " = ?", cnn);
                }

                command.Parameters.Add(new OleDbParameter("@searchValue", searchText));
                reader = command.ExecuteReader();
                dataGridView1.ColumnCount = 6;
                dataGridView1.Columns[0].Name = "Brand";
                dataGridView1.Columns[1].Name = "Model";
                dataGridView1.Columns[2].Name = "Camera";
                dataGridView1.Columns[3].Name = "OS";
                dataGridView1.Columns[4].Name = "Battery";
                dataGridView1.Columns[5].Name = "Price";
                while (reader.Read())
                {
                    string[] row = new string[] { reader["Brand"].ToString(), reader["Model"].ToString(), reader["Camera"].ToString()+" mpx", reader["OS"].ToString(), reader["Battery"].ToString() + " mAh", reader["Price"].ToString() + " лв." };
                    dataGridView1.Rows.Add(row);                    
                }
            }
            catch
            {
                label2.Text = "Неуспешна";
                label2.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}
