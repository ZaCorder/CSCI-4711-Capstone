using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityRegistrationSystem.Control;
using UniversityRegistrationSystem.Entity;

namespace UniversityRegistrationSystem.Boundry
{
    class ClassWorksheet : TableList
    {

        private StudentAccount student;

        public ClassWorksheet(StudentAccount student)
        {
            this.student = student;
            this.InitalizeTable();
        }

        public void Update(StudentAccount student)
        {
            this.table.Clear();
            this.student = student;
            this.LoadData();
        }

        protected override void BuildColumns()
        {
            this.table.Columns.Add("Course");
            this.table.Columns.Add("Class name");
            this.table.Columns.Add("Credits");
            this.table.Columns.Add("Start date");
            this.table.Columns.Add("End date");
            this.table.Columns.Add("Days");
            this.table.Columns.Add("Time");
            this.table.Columns.Add("Location");
            this.table.Columns.Add("Instructor");
        }

        protected override void BuildRows()
        {
            foreach (Class c in this.student.Classes)
            {
                string fullClassId = String.Format("{0}-{1}", c.CourseNo, c.Section);
                this.table.Rows.Add(fullClassId, c.ClassName, c.Credits,
                    c.StartDate.ToString("MMM dd, yyyy"),
                    c.EndDate.ToString("MMM dd, yyy"),
                    c.ClassDays,
                    c.TimeStart.ToString("HH:mm") + "-" + c.TimeEnd.ToString("HH:mm"),
                    c.Location, c.Instructor);
            }

        }
    }
}
