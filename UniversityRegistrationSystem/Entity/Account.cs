using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace UniversityRegistrationSystem.Entity
{
    public class Account
    {
        private string email;
        private string password;
        private string type;

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public Account()
        {
        }

        public Account(DbDataReader reader)
        {
            this.Email = reader.GetString(0);
            this.Password = reader.GetString(1);
            this.Type = reader.GetString(2);
        }
    }
}
