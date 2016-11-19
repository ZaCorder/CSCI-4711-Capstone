using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityRegistrationSystem.Control;
using UniversityRegistrationSystem.Entity;
using UniversityRegistrationSystem.Boundry;

namespace UniversityRegistrationSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DBConnect db = DBConnect.Instance;
            new DBConnectorInit(db);
            AccountController accountControl = new AccountController(db);
            RegistrationController registrationControl = new RegistrationController(db, accountControl);
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            accountControl.Login("student@example.com", "donotenter");
            registrationControl.Register("CSCI 1101-B");
            Application.Run();
        }
    }
}
