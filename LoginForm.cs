using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

namespace Enterprise_Systems_Project
{
    public partial class Item_Information : Form
    {
        public Item_Information()
        {
            InitializeComponent();
        }
       
        private void LoginForm_Load(object sender, EventArgs e)
        {  }

        private void button2_Click(object sender, EventArgs e)
        {
            //clear
            this.Hide();
            Item_Information login = new Item_Information();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //db


            //login
            if (uname.Text == " " || pass.Text == " ")
            {
                MessageBox.Show("Enter the UserName and Password");
            }
            else
            {
                if (comboBox1.SelectedIndex > -1)
                {
                    if (comboBox1.SelectedItem.ToString() == "ADMIN")
                    {
                        if (uname.Text == "admin" && pass.Text == "a1234")
                        {
                            this.Hide();
                            Item_Information login = new Item_Information();
                            login.Show();
                        }
                        else
                        {
                            MessageBox.Show("ADMIN, Your UserName or Password is Wrong");
                        }
                    }
                    else if (comboBox1.SelectedItem.ToString() == "SELLER")
                    {
                        if (uname.Text == "seller" && pass.Text == "s123")
                        {
                            this.Hide();
                            ManageItems login = new ManageItems();
                            login.Show();
                        }
                        else
                        {
                            MessageBox.Show("SELLER, Your UserName or Password is Wrong");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your are not in the Section");
                    }
                }
                else
                {

                }
            }

            //database
            try
            {
                String ConnectionString = "Data Source=DESKTOP-1KGGCVK\\SQLEXPRESS;Initial Catalog=SuperMarket_DB;Integrated Security=True";
                SqlConnection Con=new SqlConnection(ConnectionString);

                Con.Open();
                string query = "insert into LoginTbl(NIC,User_Name,Password) values('" + nic.Text + "','" + uname.Text + "','" + pass.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Data is Saved");
                Con.Close();               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //register
            this.Hide();
            RegistrationForm  login = new RegistrationForm();
            login.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //exit
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
