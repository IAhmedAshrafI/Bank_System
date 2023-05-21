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
    public partial class emplistofcustomers : Form
    {
        public emplistofcustomers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            emplistofloans emplistofloans = new emplistofloans();
            emplistofloans.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            emploggedin emploggedin = new emploggedin();
            emploggedin.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            emplistofloans emplistofloans = new emplistofloans();
            emplistofloans.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            emplistofpendingloans emplistofpendingloans = new emplistofpendingloans();
            emplistofpendingloans.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            emplogin emplogin = new emplogin();
            emplogin.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void emplistofcustomers_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            empupdatecustomer empupdatecustomer = new empupdatecustomer();
            empupdatecustomer.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string query = "SELECT Customer.Name, Customer.SSN, Account.AccountNumber " + "FROM Customer " + "INNER JOIN Account ON Customer.SSN = Account.CustomerSSN";

            // Create a SqlConnection (replace connectionStr with your actual connection string)
            using (SqlConnection connection = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Bank_System;Integrated Security=True"))
            {
                // Create a SqlDataAdapter with the query and connection
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    try
                    {
                        // Create a new DataTable to hold the results
                        DataTable dataTable = new DataTable();

                        // Fill the DataTable with the query results
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the dataGridView1 control
                        dataGridView1.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that occur during the data retrieval process
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            empdeletecustomer empdeletecustomer = new empdeletecustomer(); 
            empdeletecustomer.Show();
            this.Hide();
        }
    }
}