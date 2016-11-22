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
        private RegisterForClassForm registerForm;
        private ClassList classList;

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
            List<Class> classes = db.GetClasses();
            RegisterForClassForm registerForm = new RegisterForClassForm(this.accountController, this, classes);
            this.registerForm = registerForm;
            this.classList = new ClassList(classes);
            RegisterForClass activityWindow = new RegisterForClass(this.accountController, this, registerForm, classList);
            activityWindow.Text = "Register for class";
            activityWindow.Show();
        }

        public void Submit(string fullClassNo, StudentAccount studentAccount)
        {
            // Check if user is already registered.
            if (studentAccount.IsRegistered(db.GetClass(fullClassNo)))
                PopUpWindow.Display("Already registred for " + fullClassNo + ".");
            else
            {
                db.Register(fullClassNo, studentAccount);
                this.registerForm.UpdateForm(studentAccount);
            }
        }
    }
}
