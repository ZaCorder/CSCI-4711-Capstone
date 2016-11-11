using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

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

            this.Initalize();
        }

        public bool TableExists(string tableName)
        {
            return this.dbConnection.GetSchema("Tables").Select("Table_Name = '" + tableName + "'").Length > 0;
        }

        private void Initalize()
        {
            this.CreateTables();
            this.CreateTestContent();
        }

        private void CreateTables()
        {
            this.dbConnection.Open();
            this.CreateTableAccount();
            this.CreateTableClass();
            this.CreateTableAccountClass();
            this.dbConnection.Close();
        }

        private void CreateTableAccount()
        {
            if (!TableExists("Account"))
            {
                string query = @"CREATE TABLE Account (
                email VARCHAR(255) PRIMARY KEY,
                password VARCHAR(128),
                type VARCHAR(30))";
                SQLiteCommand command = new SQLiteCommand(query, this.dbConnection);
                command.ExecuteNonQuery();
            }
        }

        private void CreateTableClass()
        {
            if (!TableExists("Class"))
            {
                string query = @"CREATE TABLE Class (
                courseNo VARCHAR(64) PRIMARY KEY,
                section VARCHAR(30),
                className VARCHAR(255),
                credits integer,
                location VARCHAR(255),
                instructor VARCHAR(255),
                timeStart DATETIME,
                timeEnd DATETIME,
                startDate DATETIME,
                endDate DATETIME,
                classDays VARCHAR(7))";
                SQLiteCommand command = new SQLiteCommand(query, this.dbConnection);
                command.ExecuteNonQuery();
            }
        }

        private void CreateTableAccountClass()
        {
            if (!TableExists("AccountClass"))
            {
                string query = @"CREATE TABLE AccountClass (
                    email VARCHAR(255),
                    courseNo VARCHAR(64),
                    FOREIGN KEY(courseNo) REFERENCES Class(courseNo),
                    FOREIGN KEY(email) REFERENCES Account(email))";
                SQLiteCommand command = new SQLiteCommand(query, this.dbConnection);
                command.ExecuteNonQuery();
            }
        }

        private void CreateTestContent()
        {

        }
    }
}
