using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistrationSystem.Control;

namespace UniversityRegistrationSystem.Boundry
{
    class CreateClass : ActivityWindow
    {
        AccountController accountControl;
        ClassController classControl;
        ClassList classList;
        CreateClassForm createClassForm;

        public CreateClass(AccountController accountControl, ClassController classControl, ClassList classList, CreateClassForm createClassForm) : base(accountControl)
        {
            this.createClassForm = createClassForm;
            this.accountControl = accountControl;
            this.classControl = classControl;
            this.classList = classList;
            this.AddClassList();

            this.AddCreateClassForm();
        }

        private void AddCreateClassForm()
        {
            this.panel2.Controls.Add(this.createClassForm);
            this.createClassForm.Show();
        }

        private void AddClassList()
        {
            this.panel3.Controls.Add(this.classList);
            classList.Show();
        }
    }
}
