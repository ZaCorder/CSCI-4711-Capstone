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

namespace UniversityRegistrationSystem.Boundry
{
    partial class ActivityWindow : Form
    {
        private AccountController accountController;

        public ActivityWindow(AccountController accountController)
        {
            this.accountController = accountController;
            InitializeComponent();
            this.AddLogoutButton();
            this.FormClosing += this.AccountController_Closing;
        }

        private void AccountController_Closing(object sender, FormClosingEventArgs e)
        {
            accountController.Logout();
        }

        private void AddLogoutButton()
        {
            Form logoutButton = new LogoutButton(new EventHandler(this.logoutButton_Click));
            this.panel1.Controls.Add(logoutButton);
            logoutButton.Show();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
