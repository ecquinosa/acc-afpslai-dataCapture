
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DCS_DataCapture
{

    public partial class MaintenanceTable : Form
    {
        public MaintenanceTable()
        {
            InitializeComponent();
        }

        //public delegate void Action(string tableName);
        //Action _action;

        private void MaintenanceTable_Load(object sender, EventArgs e)
        {
            grid.AutoGenerateColumns = true;
            if (cboTable.Items.Count > 0) cboTable.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grid.Enabled = false;
            cboTable.Enabled = false;
            txtID.Text = "0";
            txtValue.ReadOnly = false;
            txtValue.Focus();
            txtValue.SelectAll();
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            switch (cboTable.Text.Trim())
            {
                case "Branch":
                    txtID.ReadOnly = false;
                    break;
                default:
                    break;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                grid.Enabled = false;
                cboTable.Enabled = false;
                txtID.Text = grid.Rows[grid.CurrentRow.Index].Cells[0].Value.ToString().Trim();
                txtValue.Text = grid.Rows[grid.CurrentRow.Index].Cells[1].Value.ToString().Trim();
                txtValue.ReadOnly = false;
                txtValue.Focus();
                txtValue.SelectAll();
                switch (cboTable.Text.Trim())
                {
                    case "Branch":
                        lblOldCode.Text = grid.Rows[grid.CurrentRow.Index].Cells[0].Value.ToString().Trim();
                        txtID.ReadOnly = false;
                        label2.Text = "Code";
                        break;
                    default:
                        txtID.ReadOnly = true;
                        label2.Text = "ID";
                        break;
                }
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btnCancel.Visible = true;
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            label2.Text = "ID";
            cboTable.Enabled = true;
            grid.Enabled = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            txtID.ReadOnly = true;
            txtID.Clear();
            txtValue.Clear();
            txtValue.ReadOnly = true;
            lblOldCode.Text = "";
            lblResult.Text = "Ready";
            lblResult.ForeColor = Color.Black;
        }

        private void cboTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch { }
        }

        private void BindGrid()
        {
            object obj = null;

            switch (cboTable.Text.Trim())
            {
                case "Associate Type":
                    if (MiddleServerApi.GetTable(MiddleServerApi.msApi.getAssociateType, ref obj))
                    {
                        var associateTypes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Class.associate_type>>(obj.ToString());
                        grid.DataSource = associateTypes;
                    }
                    break;
                case "Branch":
                    if (MiddleServerApi.GetTable(MiddleServerApi.msApi.getBranch, ref obj))
                    {
                        var branches = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Class.branch>>(obj.ToString());
                        grid.DataSource = branches;
                    }
                    break;
                case "Marital Status":
                    if (MiddleServerApi.GetTable(MiddleServerApi.msApi.getCivilStatus, ref obj))
                    {
                        var civilStatuses = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Class.civil_status>>(obj.ToString());
                        grid.DataSource = civilStatuses;
                    }
                    break;
                case "Membership Status":
                    if (MiddleServerApi.GetTable(MiddleServerApi.msApi.getMembershipStatus, ref obj))
                    {
                        var membershipStatuses = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Class.membership_status>>(obj.ToString());
                        grid.DataSource = membershipStatuses;
                    }
                    break;
                case "Membership Type":
                    if (MiddleServerApi.GetTable(MiddleServerApi.msApi.getMembershipType, ref obj))
                    {
                        var membershipTypes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Class.membership_type>>(obj.ToString());
                        grid.DataSource = membershipTypes;
                    }
                    break;
                case "Printing Type":
                    if (MiddleServerApi.GetTable(MiddleServerApi.msApi.getPrintType, ref obj))
                    {
                        var printTypes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Class.print_type>>(obj.ToString());
                        grid.DataSource = printTypes;
                    }
                    break;
                case "Replace Reason":
                    if (MiddleServerApi.GetTable(MiddleServerApi.msApi.getRecardReason, ref obj))
                    {
                        var replaceReasons = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Class.recard_reason>>(obj.ToString());
                        grid.DataSource = replaceReasons;
                    }
                    break;
                case "System Role":
                    if (MiddleServerApi.GetTable(MiddleServerApi.msApi.getRole, ref obj))
                    {
                        var roles = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Class.system_role>>(obj.ToString());
                        grid.DataSource = roles;
                    }
                    break;
            }

            grid.Columns[grid.Columns.Count - 1].Visible = false;
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtValue.Text == "")
            {
                Class.Utilities.ShowWarningMessage("Please enter value");
                txtValue.Focus();
                return;
            }

            if (MessageBox.Show("Are you sure you want to commit changes?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                switch (cboTable.Text.Trim())
                {
                    case "Associate Type":
                        Class.associate_type objAT = new Class.associate_type();
                        objAT.id = Convert.ToInt32(txtID.Text);
                        objAT.associateType = txtValue.Text;
                        if (MiddleServerApi.addDeleteGenericTable(objAT))
                        {
                            BindGrid();
                            ResetForm();
                            //lblResult.Text = "Record is added/ updated";
                            //lblResult.ForeColor = Color.Green;
                        }
                        break;
                    case "Branch":
                        Class.branch objBranch = new Class.branch();
                        objBranch.id = Convert.ToInt32(txtID.Text);
                        objBranch.branchName = txtValue.Text;
                        if (MiddleServerApi.addDeleteGenericTable(objBranch))
                        {
                            BindGrid();
                            ResetForm();
                        }
                        break;
                    case "Marital Status":
                        Class.civil_status objCV = new Class.civil_status();
                        objCV.id = Convert.ToInt32(txtID.Text);
                        objCV.civilStatus = txtValue.Text;
                        if (MiddleServerApi.addDeleteGenericTable(objCV))
                        {
                            BindGrid();
                            ResetForm();
                        }
                        break;
                    case "Membership Status":
                        Class.membership_status objMS = new Class.membership_status();
                        objMS.id = Convert.ToInt32(txtID.Text);
                        objMS.membershipStatus = txtValue.Text;
                        if (MiddleServerApi.addDeleteGenericTable(objMS))
                        {
                            BindGrid();
                            ResetForm();
                        }
                        break;
                    case "Membership Type":
                        Class.membership_type objMT = new Class.membership_type();
                        objMT.id = Convert.ToInt32(txtID.Text);
                        objMT.membershipType = txtValue.Text;
                        if (MiddleServerApi.addDeleteGenericTable(objMT))
                        {
                            BindGrid();
                            ResetForm();
                        }
                        break;
                    case "Printing Type":
                        Class.print_type objPT = new Class.print_type();
                        objPT.id = Convert.ToInt32(txtID.Text);
                        objPT.printType = txtValue.Text;
                        if (MiddleServerApi.addDeleteGenericTable(objPT))
                        {
                            BindGrid();
                            ResetForm();
                        }
                        break;
                    case "Replace Reason":
                        Class.recard_reason objRR = new Class.recard_reason();
                        objRR.id = Convert.ToInt32(txtID.Text);
                        objRR.recardReason = txtValue.Text;
                        if (MiddleServerApi.addDeleteGenericTable(objRR))
                        {
                            BindGrid();
                            ResetForm();
                        }
                        break;
                    case "System Role":
                        Class.system_role objSR = new Class.system_role();
                        objSR.id = Convert.ToInt32(txtID.Text);
                        objSR.role = txtValue.Text;
                        if (MiddleServerApi.addDeleteGenericTable(objSR))
                        {
                            BindGrid();
                            ResetForm();
                        }
                        break;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells[0].Value.ToString().Trim());
            if (MessageBox.Show("Are you sure you want to delete the record?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                switch (cboTable.Text.Trim())
                {
                    case "Associate Type":
                        Class.associate_type objAT = new Class.associate_type();
                        objAT.id = id;                        
                        if (MiddleServerApi.addDeleteGenericTable(objAT, false)) BindGrid();
                        break;
                    case "Branch":
                        Class.branch objBranch = new Class.branch();
                        objBranch.id = id;
                        if (MiddleServerApi.addDeleteGenericTable(objBranch, false)) BindGrid();
                        break;
                    case "Marital Status":
                        Class.civil_status objCV = new Class.civil_status();
                        objCV.id = id;
                        if (MiddleServerApi.addDeleteGenericTable(objCV, false)) BindGrid();

                        break;
                    case "Membership Status":
                        Class.membership_status objMS = new Class.membership_status();
                        objMS.id =   id;
                        if (MiddleServerApi.addDeleteGenericTable(objMS, false)) BindGrid();
                        break;
                    case "Membership Type":
                        Class.membership_type objMT = new Class.membership_type();
                        objMT.id =   id;
                        if (MiddleServerApi.addDeleteGenericTable(objMT, false)) BindGrid();
                        break;
                    case "Printing Type":
                        Class.print_type objPT = new Class.print_type();
                        objPT.id =   id;
                        if (MiddleServerApi.addDeleteGenericTable(objPT, false)) BindGrid();
                        break;
                    case "Replace Reason":
                        Class.recard_reason objRR = new Class.recard_reason();
                        objRR.id =  id;
                        if (MiddleServerApi.addDeleteGenericTable(objRR, false)) BindGrid();
                        break;
                    case "System Role":
                        Class.system_role objSR = new Class.system_role();
                        objSR.id =  id;
                        if (MiddleServerApi.addDeleteGenericTable(objSR, false)) BindGrid();
                        break;
                }
            }          
        }
    }
}
