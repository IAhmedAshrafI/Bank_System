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
    public partial class adminlogin : Form
    {
        public adminlogin()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            emplogin emplogin = new emplogin();
            emplogin.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            customerlogin customerlogin = new customerlogin();
            customerlogin.Show();
            this.Hide();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=Bank_System;Integrated Security=True");
            cn.Open();
            SqlCommand MyCommand = new SqlCommand("SELECT COUNT(*) FROM Admin WHERE Admin_Name = @AdminName AND Admin_ID = @AdminID", cn);
            textBox2.PasswordChar = '*';
            MyCommand.Parameters.AddWithValue("@AdminName", textBox1.Text);
            MyCommand.Parameters.AddWithValue("@AdminID", textBox2.Text.ToString());
            int count = (int)MyCommand.ExecuteScalar();
            cn.Close();

            if (count > 0)
            {
                // Admin login successful
                MessageBox.Show("Admin login successful");

                // Proceed with the admin-related actions or navigation
                // For example:
                adminaddbank adminaddbank = new adminaddbank();
                adminaddbank.Show();
                this.Hide();
            }
            else
            {
                // Admin login failed
                MessageBox.Show("Admin login failed");
            }
        }

        private void adminlogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            main main = new main();
            main.Show();
            this.Hide();
        }
    }
}
