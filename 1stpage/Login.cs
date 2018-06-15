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
    public partial class Login : Form
    {
        public static string login_name
        {
            set;
            get;
        }
        public static string login_type
        {
            set;
            get;
        }
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Password sent to your number");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration r1 = new Registration();
            r1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Startup s = new Startup();
            s.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ORMDataContext db = new ORMDataContext();
            var query = from User_info in db.User_infos
                        where User_info.First_name == textBox1.Text && User_info.Password == textBox2.Text && User_info.Account_type=="user"
                        select User_info;
            var query1 = from User_info in db.User_infos
                         where User_info.First_name == textBox1.Text && User_info.Password == textBox2.Text && User_info.Account_type == "admin"
                         select User_info;
            if (query.Any())
            {
                this.Hide();
                Account_normal_page a1 = new Account_normal_page();
                login_name = textBox1.Text;
                login_type = "user";
                a1.Show();
                
            }
            else if (query1.Any())
            {
                this.Hide();
                Admin_panel a1 = new Admin_panel();
                login_name = textBox1.Text;
                login_type = "admin";
                a1.Show();
                
            }
            else
            {
                label4.Visible = true;
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
