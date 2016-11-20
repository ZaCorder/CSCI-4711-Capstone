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

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            string username = Emailtbx.Text;
            string password = Passwordtbx.Text;

            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password))
                this.DisplayError();
            else
            {

                if (Controller.Login(username, password))
                    this.Hide();
                else
                    this.InvalidLogin(username);
            }
            
        }

        public void InvalidLogin(string username)
        {
            this.DisplayError();
            this.Emailtbx.Text = username;
            this.Passwordtbx.Text = "";
        }

        private void DisplayError()
        {
            this.ErrorLbl.Text = "You must enter a valid username and password";
            this.ErrorLbl.Visible = true;
            this.ErrorLbl.ForeColor = Color.Red;
        }

        public LoginForm Reset()
        {
            this.Emailtbx.Text = "";
            this.Passwordtbx.Text = "";
            this.ErrorLbl.Text = "";
            this.ErrorLbl.Visible = false;
            return this;
        }

      
    }
}
