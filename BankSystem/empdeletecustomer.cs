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
            string ssnToDelete = SSN_input.Text; // Assuming you have a TextBox named "SSN_input" for SSN input
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Bank_System;Integrated Security=True";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                // Start a transaction
                SqlTransaction transaction = sqlConnection.BeginTransaction();

                try
                {
                    // Delete account records associated with the customer
                    string accountDeleteQuery = "DELETE FROM Account WHERE CustomerSSN = @ssn";
                    using (SqlCommand accountDeleteCommand = new SqlCommand(accountDeleteQuery, sqlConnection, transaction))
                    {
                        accountDeleteCommand.Parameters.AddWithValue("@ssn", ssnToDelete);
                        int accountRowsAffected = accountDeleteCommand.ExecuteNonQuery();
                    }

                    // Delete customer record
                    string customerDeleteQuery = "DELETE FROM Customer WHERE SSN = @ssn";
                    using (SqlCommand customerDeleteCommand = new SqlCommand(customerDeleteQuery, sqlConnection, transaction))
                    {
                        customerDeleteCommand.Parameters.AddWithValue("@ssn", ssnToDelete);
                        int customerRowsAffected = customerDeleteCommand.ExecuteNonQuery();

                        if (customerRowsAffected == 0)
                        {
                            // No customer with the provided SSN was found
                            transaction.Rollback();
                            MessageBox.Show("No customer with the provided SSN was found.");
                            return;
                        }
                    }

                    // Commit the transaction if both delete statements executed successfully
                    transaction.Commit();
                    MessageBox.Show("The customer has been deleted successfully.");
                }
                catch (Exception ex)
                {
                    // Roll back the transaction if an error occurs
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
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
