using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityRegistrationSystem.Entity;
using UniversityRegistrationSystem.Control;

namespace UniversityRegistrationSystem.Boundry
{
    partial class RegisterForClassForm : Form
    {
        private AccountController accountControl;
        private RegistrationController registrationControl;
        private List<Class> classes;

        public RegisterForClassForm(AccountController accountControl, RegistrationController registrationControl, List<Class> classes)
        {
            this.SetTopLevel(false);
            this.registrationControl = registrationControl;
            this.accountControl = accountControl;
            this.classes = classes;

            if (!(accountControl.GetLoggedInUser() is StudentAccount))
                throw new Exception("Only student accounts can be used for registering classes.");

            InitializeComponent();
            this.PopulateComboBox1((StudentAccount) accountControl.GetLoggedInUser());
        }

        private void PopulateComboBox1(StudentAccount student)
        {
            foreach (Class classRecord in this.classes)
            {
                if (!student.IsRegistered(classRecord))
                    this.listBox1.Items.Add(classRecord);
            }
        }

        public void UpdateForm(StudentAccount student)
        {
            this.listBox1.Items.Clear();
            this.PopulateComboBox1(student);
        }

        private void Register(object sender, EventArgs e)
        {
            string fullCourseNo = listBox1.Text;
            this.registrationControl.Register(fullCourseNo);
        }

    }
}
