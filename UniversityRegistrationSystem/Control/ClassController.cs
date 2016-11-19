using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityRegistrationSystem.Control
{
    class ClassController : Controller
    {
        private DBConnect db;

        public ClassController(DBConnect db) : base(db)
        {
            this.db = db;
        }

        public void Submit(string section, string className,
            int credits, string location, string instructor, DateTime timeStart,
            DateTime timeEnd, DateTime startDate, DateTime endDate, string classDays)
        {
            return this.CreateClass(courseNo, section, className,
            credits, location, instructor, timeStart,
            timeEnd, startDate, endDate, classDays);
        }
    }
}
