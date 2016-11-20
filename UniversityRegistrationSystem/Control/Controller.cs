using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistrationSystem.Boundry;
using System.Reflection;

namespace UniversityRegistrationSystem.Control
{
    public class Controller
    {
        private DBConnect db;

        public Controller(DBConnect db)
        {
            this.db = db;   
        }
    }
}
