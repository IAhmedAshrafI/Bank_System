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
    public partial class adminupdatebranch : Form
    {
        public adminupdatebranch()
        {
            InitializeComponent();
        }

        private void branch_address_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void adminupdatebank_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            adminlogin ad = new adminlogin();
            ad.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string branchnumber = branch_num_input.Text; // Assuming you have a TextBox named "textBoxSSN" for input

            // Construct the SQL UPDATE statement
            string updateQuery = "UPDATE Branch SET Address = @address WHERE BranchNumber = @branchnumber";

            // Create a SqlConnection (replace connectionStr with your actual connection string)
            using (SqlConnection connection = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Bank_System;Integrated Security=True"))
            {
                // Create a SqlCommand with the update query and connection
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    // Set parameter values
                    command.Parameters.AddWithValue("@address", branch_address_input.Text); // Assuming you have a TextBox named "textBoxAddress" for address input
                    command.Parameters.AddWithValue("@branchnumber", branchnumber);

                    try
                    {
                        // Open the database connection
                        connection.Open();
                        // Execute the UPDATE query
                        int rowsAffected = command.ExecuteNonQuery();
                        // Display the number of rows affected (optional)
                        MessageBox.Show(rowsAffected + " row(s) updated successfully.");
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that occur during the update process
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminaddbranch addbranch = new adminaddbranch();
            addbranch.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminaddbank addbank = new adminaddbank();
            addbank.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            admindeletebranch deletebranch = new admindeletebranch();
            deletebranch.Show();
            this.Hide();
        }
    }
}