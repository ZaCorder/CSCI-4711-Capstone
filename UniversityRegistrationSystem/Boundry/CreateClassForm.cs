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
            ClearForm();
        }

        public void ClearForm()
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
            ClassDays.SelectedIndex = -1;

        }

        private void Submitbtn_Click(object sender, EventArgs e)
        {
            bool isValidStrings = true;
            bool isValidDates = true;
            if(String.IsNullOrWhiteSpace(CourseNotbx.Text)||String.IsNullOrWhiteSpace(sectionList.Text) || String.IsNullOrWhiteSpace(classNametbx.Text) ||
                String.IsNullOrWhiteSpace(creditsList.Text) || String.IsNullOrWhiteSpace(locationList.Text) || String.IsNullOrWhiteSpace(instructorList.Text) || 
                String.IsNullOrWhiteSpace(ClassDays.Text))
            {
                PopUpWindow.Display("All class attributes must have a value.");
                isValidStrings = false;
            }

            if (StartDate.Value <= DateTime.Now || StartDate.Value > EndDate.Value)
            {
                PopUpWindow.Display("Invalid start date. Please choose a start date after today and before the end date.");
                isValidDates = false;
            }
            else if (EndDate.Value <= DateTime.Now || EndDate.Value < StartDate.Value)
            {
                PopUpWindow.Display("Invalid end date. Please choose an end date after today and after the start date.");
                isValidDates = false;
            }
            else if (StartTime.Value > EndTime.Value) {
                PopUpWindow.Display("Invalid time. End time must be after the start time.");
                isValidDates = false;
            }

            if (isValidStrings && isValidDates)
            {
                CreateClassEventArgs createClassEventArgs = new CreateClassEventArgs(CourseNotbx.Text, sectionList.Text,
                    classNametbx.Text, Convert.ToInt32(creditsList.Text), locationList.Text, instructorList.Text, StartTime.Value, EndTime.Value, StartDate.Value,
                    EndDate.Value, ClassDays.Text);
                this.createClassListener.Invoke(sender, createClassEventArgs);
            }
        }

    }
}
