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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            accountControl.Login("administrator@example.com", "donotenter");

            Application.Run();
        }
    }
}
