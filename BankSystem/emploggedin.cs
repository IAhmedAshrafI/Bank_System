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
    public partial class emploggedin : Form
    {
        public emploggedin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            emplistofpendingloans emplistofpendingloans = new emplistofpendingloans();
            emplistofpendingloans.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            emplistofloans emplistofloans = new emplistofloans();
            emplistofloans.Show();
            this.Hide();
        }

        private void emploggedin_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            emplistofcustomers emplistofcustomers = new emplistofcustomers();
            emplistofcustomers.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            emplogin emplogin = new emplogin();
            emplogin.Show();
            this.Hide();
        }

        private bool isFound(string atrrbute, string table, string value, SqlConnection con)
        {
            string sqlSelect = "select "+ atrrbute + " from " + table;
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string bCodeInput = value;

            // Check if the value exists in the DataTable
            DataRow[] foundRows = dt.Select(atrrbute + " = '" + bCodeInput + "'");
            return foundRows.Length > 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Changed the connection string declaration to a regular string variable.
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Bank_System;Integrated Security=True";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString)) 
            {
                bool found = isFound("BranchNumber", "Branch", branchNo_input.Text, sqlConnection);
                if (found)
                {
                    string sqlInsert = "insert into Customer(Name,Phone,Address,BranchNumber,SSN) values(@Name,@Phone,@Address,@BranchNumber,@SSN)";
                    SqlCommand cmd = new SqlCommand(sqlInsert, sqlConnection);
                    cmd.Parameters.AddWithValue("@Name", userName_input.Text);
                    cmd.Parameters.AddWithValue("@Phone", userPhone_input.Text);
                    cmd.Parameters.AddWithValue("@Address", userAddr_input.Text);
                    cmd.Parameters.AddWithValue("@BranchNumber", branchNo_input.Text);
                    cmd.Parameters.AddWithValue("@SSN", userSSN_input.Text);
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("The Customer has been added successfully");
                }
                else
                {
                    MessageBox.Show("The Branch Not Founded");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            empdeletecustomer empdeletecustomer = new empdeletecustomer();
            empdeletecustomer.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            empupdatecustomer empupdatecustomer = new empupdatecustomer();
            empupdatecustomer.Show();
            this.Hide();
        }
    }
}
