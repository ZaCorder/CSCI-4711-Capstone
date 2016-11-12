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

        private DBConnect()
        {
            this.dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
        }

        public SQLiteConnection GetConnection()
        {
            return this.dbConnection;
        }

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

        public void SaveAccount(StudentAccount student)
        {
            this.SaveAccount((Account) student);

            Console.WriteLine(student.Classes.Length);
            for (int i = 0; i < student.Classes.Length; i++) {
                if (student.Classes[i] != null)
                 this.SaveAccountClass(student, student.Classes[i]);
            }
                
        }

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

        private void CreateTestClasses()
        {
            Class classA = new Class();
            classA.CourseNo = "ENG 1101";
            classA.Section = "N";
            classA.ClassName = "College Composition I";
            classA.Credits = 4;
            classA.Location = "UH 100";
            classA.Instructor = "Wayne";
            classA.TimeStart = new DateTime(2016, 1, 1, 9, 0, 0);
            classA.TimeEnd = new DateTime(2016, 1, 1, 10, 45, 0);
            classA.StartDate =  DateTime.Now;
            classA.EndDate = DateTime.Now.AddDays(84);
            classA.ClassDays = "MW";
            this.SaveClass(classA);

            Class classB = new Class();
            classB.CourseNo = "CSCI 1101";
            classB.Section = "B";
            classB.ClassName = "Math Structures";
            classB.Credits = 3;
            classB.Location = "AH 300";
            classB.Instructor = "Grayson";
            classB.TimeStart = new DateTime(2016, 1, 1, 11, 0, 0);
            classB.TimeEnd = new DateTime(2016, 1, 1, 12, 45, 0);
            classB.StartDate = DateTime.Now;
            classB.EndDate = DateTime.Now.AddDays(84);
            classB.ClassDays = "TR";
            this.SaveClass(classB);

            Class classC = new Class();
            classC.CourseNo = "MATH 2011";
            classC.Section = "D";
            classC.ClassName = "Calculus";
            classC.Credits = 4;
            classC.Location = "AH 200";
            classC.Instructor = "Pennyworth";
            classC.TimeStart = new DateTime(2016, 1, 1, 2, 0, 0);
            classC.TimeEnd = new DateTime(2016, 1, 1, 3, 45, 0);
            classC.StartDate = DateTime.Now;
            classC.EndDate = DateTime.Now.AddDays(84);
            classC.ClassDays = "TR";
            this.SaveClass(classC);
        }

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
                {
                    classes[reader.StepCount - 1] = new Class(reader);
                }
            }
            reader.Close();
            this.dbConnection.Close();
            return classes;
        }
    }
}
