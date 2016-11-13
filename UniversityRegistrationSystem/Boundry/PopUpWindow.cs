using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityRegistrationSystem.Boundry
{
    /// <summary>
    /// Display a pop up window.
    /// </summary>
    public static class PopUpWindow
    {
        /// <summary>
        /// Display a popup window the specified message and title.
        /// </summary>
        /// <param name="message">The message to be displayed to the user.</param>
        /// <param name="title">The text to be displayed as the title.</param>
        public static void Display(string message, string title ="")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK);
        }
    }
}
