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
        ClassWorksheet classList;

        public RegisterForClass(AccountController accountControl, RegistrationController registerControl, RegisterForClassForm registerForm, ClassWorksheet classWorksheet) : base(accountControl)
        {
            this.accountControl = accountControl;
            this.registerControl = registerControl;
            this.registerForm = registerForm;
            this.classList = classWorksheet;

            this.AddClassList();
           
            this.AddRegisterForClassForm();
        }

        private void AddRegisterForClassForm()
        {
            this.label1.Text = "Register for classes";
            this.panel2.Controls.Add(this.registerForm);
            this.registerForm.Show();
        }

        private void AddClassList()
        {
            this.label2.Text = "Registered classes";
            this.panel3.Controls.Add(this.classList);
            classList.Show();
        }
    }
}
