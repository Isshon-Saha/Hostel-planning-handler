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
    public partial class Admin_panel : Form
    {
        public Admin_panel()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            ORMDataContext o1 = new ORMDataContext();
            dataGridView1.DataSource = o1.User_infos;
        }
        private void Admin_panel_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ORMDataContext o1 = new ORMDataContext();
            Control c1 = new Control();
            c1.ShowDialog();
            LoadData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void Admin_panel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Control c1 = new Control();
                c1.textBox1.ReadOnly = true;
                c1.textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                c1.textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                c1.textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                c1.textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                c1.textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                c1.ShowDialog();
                LoadData();
            }

        }
    }
}
