using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            emploggedin employeeloggedin = new emploggedin();
            employeeloggedin.Show();
            this.Hide();
        }

        private void emplogin_Load(object sender, EventArgs e)
        {

        }
    }
}
