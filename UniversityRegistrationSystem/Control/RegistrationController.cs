using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityRegistrationSystem.Control
{
    class RegistrationController : Controller
    {
        private DBConnect db;

        public RegistrationController(DBConnect db) : base(db)
        {
            this.db = db;
        }

        public Student Register(string fullCourseId)
        {

            Account user = GetLoggedInUser();
            return this.Register(fullCourseId, user);
        }
    }
}
