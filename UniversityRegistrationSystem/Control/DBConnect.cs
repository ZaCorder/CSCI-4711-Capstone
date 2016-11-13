using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using UniversityRegistrationSystem.Entity;
using System.Data.Common;
using System.Data;

namespace UniversityRegistrationSystem.Control
{
    /// <summary>
    /// Database connector class. Used to communication with the databse.
    /// </summary>
    class DBConnect
    {
        private SQLiteConnection dbConnection;
        private static DBConnect instance;

        public static DBConnect Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBConnect();

                return instance;
            }
        }

        /// <summary>
        /// Use DBConnect.GetInstance().
        /// 
        /// The constructor for DBConnect. Is private since we are using it as
        /// a singleton.
        /// </summary>
        private DBConnect()
        {
            this.dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
        }

        /// <summary>
        /// Retrieve the current database connection object.
        /// </summary>
        /// <returns>The current database connection object.</returns>
        public SQLiteConnection GetConnection()
        {
            return this.dbConnection;
        }

        public Account GetAccount(string email, string password)
        {
            this.dbConnection.Open();
            Account account = new Account();
            string query = @"SELECT email, password, type FROM Account WHERE
                email = @email AND password = @password";
            SQLiteCommand command = new SQLiteCommand(query, this.dbConnection);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                string type = reader.GetString(2);
                if (type == "Administrator")
                    account = new AdministratorAccount(reader);
                else if (type == "Student")
                {
                    StudentAccount studentAccount = new StudentAccount(reader);
                    studentAccount.Classes = this.GetClasses(studentAccount);
                    account = studentAccount;
                }
                else
                    account = new Account(reader);
                    
            }
            reader.Close();
            this.dbConnection.Close();
            return account;
        }

        /// <summary>
        /// Save an "Account" entity to the database.
        /// </summary>
        /// <param name="account">The "Account" entity to be saved to the database.</param>
        public void SaveAccount(Account account)
        {
            this.dbConnection.Open();
            string query = @"INSERT OR REPLACE INTO Account (email, password, type)
                VALUES (@email, @password, @type)";
            SQLiteCommand command = new SQLiteCommand(query, this.dbConnection);
            command.Parameters.AddWithValue("@email", account.Email);
            command.Parameters.AddWithValue("@password", account.Password);
            command.Parameters.AddWithValue("@type", account.Type);
            command.ExecuteNonQuery();
            this.dbConnection.Close();
        }

        /// <summary>
        /// Save a "Student" entity to the database.
        /// </summary>
        /// <param name="student">A "Student" entity to be saved to the database.</param>
        public void SaveAccount(StudentAccount student)
        {
            this.SaveAccount((Account) student);

            foreach (Class classRecord in student.Classes)
                this.SaveAccountClass(student, classRecord);  
        }

        /// <summary>
        /// Save a "AccountClass" relationship to the database.
        /// </summary>
        /// <param name="student">The "Student" entity for which to save the relationship.</param>
        /// <param name="classRecord">The "Class" entity for which to save the relationship.</param>
        public void SaveAccountClass(StudentAccount student, Class classRecord)
        {
            this.dbConnection.Open();
            string query = @"INSERT OR REPLACE INTO AccountClass (email, courseNo)
                VALUES (@email, @courseNo)";
            SQLiteCommand command = new SQLiteCommand(query, this.dbConnection);
            command.Parameters.AddWithValue("@email", student.Email);
            command.Parameters.AddWithValue("@courseNo", classRecord.CourseNo);
            command.ExecuteNonQuery();
            this.dbConnection.Close();
        }

        /// <summary>
        /// Create "Class" entity and write to database.
        /// </summary>
        /// <param name="courseNo">The course number for the class. Part of the primary key.</param>
        /// <param name="section">The section number for the class. Part of the primary key.</param>
        /// <param name="className">The name of the class.</param>
        /// <param name="credits">The number of credit hours.</param>
        /// <param name="location">The location where the class will be held.</param>
        /// <param name="instructor">The instructor who will be teaching the class.</param>
        /// <param name="timeStart">The time the class will start.</param>
        /// <param name="timeEnd">The time the class will end.</param>
        /// <param name="startDate">The date when the class will start.</param>
        /// <param name="endDate">Then date when the class will end.</param>
        /// <param name="classDays">The days of the week the class meets.</param>
        /// <returns>A "Class" entity object.</returns>
        public Class CreateClass(string courseNo, string section, string className,
            int credits, string location, string instructor, DateTime timeStart,
            DateTime timeEnd, DateTime startDate, DateTime endDate, string classDays)
        {
            Class classRecord = new Class();
            classRecord.CourseNo = courseNo;
            classRecord.Section = section;
            classRecord.ClassName = className;
            classRecord.Credits = credits;
            classRecord.Location = location;
            classRecord.Instructor = instructor;
            classRecord.TimeStart = timeStart;
            classRecord.TimeEnd = timeEnd;
            classRecord.StartDate = startDate;
            classRecord.EndDate = endDate;
            classRecord.ClassDays = classDays;
            this.SaveClass(classRecord);

            return classRecord;
        }

        /// <summary>
        /// Save a "Class" relationship to the database.
        /// </summary>
        /// <param name="classRecord">The "Class" entity for which to save to the database.</param>
        public void SaveClass(Class classRecord)
        {
            this.dbConnection.Open();
            string query = @"INSERT OR REPLACE INTO Class (courseNo, section, className,
                credits, location, instructor, timeStart, timeEnd, startDate, endDate, classDays)
                VALUES (@courseNo, @section, @className, @credits, @location, @instructor, @timeStart,
                    @timeEnd, @startDate, @endDate, @classDays)";
            SQLiteCommand command = new SQLiteCommand(query, this.dbConnection);
            command.Parameters.AddWithValue("@courseNo", classRecord.CourseNo);
            command.Parameters.AddWithValue("@section", classRecord.Section);
            command.Parameters.AddWithValue("@className", classRecord.ClassName);
            command.Parameters.AddWithValue("@credits", classRecord.Credits);
            command.Parameters.AddWithValue("@location", classRecord.Location);
            command.Parameters.AddWithValue("@instructor", classRecord.Instructor);
            command.Parameters.AddWithValue("@timeStart", classRecord.TimeStart);
            command.Parameters.AddWithValue("@timeEnd", classRecord.TimeEnd);
            command.Parameters.AddWithValue("@startDate", classRecord.StartDate);
            command.Parameters.AddWithValue("@endDate", classRecord.EndDate);
            command.Parameters.AddWithValue("@classDays", classRecord.ClassDays);
            command.ExecuteNonQuery();
            this.dbConnection.Close();
        }

        /// <summary>
        /// Retrieve all classes in the Database.
        /// </summary>
        /// <returns>An array of classes that exist.</returns>
        public List<Class> GetClasses()
        {
            List<Class> classes = new List<Class>();

            this.dbConnection.Open();
            string query = @"SELECT * FROM Class";
            SQLiteCommand command = new SQLiteCommand(query, this.dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Class classRecord = new Class(reader);
                    classes.Add(classRecord);
                }
            }
            reader.Close();
            this.dbConnection.Close();
            return classes;
        }

        /// <summary>
        /// Retrieve all classes for which the specified student is registerd.
        /// </summary>
        /// <param name="student">The "Student" entity for which to retrieve registered classes.</param>
        /// <returns>A list of "Class" entities for which the "Student" is registerd.</returns>
        public List<Class> GetClasses(StudentAccount student)
        {
            List<Class> classes = new List<Class>();

            // This is pretty silly, but it is so far the only one I ran into
            // this particlar problem as most places would not already have an
            // opened connection. If we see this pop-up again we'll want to move
            // it out into a connection toggle that stacks the counts of opens
            // vs closes.
            bool openedConnection = false;
            if (this.dbConnection.State == ConnectionState.Closed)
            {
                this.dbConnection.Open();
                openedConnection = true;
            }

            string query = @"SELECT c.* FROM AccountClass ac INNER JOIN Class c ON ac.courseNo = c.courseNo WHERE email = @email";
            SQLiteCommand command = new SQLiteCommand(query, this.dbConnection);
            command.Parameters.AddWithValue("@email", student.Email);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read()) {
                    Class classRecord = new Class(reader);
                    classes.Add(classRecord);
                }
                
            }
            reader.Close();
            if (openedConnection)
                this.dbConnection.Close();
            return classes;
        }

        /// <summary>
        /// Determines if a Class already exists.
        /// </summary>
        /// <param name="courseNo"></param>
        /// <param name="section"></param>
        /// <returns>True if the class exists and False otherwise.</returns>
        public bool DoesClassExist(string courseNo, string section)
        {
            this.dbConnection.Open();
            string query = @"SELECT COUNT(1) FROM Class
                WHERE courseNo = @courseNo AND section = @section LIMIT 1";
            SQLiteCommand command = new SQLiteCommand(query, this.dbConnection);
            command.Parameters.AddWithValue("@courseNo", courseNo);
            command.Parameters.AddWithValue("@section", section);
            bool classExists = Int32.Parse(command.ExecuteScalar().ToString()) > 0;
            this.dbConnection.Close();
            return classExists;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseNo"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public Class GetClass(string courseNo, string section)
        {
            this.dbConnection.Open();
            Class classRecord = new Class();
            string query = @"SELECT * FROM Class WHERE
                courseNo = @courseNo AND section = @section";
            SQLiteCommand command = new SQLiteCommand(query, this.dbConnection);
            command.Parameters.AddWithValue("@courseNo", courseNo);
            command.Parameters.AddWithValue("@section", section);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                classRecord = new Class(reader);
            }
            reader.Close();
            this.dbConnection.Close();
            return classRecord;
        }

        /// <summary>
        /// Register a student to a class.
        /// </summary>
        /// <param name="fullCourseId">The full course id for a class. Example: courseNo-section.</param>
        /// <param name="student">The "Student" entity for which to register a class.</param>
        /// <returns></returns>
        public StudentAccount Register(string fullCourseId, StudentAccount student)
        {
            String[] parsedCourseId = fullCourseId.Split('-');
            if (parsedCourseId.Length != 2)
                throw new Exception("Invalid full course id. Ex: courseNo-section");

            Class classRecord = GetClass(parsedCourseId[0], parsedCourseId[1]);
            if (classRecord != null)
                student.Classes.Add(classRecord);

            this.SaveAccount(student);
            return student;
        }
    }
}
