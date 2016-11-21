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

    public class CreateClassEventArgs : EventArgs
    {
        private string courseNum;
        private string section;
        private string className;
        private int credits;
        private string location;
        private string instructor;
        private DateTime startTime;
        private DateTime endTime;
        private DateTime startDate;
        private DateTime endDate;
        private string classDays;

        public string CourseNum{ 
            get{
                return courseNum;
            }
             set
            {
                courseNum = value;
            }
        }
        
        public string Section  
        {
            get
            {
                return section;
            }
            set
            {
                section = value;
            }
        }
        
        public string ClassName
        {
            get
            {
                return className;
            }
            set
            {
                className = value;
            }
        }
        public int Credits
        {
            get
            {
                return credits;
            }
            set
            {
                credits = value;
            }
        }

        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }

        public string Instructor
        {
            get
            {
                return instructor;
            }
            set
            {
                instructor = value;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
            }
        }

        public string ClassDays
        {
            get
            {
                return classDays;
            }
            set
            {
                classDays = value;
            }
        }

        public CreateClassEventArgs(string CourseNum, string section, string className, int credits, 
            string location, string instructor, DateTime StartTime, DateTime EndTime, DateTime StartDate, 
            DateTime EndDate, string classDays)
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
            this.ClassDays = classDays;
        }
    }
}
