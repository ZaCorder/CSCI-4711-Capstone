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
    public partial class LogoutButton : Form
    {
        private EventHandler logoutListener;

        public LogoutButton(EventHandler logoutListener)
        {
            this.logoutListener = logoutListener;
            this.SetTopLevel(false);
            InitializeComponent();
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.logoutListener.Invoke(sender, e);
        }
    }
}
