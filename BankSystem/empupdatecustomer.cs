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
    public partial class empupdatecustomer : Form
    {
        public empupdatecustomer()
        {
            InitializeComponent();
        }

        private void empupdatecustomer_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void userAddr_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void userPhone_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void userSSN_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void branchNo_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ssn = userSSN_input.Text; // Assuming you have a TextBox named "textBoxSSN" for input

            // Construct the SQL UPDATE statement
            string updateQuery = "UPDATE Customer SET Address = @address, Phone = @phone WHERE SSN = @ssn";

            // Create a SqlConnection (replace connectionStr with your actual connection string)
            using (SqlConnection connection = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Bank_System;Integrated Security=True"))
            {
                // Create a SqlCommand with the update query and connection
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    // Set parameter values
                    command.Parameters.AddWithValue("@address", userAddr_input.Text); // Assuming you have a TextBox named "textBoxAddress" for address input
                    command.Parameters.AddWithValue("@phone", userPhone_input.Text); // Assuming you have a TextBox named "textBoxPhone" for phone number input
                    command.Parameters.AddWithValue("@ssn", ssn);

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
            emploggedin emp = new emploggedin();
            emp.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            emplistofloans emp = new emplistofloans();
            emp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            emplistofcustomers emp = new emplistofcustomers();
            emp.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            emplistofpendingloans emp = new emplistofpendingloans();
            emp.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            empdeletecustomer emp = new empdeletecustomer();
            emp.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            emplogin emp = new emplogin();
            emp.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }
    }
}
