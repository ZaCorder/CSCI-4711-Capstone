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
    public partial class CreateClassForm : Form
    {
        private EventHandler createClassListener;
        public CreateClassForm()
        {
            this.SetTopLevel(false);
            InitializeComponent();
        }

        public CreateClassForm(EventHandler createClassListener)
        {
            this.createClassListener = createClassListener;
            this.SetTopLevel(false);
            InitializeComponent();
        }

        private void CreateClassWindow_Load(object sender, EventArgs e)
        {

        }

        private void CreateClassForm_Click(object sender, EventArgs e)
        {

        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
