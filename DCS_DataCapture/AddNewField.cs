
using System;
using System.Data;
using System.Windows.Forms;

namespace DCS_DataCapture
{
    public partial class AddNewField : Form
    {
        public AddNewField()
        {
            InitializeComponent();
        }
       
        private DataTable dtCustomFields;
        public bool IsHaveChanges;

        private void AddNewField_Load(object sender, EventArgs e)
        {
            //ResetForm();
            CreateCustomFieldsTable();
            PopulateCustomFields();
            BindGrid();

            CheckLimit();
            cboControlType.SelectedIndex = 0;
        }

        private void ResetForm()
        {
            this.Width = 407;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtLabel.Text == "") return;
            if (txtFieldID.Text == "") return;
            if (cboControlType.Text == "") return;

            lblStatus.Text = "";

            if (!AddCustomFields()) return;

            BindGrid();
            Reset();
            //ResetForm();
            IsHaveChanges = true;
            CheckLimit();
        }

        private void BindGrid()
        {
            grid.DataSource = dtCustomFields;
        }

        private void txtLabel_TextChanged(object sender, EventArgs e)
        {
            string[] replaceThese = { "/", @"\", " ", ";", ",", "@", "(", ")", ":", "`", "'" };
            string data = txtLabel.Text.Trim();

            foreach (string curr in replaceThese)
            {
                data = data.Replace(curr, string.Empty);
            }

            if (txtLabel.Text.Trim().Length <= 10)
                txtFieldID.Text = data; //+ "_Custom";
            else
                txtFieldID.Text = data.Substring(0, 10);// + "_Custom";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
            //ResetForm();
        }

        private void Reset()
        {
            txtFieldID.Clear();
            txtLabel.Clear();
            cboControlType.SelectedIndex = 0;
            chkMandatory.Checked = false;            
        }

        private void aDDNEWFIELDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Width = 653;
            txtLabel.Select();
            txtLabel.Focus();
        }

        private void CreateCustomFieldsTable()
        {
            if (dtCustomFields == null)
            {
                dtCustomFields = new DataTable();
                dtCustomFields.Columns.Add("ID", Type.GetType("System.String"));
                dtCustomFields.Columns.Add("Label", Type.GetType("System.String"));
                dtCustomFields.Columns.Add("ControlType", Type.GetType("System.String"));
                dtCustomFields.Columns.Add("ControlName", Type.GetType("System.String"));
                dtCustomFields.Columns.Add("Mandatory", Type.GetType("System.Boolean"));                
            }
        }

        private void PopulateCustomFields()
        {            
            foreach (DataRow rw in DCS_MemberInfo.Data.MemberInfo.Select("IsBuiltInControl=0"))
            {
                DataRow rwNew = dtCustomFields.NewRow();
                rwNew["ID"] = rw["Field"].ToString();
                rwNew["Label"] = rw["Label"].ToString();
                rwNew["ControlType"] = rw["ControlType"].ToString();
                rwNew["ControlName"] = rw["ControlName"].ToString();
                rwNew["Mandatory"] = rw["IsMandatory"].ToString();
                dtCustomFields.Rows.Add(rwNew);
            }
        }

        private bool AddCustomFields()
        {
            if (dtCustomFields.Select("ID='" + txtFieldID.Text + "'").Length == 0)
            {
                DataRow rw = dtCustomFields.NewRow();
                rw["ID"] = txtFieldID.Text;
                rw["Label"] = txtLabel.Text;
                rw["ControlType"] = cboControlType.Text;
                rw["ControlName"] = ControlID_Prefix(txtFieldID.Text) + txtFieldID.Text;
                rw["Mandatory"] = chkMandatory.Checked.ToString();
                dtCustomFields.Rows.Add(rw);
                return true;
            }
            else
            {
                lblStatus.Text = "Duplicate entry not allowed";
                lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
                return false;
            }            
        }

        private void SaveChanges()
        {
            foreach (DataRow rw in DCS_MemberInfo.Data.MemberInfo.Select("IsBuiltInControl=0"))
            {
                rw.Delete();
            }
                        
            foreach (DataRow rw in dtCustomFields.Rows)
            {                
                //DCS_MemberInfo.Data.AddMemberInfoRow(rw["ID"].ToString().Trim(), "", rw["Label"].ToString().Trim(), ControlID_Prefix(rw["ControlType"].ToString().Trim()) + rw["ID"].ToString().Trim(), rw["ControlType"].ToString().Trim(), false, (bool)rw["Mandatory"], false, false, false);
                DCS_MemberInfo.Data.AddMemberInfoRow(rw["ID"].ToString().Trim(), "", rw["Label"].ToString().Trim(), rw["ControlName"].ToString().Trim(), rw["ControlType"].ToString().Trim(), false, (bool)rw["Mandatory"], false, false, false);
            }

            DataCapture.SaveMemberInfoFields();
        }

        private string ControlID_Prefix(string ControlType)
        {
            switch (ControlType)
            {
                case "TextBox":
                    return "txt";                    
                case "MaskedTextBox":
                    return "mtb";                    
                case "CheckBox":
                    return "chk";                    
                case "RadioButton":
                    return "rb";                    
                default:
                    return "";                    
            }
        }

        private void AddNewField_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsHaveChanges)
            {
                if (MessageBox.Show("Do you want to save changes?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) SaveChanges();
            }
        }

        private void dELETEFIELDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dtCustomFields.Select("ID='" + grid.CurrentRow.Cells[0].Value.ToString() + "'")[0].Delete();
                BindGrid();
                IsHaveChanges = true;
                CheckLimit();
            }
            catch { }
        }

        private void CheckLimit()
        {
            if (dtCustomFields.DefaultView.Count == 10)
                aDDNEWFIELDToolStripMenuItem.Enabled = false;
            else aDDNEWFIELDToolStripMenuItem.Enabled = true;

            if (dtCustomFields.DefaultView.Count == 0)
                dELETEFIELDToolStripMenuItem.Enabled = false;
            else dELETEFIELDToolStripMenuItem.Enabled = true;
        }

        private void cboControlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                chkMandatory.Checked = false;
                switch (cboControlType.Text)
                {
                    case "TextBox":
                        chkMandatory.Enabled = true;
                        break;
                    case "MaskedTextBox":
                        chkMandatory.Enabled = true;
                        break;
                    case "CheckBox":
                        chkMandatory.Enabled = false;
                        break;
                    case "RadioButton":
                        chkMandatory.Enabled = false;
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }

        private void MoveRow(int NewRowIndex)
        {
            try
            {
                int intRowIndex = grid.CurrentRow.Index;

                DataRow rw = dtCustomFields.Rows[NewRowIndex];
                DataRow newRow = dtCustomFields.NewRow();
                newRow.ItemArray = rw.ItemArray;

                dtCustomFields.Rows.Remove(rw);
                dtCustomFields.Rows.InsertAt(newRow, intRowIndex);

                IsHaveChanges = true;
            }
            catch { }
        }        

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow.Index != 0) MoveRow(grid.CurrentRow.Index - 1);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow.Index != (dtCustomFields.DefaultView.Count - 1)) MoveRow(grid.CurrentRow.Index + 1);
        }
    }

   
}
