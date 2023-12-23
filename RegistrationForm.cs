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

namespace Enterprise_Systems_Project
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            //form
        }

        private void populate()
        {
            String ConnectionString = "Data Source=DESKTOP-1KGGCVK\\SQLEXPRESS;Initial Catalog=SuperMarket_DB;Integrated Security=True";
            SqlConnection Con = new SqlConnection(ConnectionString);

            Con.Open();
            string query = "select * from RegistrationTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //register
            //Registration table
            try
            {
                String ConnectionString = "Data Source=DESKTOP-1KGGCVK\\SQLEXPRESS;Initial Catalog=SuperMarket_DB;Integrated Security=True";
                SqlConnection Con = new SqlConnection(ConnectionString);

                Con.Open();
                string query = "insert into RegistrationTbl values('"+Cat.Text+ "','"+Nic.Text+"','" + Fname.Text+"','"+Lname.Text+"','"+Gender.Text+ "','"+Age.Text+"','"+Add.Text+"','"+Pno.Text+"','"+Email.Text+"','"+Cname.Text+"')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Registration Details Added Successfully");
                Con.Close();
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Hide();
                ManageCategory login = new ManageCategory();
                login.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //login page
            this.Hide();
            Item_Information login = new Item_Information();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cancel
            this.Hide();
            Item_Information login = new Item_Information();
            login.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {  }

        private void label16_Click(object sender, EventArgs e)
        {
            //exit
            Application.Exit();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
