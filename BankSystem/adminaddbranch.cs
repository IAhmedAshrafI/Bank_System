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
    public partial class adminaddbranch : Form
    {
        public adminaddbranch()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            adminaddbank adminaddbank = new adminaddbank();
            adminaddbank.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adminlogin adminlogin = new adminlogin();
            adminlogin.Show();
            this.Hide();
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
            //Changed the connection string declaration to a regular string variable.
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Bank_System;Integrated Security=True";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                bool found = IsFound("BankCode", "Bank", b_code_input.Text, sqlConnection);

                if (found)
                {
                    string sqlInsert = "INSERT INTO Branch(BranchNumber, BankCode, Address) VALUES (@bNumber, @code, @address)";
                    SqlCommand cmd = new SqlCommand(sqlInsert, sqlConnection);
                    cmd.Parameters.AddWithValue("@bNumber", branch_num_input.Text);
                    cmd.Parameters.AddWithValue("@code", b_code_input.Text);
                    cmd.Parameters.AddWithValue("@address", branch_address_input.Text);
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("The Branch has been added successfully");
                }
                else
                {
                    MessageBox.Show("The Bank was not found");
                }
            }
        }

        private void adminaddbranch_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            adminupdatebranch adminupdatebranch = new adminupdatebranch(); 
            adminupdatebranch.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            admindeletebranch admindeletebranch = new admindeletebranch();
            admindeletebranch.Show();
            this.Hide();
        }
    }
}
