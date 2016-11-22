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
        private ClassWorksheet classWorksheet;

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
            this.classWorksheet = new ClassWorksheet((StudentAccount) this.accountController.GetLoggedInUser());
            RegisterForClass activityWindow = new RegisterForClass(this.accountController, this, registerForm, this.classWorksheet);
            activityWindow.Text = "Register for class";
            activityWindow.Show();
        }

        public void Submit(string fullClassNo, StudentAccount studentAccount)
        {
            // Check if user is already registered.
            if (fullClassNo == "")
                PopUpWindow.Display("Please select a class for which to register.");
            else if (studentAccount.IsRegistered(db.GetClass(fullClassNo)))
                PopUpWindow.Display("Already registred for " + fullClassNo + ".");
            else
            {
                db.Register(fullClassNo, studentAccount);
                this.registerForm.UpdateForm(studentAccount);
                this.classWorksheet.Update(studentAccount);
            }
        }
    }
}
