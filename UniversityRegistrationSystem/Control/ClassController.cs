using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityRegistrationSystem.Boundry;

namespace UniversityRegistrationSystem.Control
{
    class ClassController : Controller
    {
        private DBConnect db;
        private AccountController accountController;
        private CreateClassForm createClassForm;
        ClassList classList;

        public ClassController(DBConnect db, AccountController accountController) : base(db)
        {
            this.accountController = accountController;
            this.db = db;
        }

        public void Submit(string courseNo, string section, string className,
            int credits, string location, string instructor, DateTime timeStart,
            DateTime timeEnd, DateTime startDate, DateTime endDate, string classDays)
        {
            this.db.CreateClass(courseNo, section, className,
                credits, location, instructor, timeStart,
                timeEnd, startDate, endDate, classDays);
        }

        public void ShowCreateClass()
        {
            classList = new ClassList(db.GetClasses());
            createClassForm = new CreateClassForm(new EventHandler<CreateClassEventArgs>(this.Submit));
            CreateClass activityWindow = new CreateClass(this.accountController, this, classList, createClassForm);
            activityWindow.Text = "Create class Activity Window";
            activityWindow.Show();
        }

        private void Submit(object sender, CreateClassEventArgs e)
        {
            if(db.DoesClassExist(e.CourseNum, e.Section))
            {
                PopUpWindow.Display("A class with course number: " + e.CourseNum + " and section: " + e.Section + " already exists.");
            }
            else
            {
                
                //save to database and update classList
                db.CreateClass(e.CourseNum, e.Section, e.ClassName, e.Credits, e.Location, e.Instructor,e.StartTime, e.EndTime, e.StartDate, e.EndDate, e.ClassDays);
                classList.Update(db.GetClasses());
                createClassForm.ClearForm();
                PopUpWindow.Display("Class: " + e.CourseNum + ", section: " + e.Section + ", added!");
            }
        }
        
    }
}
