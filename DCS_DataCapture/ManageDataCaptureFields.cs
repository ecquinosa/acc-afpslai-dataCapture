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
    public partial class ManageDataCaptureFields : Form
    {
        public ManageDataCaptureFields()
        {
            InitializeComponent();
        }

        private DataTable dtMemberInfo;
        public bool IsHaveChanges;

        private void ManageDataCaptureFields_Load(object sender, EventArgs e)
        {
            grid.AutoGenerateColumns = false;
            BindGrid();
        }

        private void BindGrid()
        {
            dtMemberInfo = DCS_MemberInfo.Data.MemberInfo;
            grid.DataSource = dtMemberInfo;
        }

        private void btnNewField_Click(object sender, EventArgs e)
        {
            AddNewField _addnew = new AddNewField();
            _addnew.ShowDialog();
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MessageBox.Show(grid.CurrentRow.Cells[1].Value.ToString());
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in grid.Rows)
            {                
                bool IsMandatory = false;
                bool IsCapturedListViewable = false;
                try { IsMandatory = (bool)row.Cells[2].Value; }
                catch { }
                try { IsCapturedListViewable = (bool)row.Cells[5].Value; }
                catch { }

                DCS_MemberInfo.Data.EditMemberInfoRow_IsMandatory_IsCapturedListViewable(row.Cells[0].Value.ToString().Trim(), IsMandatory, IsCapturedListViewable);
            }            

            DataCapture.SaveMemberInfoFields();            

            IsHaveChanges = true;

            MessageBox.Show("Save!",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset fields?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.IO.File.Delete(DataCapture.DataFields);
                DataCapture.InitMemberInfoTable();
                BindGrid();
            }
        }
    }
}
