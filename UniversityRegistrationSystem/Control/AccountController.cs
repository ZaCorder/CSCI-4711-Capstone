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
    class AccountController : Controller
    {
        private Account account;
        private DBConnect db;

        public AccountController(DBConnect db) : base(db)
        {
            this.db = db;
        }

        public Account GetLoggedInUser()
        {
            return this.account;
        }

        public void Login(string username, string password)
        {
            this.account = db.GetAccount(username, password);

            if (account.Type == "Administrator") {
                ActivityWindow ActivityWindow = new ActivityWindow(this);
                ActivityWindow.Text = "Main Activity Window";
                ActivityWindow.Show();
            }
        }

        public void Logout()
        {
            this.account = null;
            ActivityWindow loginForm = new ActivityWindow(this);
            loginForm.Text = "Login";
            loginForm.Show();
        }
    }
}
