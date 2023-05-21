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
    public partial class admindeletebranch : Form
    {
        public admindeletebranch()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string branchToDelete = b_code_input.Text; // Assuming you have a TextBox named "b_code_input" for branch number input
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Bank_System;Integrated Security=True";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                // Start a transaction
                SqlTransaction transaction = sqlConnection.BeginTransaction();

                try
                {
                    // Delete account records associated with the customer
                    string accountDeleteQuery = "DELETE FROM Account WHERE CustomerSSN IN (SELECT SSN FROM Customer WHERE BranchNumber = @branchnumber)";
                    using (SqlCommand accountDeleteCommand = new SqlCommand(accountDeleteQuery, sqlConnection, transaction))
                    {
                        accountDeleteCommand.Parameters.AddWithValue("@branchnumber", branchToDelete);
                        int accountRowsAffected = accountDeleteCommand.ExecuteNonQuery();
                    }

                    //loan

                    string AccountDeleteQuery = "DELETE FROM Loan WHERE BranchNumber = @branchnumber";
                    using (SqlCommand accountDeleteCommand = new SqlCommand(AccountDeleteQuery, sqlConnection, transaction))
                    {
                        accountDeleteCommand.Parameters.AddWithValue("@branchnumber", branchToDelete);
                        int accountRowsAffected = accountDeleteCommand.ExecuteNonQuery();
                    }

                    // Delete customer records associated with the branch
                    string customerDeleteQuery = "DELETE FROM Customer WHERE BranchNumber = @branchnumber";
                    using (SqlCommand customerDeleteCommand = new SqlCommand(customerDeleteQuery, sqlConnection, transaction))
                    {
                        customerDeleteCommand.Parameters.AddWithValue("@branchnumber", branchToDelete);
                        int customerRowsAffected = customerDeleteCommand.ExecuteNonQuery();

                        if (customerRowsAffected == 0)
                        {
                            // No branch with the provided branch number was found
                            transaction.Rollback();
                            MessageBox.Show("No branches with the provided branch number was found.");
                            return;
                        }
                    }

                    // Delete branch record
                    string branchDeleteQuery = "DELETE FROM Branch WHERE BranchNumber = @branchnumber";
                    using (SqlCommand branchDeleteCommand = new SqlCommand(branchDeleteQuery, sqlConnection, transaction))
                    {
                        branchDeleteCommand.Parameters.AddWithValue("@branchnumber", branchToDelete);
                        int branchRowsAffected = branchDeleteCommand.ExecuteNonQuery();

                        if (branchRowsAffected == 0)
                        {
                            // No branch with the provided branch number was found
                            transaction.Rollback();
                            MessageBox.Show("No branches with the provided branch number was found.");
                            return;
                        }
                    }

                    // Commit the transaction if all delete statements executed successfully
                    transaction.Commit();
                    MessageBox.Show("The branch number and associated customers and accounts and customers' loans have been deleted successfully.");
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



        private void button1_Click(object sender, EventArgs e)
        {
            adminaddbank adminaddbank = new adminaddbank();
            adminaddbank.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminaddbranch adminaddbranch = new adminaddbranch();
            adminaddbranch.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            adminupdatebranch adminupdatebranch = new adminupdatebranch();
            adminupdatebranch.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adminlogin adminlogin = new adminlogin();
            adminlogin.Show();
            this.Hide();
        }

        private void admindeletebranch_Load(object sender, EventArgs e)
        {

        }
    }
}
