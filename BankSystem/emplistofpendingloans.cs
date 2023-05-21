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
using Microsoft.VisualBasic;

namespace BankSystem
{
    public partial class emplistofpendingloans : Form
    {






        public emplistofpendingloans()
        {
            InitializeComponent();

            // Assuming you have a DataGridView control named loanDataGridView
            DataGridViewButtonColumn acceptButtonColumn = new DataGridViewButtonColumn();
            acceptButtonColumn.HeaderText = "Accept";
            acceptButtonColumn.Name = "AcceptButton";
            acceptButtonColumn.Text = "Accept";
            acceptButtonColumn.UseColumnTextForButtonValue = true;
            loandataGridView.Columns.Add(acceptButtonColumn);

            DataGridViewButtonColumn rejectButtonColumn = new DataGridViewButtonColumn();
            rejectButtonColumn.HeaderText = "Reject";
            rejectButtonColumn.Name = "RejectButton";
            rejectButtonColumn.Text = "Reject";
            rejectButtonColumn.UseColumnTextForButtonValue = true;
            loandataGridView.Columns.Add(rejectButtonColumn);

         
        }
        private void emplistofpendingloans_Load(object sender, EventArgs e)
        {
            // Add the event handler for button clicks
            loandataGridView.CellContentClick += loanDataGridView_CellContentClick;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            emplistofcustomers emplistofcustomers = new emplistofcustomers();
            emplistofcustomers.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            emplistofloans emploans = new emplistofloans();
            emploans.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            emplistofcustomers emplistofcustomers = new emplistofcustomers();
            emplistofcustomers.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            emplogin emplogin = new emplogin();
            emplogin.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Bank_System;Integrated Security=True";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlSelect = "SELECT * FROM Loan WHERE LoanType IS NULL OR LoanType = ''";
                SqlCommand cmd = new SqlCommand(sqlSelect, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                loandataGridView.DataSource = dataTable;
            }


        }

        private void loanDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Bank_System;Integrated Security=True";
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == loandataGridView.Columns["AcceptButton"].Index)
                {
                    // Handle the Accept button click
                    if (!loandataGridView.Rows[e.RowIndex].IsNewRow)
                    {
                        int loanNumber = Convert.ToInt32(loandataGridView.Rows[e.RowIndex].Cells["LoanNumber"].Value);
                        string loanType = Interaction.InputBox("Enter loan type:", "Loan Type", "");

                        if (!string.IsNullOrEmpty(loanType))
                        {
                            // Remove the loan from the pending loans
                            loandataGridView.Rows.RemoveAt(e.RowIndex);

                            // Update the Loan table with the loan type
                            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                            {
                                string sqlUpdate = "UPDATE Loan SET LoanType = @LoanType WHERE LoanNumber = @PendingLoanNumber";
                                SqlCommand cmd = new SqlCommand(sqlUpdate, sqlConnection);
                                cmd.Parameters.AddWithValue("@LoanType", loanType);
                                cmd.Parameters.AddWithValue("@PendingLoanNumber", loanNumber);

                                sqlConnection.Open();
                                cmd.ExecuteNonQuery();
                                sqlConnection.Close();

                                MessageBox.Show("Loan accepted");
                            }
                        }
                    }
                }
                else if (e.ColumnIndex == loandataGridView.Columns["RejectButton"].Index)
                {
                    // Handle the Reject button click
                    if (!loandataGridView.Rows[e.RowIndex].IsNewRow)
                    {
                        int loanNumber = Convert.ToInt32(loandataGridView.Rows[e.RowIndex].Cells["LoanNumber"].Value);

                        // Delete the loan from the Loan table
                        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                        {
                            string sqlDelete = "DELETE FROM Loan WHERE LoanNumber = @LoanNumber";
                            SqlCommand cmd = new SqlCommand(sqlDelete, sqlConnection);
                            cmd.Parameters.AddWithValue("@LoanNumber", loanNumber);

                            sqlConnection.Open();
                            cmd.ExecuteNonQuery();
                            sqlConnection.Close();

                            MessageBox.Show("Loan rejected");
                        }

                        // Remove the loan from the pending loans
                        loandataGridView.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            empupdatecustomer empupdatecustomer = new empupdatecustomer();
            empupdatecustomer.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            empdeletecustomer empdeletecustomer = new empdeletecustomer();
            empdeletecustomer.Show();
            this.Hide();
        }
    }
}
