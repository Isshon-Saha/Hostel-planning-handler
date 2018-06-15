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
    public partial class Hostel_select : Form
    {
        public string sel = Form1.selectedarea;
        public Hostel_select()
        {
            InitializeComponent();
        }

        private void Hostel_select_Load(object sender, EventArgs e)
        {
            ORMDataContext a1 = new ORMDataContext();
            Hostel_find h1 = new Hostel_find();
            var query = from Hostel_find in a1.Hostel_finds
                        where Hostel_find.A_name == sel
                        select Hostel_find.H_name;

            comboBox1.ValueMember = "H_name";
            comboBox1.DisplayMember = "H_name";
            comboBox1.DataSource = query;

            var query1 = from Cost_info in a1.Cost_infos
                         where Cost_info.name == comboBox1.SelectedItem.ToString()
                         select Cost_info;
            dataGridView1.DataSource = query1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Login.login_type=="user")
            {
                ORMDataContext a1 = new ORMDataContext();
                Verification_table v1 = new Verification_table();
                v1.Hostel_name = comboBox1.SelectedItem.ToString();
                v1.Login_name = Login.login_name;
                v1.Verifi_status = "pending";
                MessageBox.Show("Applied successfully");
            }
            else if(Login.login_type=="admin")
            {
                ORMDataContext a1 = new ORMDataContext();
                Verification_table v1 = new Verification_table();
                v1.Hostel_name = comboBox1.SelectedItem.ToString();
                v1.Login_name = Login.login_name;
                v1.Verifi_status = "Approved";
                MessageBox.Show("Room booked");
            }
            else
            {
                MessageBox.Show("You need to login first");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ORMDataContext a1 = new ORMDataContext();
            var query1 = from Cost_info in a1.Cost_infos
                         where Cost_info.name == comboBox1.SelectedItem.ToString()
                         select Cost_info;
            dataGridView1.DataSource = query1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void Hostel_select_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
