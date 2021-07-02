using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCS_DataCapture.Class
{
    class Utilities
    {

        private static string MSG_HEADER = "Data Capture System";

        public static void ShowInformationMessage(string msg)
        {
            System.Windows.Forms.MessageBox.Show(msg, MSG_HEADER, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        public static void ShowWarningMessage(string msg)
        {
            System.Windows.Forms.MessageBox.Show(msg, MSG_HEADER, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
        }

        public static void ShowErrorMessage(string msg)
        {
            System.Windows.Forms.MessageBox.Show(msg, MSG_HEADER, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }      

    }
}
