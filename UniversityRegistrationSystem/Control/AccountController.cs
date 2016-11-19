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
    class AccountController : Controller
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
        public void Login(string username, string password)
        {
            this.account = db.GetAccount(username, password);
            this.ShowActivityWorspace(account.Type);
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
        public void DisplayLoginForm()
        {
            ActivityWindow loginForm = new ActivityWindow(this);
            loginForm.Text = "Login";
            loginForm.Show();
        }

        /// <summary>
        /// Display the Activity workspace form.
        /// </summary>
        /// <param name="type"></param>
        public void ShowActivityWorspace(string type)
        {
            ActivityWindow ActivityWindow = new ActivityWindow(this);
            ActivityWindow.Text = "Main Activity Window";
            ActivityWindow.Show();
        }
    }
}
