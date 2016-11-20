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
        RegisterForClassForm registerForm;

        public RegisterForClass(AccountController accountControl, RegistrationController registerControl, RegisterForClassForm registerForm) : base(accountControl)
        {
            this.accountControl = accountControl;
            this.registerControl = registerControl;
            this.registerForm = registerForm;
            this.AddRegisterForClassForm();

        }

        private void AddRegisterForClassForm()
        {
            this.panel2.Controls.Add(this.registerForm);
            this.registerForm.Show();
        }
    }
}
