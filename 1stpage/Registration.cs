using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1stpage
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l1 = new Login();
            l1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox2.Text == null || textBox3.Text == null || textBox4.Text == null || textBox5.Text == null)
            {
                MessageBox.Show("Please fill up the form properly");
            }
            else if (textBox4.Text.Equals(textBox5.Text))
            {
                ORMDataContext db = new ORMDataContext();
                User_info u1 = new User_info();
                u1.First_name = textBox1.Text;
                u1.Last_name = textBox2.Text;
                u1.E_mail = textBox3.Text;
                u1.Password = textBox5.Text;
                u1.DOB = dateTimePicker1.Text;
                db.User_infos.InsertOnSubmit(u1);
                db.SubmitChanges();
                MessageBox.Show("Account created successfully");
            }
            else
            {
                MessageBox.Show("Password mismatch");
            }
        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
