using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using UniversityRegistrationSystem.Entity;
using System.Data.Common;

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

            Console.WriteLine(student.Classes.Length);
            for (int i = 0; i < student.Classes.Length; i++) {
                if (student.Classes[i] != null)
                 this.SaveAccountClass(student, student.Classes[i]);
            }      
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
        public Class[] GetClasses()
        {
            Class[] classes = new Class[1];

            this.dbConnection.Open();
            string query = @"SELECT * FROM Class";
            SQLiteCommand command = new SQLiteCommand(query, this.dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                classes = new Class[reader.FieldCount];
                while (reader.Read())
                    classes[reader.StepCount - 1] = new Class(reader);
            }
            reader.Close();
            this.dbConnection.Close();
            return classes;
        }
    }
}
