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
        private EventHandler<CreateClassEventArgs> createClassListener;
        public CreateClassForm()
        {
            this.SetTopLevel(false);
            InitializeComponent();
        }

        public CreateClassForm(EventHandler<CreateClassEventArgs> createClassListener)
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
            CourseNotbx.ResetText();
            sectionList.SelectedIndex = -1;
            classNametbx.ResetText();
            creditsList.SelectedIndex = -1;
            locationList.SelectedIndex = -1;
            instructorList.SelectedIndex = -1;
            StartTime.ResetText();
            EndTime.ResetText();
            StartDate.ResetText();
            EndDate.ResetText();
            DayOfClass.SelectedIndex = -1;
            
        }

        private void Submitbtn_Click(object sender, EventArgs e)
        {
            CreateClassEventArgs createClassEventArgs = new CreateClassEventArgs(CourseNotbx.Text, sectionList.Text,
                classNametbx.Text, Convert.ToInt32(creditsList.Text), locationList.Text, instructorList.Text, StartTime.Value, EndTime.Value, StartDate.Value,
                EndDate.Value, DayOfClass.Text);
            this.createClassListener.Invoke(sender, createClassEventArgs);
        }

        public Label GetErrorLabel()
        {
            return Errorlbl;
        }
    }
}
