﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Common;
using UniversityRegistrationSystem.Entity;

namespace UniversityRegistrationSystem.Control
{
    /// <summary>
    /// Database initialization class. This will create the tables and insert
    /// testing data.
    /// </summary>
    class DBConnectorInit
    {
        private DBConnect dbConnector;

        /// <summary>
        /// Constructor for the Database initialization class.
        /// </summary>
        /// <param name="dbConnector">An instance of the dbConnector.</param>
        public DBConnectorInit(DBConnect dbConnector)
        {
            this.dbConnector = dbConnector;
            this.CreateTables();

            if (this.ShouldCreateTestContent())
                this.CreateTestContent();
        }

        /// <summary>
        /// Determine if the specified table exists.
        /// </summary>
        /// <param name="tableName">The table name for which to check existance.</param>
        public bool TableExists(string tableName)
        {
            return this.dbConnector.GetConnection().GetSchema("Tables").Select("Table_Name = '" + tableName + "'").Length > 0;
        }

        /// <summary>
        /// Create all necessary tables.
        /// </summary>
        private void CreateTables()
        {
            this.dbConnector.GetConnection().Open();
            this.CreateTableAccount();
            this.CreateTableClass();
            this.CreateTableAccountClass();
            this.dbConnector.GetConnection().Close();
        }

        /// <summary>
        /// Create the "Account" entity table.
        /// </summary>
        private void CreateTableAccount()
        {
            if (!TableExists("Account"))
            {
                string query = @"CREATE TABLE Account (
                email VARCHAR(255) NOT NULL,
                password VARCHAR(128),
                type VARCHAR(30),
                PRIMARY KEY (email))";
                SQLiteCommand command = new SQLiteCommand(query, this.dbConnector.GetConnection());
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the "Class" entity table.
        /// </summary>
        private void CreateTableClass()
        {
            if (!TableExists("Class"))
            {
                string query = @"CREATE TABLE Class (
                courseNo VARCHAR(64) NOT NULL,
                section VARCHAR(30),
                className VARCHAR(255),
                credits integer,
                location VARCHAR(255),
                instructor VARCHAR(255),
                timeStart DATETIME,
                timeEnd DATETIME,
                startDate DATETIME,
                endDate DATETIME,
                classDays VARCHAR(7),
                PRIMARY KEY (courseNo, section))";
                SQLiteCommand command = new SQLiteCommand(query, this.dbConnector.GetConnection());
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the "AccountClass" entity table.
        /// </summary>
        private void CreateTableAccountClass()
        {
            if (!TableExists("AccountClass"))
            {
                string query = @"CREATE TABLE AccountClass (
                    email VARCHAR(255),
                    courseNo VARCHAR(64),
                    FOREIGN KEY(courseNo) REFERENCES Class(courseNo),
                    FOREIGN KEY(email) REFERENCES Account(email),
                    PRIMARY KEY (email, courseNo))";
                SQLiteCommand command = new SQLiteCommand(query, this.dbConnector.GetConnection());
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create test content.
        /// </summary>
        private void CreateTestContent()
        {
            this.CreateTestClasses();
            this.CreateTestContentAccounts();
        }

        /// <summary>
        /// Determine if test content should be created.
        /// </summary>
        private bool ShouldCreateTestContent()
        {
            this.dbConnector.GetConnection().Open();
            string query = @"SELECT COUNT(1) FROM ACCOUNT LIMIT 1";
            SQLiteCommand command = new SQLiteCommand(query, this.dbConnector.GetConnection());
            bool has_content = Int32.Parse(command.ExecuteScalar().ToString()) > 0;
            this.dbConnector.GetConnection().Close();
            return !has_content;
        }

        /// <summary>
        /// Create test Accounts.
        /// </summary>
        private void CreateTestContentAccounts()
        {
            AdministratorAccount administrator = new AdministratorAccount();
            administrator.Email = "administrator@example.com";
            administrator.Password = "donotenter";
            administrator.Type = "Administrator";
            dbConnector.SaveAccount(administrator);

            StudentAccount student = new StudentAccount();
            student.Email = "student@example.com";
            student.Password = "donotenter";
            student.Type = "Student";
            student.Classes = dbConnector.GetClasses();
            dbConnector.SaveAccount(student);
        }

        /// <summary>
        /// Create test Classes.
        /// </summary>
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
            classA.StartDate = DateTime.Now;
            classA.EndDate = DateTime.Now.AddDays(84);
            classA.ClassDays = "MW";
            dbConnector.SaveClass(classA);

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
            dbConnector.SaveClass(classB);

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
            dbConnector.SaveClass(classC);
        }
    }
}