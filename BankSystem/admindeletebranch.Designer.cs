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
            SqlConnection sqlConnection = new SqlConnection("Data Source=BODA;Initial Catalog=Bank_System;Integrated Security=True");
            string branchtodelete = b_code_input.Text;

            string sqlDelete = "DELETE FROM Branch WHERE BranchNumber = @bNumber";
            SqlCommand cmd = new SqlCommand(sqlDelete, sqlConnection);
            cmd.Parameters.AddWithValue("@bNumber", branchtodelete);

            sqlConnection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("The branch has been deleted successfully");
            }
            else
            {
                MessageBox.Show("No branch with the provided BankCode was found");
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
