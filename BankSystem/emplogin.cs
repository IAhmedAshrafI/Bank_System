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
    public partial class emplogin : Form
    {
        public emplogin()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            adminlogin adminlogin = new adminlogin();
            adminlogin.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            customerlogin customerlogin = new customerlogin();
            customerlogin.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=Bank_System;Integrated Security=True");
            cn.Open();
            SqlCommand MyCommand = new SqlCommand("SELECT COUNT(*) FROM Employee WHERE Emp_Name = @EmpName AND Emp_ID = @EmpID", cn);
            textBox2.PasswordChar = '*';
            MyCommand.Parameters.AddWithValue("@EmpName", textBox1.Text);
            MyCommand.Parameters.AddWithValue("@EmpID", textBox2.Text);  // Updated parameter name
            int count = (int)MyCommand.ExecuteScalar();
            cn.Close();

            if (count > 0)
            {
                // Admin login successful
                MessageBox.Show("Employee login successful");

                // Proceed with the admin-related actions or navigation
                // For example:
                emploggedin employeeloggedin = new emploggedin();
                employeeloggedin.Show();
                this.Hide();
            }
            else
            {
                // Admin login failed
                MessageBox.Show("Employee login failed");
            }
        }

        private void emplogin_Load(object sender, EventArgs e)
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
