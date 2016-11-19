using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
