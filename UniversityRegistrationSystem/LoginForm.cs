using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityRegistrationSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            string username = Emailtbx.Text;
            string password = passwordtbx.Text;
            if(String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password))
            {
                ErrorLbl.Text = "You must enter a valid username and password";
                ErrorLbl.Visible = true;
            }

        }

      
    }
}
