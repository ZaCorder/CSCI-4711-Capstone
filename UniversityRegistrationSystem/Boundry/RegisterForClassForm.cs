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
            this.PopulateComboBox1();
        }

        private void PopulateComboBox1()
        {
            
            StudentAccount student = new StudentAccount();
            student = (StudentAccount) this.accountControl.GetLoggedInUser();
            foreach (Class classRecord in this.classes)
            {
                foreach(Class registeredClass in student.Classes)
                {
                    if (!registeredClass.Equals(classRecord))
                        this.comboBox1.Items.Add(classRecord);
                }
                
            }    
                
        }

        public void Update(List<Class> classes)
        {
            this.classes = classes;
            // Update form.
            // Update table (different ticket).
        }

        private void OnClick(object sender, EventArgs e)
        {
            this.registrationControl.Submit(comboBox1.Text, (StudentAccount) this.accountControl.GetLoggedInUser());
            // Will need to update form.
        }

    }
}
