using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityRegistrationSystem.Control;

namespace UniversityRegistrationSystem
{
    public partial class LoginForm : Form
    {
        AccountController Controller;
        public LoginForm(AccountController aController)
        {
            Controller = aController;
            InitializeComponent();
        }

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
            string password = Passwordtbx.Text;
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password))
            {
                DisplayError();
            }
            else
            {
                this.Close();
                if(!Controller.Login(username, password))
                {
                    //previously entered username not persisting in textbox form
                    this.Emailtbx.Text = username;
                }
            }
            
        }

        public void InvalidLogin(string username)
        {
            InitializeComponent();
            DisplayError();
            Emailtbx.Text = username;

        }

        private void DisplayError()
        {
            ErrorLbl.Text = "You must enter a valid username and password";
            ErrorLbl.Visible = true;
        }

      
    }
}
