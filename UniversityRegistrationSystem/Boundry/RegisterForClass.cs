using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistrationSystem.Control;

namespace UniversityRegistrationSystem.Boundry
{
    class RegisterForClass : ActivityWindow
    {
        AccountController accountControl;
        RegistrationController registerControl;

        public RegisterForClass(AccountController accountControl, RegistrationController registerControl) : base(accountControl)
        {
            this.accountControl = accountControl;
            this.registerControl = registerControl;
        }
    }
}
