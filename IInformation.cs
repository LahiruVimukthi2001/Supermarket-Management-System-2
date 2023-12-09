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

namespace Enterprise_Systems_Project
{
    public partial class IInformation : Form
    {
        public IInformation()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //add
            try
            {
                String ConnectionString = "Data Source=DESKTOP-1KGGCVK\\SQLEXPRESS;Initial Catalog=SuperMarket_DB;Integrated Security=True";
                SqlConnection Con = new SqlConnection(ConnectionString);
                Con.Open();
                string query = "insert into ITinformationTbl values('" + IID.Text + "','" + IName.Text + "','" + CPrice.Text + "','" + RPrice.Text + "','" + IStock.Text + "','" + SIn.Text + "','" + SOut.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Seller Details Added Successfully");
                Con.Close();
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void populate()
        {
            String ConnectionString = "Data Source=DESKTOP-1KGGCVK\\SQLEXPRESS;Initial Catalog=SuperMarket_DB;Integrated Security=True";
            SqlConnection Con = new SqlConnection(ConnectionString);

            Con.Open();
            string query = "select * from ITinformationTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //edit
            try
            {
                if (IID.Text == "" || IName.Text == "" || CPrice.Text == "" || RPrice.Text == "" || IStock.Text == "" || SIn.Text == "" || SOut.Text == "" )
                {
                    MessageBox.Show("Your Item Information is missing");
                }
                else
                {
                    String ConnectionString = "Data Source=DESKTOP-1KGGCVK\\SQLEXPRESS;Initial Catalog=SuperMarket_DB;Integrated Security=True";
                    SqlConnection Con = new SqlConnection(ConnectionString);

                    Con.Open();
                    string query = "update  ITinformationTbl set Item_Name = '" + IName.Text + "', Cost_Price ='" + CPrice.Text + "', Retail_Price ='" + RPrice.Text + "', Initial_Stock = '" + IStock.Text + "', Stock_In = '" + SIn.Text + "',Stock_Out = '" + SOut.Text + "'  where Item_ID= '"+IID.Text+"'; ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Information Successfully Updated");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //delete
            try
            {
                if (IID.Text == "" || IName.Text == "" || CPrice.Text == "" || RPrice.Text == "" || IStock.Text == "" || SIn.Text == "" || SOut.Text == "")
                {
                    MessageBox.Show("Select the Item Information to delete");
                }
                else
                {
                    String ConnectionString = "Data Source=DESKTOP-1KGGCVK\\SQLEXPRESS;Initial Catalog=SuperMarket_DB;Integrated Security=True";
                    SqlConnection Con = new SqlConnection(ConnectionString);

                    Con.Open();
                    string query = "delete from ITinformationTbl where Item_ID= '" + IID.Text + "' ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Information Deleted Successfully");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataguide view
            IID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            IName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            CPrice.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            RPrice.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            IStock.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            SIn.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            SOut.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}
