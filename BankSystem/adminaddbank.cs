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
    public partial class adminaddbank : Form
    {

        public adminaddbank()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminaddbranch adminaddbranch = new adminaddbranch();
            adminaddbranch.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adminlogin adminlogin = new adminlogin();
            adminlogin.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Bank_System;Integrated Security=True");
            string sql = "insert into Bank(BankName,BankCode,Address) values (@name,@code,@address)";
            SqlCommand cmd = new SqlCommand(sql,sqlConnection);
            cmd.Parameters.AddWithValue("@name", b_name_input.Text);
            cmd.Parameters.AddWithValue("@code", b_code_input.Text);
            cmd.Parameters.AddWithValue("@address", b_address_input.Text);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("The bank has been added successfully");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void adminaddbank_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            admindeletebranch admindeletebank = new admindeletebranch();
            admindeletebank.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            adminupdatebranch adminupdatebranch = new adminupdatebranch();
            adminupdatebranch.Show();
            this.Hide();
        }
    }
}
