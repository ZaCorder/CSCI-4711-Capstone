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
    /// <summary>
    /// Display a pop up window.
    /// </summary>
    public partial class PopUpWindow : Form
    {
        public PopUpWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Display a popup window the specified message and title.
        /// </summary>
        /// <param name="message">The message to be displayed to the user.</param>
        /// <param name="title">The text to be displayed as the title.</param>
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
