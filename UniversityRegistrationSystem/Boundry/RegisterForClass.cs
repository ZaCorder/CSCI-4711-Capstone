using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistrationSystem.Control;
using UniversityRegistrationSystem.Boundry;

namespace UniversityRegistrationSystem.Boundry
{
    class RegisterForClass : ActivityWindow
    {
        AccountController accountControl;
        RegistrationController registerControl;
        RegisterForClassForm registerForm;
        ClassList classList;

        public RegisterForClass(AccountController accountControl, RegistrationController registerControl, RegisterForClassForm registerForm, ClassList classList) : base(accountControl)
        {
            this.accountControl = accountControl;
            this.registerControl = registerControl;
            this.registerForm = registerForm;
            this.classList = classList;

            this.AddClassList();
           
            this.AddRegisterForClassForm();

        }

        private void AddRegisterForClassForm()
        {
            this.panel2.Controls.Add(this.registerForm);
            this.registerForm.Show();
        }

        private void AddClassList()
        {
            this.panel3.Controls.Add(this.classList);
            classList.Show();
        }
    }
}
