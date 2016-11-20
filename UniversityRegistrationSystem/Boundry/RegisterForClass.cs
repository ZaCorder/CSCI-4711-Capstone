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
        ClassController classControl;
        ClassList classList;

        public RegisterForClass(AccountController accountControl, ClassController classControl, ClassList classList) : base(accountControl)
        {
            this.accountControl = accountControl;
            this.classControl = classControl;
            this.classList = classList;
            this.AddClassList();
        }

        private void AddClassList()
        {
            this.panel3.Controls.Add(this.classList);
            classList.Show();
        }
    }
}
