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
    public partial class Form1 : Form
    {
        public static string selectedarea
        {
            get;
            set;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Search_data_Click(object sender, EventArgs e)
        {
            string City = comboBox1.Text;
            

            try
            {
                StringBuilder queryaddress = new StringBuilder();
                queryaddress.Append("https://www.google.com.bd/maps/@23.7210967,90.4078061,15z?hl=en");

                if(City != string.Empty)
                {
                    queryaddress.Append("/"+City+","+"+");


                }

               
                


                webBrowser1.Navigate(queryaddress.ToString());


            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ORMDataContext db = new ORMDataContext();
            //Area objCourse = db.Areas.Single(Area => Area.Area1 == "sample");

            //objCourse.Area1 = comboBox1.SelectedItem.ToString();
            //db.SubmitChanges();

            selectedarea = comboBox1.SelectedItem.ToString();
            this.Hide();
            Hostel_select h1 = new Hostel_select();
            h1.ShowDialog();


        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StringBuilder queryaddress = new StringBuilder();
            queryaddress.Append("https://www.google.com.bd/maps/@23.7210967,90.4078061,15z?hl=en");
            webBrowser1.Navigate(queryaddress.ToString());
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Startup s = new Startup();
            s.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
