using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class empdeletecustomer : Form
    {
        public empdeletecustomer()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=BODA;Initial Catalog=Bank_System;Integrated Security=True";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string ssnToDelete = SSN_input.Text;
                string sqlDelete = "DELETE FROM Customer WHERE SSN = @SSN";
                SqlCommand cmd = new SqlCommand(sqlDelete, sqlConnection);
                cmd.Parameters.AddWithValue("@SSN", ssnToDelete);

                sqlConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("The customer has been deleted successfully");
                }
                else
                {
                    MessageBox.Show("No customer with the provided SSN was found");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            emploggedin emploggedin = new emploggedin();
            emploggedin.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            emplistofloans emplistofloans = new emplistofloans();
            emplistofloans.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            emplistofcustomers emplistofcustomers = new emplistofcustomers();
            emplistofcustomers.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            emplistofpendingloans emplistofpendingloans = new emplistofpendingloans();
            emplistofpendingloans.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            empupdatecustomer empupdatecustomer = new empupdatecustomer();
            empupdatecustomer.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            emplogin emplogin = new emplogin();
            emplogin.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void empdeletecustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
