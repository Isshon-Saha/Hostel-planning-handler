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
    public partial class Account_normal_page : Form
    {
        public Account_normal_page()
        {
            InitializeComponent();
        }

        private void Account_normal_page_Load(object sender, EventArgs e)
        {
            ORMDataContext o1 = new ORMDataContext();
            User_info u1 = new User_info();
            label2.Text = Login.login_name;
            label6.Text = Login.login_name;
            var query = (from User_info in o1.User_infos
                        where User_info.First_name == Login.login_name
                        select User_info.E_mail).Single();
            label7.Text = query.ToString();
            var query1 = (from User_info in o1.User_infos
                        where User_info.First_name == Login.login_name
                        select User_info.DOB).Single();
            label8.Text = query1.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.login_name = "not logged in";
            Login l = new Login();
            l.ShowDialog();
        }

        private void Account_normal_page_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
