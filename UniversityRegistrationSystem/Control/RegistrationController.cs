using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistrationSystem.Boundry;
using UniversityRegistrationSystem.Entity;

namespace UniversityRegistrationSystem.Control
{
    class RegistrationController : Controller
    {
        private DBConnect db;
        private AccountController accountController;

        public RegistrationController(DBConnect db, AccountController accountController) : base(db)
        {
            this.db = db;
            this.accountController = accountController;
        }

        public StudentAccount Register(string fullCourseId)
        {
            return this.db.Register(fullCourseId, (StudentAccount) this.accountController.GetLoggedInUser());
        }

        public void ShowActivityWorkspace()
        {
            RegisterForClassForm registerForm = new RegisterForClassForm(this.accountController, this, db.GetClasses());
            RegisterForClass activityWindow = new RegisterForClass(this.accountController, this, registerForm);
            activityWindow.Text = "Register for class";
            activityWindow.Show();
        }

        public void Submit(string fullClassNo, StudentAccount studentAccount)
        {
            Console.WriteLine("Testing....");
            // Check if user is already registered.
            db.Register(fullClassNo, studentAccount);
        }
    }
}
