using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace UniversityRegistrationSystem.Entity
{
    class AdministratorAccount : Account
    {
        public AdministratorAccount() : base()
        {
        }

        public AdministratorAccount(DbDataReader reader) : base(reader)
        {
        }
    }
}
