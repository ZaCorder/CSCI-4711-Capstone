using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityRegistrationSystem.Entity
{
    class StudentAccount : Account
    {
        public List<Class> classes { get; set; } = new List<Class>(); 

        public Account account { get; set; }
    }
}
