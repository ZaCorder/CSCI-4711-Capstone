using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityRegistrationSystem.Entity
{
    class Class
    {
        private string courseNo;
        private string section;
        private string className;
        private int credits;
        private string location;
        private string instructor;
        private DateTime timeStart;
        private DateTime timeEnd;
        private DateTime startDate;
        private DateTime endDate;
        private string classDays;

        public string CourseNo
        {
            get
            {
                return courseNo;
            }

            set
            {
                courseNo = value;
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

        public DateTime TimeStart
        {
            get
            {
                return timeStart;
            }

            set
            {
                timeStart = value;
            }
        }

        public DateTime TimeEnd
        {
            get
            {
                return timeEnd;
            }

            set
            {
                timeEnd = value;
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
    }
}
