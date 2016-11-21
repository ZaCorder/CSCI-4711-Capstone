using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistrationSystem.Boundry;

namespace UniversityRegistrationSystem.Control
{
    class ClassController : Controller
    {
        private DBConnect db;
        private AccountController accountController;

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
            ClassList classList = new ClassList(db.GetClasses());
            CreateClassForm createClassForm = new CreateClassForm(new EventHandler(this.Submit));
            CreateClass activityWindow = new CreateClass(this.accountController, this, classList, createClassForm);
            activityWindow.Text = "Create class Activity Window";
            activityWindow.Show();
        }

        private void Submit(object sender, EventArgs e)
        {

            PopUpWindow.Display("adfasfd", "Title");
            Console.WriteLine();
        }
    }
}
