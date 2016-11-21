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

    class CreateClassEventArgs : EventArgs
    {
        private string CourseNum { get; set; }
        private string section { get; set; }
        private string className { get; set; }
        private string credits { get; set; }
        private string location { get; set; }
        private string instructor { get; set; }
        private DateTime StartTime { get; set; }
        private DateTime EndTime { get; set; }
        private DateTime StartDate { get; set; }
        private DateTime EndDate { get; set; }
        private string DayOfClass { get; set; }

        public CreateClassEventArgs(string CourseNum, string section, string className, string credits, 
            string location, string instructor, DateTime StartTime, DateTime EndTime, DateTime StartDate, 
            DateTime EndDate, string DayOfClass)
        {
            this.CourseNum = CourseNum;
            this.section = section;
            this.className = className;
            this.credits = credits;
            this.location = location;
            this.instructor = instructor;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.DayOfClass = DayOfClass;
        }
    }
}
