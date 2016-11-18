using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityRegistrationSystem.Control
{
    class Controller
    {
        private DBConnect db;

        public Controller(DBConnect db)
        {
            this.db = db;   
        }
    }
}
