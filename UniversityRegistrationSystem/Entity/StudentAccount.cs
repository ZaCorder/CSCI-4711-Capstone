using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityRegistrationSystem.Entity
{
    class StudentAccount : Account
    {
        private Class[] classes;

        public Class[] Classes
        {
            get
            {
                return classes;
            }

            set
            {
                classes = value;
            }
        }
    }
}
