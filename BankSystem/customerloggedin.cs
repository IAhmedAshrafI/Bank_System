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
    public partial class customerloggedin : Form
    {
        public customerloggedin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            customerlogin customerlogin = new customerlogin();
            customerlogin.Show();
            this.Hide();
        }

        private void employeeloggedin_Load(object sender, EventArgs e)
        {

        }

        private bool IsFound(string attribute, string table, string value, SqlConnection con)
        {
            string sqlSelect = "SELECT " + attribute + " FROM " + table;
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string bCodeInput = value;

            // Check if the value exists in the DataTable
            DataRow[] foundRows = dt.Select(attribute + " = '" + bCodeInput + "'");
            return foundRows.Length > 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Bank_System;Integrated Security=True";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                bool found = IsFound("BranchNumber", "Branch", branchNo_input.Text, sqlConnection);
                if (found)
                {
                    string sqlInsert = "insert into Loan(LoanAmount,BranchNumber) values(@LoanAmount,@BranchNumber)";
                    SqlCommand cmd = new SqlCommand(sqlInsert, sqlConnection);
                    cmd.Parameters.AddWithValue("@LoanAmount",amount_input.Text);
                    cmd.Parameters.AddWithValue("@BranchNumber", branchNo_input.Text);
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("The loan is under review");
                }
                else
                {
                    MessageBox.Show("The Branch was not found");
                }

            }
        }
    }
}
