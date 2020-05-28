using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uspproject
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPhone form = new AddPhone();
            form.Owner = this;
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AllPhones form = new AllPhones();
            form.Owner = this;
            form.Text = "Изтриване на телефон";
            AllPhones.isDelete = true;
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AllPhones form = new AllPhones();
            form.Owner = this;
            form.Text = "Всички телефони";
            AllPhones.isDelete = false;
            form.Show();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            this.Owner.Hide();
        }

        private void AdminPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Owner.Show();
        }
    }
}
