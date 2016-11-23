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
        public RegisterForClassForm registerForm;
        public ClassWorksheet classWorksheet;

        public RegistrationController(DBConnect db, AccountController accountController) : base(db)
        {
            this.db = db;
            this.accountController = accountController;
        }

       
        public void Register(string fullClassNo)
        {
            StudentAccount studentAccount = (StudentAccount)this.accountController.GetLoggedInUser();
            // Check if user is already registered.
            if (fullClassNo == "")
                PopUpWindow.Display("Please select a class for which to register.");
            else if (studentAccount.IsRegistered(db.GetClass(fullClassNo)))
                PopUpWindow.Display("Already registred for " + fullClassNo + ".");
            else
            {
                studentAccount = db.Register(fullClassNo, studentAccount);
                this.registerForm.UpdateForm(studentAccount);
                this.classWorksheet.Update(studentAccount);
            }
        }
    }
}
