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
    public partial class customerlogin : Form
    {
        public customerlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminlogin adminlogin = new adminlogin();
            adminlogin.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            emplogin emplogin = new emplogin();
            emplogin.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=Bank_System;Integrated Security=True");
            cn.Open();
            SqlCommand MyCommand = new SqlCommand("SELECT COUNT(*) FROM Customer WHERE Name = @Name AND SSN = @SSN", cn);
            textBox2.PasswordChar = '*';
            MyCommand.Parameters.AddWithValue("@Name", textBox1.Text);
            MyCommand.Parameters.AddWithValue("@SSN", textBox2.Text);  // Updated parameter name
            int count = (int)MyCommand.ExecuteScalar();
            cn.Close();

            if (count > 0)
            {
                // Admin login successful
                MessageBox.Show("Customer login successful");

                // Proceed with the admin-related actions or navigation
                // For example:
                customerloggedin customerloggedin = new customerloggedin();
                customerloggedin.Show();
                this.Hide();
            }
            else
            {
                // Admin login failed
                MessageBox.Show("Customer login failed");
            }
        }

        private void customerlogin_Load(object sender, EventArgs e)
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
