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
        public bool IsRegistered(StudentAccount student, Class classRecord)
        {
            bool isRegistered = false;
            foreach (Class registeredClass in student.Classes)
                if (registeredClass.CourseNo.Equals(classRecord.CourseNo) && registeredClass.Section.Equals(classRecord.Section))
                    isRegistered = true;
            return isRegistered;
        }
    }
}
