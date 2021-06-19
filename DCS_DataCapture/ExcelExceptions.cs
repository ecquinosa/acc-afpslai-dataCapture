using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCS_DataCapture
{
    public partial class ExcelExceptions : Form
    {
        public ExcelExceptions(string _data)
        {
            InitializeComponent();
            this._data = _data;
        }

        private string _data;

        private void ExcelExceptions_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = _data;
            richTextBox1.ScrollToCaret();
        }
    }
}
