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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.TransparencyKey = Color.Gray;
            this.BackColor = Color.Gray;
        }

        private string username, password;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

            this.Owner.Hide();
            label1.BackColor = Color.White;
            label2.BackColor = Color.White;
            this.ActiveControl = textBox1;

            string dbDir = AppDomain.CurrentDomain.BaseDirectory + "admin.accdb";
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @dbDir;
            OleDbConnection cnn = new OleDbConnection(connString);
            try
            {
                cnn.Open();
                OleDbDataReader reader = null;
                OleDbCommand command = new OleDbCommand("SELECT Username, Password FROM Users", cnn);

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    username = reader["Username"].ToString();
                    password = reader["Password"].ToString();
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string current_user, current_password;
            current_user = textBox1.Text;
            current_password = textBox2.Text;
            if (current_user == username && current_password == password)
            {
                AdminPanel form = new AdminPanel();
                form.Owner = this;
                form.Show();
            }
            else
            {
                MessageBox.Show("Моля въведете правилни данни за достъп.", "Достъп отказан", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button2_Click(this, e);
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
