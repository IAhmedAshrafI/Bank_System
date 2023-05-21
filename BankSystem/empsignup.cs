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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BankSystem
{
    public partial class empsignup : Form
    {
        public empsignup()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main homepage = new main();
            homepage.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=Bank_System;Integrated Security=True");
            cn.Open();
            SqlCommand MyCommand = new SqlCommand("INSERT INTO Employee (Emp_ID, Emp_Name, Emp_Phone) VALUES (@EmpID, @EmpName, @EmpPhone)", cn);
            MyCommand.Parameters.AddWithValue("@EmpID", textBox2.Text);
            MyCommand.Parameters.AddWithValue("@EmpName", textBox1.Text.ToString());
            MyCommand.Parameters.AddWithValue("@EmpPhone", textBox4.Text.ToString());
            MyCommand.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Employee Added Successfully");

            emplogin emplogin = new emplogin();
            emplogin.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void empsignup_Load(object sender, EventArgs e)
        {

        }
    }
}
