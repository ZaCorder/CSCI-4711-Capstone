using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityRegistrationSystem.Boundry
{
    public partial class RegisterForClassForm : Form
    {
        private EventHandler registerForClassListener;
        public RegisterForClassForm()
        {
            this.SetTopLevel(false);
            InitializeComponent();
        }

        public RegisterForClassForm(EventHandler registerForClassListener)
        {
            this.registerForClassListener = registerForClassListener;
            this.SetTopLevel(false);
            InitializeComponent();  
        }
    }
}
