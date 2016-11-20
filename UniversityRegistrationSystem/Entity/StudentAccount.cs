using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace UniversityRegistrationSystem.Entity
{
    public class StudentAccount : Account
    {
        private List<Class> classes;

        public List<Class> Classes
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

        public StudentAccount() : base()
        {
        }

        public StudentAccount(DbDataReader reader) : base(reader)
        {
        }
    }
}
