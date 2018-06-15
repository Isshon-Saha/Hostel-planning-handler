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
    public partial class Control : Form
    {
        public Control()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ORMDataContext db = new ORMDataContext();
            User_info u1 = new User_info();
            if (textBox1.ReadOnly == false)
            {


                u1.First_name = textBox1.Text;
                u1.Last_name = textBox2.Text;
                u1.E_mail = textBox4.Text;
                u1.Password = textBox3.Text;
                u1.DOB = textBox5.Text;
                u1.Account_type = "user";
                db.User_infos.InsertOnSubmit(u1);
                db.SubmitChanges();
                MessageBox.Show("Data inserted successfully");
            }
            else
            {
                User_info u2 = db.User_infos.SingleOrDefault();
                u2.First_name = textBox1.Text;
                u2.Last_name = textBox2.Text;
                u2.E_mail = textBox3.Text;
                u2.Password = textBox4.Text;
                u2.DOB = textBox5.Text;
                db.SubmitChanges();
                MessageBox.Show("Record updated");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void Control_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
