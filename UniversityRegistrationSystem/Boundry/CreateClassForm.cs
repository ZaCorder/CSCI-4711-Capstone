using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityRegistrationSystem.Control;

namespace UniversityRegistrationSystem.Boundry
{
    partial class CreateClassForm : Form
    {
        private ClassController createClassControl;

        public CreateClassForm()
        {
            this.SetTopLevel(false);
            InitializeComponent();
        }

        public CreateClassForm(ClassController createClassController)
        {
            this.createClassControl = createClassController;
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
            List<string> errors = new List<string>();
            if(String.IsNullOrWhiteSpace(CourseNotbx.Text)||String.IsNullOrWhiteSpace(sectionList.Text) || String.IsNullOrWhiteSpace(classNametbx.Text) ||
                String.IsNullOrWhiteSpace(creditsList.Text) || String.IsNullOrWhiteSpace(locationList.Text) || String.IsNullOrWhiteSpace(instructorList.Text) || 
                String.IsNullOrWhiteSpace(ClassDays.Text))
            {
                errors.Add("All class attributes must have a value.");
                isValidStrings = false;
            }

            if (StartDate.Value <= DateTime.Now || StartDate.Value > EndDate.Value)
            {
                errors.Add("Invalid start date. Please choose a start date after today and before the end date.");
                isValidDates = false;
            }
            else if (EndDate.Value <= DateTime.Now || EndDate.Value < StartDate.Value)
            {
                errors.Add("Invalid end date. Please choose an end date after today and after the start date.");
                isValidDates = false;
            }
            else if (StartTime.Value > EndTime.Value) {
                errors.Add("Invalid time. End time must be after the start time.");
                isValidDates = false;
            }

            if (isValidStrings && isValidDates)
                this.createClassControl.Submit(CourseNotbx.Text, sectionList.Text,
                    classNametbx.Text, Convert.ToInt32(creditsList.Text), locationList.Text, instructorList.Text, StartTime.Value, EndTime.Value, StartDate.Value,
                    EndDate.Value, ClassDays.Text);
            else
                this.createClassControl.Submit(errors);
        }

    }
}
