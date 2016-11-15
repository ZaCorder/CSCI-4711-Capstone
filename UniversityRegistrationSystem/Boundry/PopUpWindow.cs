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
    public partial class PopUpWindow : Form
    {
        public PopUpWindow()
        {
            InitializeComponent();
        }

        public static void Display(string message, string title = "")
        {
            PopUpWindow popup = new PopUpWindow();
            popup.messageLabel.Text = message;
            popup.Text = title;
            popup.ShowDialog();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
