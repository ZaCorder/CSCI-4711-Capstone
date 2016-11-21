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
        StudentAccount student = new StudentAccount();
        

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
            student = (StudentAccount)this.accountControl.GetLoggedInUser();
            foreach (Class classRecord in this.classes)
            {
                if (!student.IsRegistered(student, classRecord))
                    this.comboBox1.Items.Add(classRecord);
            }

        }

        public void Update(List<Class> classes)
        {
            student = (StudentAccount)this.accountControl.GetLoggedInUser();
            this.classes = classes;
            // Update form.
            for(int i = 0; i < classes.Count; i++)
            {
                if(comboBox1.Text.StartsWith(classes[i].CourseNo))
                {
                    if(!student.IsRegistered(student, classes[i]))
                    {
                        classes.Remove(classes[i]);
                        this.comboBox1.Items.Clear();
                        PopulateComboBox1();
                        classes.Add(classes[i]);
                    }
                    else
                    {
                        PopUpWindow.Display("Already Registered. No changes have been made to your account.");
                    }
                    break;
                }
                
            }

        
            // Update table (different ticket).
        }

        private void OnClick(object sender, EventArgs e)
        {
            string fullCourseNo = comboBox1.Text;
            this.Update(this.classes);
            this.registrationControl.Submit(fullCourseNo, (StudentAccount) this.accountControl.GetLoggedInUser());
            // Will need to update form.
        }

    }
}
