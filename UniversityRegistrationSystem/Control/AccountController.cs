using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityRegistrationSystem.Boundry;
using UniversityRegistrationSystem.Entity;

namespace UniversityRegistrationSystem.Control
{
    /// <summary>
    /// Account controller class definition.
    /// </summary>
    public class AccountController : Controller
    {
        private Account account;
        private DBConnect db;

        public AccountController(DBConnect db) : base(db)
        {
            this.db = db;
        }

        /// <summary>
        /// Retrieve the currently logged in user account.
        /// </summary>
        /// <returns>The "Account" entity for the user that is currently logged in.</returns>
        public Account GetLoggedInUser()
        {
            return this.account;
        }

        /// <summary>
        /// Log in a specified user.
        /// </summary>
        /// <param name="username">The username of the user to be logged in.</param>
        /// <param name="password">The password of the user to be logged in.</param>
        public bool Login(string username, string password)
        {
            string hashedPassword = password.GetHashCode().ToString();
            this.account = db.GetAccount(username, hashedPassword);
            if (account.Type == null)
            {
                //invalid login - display error message
                DisplayLoginForm(true, username);
                return false;

            }
            else
            {
                this.ShowActivityWorkspace(account.Type);
                return true;
            }
        }

        /// <summary>
        /// Log out the currently logged in user and display the login form.
        /// </summary>
        public void Logout()
        {
            this.account = null;
            this.DisplayLoginForm();
        }

        /// <summary>
        /// Display the Login form.
        /// </summary>
        public void DisplayLoginForm(bool displayError = false, string username = "" )
        {
            LoginForm loginForm = new LoginForm(this);
            if (displayError)
            {
                loginForm.InvalidLogin(username);
            }
            else
            {
                loginForm._ErrorLbl.Visible = false;
            }
            loginForm.Show();
        }

        /// <summary>
        /// Display the Activity workspace form.
        /// </summary>
        /// <param name="type"></param>
        public void ShowActivityWorkspace(string type)
        {
            ActivityWindow ActivityWindow = new ActivityWindow(this);
            ActivityWindow.Text = "Main Activity Window";
            ActivityWindow.Show();
        }
    }
}
