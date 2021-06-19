
using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace DCS_DataCapture
{
    public partial class ManageRecord : Form
    {

        private DataTable dtOldTable = null;
        private string _ErrorMessage = "";

        public ManageRecord()
        {
            InitializeComponent();
            txtCIF.MaxLength = DataCapture.dcs_system_setting.cif_length;
            txtCIF_PrincipalMember.MaxLength = DataCapture.dcs_system_setting.cif_length;
        }

        private void ManageRecord_Load(object sender, EventArgs e)
        {
            PopulateComboBox("tblAssociateType", "AssociateTypeID", "AssociateType", ref cboAssociateType);
            PopulateComboBox("tblMaritalStatus", "MaritalStatusID", "MaritalStatus", ref cboMaritalStatus);
            PopulateComboBox("tblMembershipStatus", "MembershipStatusID", "MembershipStatus", ref cboMembershipStatus);
            PopulateComboBox("tblMembershipType", "MembershipTypeID", "MembershipType", ref cboMembershipType);
            PopulateComboBox("tblPrintingType", "PrintingTypeID", "PrintingType", ref cboPrintingType);
            PopulateComboBox("tblReplaceReason", "ReasonID", "Reason", ref cboReplaceReason);
            PopulateComboBox("tblBranch", "Code", "Branch", ref cboBranchIssue);
            PopulateCboCountry("tblCountry", "Country", "Country", ref cboCountry);
            cboBranchIssue.SelectedIndex = cboBranchIssue.FindStringExact(Properties.Settings.Default.BranchIssue);
            cboCountry.SelectedIndex = cboCountry.FindStringExact("Philippines");

            if (cboGender.Items.Count > 0) { cboGender.SelectedIndex = 0; }

            lblSupervisor.Text = "";
            lblVoidReason.Text = "";
            lblRefDataID.Text = "";

            cboPrintingType.Select();
            cboPrintingType.Focus();

            if (cboMembershipStatus.Items.Count > 3) cboMembershipStatus.SelectedIndex = 3;            
            EditMode(false);            
        }

        private void PopulateCboCountry(string tableName, string fieldID, string fieldDesc, ref ComboBox cbo)
        {
            //DAL_Mssql DAL = new DAL_Mssql();
            //if (DAL.SelectQuery(string.Format("SELECT '' As {0}, '-Select-' As {1} UNION SELECT {0}, {1} FROM {2}", fieldID, fieldDesc, tableName)))
            //{
            //    cbo.DataSource = DAL.TableResult;
            //    cbo.ValueMember = fieldID;
            //    cbo.DisplayMember = fieldDesc;
            //}
            //DAL.Dispose();
            //DAL = null;
        }

        private void PopulateComboBox(string tableName, string fieldID, string fieldDesc, ref ComboBox cbo)
        {
            //DAL_Mssql DAL = new DAL_Mssql();
            //if (DAL.SelectQuery(string.Format("SELECT 0 As {0}, '-Select-' As {1} UNION SELECT {0}, {1} FROM {2} WHERE ISNULL(IsDeleted,0)=0", fieldID, fieldDesc, tableName)))
            //{
            //    cbo.DataSource = DAL.TableResult;
            //    cbo.ValueMember = fieldID;
            //    cbo.DisplayMember = fieldDesc;
            //}
            //DAL.Dispose();
            //DAL = null;
        }


        private void txtCIF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                if (txtCIF.Text != "") BindData();
                //lblDuplicate.Visible = CheckIfIDHaveDuplicate();
            }
        }

        private void BindData()
        {
            //DAL_Mssql DAL = new DAL_Mssql();
            //if (DAL.SelectDataByCIF(txtCIF.Text))
            //{
            //    if (DAL.TableResult.DefaultView.Count > 0)
            //    {
            //        DataRow rw = DAL.TableResult.Rows[0];

            //        if (!string.IsNullOrEmpty(rw["IsVoid"].ToString()))
            //        {
            //            if ((bool)rw["IsVoid"])
            //            {
            //                txtCIF.Clear();
            //                txtCIF.SelectAll();
            //                txtCIF.Focus();
            //                MessageBox.Show(string.Format("CIF {0} is already voided last {1}", txtCIF.Text, rw["VoidDate"].ToString()), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //        }
            //        else
            //        {
            //            dtOldTable = DAL.TableResult;

            //            DataID.Text = rw["DataID"].ToString().Trim();
            //            txtDateIssued.Text = Convert.ToDateTime(rw["DatePosted"].ToString()).ToString("MMM dd, yyyy");
            //            if (rw["PrintingType"] != null) cboPrintingType.SelectedIndex = cboPrintingType.FindString(rw["PrintingType"].ToString().Trim());
            //            if (rw["ReplaceReason"] != null) cboReplaceReason.SelectedIndex = cboReplaceReason.FindString(rw["ReplaceReason"].ToString().Trim());
            //            txtCIF.Text = rw["CIF"].ToString().Trim();
            //            txtFName.Text = rw["FName"].ToString().Trim();
            //            txtMName.Text = rw["MName"].ToString().Trim();
            //            txtLName.Text = rw["LName"].ToString().Trim();
            //            txtSuffix.Text = rw["Suffix"].ToString().Trim();
            //            if (rw["Gender"] != null) cboGender.SelectedIndex = cboGender.FindString(rw["Gender"].ToString().Trim());
            //            mtbDateOfBirth.Text = rw["DateOfBirth"].ToString().Trim();
            //            if (rw["MaritalStatus"] != null) cboMaritalStatus.SelectedIndex = cboMaritalStatus.FindString(rw["MaritalStatus"].ToString().Trim());
            //            mtbMembershipDate.Text = rw["MembershipDate"].ToString().Trim();
            //            if (rw["MembershipStatus"] != null) cboMembershipStatus.SelectedIndex = cboMembershipStatus.FindString(rw["MembershipStatus"].ToString().Trim());
            //            if (rw["MembershipType"] != null) cboMembershipType.SelectedIndex = cboMembershipType.FindString(rw["MembershipType"].ToString().Trim());
            //            txtMobileNos.Text = rw["MobileNos"].ToString().Trim();
            //            txtContactNos.Text = rw["ContactNos"].ToString().Trim();
            //            //cboBranchIssue.Text = rw["Branch"].ToString().Trim();
            //            txtAddress1.Text = rw["Address1"].ToString().Trim();
            //            txtAddress2.Text = rw["Address2"].ToString().Trim();
            //            txtAddress3.Text = rw["Address3"].ToString().Trim();
            //            txtCity.Text = rw["City"].ToString().Trim();
            //            txtProvince.Text = rw["Province"].ToString().Trim();
            //            if (rw["Country"] != null) cboCountry.SelectedIndex = cboCountry.FindString(rw["Country"].ToString().Trim());
            //            txtZipCode.Text = rw["ZipCode"].ToString().Trim();
            //            txtFullName_Contact.Text = rw["FullName_Contact"].ToString().Trim();
            //            txtContactNos_Contact.Text = rw["ContactNos_Contact"].ToString().Trim();
            //            cboAssociateType.Text = rw["AssociateType"].ToString().Trim();
            //            txtCIF_PrincipalMember.Text = rw["CIF_PrincipalMember"].ToString().Trim();
            //            txtPrincipalName.Text = rw["PrincipalName"].ToString().Trim();
            //            lblRefDataID.Text = rw["RefDataID"].ToString().Trim();
            //            //txtCCANo.Text = rw["CCANo"].ToString().Trim();
            //            //chkForUploading.Checked = (bool)rw["IsForUpload"];
            //            if (rw["CCANo"] != null) txtCCANo.Text = rw["CCANo"].ToString().Trim();
            //            if (rw["IsForUpload"] != null) chkForUploading.Checked = (bool)rw["IsForUpload"];
            //            btnSubmit.Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("No record found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        btnSubmit.Visible = false;
            //    }
            //}      
            //DAL.Dispose();
            //DAL = null;                                                
        }

        private void EditMode(bool bln)
        {
            //cboPrintingType.Enabled = bln;
            cboReplaceReason.Enabled = bln;            
            txtFName.ReadOnly = !bln;
            txtMName.ReadOnly = !bln;
            txtLName.ReadOnly = !bln;
            txtSuffix.ReadOnly = !bln;
            cboGender.Enabled = bln;
            mtbDateOfBirth.Enabled = bln;
            cboMaritalStatus.Enabled = bln;
            mtbMembershipDate.Enabled = bln;
            cboMembershipStatus.Enabled = bln;
            cboMembershipType.Enabled = bln;
            txtMobileNos.ReadOnly = !bln;
            txtContactNos.ReadOnly = !bln;
            //cboBranchIssue.Enabled = bln;
            txtAddress1.ReadOnly = !bln;
            txtAddress2.ReadOnly = !bln;
            txtAddress3.ReadOnly = !bln;
            txtCity.ReadOnly = !bln;
            txtProvince.ReadOnly = !bln;
            cboCountry.Enabled = bln;
            txtZipCode.ReadOnly = !bln;
            txtFullName_Contact.ReadOnly = !bln;
            txtContactNos_Contact.ReadOnly = !bln;
            cboAssociateType.Enabled = bln;
            txtCIF_PrincipalMember.ReadOnly = !bln;
            txtPrincipalName.ReadOnly = !bln;
            txtCCANo.ReadOnly = !bln;
            chkForUploading.Enabled = bln;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text == "Edit")
            {
                btnSubmit.Text = "Save";
                btnCancel.Visible = true;
                EditMode(true);
            }
            else
            {
                if (IsLocalValidation())
                {
                    if (txtCIF.Text != dtOldTable.Rows[0]["CIF"].ToString().Trim())
                    {
                        if(MessageBox.Show("Are you sure you want to change existing CIF?",this.Text,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No) return;
                    }

                    string errorMsg = "";
                    if (InsertToDbase(ref errorMsg))
                    {
                        EditMode(false);
                        MessageBox.Show("Done", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {

                    }
                }
                else
                {
                    txtFooterMsg.Text = _ErrorMessage;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            btnSubmit.Text = "Edit";
            btnCancel.Visible = false;
            EditMode(false);
            if (dtOldTable.Rows[0]["PrintingType"] != null) cboPrintingType.SelectedIndex = cboPrintingType.FindString(dtOldTable.Rows[0]["PrintingType"].ToString().Trim());
        }       

        public bool InsertToDbase(ref string ErrorMsg)
        {
            ////DCS_MemberInfo.Data.CapturedDataRepo = @"E:\Projects\DCS2015\DCS2015\bin\Debug\Captured Data";
            ////DCS_MemberInfo.Data.CapturedDataRepo = @"D:\EDEL\ACC\Projects\DCS2015\DCS2015\bin\Debug\Captured Data";
            //string origPath = string.Format(@"{0}\{1}\{2}", DCS_MemberInfo.Data.CapturedDataRepo, Convert.ToDateTime(txtDateIssued.Text).ToString("MMddyyyy"), dtOldTable.Rows[0]["CIF"].ToString().Trim());
            //string backupPath = string.Format(@"{0}\{1}\{2}_{3}", DCS_MemberInfo.Data.CapturedDataRepo, Convert.ToDateTime(txtDateIssued.Text).ToString("MMddyyyy"), dtOldTable.Rows[0]["CIF"].ToString().Trim(), DateTime.Now.ToString("ddMMyyyy_hhmmss"));
            ////CopyDirectory(new DirectoryInfo(sourcePath_Orig), new DirectoryInfo(sourcePath));

            //string destiPath = string.Format(@"{0}\{1}\{2}", DCS_MemberInfo.Data.CapturedDataRepo, DateTime.Today.ToString("MMddyyyy"), txtCIF.Text);

            //if (!Directory.Exists(origPath))
            //{
            //    MessageBox.Show("Unable to find source folder '" + origPath + "'", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}

            //if (Directory.Exists(destiPath))
            //{
            //    if(MessageBox.Show("Destination folder already exist '" + destiPath + "'? Replace?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No) return false;
            //    //System.IO.Directory.Delete(destiPath, true);
            //}

            //CopyDirectory2(origPath, backupPath);

            //VoidTxn frm = new VoidTxn();
            //frm.ShowDialog();
            //if (!frm.IsApproved) return false;

            //DAL_Mssql DAL = new DAL_Mssql();
            //try
            //{
            //    object associateTypeID = null;
            //    object reason = null;
            //    object maritalStatusID = null;
            //    object membershipStatusID = null;
            //    object membershipTypeID = null;
            //    object branchCode = null;
            //    object country = null;

            //    object dob = null;
            //    if (mtbDateOfBirth.Text.Replace("/", "").Trim() != "")
            //    {
            //        string _date1 = string.Format("{0}/{1}/{2}", mtbDateOfBirth.Text.Split('/')[1], mtbDateOfBirth.Text.Split('/')[0], mtbDateOfBirth.Text.Split('/')[2]);
            //        dob = Convert.ToDateTime(_date1);
            //    }

            //    object membershipDate = null;
            //    if (mtbMembershipDate.Text.Replace("/", "").Trim() != "")
            //    {
            //        string _date2 = string.Format("{0}/{1}/{2}", mtbMembershipDate.Text.Split('/')[1], mtbMembershipDate.Text.Split('/')[0], mtbMembershipDate.Text.Split('/')[2]);
            //        membershipDate = Convert.ToDateTime(_date2);
            //    }

            //    object supervisorID = null;
            //    object voidReason = null;
            //    object refDataID = null;

            //    if (cboAssociateType.Text.ToString() != "")
            //    {
            //        if (cboAssociateType.Text.ToString().ToUpper() != "-SELECT-") associateTypeID = Convert.ToInt16(cboAssociateType.SelectedValue);
            //    }

            //    if (cboReplaceReason.Text.ToString() != "")
            //    {
            //        if (cboReplaceReason.Text.ToString().ToUpper() != "-SELECT-") reason = cboReplaceReason.Text.ToString();
            //    }

            //    if (cboMaritalStatus.Text.ToString() != "")
            //    {
            //        if (cboMaritalStatus.Text.ToString().ToUpper() != "-SELECT-") maritalStatusID = Convert.ToInt16(cboMaritalStatus.SelectedValue);
            //    }

            //    if (cboMembershipStatus.Text.ToString() != "")
            //    {
            //        if (cboMembershipStatus.Text.ToString().ToUpper() != "-SELECT-") membershipStatusID = Convert.ToInt16(cboMembershipStatus.SelectedValue);
            //    }

            //    if (cboMembershipType.Text.ToString() != "")
            //    {
            //        if (cboMembershipType.Text.ToString().ToUpper() != "-SELECT-") membershipTypeID = Convert.ToInt16(cboMembershipType.SelectedValue);
            //    }

            //    if (cboBranchIssue.Text.ToString() != "")
            //    {
            //        if (cboBranchIssue.Text.ToString().ToUpper() != "-SELECT-") branchCode = cboBranchIssue.SelectedValue.ToString();
            //    }

            //    if (cboCountry.Text.ToString() != "")
            //    {
            //        if (cboCountry.Text.ToString().ToUpper() != "-SELECT-") country = cboCountry.Text;
            //    }

            //    //if (mtbMembershipDate.Text.Replace("/", "").Trim() != "") membershipDate = Convert.ToDateTime(mtbMembershipDate.Text);

            //    object _CCANo = null;
            //    if (txtCCANo.Text != "") _CCANo = txtCCANo.Text;

            //    if (!DAL.AddData(Convert.ToInt16(cboPrintingType.SelectedValue), txtCIF.Text, txtFName.Text, txtMName.Text, txtLName.Text, txtSuffix.Text, cboGender.Text, dob, maritalStatusID, membershipDate, membershipStatusID, membershipTypeID, txtMobileNos.Text, txtContactNos.Text, branchCode, txtAddress1.Text, txtAddress2.Text, txtAddress3.Text, txtCity.Text, txtProvince.Text, country, txtZipCode.Text, txtFullName_Contact.Text, txtContactNos_Contact.Text, associateTypeID, txtCIF_PrincipalMember.Text, txtPrincipalName.Text, reason, DCS_MemberInfo.Data.SessionReference, DCS_MemberInfo.Data.OperatorID, DCS_MemberInfo.Data.TerminalName, null, null, Convert.ToInt32(DataID.Text), _CCANo,chkForUploading.Checked))
            //    {
            //        ErrorMsg = DAL.ErrorMessage;
            //        DAL.AddSystemLog(string.Format("{0} failed to add new data for replacement with CIF {1}, DataID {2}, Error {3}", DCS_MemberInfo.Data.OperatorID, txtCIF.Text, DataID.Text, DAL.ErrorMessage), "Error");
            //        return false;
            //    }
            //    else
            //    {                    
            //        DAL.AddSystemLog(string.Format("{0} added new data for replacement with CIF {1}, DataID {2}", DCS_MemberInfo.Data.OperatorID, txtCIF.Text, DataID.Text), "System");

            //        if (DAL.VoidTxn(Convert.ToInt32(DataID.Text), frm.UserID(), frm.VoidReason()))
            //        {                        
            //            DAL.AddSystemLog(string.Format("{0} void CIF {1}, Dataid {2}", DCS_MemberInfo.Data.OperatorID, txtCIF.Text, DataID.Text), "System");
            //            System.IO.Directory.Delete(origPath, true);
            //            CopyDirectory_NoXML(backupPath, destiPath);

            //            //create xml data

            //            //string xmlSourceFile = string.Format(@"{0}\{1}.xml", diSourceFolder, dtOldTable.Rows[0]["CIF"].ToString().Trim());
            //            string xmlSourceFile = string.Format(@"{0}\{1}_{2}.xml", backupPath, dtOldTable.Rows[0]["CIF"].ToString().Trim(), Convert.ToDateTime(txtDateIssued.Text).ToString("ddMMyyyy"));
            //            //string xmlDestiFile = string.Format("{0}_{1}.xml", dtOldTable.Rows[0]["CIF"].ToString().Trim(), Convert.ToDateTime(txtDateIssued.Text).ToString("ddMMyyyy"));
            //            string xmlDestiFile = string.Format(@"{0}\{1}_{2}.xml", destiPath, txtCIF.Text, DateTime.Today.ToString("ddMMyyyy"));
            //            XMLMemberData _xmlMD = new XMLMemberData();
            //            if (!_xmlMD.Create2(DCS_MemberInfo.Data.MemberInfo, xmlDestiFile, xmlSourceFile))
            //            //{
            //                DAL.AddSystemLog(string.Format("{0} failed to create xml for CIF {1}, Dataid {2}", DCS_MemberInfo.Data.OperatorID, txtCIF.Text, DataID.Text), "Error");
            //            //}
            //            //else
            //            //{                            
            //            //    //diSourceFolder.MoveTo(string.Format(@"{0}\{1}\{2}_{3}", DCS_MemberInfo.Data.CapturedDataRepo, Convert.ToDateTime(txtDateIssued.Text).ToString("MMddyyyy"), dtOldTable.Rows[0]["CIF"].ToString().Trim(), DateTime.Now.ToString("yyyyMMdd_hhmmss")));
            //            //}                        
            //        }
            //        else
            //            DAL.AddSystemLog(string.Format("{0} failed to void CIF {1}, Dataid {2}, Error {3}", DCS_MemberInfo.Data.OperatorID, txtCIF.Text, DataID.Text,DAL.ErrorMessage), "Error");
            //    }

            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    ErrorMsg = ex.Message;
            //    return false;
            //}
            //finally
            //{
            //    DAL.Dispose();
            //    DAL = null;
            //}

            return true;
        }

        private void CopyDirectory2(string source, string destination)
        {            
            if (!System.IO.Directory.Exists(destination))System.IO.Directory.CreateDirectory(destination);

            foreach (string strFile in System.IO.Directory.GetFiles(source))
            {
                System.IO.File.Copy(strFile, string.Format(@"{0}\{1}", destination, System.IO.Path.GetFileName(strFile)));
            }
        }

        private void CopyDirectory_NoXML(string source, string destination)
        {
            if (!System.IO.Directory.Exists(destination)) System.IO.Directory.CreateDirectory(destination);

            foreach (string strFile in System.IO.Directory.GetFiles(source))
            {
                if(System.IO.Path.GetExtension(strFile).ToUpper()!=".XML")
                {
                    if (System.IO.Path.GetExtension(strFile).ToUpper() == ".ANSI-FMR")
                        System.IO.File.Copy(strFile, string.Format(@"{0}\{1}", destination, System.IO.Path.GetFileName(strFile)));
                    else if (System.IO.Path.GetExtension(strFile).ToUpper() == ".WSQ")
                        System.IO.File.Copy(strFile, string.Format(@"{0}\{1}", destination, System.IO.Path.GetFileName(strFile)));
                    else
                    {
                        string[] arrs = System.IO.Path.GetFileNameWithoutExtension(strFile).Split('_');
                        string _filename = "";
                        short intCntr = 1;
                        foreach (string arr in arrs)
                        {
                            if (intCntr != 3)
                            {
                                if (intCntr == 1)
                                    _filename = arr;
                                else if (intCntr == 2)
                                    _filename += "_" + arr;
                            }
                            intCntr += 1;
                        }
                        _filename += "_" + DateTime.Today.ToString("ddMMyyyy");
                        System.IO.File.Copy(strFile, string.Format(@"{0}\{1}{2}", destination, _filename, System.IO.Path.GetExtension(strFile)),true);
                    }                      
                    
                }                    
            }
        }

        static void CopyDirectory(DirectoryInfo source, DirectoryInfo destination)
        {
            if (!destination.Exists)
            {
                destination.Create();
            }

            // Copy all files.
            FileInfo[] files = source.GetFiles();
            foreach (FileInfo file in files)
            {
                string oldCIF = source.FullName.Substring(source.FullName.LastIndexOf(@"\") + 1);
                string newCIF = destination.FullName.Substring(destination.FullName.LastIndexOf(@"\") + 1);
                file.CopyTo(Path.Combine(destination.FullName,
                    file.Name.Replace(oldCIF,newCIF)));
            }

            // Process subdirectories.
            DirectoryInfo[] dirs = source.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                // Get destination directory.
                string destinationDir = Path.Combine(destination.FullName, dir.Name);

                // Call CopyDirectory() recursively.
                CopyDirectory(dir, new DirectoryInfo(destinationDir));
            }
        }

        private bool ValidateControl(params Control[] ctrls)
        {
            bool bln = true;
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                {
                    if (((TextBox)ctrl).Text == "")
                    {
                        errorProvider1.SetError(ctrl, "Enter value here");
                        bln = false;
                    }
                    else
                    {
                        errorProvider1.SetError(ctrl, string.Empty);
                    }
                }
                else if (ctrl is ComboBox)
                {
                    if (((ComboBox)ctrl).Text == "")
                    {
                        errorProvider1.SetError(ctrl, "Select value here");
                        bln = false;
                    }
                    else if (((ComboBox)ctrl).Text == "-Select-")
                    {
                        errorProvider1.SetError(ctrl, "Select value here");
                        bln = false;
                    }
                    else
                    {
                        errorProvider1.SetError(ctrl, string.Empty);
                    }
                }
                else if (ctrl is MaskedTextBox)
                {
                    if (((MaskedTextBox)ctrl).Text == "")
                    {
                        errorProvider1.SetError(ctrl, "Enter value here");
                        bln = false;
                    }
                    else if (((MaskedTextBox)ctrl).Text == "  /  /")
                    {
                        errorProvider1.SetError(ctrl, "Enter value here");
                        bln = false;
                    }
                    else
                    {
                        errorProvider1.SetError(ctrl, string.Empty);
                    }
                }
                else if (ctrl is DateTimePicker)
                {
                    if (((DateTimePicker)ctrl).Text == "")
                    {
                        errorProvider1.SetError(ctrl, "Enter value here");
                        bln = false;
                    }
                    else if (((DateTimePicker)ctrl).Text == "  /  /")
                    {
                        errorProvider1.SetError(ctrl, "Enter value here");
                        bln = false;
                    }
                    else
                    {
                        errorProvider1.SetError(ctrl, string.Empty);
                    }
                }

            }

            return bln;
        }

        private Control[] ControlsToValidate()
        {
            Control[] _ctrls = new Control[1];
            short index = 0;

            foreach (DataRow rw in DCS_MemberInfo.Data.MemberInfo.Select("IsMandatory=True"))
            {
                string ControlName = rw["ControlName"].ToString();
                _ctrls[index] = FindControl(ControlName);
                index += 1;
                Array.Resize(ref _ctrls, index + 1);
            }

            return _ctrls;
        }

        private bool IsDuplicate = false;

        public bool IsLocalValidation()
        {
            //enter here your script for data validation
            bool bln = true; ;
            errorProvider1.Clear();

            if (!ValidateControl(ControlsToValidate()))
            {
                _ErrorMessage = "Please complete the required field(s)";
                bln = false;
            }
            else
            {
                if (Convert.ToInt16(txtCIF.Text.Length) != DataCapture.dcs_system_setting.cif_length)
                {
                    _ErrorMessage = string.Format("Please enter {0} characters in CIF", DataCapture.dcs_system_setting.cif_length.ToString());
                    errorProvider1.SetError(txtCIF, _ErrorMessage);
                    bln = false;
                }
                else if (txtCIF_PrincipalMember.Text != "")
                {
                    if (Convert.ToInt16(txtCIF_PrincipalMember.Text.Length) != DataCapture.dcs_system_setting.cif_length)
                    {
                        _ErrorMessage = string.Format("Please enter {0} characters in Principal Member CIF", DataCapture.dcs_system_setting.cif_length.ToString());
                        errorProvider1.SetError(txtCIF_PrincipalMember, _ErrorMessage);
                        bln = false;
                    }
                }
                else if (txtMobileNos.Text != "")
                {
                    if (txtMobileNos.Text.Length != 11)
                    {
                        _ErrorMessage = string.Format("Please enter valid 11 characters mobile number");
                        errorProvider1.SetError(txtMobileNos, _ErrorMessage);
                        bln = false;
                    }
                }
                else if (txtCCANo.Text != "")
                {
                    if (txtCCANo.Text.Length != 14)
                    {
                        _ErrorMessage = "Please enter valid CCA No";
                        errorProvider1.SetError(txtCCANo, _ErrorMessage);
                        bln = false;
                    }
                }
            }

            if (bln)
            {
                if (Convert.ToInt16(cboPrintingType.SelectedValue.ToString()) == 2)
                {
                    if (Convert.ToInt16(cboReplaceReason.SelectedValue.ToString()) == 0)
                    {
                        _ErrorMessage = "Please select replacement reason";
                        errorProvider1.SetError(cboReplaceReason, _ErrorMessage);
                        bln = false;
                    }
                }
            }

            if (bln)
            {
                //if (!chkRecapture.Checked)
                if (true)
                {
                    IsDuplicate = CheckIfIDHaveDuplicate();

                    if (IsDuplicate)
                    {
                        bln = false;
                    }
                    else if (mtbDateOfBirth.Text.Replace("/", "").Trim() != "")
                        bln = ValidateDate(mtbDateOfBirth);
                    else if (mtbMembershipDate.Text.Replace("/", "").Trim() != "")
                        bln = ValidateDate(mtbMembershipDate);

                    if (bln)
                    {
                        if (GetAge() < 10)
                        {
                            _ErrorMessage = "Please enter valid date of birth";
                            errorProvider1.SetError(mtbDateOfBirth, _ErrorMessage);
                            bln = false;
                        }
                        else if (Convert.ToInt32(cboMembershipType.SelectedValue) == 1)
                        {
                            if (GetAge() < DataCapture.dcs_system_setting.member_type_reg_allow_yrs)
                            {
                                _ErrorMessage = "Please enter valid date of birth for Regular";
                                errorProvider1.SetError(mtbDateOfBirth, _ErrorMessage);
                                bln = false;
                            }
                        }
                        else if (Convert.ToInt32(cboMembershipType.SelectedValue) == 2)
                        {
                            if (GetAge() < DataCapture.dcs_system_setting.member_type_assoc_allow_yrs)
                            {
                                _ErrorMessage = "Please enter valid date of birth for Associate";
                                errorProvider1.SetError(mtbDateOfBirth, _ErrorMessage);
                                bln = false;
                            }
                            else if (Convert.ToInt32(cboAssociateType.SelectedValue) == 1)
                            {
                                if (txtCIF_PrincipalMember.Text == "")
                                {
                                    _ErrorMessage = "Please enter CIF of Principal";
                                    errorProvider1.SetError(txtCIF_PrincipalMember, _ErrorMessage);
                                    bln = false;
                                }
                                else if (txtPrincipalName.Text == "")
                                {
                                    _ErrorMessage = "Please enter Name of Principal";
                                    errorProvider1.SetError(txtPrincipalName, _ErrorMessage);
                                    bln = false;
                                }
                            }
                        }
                    }
                }
            }

            if (bln)
            {
                //enter here your script for data submission
                //save data to MemberInfo
                foreach (DataRow rw in DCS_MemberInfo.Data.MemberInfo.Rows)
                {
                    string ControlName = rw["ControlName"].ToString();
                    Control ctrl = FindControl(ControlName);
                    switch (rw["ControlType"].ToString())
                    {
                        case "CheckBox":
                            DCS_MemberInfo.Data.EditMemberInfoRow_Value(rw["Field"].ToString(), ((CheckBox)ctrl).Checked.ToString());
                            break;
                        case "RadioButton":
                            DCS_MemberInfo.Data.EditMemberInfoRow_Value(rw["Field"].ToString(), ((RadioButton)ctrl).Checked.ToString());
                            break;
                        default:
                            if (ctrl.Text.Trim().ToUpper() != "-SELECT-")
                                DCS_MemberInfo.Data.EditMemberInfoRow_Value(rw["Field"].ToString(), ctrl.Text.Trim());
                            else
                                DCS_MemberInfo.Data.EditMemberInfoRow_Value(rw["Field"].ToString(), "");
                            break;
                    }
                }

                //SaveStaticData();
            }

            return bln;
        }

        public bool IsLocalValidation2()
        {
            //enter here your script for data validation
            bool bln = true; ;
            errorProvider1.Clear();

            if (!ValidateControl(ControlsToValidate()))
            {
                _ErrorMessage = "Please complete the required field(s)";
                bln = false;
            }
            else
            {
                if (Convert.ToInt16(txtCIF.Text.Length) != DataCapture.dcs_system_setting.cif_length)
                {
                    _ErrorMessage = string.Format("Please enter {0} characters in CIF", DataCapture.dcs_system_setting.cif_length.ToString());
                    errorProvider1.SetError(txtCIF, _ErrorMessage);
                    bln = false;
                }
                else if (txtCIF_PrincipalMember.Text != "")
                {
                    if (Convert.ToInt16(txtCIF_PrincipalMember.Text.Length) != DataCapture.dcs_system_setting.cif_length)
                    {
                        _ErrorMessage = string.Format("Please enter {0} characters in Principal Member CIF", DataCapture.dcs_system_setting.cif_length.ToString());
                        errorProvider1.SetError(txtCIF_PrincipalMember, _ErrorMessage);
                        bln = false;
                    }
                }
                else if (Convert.ToInt16(cboPrintingType.SelectedValue.ToString()) == 2)
                {
                    if (Convert.ToInt16(cboReplaceReason.SelectedValue.ToString()) == 0)
                    {
                        _ErrorMessage = "Please select replacement reason";
                        errorProvider1.SetError(cboReplaceReason, _ErrorMessage);
                        bln = false;
                    }
                    else if (Convert.ToInt16(cboReplaceReason.SelectedValue.ToString()) < 3)
                    {
                        _ErrorMessage = "Only 'Incorrect details' or 'Update information' is allowed";
                        errorProvider1.SetError(cboReplaceReason, _ErrorMessage);
                        bln = false;
                    }
                }
            }

            if (bln)
            {
                //if (!chkRecapture.Checked)
                if (true)
                {
                    if (CheckIfIDHaveDuplicate())
                    {
                        bln = false;
                    }
                    else if (mtbDateOfBirth.Text.Replace("/", "").Trim() != "")
                        bln = ValidateDate(mtbDateOfBirth);
                    else if (mtbMembershipDate.Text.Replace("/", "").Trim() != "")
                        bln = ValidateDate(mtbMembershipDate); 
                                       

                    if (bln)
                    {
                        if (GetAge() < 10)
                        {
                            _ErrorMessage = "Please enter valid date of birth";
                            errorProvider1.SetError(mtbDateOfBirth, _ErrorMessage);
                            bln = false;
                        }
                        else if (Convert.ToInt32(cboMembershipType.SelectedValue) == 1)
                        {
                            if (GetAge() < DataCapture.dcs_system_setting.member_type_reg_allow_yrs)
                            {
                                _ErrorMessage = "Please enter valid date of birth for Regular";
                                errorProvider1.SetError(mtbDateOfBirth, _ErrorMessage);
                                bln = false;
                            }
                        }
                        else if (Convert.ToInt32(cboMembershipType.SelectedValue) == 2)
                        {
                            if (GetAge() < DataCapture.dcs_system_setting.member_type_assoc_allow_yrs)
                            {
                                _ErrorMessage = "Please enter valid date of birth for Associate";
                                errorProvider1.SetError(mtbDateOfBirth, _ErrorMessage);
                                bln = false;
                            }
                            else if (Convert.ToInt32(cboAssociateType.SelectedValue) == 1)
                            {
                                if(txtCIF_PrincipalMember.Text=="")
                                {
                                    _ErrorMessage = "Please enter CIF of Principal";
                                    errorProvider1.SetError(txtCIF_PrincipalMember, _ErrorMessage);
                                    bln = false;
                                }
                                else if (txtPrincipalName.Text == "")
                                {
                                    _ErrorMessage = "Please enter Principal Name";
                                    errorProvider1.SetError(txtPrincipalName, _ErrorMessage);
                                    bln = false;
                                }
                            }
                        }
                    }                    
                }
            }

            if (bln)
            {
                //enter here your script for data submission
                //save data to MemberInfo
                foreach (DataRow rw in DCS_MemberInfo.Data.MemberInfo.Rows)
                {
                    string ControlName = rw["ControlName"].ToString();
                    Control ctrl = FindControl(ControlName);
                    switch (rw["ControlType"].ToString())
                    {
                        case "CheckBox":
                            DCS_MemberInfo.Data.EditMemberInfoRow_Value(rw["Field"].ToString(), ((CheckBox)ctrl).Checked.ToString());
                            break;
                        case "RadioButton":
                            DCS_MemberInfo.Data.EditMemberInfoRow_Value(rw["Field"].ToString(), ((RadioButton)ctrl).Checked.ToString());
                            break;
                        default:
                            if (ctrl.Text.Trim().ToUpper() != "-SELECT-")
                                DCS_MemberInfo.Data.EditMemberInfoRow_Value(rw["Field"].ToString(), ctrl.Text.Trim());
                            else
                                DCS_MemberInfo.Data.EditMemberInfoRow_Value(rw["Field"].ToString(), "");
                            break;
                    }
                }
            }

            return bln;
        }

        private int GetAge()
        {
            DateTime dob = DateTime.ParseExact(mtbDateOfBirth.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime today = DateTime.Today;

            int months = today.Month - dob.Month;
            int years = today.Year - dob.Year;

            if (today.Day < dob.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            int days = (today - dob.AddMonths((years * 12) + months)).Days;
           
            return years;
        }

        public bool CheckIfIDHaveDuplicate()
        {
            //if (Convert.ToInt16(cboPrintingType.SelectedValue.ToString()) != 1) return false;
            ////if (chkRecapture.Checked) return false;

            //DAL_Mssql DAL = new DAL_Mssql();
            //try
            //{
            //    if (DAL.ExecuteScalar(string.Format("SELECT COUNT(CIF) FROM tblData WHERE CIF = '{0}' AND ISNULL(IsVoid,0)=0", txtCIF.Text)))
            //    {
            //        if (Convert.ToInt16(DAL.ObjectResult) > 0)
            //        {
            //            _ErrorMessage = "Duplicate CIF is not allowed";
            //            errorProvider1.SetError(txtCIF, _ErrorMessage);
            //            return true;
            //        }
            //        else
            //        {
            //            string _date1 = string.Format("{0}/{1}/{2}", mtbDateOfBirth.Text.Split('/')[1], mtbDateOfBirth.Text.Split('/')[0], mtbDateOfBirth.Text.Split('/')[2]);
            //            //if (DAL.ExecuteScalar(string.Format("SELECT COUNT(*) FROM tblData WHERE FName='{0}' AND MName='{1}' AND LName='{2}' AND ISNULL(IsVoid,0)=0", txtFName.Text, txtMName.Text, txtLName.Text)))
            //            if (DAL.ExecuteScalar(string.Format("SELECT COUNT(*) FROM tblData WHERE FName='{0}' AND MName='{1}' AND LName='{2}' AND DateOfBirth='{3}' AND ISNULL(IsVoid,0)=0", txtFName.Text, txtMName.Text, txtLName.Text, Convert.ToDateTime(_date1).ToString("yyyy-MM-dd"))))
            //            {
            //                if (Convert.ToInt16(DAL.ObjectResult) > 0)
            //                {
            //                    _ErrorMessage = "Duplicate Name  is not allowed";
            //                    errorProvider1.SetError(txtFName, _ErrorMessage);
            //                    return true;
            //                }
            //            }
            //        }


            //    }

            //    return false;
            //}
            //finally
            //{
            //    DAL.Dispose();
            //    DAL = null;
            //}

            return false;
        }

        private bool ValidateDate(DateTimePicker mtb)
        {
            try
            {
                if (mtb.Text.Trim().Replace(" ", "") != "//")
                {
                    string _date = string.Format("{0}/{1}/{2}", mtb.Text.Split('/')[1], mtb.Text.Split('/')[0], mtb.Text.Split('/')[2]);
                    Convert.ToDateTime(_date);
                }

                return true;
            }
            catch
            {
                _ErrorMessage = "Please enter valid date";
                errorProvider1.SetError(mtb, _ErrorMessage);
                return false;
            }
        }

        private Control FindControl(string ControlName)
        {
            Control foundCtrl = null;

            foreach (Control ctrlFirst in pnlMain.Controls)
            {
                Control _ctrlFirst = ctrlFirst;

                if (!_ctrlFirst.HasChildren)
                {
                    if (_ctrlFirst.Name.ToUpper() == ControlName.ToUpper())
                    {
                        foundCtrl = _ctrlFirst;
                        break;
                    }
                }
                else
                {
                    foreach (Control ctrlSecond in _ctrlFirst.Controls)
                    {
                        Control _ctrlSecond = ctrlSecond;

                        if (!_ctrlSecond.HasChildren)
                        {
                            if (_ctrlSecond.Name.ToUpper() == ControlName.ToUpper())
                            {
                                foundCtrl = _ctrlSecond;
                                break;
                            }
                        }

                    }
                }
            }

            return foundCtrl;
        }        
    }    
}
