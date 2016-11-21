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
    public partial class RegisterForClassForm : Form
    {
        private DBConnect db;
        private List<Class> classes;
        private EventHandler registerForClassListener;
        AccountController accountControl;
        public RegisterForClassForm(List<Class> classes)
        {
            this.classes = classes;
            this.SetTopLevel(false);
            InitializeComponent();
        }

        public RegisterForClassForm(EventHandler registerForClassListener)
        {
            
            this.registerForClassListener = registerForClassListener;
            this.SetTopLevel(false);
            InitializeComponent();  
        }

        private void OnClick(object sender, EventArgs e)
        {
            //db.Register(comboBox1.Text, Account student);//Unsure with how to pass student info here.
        }

    }
}
