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
    public partial class emplistofloans : Form
    {
        public emplistofloans()
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            emploggedin emploggedin = new emploggedin();
            emploggedin.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            emplistofpendingloans emplistofpendingloans = new emplistofpendingloans();
            emplistofpendingloans.Show();
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
                string sqlSelect = "SELECT * FROM Loan";
                SqlCommand cmd = new SqlCommand(sqlSelect, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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
