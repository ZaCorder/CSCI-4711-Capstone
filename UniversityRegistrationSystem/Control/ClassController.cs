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
        public CreateClassForm createClassForm;
        public ClassList classList;


        public ClassController(DBConnect db, AccountController accountController) : base(db)
        {
            this.accountController = accountController;
            this.db = db;
        }

        public void Submit(string courseNo, string section, string className,
            int credits, string location, string instructor, DateTime timeStart,
            DateTime timeEnd, DateTime startDate, DateTime endDate, string classDays)
        {
            if (db.DoesClassExist(courseNo, section))
                PopUpWindow.Display("A class with course number: " + courseNo + " and section: " + section + " already exists.");
            else
            {
                this.db.CreateClass(courseNo, section, className,
                credits, location, instructor, timeStart,
                timeEnd, startDate, endDate, classDays);
                classList.Update(db.GetClasses());
                createClassForm.ClearForm();
                PopUpWindow.Display("Class: " + courseNo + ", section: " + section + ", added!");
            }
        }

        public void Submit(List<string> errors) {
            foreach (string e in errors)
                PopUpWindow.Display(e);
        }
    }
}
