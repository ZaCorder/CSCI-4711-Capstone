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
            bool reg;
            student = (StudentAccount)this.accountControl.GetLoggedInUser();
            foreach (Class classRecord in this.classes)
            {
                reg = false;
                foreach (Class registeredClass in student.Classes)
                {
                    if (!registeredClass.Equals(classRecord))
                        reg = true;
                        
                }
                if(!reg)
                {
                    this.comboBox1.Items.Add(classRecord);
                }
                
            }    
                
        }

        public void Update(List<Class> classes)
        {
            bool reg = false;
            student = (StudentAccount)this.accountControl.GetLoggedInUser();
            this.classes = classes;
            // Update form.
            for(int i = 0; i < classes.Count; i++)
            {
                Console.WriteLine(classes[i].ClassName);
                if(comboBox1.Text.StartsWith(classes[i].CourseNo))
                {
                    foreach(Class c in student.Classes)
                    {
                        if(classes[i].CourseNo.Equals(c.CourseNo) && classes[i].Section.Equals(c.Section))
                        {
                            reg = true;
                            break;
                        }
                    }
                    if(!reg)
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
            this.registrationControl.Submit(comboBox1.Text, (StudentAccount) this.accountControl.GetLoggedInUser());
            this.Update(this.classes);
            // Will need to update form.
        }

    }
}
