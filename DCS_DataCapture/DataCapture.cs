
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using accAfpslaiEmvObjct;

namespace DCS_DataCapture
{
    public partial class DataCapture : UserControl
    {
        public DataCapture()
        {
            InitializeComponent();

            txtFName.KeyPress += textBox1_KeyPress;
            txtMName.KeyPress += textBox1_KeyPress;
            txtLName.KeyPress += textBox1_KeyPress;
            txtSuffix.KeyPress += textBox1_KeyPress;
            txtFullName_Contact.KeyPress += textBox1_KeyPress;         
        }

        public static string dcsDataCaptureConfigFile = String.Format(@"{0}\{1}", Application.StartupPath, "dcsDataCaptureConfig");
        private DataTable dtOldTable;
        private object userID = null;
        private object voidReason = null;
        private bool IsDuplicate = false;

        //public static user dcsUser = null;
        public static dcs_system_setting dcs_system_setting = null;
        public static MiddleServerApi msa = null;
        public static Class.dcsDataCaptureConfig dcsDataCaptureConfig = null;

        #region " Shared Methods "

        private string _ErrorMessage = "";

        private string _MemberID = "";
        private static string _CIF = "";
        private static string _MemberName = "";
        private static string _FName = "";
        private static string _MName = "";
        private static string _LName = "";
        private static string _Suffix = "";
        private static string _DOB = "";
        private static string _DOI = "";
        private static string _Gender = "";
        private static string _ContactNos = "";
        private static string _CompleteAddress = "";
        private static string _BranchIssue = "";

        private static string _Name_Contact = "";
        private static string _ContactNos_Contact = "";

        private static string _CardName = "";

        private static string _MembershipType = "";
        private static string _AssociateType = "";
        private static string _MembershipDate = "";
        private static string _CIF_PrincipalMember = "";

        private static string _IDNumber = "";

        private static string email = "";

        private Color LabelColor_Active = Color.DimGray;
        private Color LabelColor_NotActive = Color.Silver;

        //private DataTable dtSourceData;
        //private string ExcelFileExceptions = "";

        public static string DataFields = @"DataSource\DataFields";
        //public static string SourceData = @"DataSource\SourceData";

        public string MemberID
        {
            get { return _MemberID; }
        }

        public static string CIF
        {
            get { return _CIF; }
        }

        public static string MemberName
        {
            get { return _MemberName; }
        }

        public static string FName
        {
            get { return _FName; }
        }

        public static string MName
        {
            get { return _MName; }
        }

        public static string LName
        {
            get { return _LName; }
        }

        public static string DOB
        {
            get { return _DOI; }
        }

        public static string DOI
        {
            get { return _DOI; }
        }

        public static string Gender
        {
            get { return _Gender; }
        }

        public static string CompleteAddress
        {
            get { return _CompleteAddress; }
        }

        public static string ContactNos
        {
            get { return _ContactNos; }
        }

        public static string Name_Contact
        {
            get { return _Name_Contact; }
        }

        public static string Branch
        {
            get { return _BranchIssue; }
        }

        public static string ContactNos_Contact
        {
            get { return _ContactNos_Contact; }
        }

        public static string CardName
        {
            get { return _CardName; }
        }

        public static string IDNumber
        {
            get { return _IDNumber; }
        }

        public string ErrorMessage
        {
            get { return _ErrorMessage; }
        }

        public static string ClientName
        {
            get { return "AFPSLAI"; }
        }

        public static string AppVersion
        {
            get { return "2"; }
        }

        public static string AssemblyNameAndProductVersion
        {
            get
            {
                string attributes = System.Reflection.Assembly.GetExecutingAssembly().FullName;
                return attributes;
            }
        }

        //please do not rename  or remove methods inside this region

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

        public bool Submit()
        {
            SaveStaticData();

            if (Convert.ToInt16(cboReplaceReason.SelectedValue.ToString()) != 3)
            {
                return true;
            }
            else
            {
                string origPath = string.Format(@"{0}\{1}\{2}", DCS_MemberInfo.Data.CapturedDataRepo, Convert.ToDateTime(dtOldTable.Rows[0]["DatePosted"].ToString().Trim()).ToString("MMddyyyy"), dtOldTable.Rows[0]["CIF"].ToString().Trim());
                string backupPath = string.Format(@"{0}\{1}\{2}_{3}", DCS_MemberInfo.Data.CapturedDataRepo, Convert.ToDateTime(dtOldTable.Rows[0]["DatePosted"].ToString().Trim()).ToString("MMddyyyy"), dtOldTable.Rows[0]["CIF"].ToString().Trim(), DateTime.Now.ToString("ddMMyyyy_hhmmss"));
                string destiPath = string.Format(@"{0}\{1}\{2}", DCS_MemberInfo.Data.CapturedDataRepo, DateTime.Today.ToString("MMddyyyy"), txtCIF.Text);

                //if (!System.IO.Directory.Exists(origPath))
                //{                    
                //    _ErrorMessage = "Unable to find source folder '" + origPath + "'";
                //    return false;
                //}

                if (System.IO.Directory.Exists(destiPath))
                {
                    if (System.IO.Directory.Exists(origPath))
                    {
                        CopyDirectory2(origPath, backupPath);
                        System.IO.Directory.Delete(origPath, true);
                    }
                    //_ErrorMessage = "Destination folder already exist '" + sourcePath + "'";                    
                }

                if (IsPrimeFieldsHaveChanges())
                {
                    VoidTxn frm = new VoidTxn();
                    frm.ShowDialog();
                    if (!frm.IsApproved)
                    {
                        return false;
                    }
                    else
                    {
                        userID = frm.UserID();
                        voidReason = frm.VoidReason();
                        return true;
                    }
                }
                else return true;
            }
        }

        private void CopyDirectory2(string source, string destination)
        {
            if (!System.IO.Directory.Exists(destination)) System.IO.Directory.CreateDirectory(destination);

            foreach (string strFile in System.IO.Directory.GetFiles(source))
            {
                System.IO.File.Copy(strFile, string.Format(@"{0}\{1}", destination, System.IO.Path.GetFileName(strFile)));
            }
        }

        public bool InsertToDbase(ref string ErrorMsg, string stationName = "", string photoPath = "", string zipPath = "")
        {
            member member = new member();
            member.cif = txtCIF.Text;
            member.last_name = txtLName.Text;
            member.first_name = txtFName.Text;
            member.middle_name = txtMName.Text;
            member.suffix = txtSuffix.Text;
            member.gender = cboGender.Text;
            member.date_birth = mtbDateOfBirth.Value.Date;
            if (cboMaritalStatus.SelectedIndex > 0) member.civil_status_id = (int)cboMaritalStatus.SelectedValue;
            if (cboMembershipStatus.SelectedIndex > 0) member.membership_type_id = (int)cboMembershipStatus.SelectedValue;
            if (cboMembershipType.SelectedIndex > 0) member.membership_status_id = (int)cboMembershipType.SelectedValue;
            if (cboPrintingType.SelectedIndex > 0) member.print_type_id = (int)cboPrintingType.SelectedValue;
            if (cboReplaceReason.SelectedIndex > 0) member.recard_reason_id = (int)cboReplaceReason.SelectedValue;
            member.membership_date = mtbMembershipDate.Value.Date;
            member.contact_nos = txtContactNos.Text;
            member.mobile_nos = txtMobileNos.Text;
            member.emergency_contact_name = txtFullName_Contact.Text;
            member.emergency_contact_nos = txtContactNos_Contact.Text;
            if (cboMaritalStatus.SelectedIndex > 0) member.principal_associate_type_id = (int)cboAssociateType.SelectedValue;
            member.principal_cif = txtCIF_PrincipalMember.Text;
            member.principal_name = txtPrincipalName.Text;
            member.cca_no = txtCCANo.Text;
            member.user_id = msa.dcsUser.userId;
            member.terminal_id = stationName;
            member.branch_id = (int)cboBranchIssue.SelectedValue;
            member.online_reference_number = txtReferenceNumber.Text;
            member.card_name = txtCardName.Text;
            member.email = email;

            int memberId = 0;
            int addressId = 0;

            cancelCapture cancelCapture = new cancelCapture();

            var responseMember = msa.addMember(member, ref memberId);
            bool response = false;

            if (responseMember)
            {
                if (memberId != 0)
                {
                    cancelCapture.memberId = memberId;

                    address address = new address();
                    address.member_id = memberId;
                    address.address1 = txtAddress1.Text;
                    address.address2 = txtAddress2.Text;
                    address.address3 = txtAddress3.Text;
                    address.city = txtCity.Text;
                    address.province = txtProvince.Text;
                    address.country_id = (int)cboCountry.SelectedValue;
                    address.zipcode = txtZipCode.Text;

                    var responseAddress = msa.addAddress(address, ref addressId);

                    if (responseAddress)
                    {
                        if (addressId != 0)
                        {
                            cancelCapture.addressId = addressId;

                            memberImages memberImages = new memberImages();
                            memberImages.cif = txtCIF.Text;
                            memberImages.dateCaptured = DateTime.Now.ToString();
                            if (System.IO.File.Exists(photoPath))
                            {
                                byte[] photo = System.IO.File.ReadAllBytes(photoPath);
                                var base64Photo = System.Convert.ToBase64String(photo);
                                memberImages.base64Photo = base64Photo;
                            }

                            if (System.IO.File.Exists(zipPath))
                            {
                                byte[] zipFile = System.IO.File.ReadAllBytes(zipPath);
                                var base64ZipFile = System.Convert.ToBase64String(zipFile);
                                memberImages.base64ZipFile = base64ZipFile;
                            }

                            var responseMemberImages = msa.saveMemberImages(memberImages);

                            if (responseMemberImages) response = true;
                            else
                            {
                                var responseCancelCapture = msa.cancelCapture(cancelCapture);
                            }
                        }
                    }
                }
            }

            return response;
        }

        public void ShowManageDataCaptureFieldsForm()
        {
            ManageDataCaptureFields _frm = new ManageDataCaptureFields();
            _frm.ShowDialog();
            if (_frm.IsHaveChanges)
            {
                PopulateCustomControls();
            }
        }

        public static void InitMemberInfoTable()
        {
            DCS_MemberInfo.Data.InitMemberInfo();
            if (!System.IO.File.Exists(DataFields))
            {
                DCS_MemberInfo.Data.AddMemberInfoRow("PrintingType", "", "Printing Type:", "cboPrintingType", "ComboBox", true, true, true, true, true);
                DCS_MemberInfo.Data.AddMemberInfoRow("ReplaceReason", "", "Replace Reason:", "cboReplaceReason", "ComboBox", true, false, true, true, true);
                DCS_MemberInfo.Data.AddMemberInfoRow("CIF_ID", "", "CIF ID:", "txtCIF", "TextBox", true, true, true, true, true);
                DCS_MemberInfo.Data.AddMemberInfoRow("FirstName", "", "First Name:", "txtFName", "TextBox", true, true, true, true, true);
                DCS_MemberInfo.Data.AddMemberInfoRow("MiddleName", "", "Middle Name:", "txtMName", "TextBox", true, false, true, true, true);
                DCS_MemberInfo.Data.AddMemberInfoRow("LastName", "", "Last Name:", "txtLName", "TextBox", true, true, true, true, true);
                DCS_MemberInfo.Data.AddMemberInfoRow("Suffix", "", "Suffix:", "txtSuffix", "TextBox", true, false, false, true, true);
                DCS_MemberInfo.Data.AddMemberInfoRow("Gender", "", "Gender:", "cboGender", "ComboBox", true, true, false, true, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("DateOfBirth", "", "Date of Birth:", "mtbDateOfBirth", "DateTimePicker", true, true, false, true, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("MaritalStatus", "", "Marital Status:", "cboMaritalStatus", "ComboBox", true, false, false, false, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("MembershipDate", "", "Membership Date:", "mtbMembershipDate", "DateTimePicker", true, false, false, false, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("MembershipStatus", "", "Membership Status:", "cboMembershipStatus", "ComboBox", true, false, false, false, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("MembershipType", "", "Membership Type:", "cboMembershipType", "ComboBox", true, false, false, false, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("MobileNos", "", "Mobile Nos:", "txtMobileNos", "ComboBox", true, false, false, false, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("ContactNos", "", "Contact Nos:", "txtContactNos", "ComboBox", true, false, false, false, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("IDNumber", "", "ID Number:", "txtIDNumber", "TextBox", true, false, false, false, true);
                DCS_MemberInfo.Data.AddMemberInfoRow("BranchIssue", "", "Branch Issue:", "cboBranchIssue", "ComboBox", true, false, false, false, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("Address1", "", "Address1:", "txtAddress1", "TextBox", true, false, false, true, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("Address2", "", "Address2:", "txtAddress2", "TextBox", true, false, false, true, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("Address3", "", "Address3:", "txtAddress3", "TextBox", true, false, false, true, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("City", "", "City:", "txtCity", "TextBox", true, false, false, true, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("Province", "", "Province:", "txtProvince", "TextBox", true, false, false, true, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("Country", "", "Country:", "cboCountry", "ComboBox", true, false, false, true, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("ZipCode", "", "ZipCodeAddress:", "txtZipCode", "TextBox", true, false, false, true, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("FullName_Contact", "", "Contact Name:", "txtFullName_Contact", "TextBox", true, false, false, true, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("ContactNos_Contact", "", "Contact Nos.:", "txtContactNos_Contact", "TextBox", true, false, false, true, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("AssociateType", "", "Associate Type:", "cboAssociateType", "ComboBox", true, false, false, true, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("CIF_ID_PrincipalMember", "", "Principal Member CIF:", "txtCIF_PrincipalMember", "TextBox", true, false, false, true, true);
                DCS_MemberInfo.Data.AddMemberInfoRow("PrincipalName", "", "Principal Name:", "txtPrincipalName", "TextBox", true, false, false, true, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("IDs", "", "IDs:", "lblIDs", "Label", true, false, false, false, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("Supervisor", "", "Supervisor:", "lblSupervisor", "Label", true, false, false, false, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("VoidReason", "", "VoidReason:", "lblVoidReason", "Label", true, false, false, false, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("RefDataID", "", "RefDataID:", "lblRefDataID", "Label", true, false, false, false, false);
                //DCS_MemberInfo.Data.AddMemberInfoRow("IsRecapture", "", "Recapture:", "chkRecapture", "CheckBox", true, false, false, false, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("CCANo", "", "CCA Nos:", "txtCCANo", "TextBox", true, false, false, false, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("ForUpload", "", "For Upload:", "chkForUploading", "CheckBox", true, false, false, false, false);
                DCS_MemberInfo.Data.AddMemberInfoRow("ReferenceNumber", "", "Reference Number:", "txtReferenceNumber", "TextBox", true, false, true, true, true);
                DCS_MemberInfo.Data.AddMemberInfoRow("CardName", "", "Card Name:", "txtCardName", "TextBox", true, true, true, true, true);
                SaveMemberInfoFields();
            }
            else
            {
                string[] strLines = System.IO.File.ReadAllLines(DataFields);
                foreach (string strLine in strLines)
                {
                    string[] strFields = strLine.Split('|');
                    DCS_MemberInfo.Data.AddMemberInfoRow(strFields[0], strFields[1], strFields[2], strFields[3], strFields[4], Convert.ToBoolean(strFields[5]), Convert.ToBoolean(strFields[6]), Convert.ToBoolean(strFields[7]), Convert.ToBoolean(strFields[8]), Convert.ToBoolean(strFields[9]));
                }
            }
        }



        public static void SaveMemberInfoFields()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (DataRow rw in DCS_MemberInfo.Data.MemberInfo.Rows)
            {
                sb.AppendLine(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}", rw[0].ToString().Trim(), rw[1].ToString().Trim(), rw[2].ToString().Trim(), rw[3].ToString().Trim(), rw[4].ToString().Trim(), rw[5].ToString().Trim(), rw[6].ToString().Trim(), rw[7].ToString().Trim(), rw[8].ToString().Trim(), rw[9].ToString().Trim()));
            }

            System.IO.File.WriteAllText(DataFields, sb.ToString());
        }

        private void SaveStaticData()
        {
            _MemberID = txtCIF.Text;
            _CIF = txtCIF.Text;
            _FName = txtFName.Text;
            _MName = txtMName.Text;
            _LName = txtLName.Text;
            _Suffix = txtSuffix.Text;

            string middleName = _MName;
            string suffix = _Suffix;

            if (_MName != "")
                middleName = " " + middleName + " ";
            else
                middleName = " ";

            if (_Suffix != "")
                suffix = " " + suffix;

            if (_Suffix == "")
                _MemberName = string.Format("{0}{1}{2}", _FName, middleName, _LName);
            else
                _MemberName = string.Format("{0}{1}{2}{3}", _FName, middleName, _LName, suffix);

            _DOB = mtbDateOfBirth.Text;
            _DOI = DateTime.Today.ToString(DateFormat());
            _Gender = cboGender.Text;
            if (txtContactNos.Text != "") _ContactNos = txtContactNos.Text;
            else _ContactNos = txtMobileNos.Text;

            if (cboBranchIssue.Text.Trim().ToUpper() == "-SELECT-")
                _BranchIssue = "";
            else
                _BranchIssue = cboBranchIssue.Text;

            string address2 = txtAddress2.Text;
            string address3 = txtAddress3.Text;
            string city = txtCity.Text;
            string province = txtProvince.Text;
            string zipcode = txtZipCode.Text;

            if (address2 != "")
                address2 = " " + address2;
            else
                address2 = " ";

            if (address3 != "")
                address3 = " " + address3;
            else
                address3 = " ";

            if (city != "")
                city = " " + city;
            else
                city = " ";

            if (province != "")
                province = " " + province;
            else
                province = " ";

            if (zipcode != "")
                zipcode = " " + zipcode;
            else
                zipcode = " ";

            _CompleteAddress = String.Format("{0}{1}{2}{3}{4}{5}", txtAddress1.Text, address2, address3, city, province, zipcode);

            _Name_Contact = txtFullName_Contact.Text;
            _ContactNos_Contact = txtContactNos_Contact.Text;

            _CardName = txtCardName.Text;

            _MembershipType = cboMembershipType.Text;

            if (cboAssociateType.Text.Trim().ToUpper() == "-SELECT-")
                _AssociateType = "";
            else
                _AssociateType = cboAssociateType.Text;

            _MembershipDate = mtbMembershipDate.Text;
            _CIF_PrincipalMember = txtCIF_PrincipalMember.Text;

            _IDNumber = txtIDNumber.Text;

            lblIDs.Text = string.Format("{0},{1},{2},{3},{4},{5},{6}",
                                        cboPrintingType.SelectedIndex == 0 ? "0" : cboPrintingType.SelectedValue.ToString(),
                                        cboReplaceReason.SelectedIndex == 0 ? "0" : cboReplaceReason.SelectedValue.ToString(),
                                        cboMaritalStatus.SelectedIndex == 0 ? "0" : cboMaritalStatus.SelectedValue.ToString(),
                                        cboMembershipStatus.SelectedIndex == 0 ? "0" : cboMembershipStatus.SelectedValue.ToString(),
                                        cboMembershipType.SelectedIndex == 0 ? "0" : cboMembershipType.SelectedValue.ToString(),
                                        cboBranchIssue.SelectedIndex == 0 ? "0" : cboBranchIssue.SelectedValue.ToString(),
                                        cboAssociateType.SelectedIndex == 0 ? "0" : cboAssociateType.SelectedValue.ToString());

            DCS_MemberInfo.Data.MemberID = _MemberID;
        }

        private void SingleFile_SB_Appender(string file, string element, ref System.Text.StringBuilder sb)
        {
            if (file != "")
            {
                if (System.IO.File.Exists(file))
                    sb.Append("{" + element + "}" + Convert.ToBase64String(System.IO.File.ReadAllBytes(file)));
                else
                    sb.Append("{" + element + "}");
            }
            else
                sb.Append("{" + element + "}");
        }

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
            else if (dcs_system_setting == null)
            {
                _ErrorMessage = "Failed to get dcs settings";
                bln = false;
            }
            else
            {
                if (Convert.ToInt16(txtCIF.Text.Length) != dcs_system_setting.cif_length)
                {
                    _ErrorMessage = string.Format("Please enter {0} characters in CIF", dcs_system_setting.cif_length.ToString());
                    errorProvider1.SetError(txtCIF, _ErrorMessage);
                    bln = false;
                }
                else if (txtCIF_PrincipalMember.Text != "")
                {
                    if (Convert.ToInt16(txtCIF_PrincipalMember.Text.Length) != dcs_system_setting.cif_length)
                    {
                        _ErrorMessage = string.Format("Please enter {0} characters in Principal Member CIF", dcs_system_setting.cif_length.ToString());
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
                            if (GetAge() < dcs_system_setting.member_type_reg_allow_yrs)
                            {
                                _ErrorMessage = "Please enter valid date of birth for Regular";
                                errorProvider1.SetError(mtbDateOfBirth, _ErrorMessage);
                                bln = false;
                            }
                        }
                        else if (Convert.ToInt32(cboMembershipType.SelectedValue) == 2)
                        {
                            if (GetAge() < dcs_system_setting.member_type_assoc_allow_yrs)
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

                SaveStaticData();
            }

            return bln;
        }

        public bool ValidateLogIn(string userName, string userPass)
        {
            InitMiddleServerApi();
            var response = msa.ValidateLogIn(userName, userPass);
            //if (response) dcsUser = msa.dcsUser;

            return response;
        }

        public MiddleServerApi middleServerApi()
        {
            InitMiddleServerApi();
            return msa;
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

        public static System.Boolean IsNumeric(System.Object Expression)
        {
            if (Expression == null || Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is short || Expression is long || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;

            try
            {
                if (Expression is string)
                {
                    Double.Parse(Expression as string);
                    return true;
                }
                else
                {
                    Double.Parse(Expression.ToString());
                    return true;
                }
            }
            catch  // just dismiss errors but return false
            {
                return false;
            }
        }

        public bool CheckIfIDHaveDuplicate()
        {
            member member = new member();
            member.cif = txtCIF.Text;
            member.last_name = txtLName.Text;
            member.first_name = txtFName.Text;
            member.middle_name = txtMName.Text;
            member.suffix = txtSuffix.Text;
            member.print_type_id = (int)cboPrintingType.SelectedValue;

            return !msa.checkMemberIfCaptured(member);
        }

        public void CloseDataCapture()
        {

        }


        #endregion    

        private void InitMiddleServerApi()
        {
            if (dcsDataCaptureConfig == null)
            {
                if (System.IO.File.Exists(dcsDataCaptureConfigFile)) dcsDataCaptureConfig = Newtonsoft.Json.JsonConvert.DeserializeObject<Class.dcsDataCaptureConfig>(System.IO.File.ReadAllText(dcsDataCaptureConfigFile));
            }

            if (dcsDataCaptureConfig != null)
            {
                if (msa == null) msa = new MiddleServerApi(dcsDataCaptureConfig.middleServerUrl, dcsDataCaptureConfig.apiKey, dcsDataCaptureConfig.branchIssue, MiddleServerApi.afpslaiEmvSystem.dcs);
            }
        }

        private void DataCapture_Load(object sender, EventArgs e)
        {
            InitMiddleServerApi();

            InitMemberInfoTable();
            PopulateCustomControls();

            if (msa.checkServerDBStatus(dcsDataCaptureConfig.middleServerUrl))
            {
                //MiddleServerApi.ValidateLogIn("admin", "afPsL@ieMv2021");
                PopulateComboBox(MiddleServerApi.msApi.getAssociateType, ref cboAssociateType);
                PopulateComboBox(MiddleServerApi.msApi.getCivilStatus, ref cboMaritalStatus);
                PopulateComboBox(MiddleServerApi.msApi.getMembershipStatus, ref cboMembershipStatus);
                PopulateComboBox(MiddleServerApi.msApi.getMembershipType, ref cboMembershipType);
                PopulateComboBox(MiddleServerApi.msApi.getPrintType, ref cboPrintingType);
                PopulateComboBox(MiddleServerApi.msApi.getRecardReason, ref cboReplaceReason);
                PopulateComboBox(MiddleServerApi.msApi.getBranch, ref cboBranchIssue);
                PopulateComboBox(MiddleServerApi.msApi.getCountry, ref cboCountry);
                //PopulateCboCountry("tblCountry", "Country", "Country", ref cboCountry);
                cboBranchIssue.SelectedIndex = cboBranchIssue.FindStringExact(dcsDataCaptureConfig.branchIssue);
                txtBranchIssue.Text = dcsDataCaptureConfig.branchIssue;
                cboCountry.SelectedIndex = cboCountry.FindStringExact("Philippines");

                if (cboGender.Items.Count > 0) { cboGender.SelectedIndex = 0; }

                lblSupervisor.Text = "";
                lblVoidReason.Text = "";
                lblRefDataID.Text = "";

                cboPrintingType.Select();
                cboPrintingType.Focus();

                if (cboMembershipStatus.Items.Count > 3) cboMembershipStatus.SelectedIndex = 3;

                GetDCSSystemSettings();

                if (msa.dcsUser != null)
                {
                    if (msa.dcsUser.roleDesc == "DCS Admin")
                    {
                        linkLabel1.Visible = true;
                        lbManageTables.Visible = true;
                    }
                    else
                    {
                        linkLabel1.Visible = false;
                        lbManageTables.Visible = false;
                    }
                }

                txtCIF.MaxLength = dcs_system_setting.cif_length;
                txtCIF_PrincipalMember.MaxLength = dcs_system_setting.cif_length;
                txtCardName.MaxLength = dcs_system_setting.cardname_length;
                txtMobileNos.MaxLength = 11;
            }
            else
            {
                Utilities.ShowErrorMessage("Unable to connect to " + dcsDataCaptureConfig.middleServerUrl);
                //Environment.Exit(0);
            }
        }

        private void PopulateCombobox2(MiddleServerApi.msApi api)
        {
            switch (api)
            {
                case MiddleServerApi.msApi.getAssociateType:
                    PopulateComboBox(MiddleServerApi.msApi.getAssociateType, ref cboAssociateType);
                    break;
                case MiddleServerApi.msApi.getCivilStatus:
                    PopulateComboBox(MiddleServerApi.msApi.getCivilStatus, ref cboMaritalStatus);
                    break;
                case MiddleServerApi.msApi.getMembershipStatus:
                    PopulateComboBox(MiddleServerApi.msApi.getMembershipStatus, ref cboMembershipStatus);
                    break;
                case MiddleServerApi.msApi.getMembershipType:
                    PopulateComboBox(MiddleServerApi.msApi.getMembershipType, ref cboMembershipType);
                    break;
                case MiddleServerApi.msApi.getPrintType:
                    PopulateComboBox(MiddleServerApi.msApi.getPrintType, ref cboPrintingType);
                    break;
                case MiddleServerApi.msApi.getRecardReason:
                    PopulateComboBox(MiddleServerApi.msApi.getRecardReason, ref cboReplaceReason);
                    break;
                case MiddleServerApi.msApi.getBranch:
                    PopulateComboBox(MiddleServerApi.msApi.getBranch, ref cboBranchIssue);
                    break;
                default:
                    break;
            }
        }

        public static void PopulateComboBox(MiddleServerApi.msApi api, ref ComboBox cbo)
        {
            //MiddleServerApi msa = new MiddleServerApi(Properties.Settings.Default.MiddleServerUrl, Properties.Settings.Default.ApiKey, Properties.Settings.Default.BranchIssue);
            object obj = null;

            switch (api)
            {
                case MiddleServerApi.msApi.getPrintType:

                    if (msa.GetTable(api, ref obj))
                    {
                        var printTypes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<print_type>>(obj.ToString());
                        printTypes.Insert(0, new print_type { id = 0, printType = "-Select-" });
                        cbo.DataSource = printTypes;
                        cbo.DisplayMember = "printType";
                        cbo.ValueMember = "id";
                        cbo.SelectedIndex = 0;
                    }
                    break;
                case MiddleServerApi.msApi.getAssociateType:
                    if (msa.GetTable2(api, ref obj))
                    {
                        var associateTypes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<associate_type>>(obj.ToString());
                        associateTypes.Insert(0, new associate_type { id = 0, associateType = "-Select-" });
                        cbo.DataSource = associateTypes;
                        cbo.DisplayMember = "associateType";
                        cbo.ValueMember = "id";
                        cbo.SelectedIndex = 0;
                    }
                    break;
                case MiddleServerApi.msApi.getCivilStatus:
                    if (msa.GetTable(api, ref obj))
                    {
                        var civilStatuses = Newtonsoft.Json.JsonConvert.DeserializeObject<List<civil_status>>(obj.ToString());
                        civilStatuses.Insert(0, new civil_status { id = 0, civilStatus = "-Select-" });
                        cbo.DataSource = civilStatuses;
                        cbo.DisplayMember = "civilStatus";
                        cbo.ValueMember = "id";
                        cbo.SelectedIndex = 0;
                    }
                    break;
                case MiddleServerApi.msApi.getMembershipStatus:
                    if (msa.GetTable(api, ref obj))
                    {
                        var membershipStatuses = Newtonsoft.Json.JsonConvert.DeserializeObject<List<membership_status>>(obj.ToString());
                        membershipStatuses.Insert(0, new membership_status { id = 0, membershipStatus = "-Select-" });
                        cbo.DataSource = membershipStatuses;
                        cbo.DisplayMember = "membershipStatus";
                        cbo.ValueMember = "id";
                        cbo.SelectedIndex = 0;
                    }
                    break;
                case MiddleServerApi.msApi.getMembershipType:
                    if (msa.GetTable(api, ref obj))
                    {
                        var membershipTypes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<membership_type>>(obj.ToString());
                        membershipTypes.Insert(0, new membership_type { id = 0, membershipType = "-Select-" });
                        cbo.DataSource = membershipTypes;
                        cbo.DisplayMember = "membershipType";
                        cbo.ValueMember = "id";
                        cbo.SelectedIndex = 0;
                    }
                    break;
                case MiddleServerApi.msApi.getBranch:
                    if (msa.GetTable(api, ref obj))
                    {
                        var branches = Newtonsoft.Json.JsonConvert.DeserializeObject<List<branch>>(obj.ToString());
                        branches.Insert(0, new branch { id = 0, branchName = "-Select-" });
                        cbo.DataSource = branches;
                        cbo.DisplayMember = "branchName";
                        cbo.ValueMember = "id";
                        cbo.SelectedIndex = 0;
                    }
                    break;
                case MiddleServerApi.msApi.getCountry:
                    if (msa.GetTable(api, ref obj))
                    {
                        var countries = Newtonsoft.Json.JsonConvert.DeserializeObject<List<country>>(obj.ToString());
                        countries.Insert(0, new country { id = 0, countryName = "-Select-" });
                        cbo.DataSource = countries;
                        cbo.DisplayMember = "countryName";
                        cbo.ValueMember = "id";
                        cbo.SelectedIndex = 0;
                    }
                    break;
                default:
                    if (msa.GetTable(api, ref obj))
                    {
                        var replaceReasons = Newtonsoft.Json.JsonConvert.DeserializeObject<List<recard_reason>>(obj.ToString());
                        replaceReasons.Insert(0, new recard_reason { id = 0, recardReason = "-Select-" });
                        cbo.DataSource = replaceReasons;
                        cbo.DisplayMember = "recardReason";
                        cbo.ValueMember = "id";
                        cbo.SelectedIndex = 0;
                    }
                    break;
            }
        }

        private void GetDCSSystemSettings()
        {
            object obj = null;
            if (msa.GetTable(MiddleServerApi.msApi.getDCSSystemSetting, ref obj))
            {
                var response = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dcs_system_setting>>(obj.ToString());
                dcs_system_setting = response[0];
            }
        }

        private void GetOnlineRegistration()
        {
            object obj = null;
            if (msa.GetTable(MiddleServerApi.msApi.getOnlineRegistration, ref obj, "{ 'reference_number': '" + txtReferenceNumber.Text + "' }"))
            {
                if (obj.ToString().Length != 2)
                {
                    Utilities.ShowInformationMessage("Reference number is VALID");

                    var response = Newtonsoft.Json.JsonConvert.DeserializeObject<List<online_registration>>(obj.ToString());
                    var online_registration = response[0];
                    //txtReferenceNumber.Text = online_registration.reference_number;
                    txtCIF.Text = online_registration.cif;
                    //txtFName.Text = online_registration.first_name;
                    //txtMName.Text = online_registration.middle_name;
                    //txtLName.Text = online_registration.last_name;
                    //txtSuffix.Text = online_registration.suffix;
                    //txtMobileNos.Text = online_registration.mobile_nos;
                    //txtCCANo.Text = online_registration.cca_no;
                    //if (string.IsNullOrEmpty(online_registration.gender))
                    //    if (online_registration.gender.Substring(0, 1) == "M") cboGender.SelectedIndex = 1; else cboGender.SelectedIndex = 2;
                    //mtbDateOfBirth.Value = Convert.ToDateTime(online_registration.date_birth);
                    email = online_registration.email;
                }
                else
                {
                    Utilities.ShowWarningMessage("Reference number is INVALID");
                    ResetForm();
                }
            }
        }

        private void GetCBSData()
        {
            object obj = null;
            if (msa.GetTable(MiddleServerApi.msApi.pullCBSData, ref obj, "{ 'cif': '" + txtCIF.Text + "' }"))
            {
                var cbsData = Newtonsoft.Json.JsonConvert.DeserializeObject<cbsData>(obj.ToString());

                if (cbsData.cif != null)
                {
                    txtCIF.Text = cbsData.cif;
                    txtFName.Text = cbsData.first_name;
                    txtMName.Text = cbsData.middle_name;
                    txtLName.Text = cbsData.last_name;
                    txtSuffix.Text = cbsData.suffix;
                    mtbDateOfBirth.Value = Convert.ToDateTime(cbsData.date_birth);
                    mtbMembershipDate.Value = Convert.ToDateTime(cbsData.membership_date);
                    txtMobileNos.Text = cbsData.mobile_nos;
                    txtContactNos.Text = cbsData.contact_nos;
                    txtAddress1.Text = cbsData.address1;
                    txtAddress2.Text = cbsData.address2;
                    txtAddress3.Text = cbsData.address3;
                    txtCity.Text = cbsData.city;
                    txtProvince.Text = cbsData.province;
                    txtZipCode.Text = cbsData.zipCode;
                    txtFullName_Contact.Text = cbsData.emergency_contact_name;
                    txtContactNos_Contact.Text = cbsData.emergency_contact_nos;
                    txtPrincipalName.Text = cbsData.principal_name;
                    txtCIF_PrincipalMember.Text = cbsData.principal_cif;
                    txtCCANo.Text = cbsData.cca_no;

                    if (!string.IsNullOrEmpty(cbsData.gender)) if (cbsData.gender.Substring(0, 1) == "M") cboGender.SelectedIndex = 1; else cboGender.SelectedIndex = 2;
                    if (!string.IsNullOrEmpty(cbsData.civilStatus)) cboMaritalStatus.SelectedIndex = cboMaritalStatus.FindStringExact(cbsData.civilStatus);
                    if (!string.IsNullOrEmpty(cbsData.membershipStatus)) cboMembershipStatus.SelectedIndex = cboMembershipStatus.FindStringExact(cbsData.membershipStatus);
                    if (!string.IsNullOrEmpty(cbsData.membershipType)) cboMembershipType.SelectedIndex = cboMembershipType.FindStringExact(cbsData.membershipType);
                    if (!string.IsNullOrEmpty(cbsData.associateType)) cboAssociateType.SelectedIndex = cboAssociateType.FindStringExact(cbsData.associateType);
                    if (!string.IsNullOrEmpty(cbsData.country)) cboCountry.SelectedIndex = cboCountry.FindStringExact(cbsData.country);
                }
                else
                {
                    Utilities.ShowWarningMessage("CIF not found.");
                    ResetForm();
                }
            }
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

        private bool IsPrimeFieldsHaveChanges()
        {
            //string _date1 = string.Format("{0}/{1}/{2}", mtbDateOfBirth.Text.Split('/')[1], mtbDateOfBirth.Text.Split('/')[0], mtbDateOfBirth.Text.Split('/')[2]);
            //DataRow rw = dtOldTable.Rows[0];
            //if (txtCIF.Text.Trim().ToUpper() != rw["CIF"].ToString().Trim().ToUpper())
            //    return true;
            //else if (txtFName.Text.Trim().ToUpper() != rw["FName"].ToString().Trim().ToUpper())
            //    return true;
            //else if (txtMName.Text.Trim().ToUpper() != rw["MName"].ToString().Trim().ToUpper())
            //    return true;
            //else if (txtLName.Text.Trim().ToUpper() != rw["LName"].ToString().Trim().ToUpper())
            //    return true;
            //else if (txtSuffix.Text.Trim().ToUpper() != rw["Suffix"].ToString().Trim().ToUpper())
            //    return true;
            //else if (_date1 != Convert.ToDateTime(rw["DateOfBirth"].ToString()).ToString("MM/dd/yyyy"))
            //    return true;
            //else
            //    return false;

            //disable on this version
            return false;
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
            //            //txtDateIssued.Text = Convert.ToDateTime(rw["DatePosted"].ToString()).ToString("MMM dd, yyyy");
            //            //if (rw["PrintingType"] != null) cboPrintingType.SelectedIndex = cboPrintingType.FindString(rw["PrintingType"].ToString().Trim());
            //            //if (rw["ReplaceReason"] != null) cboReplaceReason.SelectedIndex = cboReplaceReason.FindString(rw["ReplaceReason"].ToString().Trim());
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
            //            cboBranchIssue.Text = rw["Branch"].ToString().Trim();
            //            txtAddress1.Text = rw["Address1"].ToString().Trim();
            //            txtAddress2.Text = rw["Address2"].ToString().Trim();
            //            txtAddress3.Text = rw["Address3"].ToString().Trim();
            //            txtCity.Text = rw["City"].ToString().Trim();
            //            txtProvince.Text = rw["Province"].ToString().Trim();
            //            if (rw["Country"] != null) cboCountry.SelectedIndex = cboCountry.FindString(rw["Country"].ToString().Trim());
            //            if(cboCountry.Text=="")cboCountry.SelectedIndex = cboCountry.FindStringExact("Philippines");
            //            txtZipCode.Text = rw["ZipCode"].ToString().Trim();
            //            txtFullName_Contact.Text = rw["FullName_Contact"].ToString().Trim();
            //            txtContactNos_Contact.Text = rw["ContactNos_Contact"].ToString().Trim();
            //            cboAssociateType.Text = rw["AssociateType"].ToString().Trim();
            //            txtCIF_PrincipalMember.Text = rw["CIF_PrincipalMember"].ToString().Trim();
            //            txtPrincipalName.Text = rw["PrincipalName"].ToString().Trim();
            //            lblRefDataID.Text = rw["RefDataID"].ToString().Trim();                        
            //            if (rw["CCANo"] != null) txtCCANo.Text = rw["CCANo"].ToString().Trim();
            //            if (rw["IsForUpload"] != null)
            //                if(rw["IsForUpload"].ToString()!="")
            //                    chkForUploading.Checked = (bool)rw["IsForUpload"];
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("No record found",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
            //    }
            //}            
            //DAL.Dispose();
            //DAL = null;
        }

        public void PopulateCustomControls()
        {
            //intTextBoxTopVariable = 32;
            //intLabelLastTop = 91;//27;
            //intTextBoxLastTop = 90;// 26;
            //intLastTabIndex = 46;

            //foreach (Control ctrl in gbOtherFields.Controls)
            //{
            //    if (ctrl.Name == "chkForReview") { }
            //    else if (ctrl.Name == "chkRecapture") { }
            //    else if (ctrl.Name == "lblForReview") { }
            //    else if (ctrl.Name == "lblRecapture") { }
            //    else
            //    {
            //        ctrl.Dispose();
            //        gbOtherFields.Controls.Remove(ctrl);
            //        break;
            //    }                    
            //}            

            //foreach (DataRow rw in DCS_MemberInfo.Data.MemberInfo.Select("IsBuiltInControl=0"))
            //{
            //    AddOtherFieldNewControls(rw["Field"].ToString().Trim(), rw["Label"].ToString().Trim(), rw["ControlType"].ToString().Trim(), rw["ControlName"].ToString().Trim());
            //}
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

        //private short intTextBoxTopVariable = 26;
        //private int intLabelLastTop = 91;//27;
        //private int intTextBoxLastTop = 90;//26;
        //private int intLastTabIndex = 46;

        private void btnNewField_Click(object sender, EventArgs e)
        {
            AddNewField _addnew = new AddNewField();
            _addnew.ShowDialog();
            if (_addnew.IsHaveChanges)
            {
                PopulateCustomControls();
            }
        }

        //private void AddOtherFieldNewControls(string FieldID, string FieldLabel, string ControlType, string ControlName)
        //{
        //   Label lbl = new Label();
        //    lbl.AutoSize = true;
        //    lbl.Font = new Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //    lbl.Location = new Point(8, intLabelLastTop);
        //    //lbl.Size = new Size(48, 14);
        //    lbl.Name = "lbl" + FieldID;
        //    lbl.Text = FieldLabel;
        //    lbl.ForeColor = Color.DimGray;
        //    gbOtherFields.Controls.Add(lbl);

        //    switch (ControlType)
        //    {
        //        case "TextBox":
        //            TextBox txtBox = new TextBox();
        //            //txtBox.Name = "txt" + FieldID;
        //            txtBox.Name = ControlName;
        //            txtBox.Location = new Point(108, intTextBoxLastTop);
        //            txtBox.Font = new Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //            txtBox.Size = new Size(199, 21);
        //            txtBox.TabIndex = intLastTabIndex;
        //            txtBox.ReadOnly = true;
        //            txtBox.BackColor = Color.White;
        //            gbOtherFields.Controls.Add(txtBox);
        //            break;
        //        case "MaskedTextBox":
        //            MaskedTextBox mtbTextBox = new MaskedTextBox();
        //            mtbTextBox.Mask = "00/00/0000";                                        
        //            mtbTextBox.Name = ControlName;
        //            mtbTextBox.Location = new Point(108, intTextBoxLastTop);
        //            mtbTextBox.Font = new Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //            mtbTextBox.Size = new Size(199, 21);
        //            mtbTextBox.TabIndex = intLastTabIndex;
        //            mtbTextBox.ReadOnly = true;
        //            mtbTextBox.BackColor = Color.White;
        //            gbOtherFields.Controls.Add(mtbTextBox);
        //            break;
        //        case "CheckBox":
        //            CheckBox chkBox = new CheckBox();                    
        //            chkBox.Name = ControlName;
        //            chkBox.Location = new Point(108, intTextBoxLastTop);
        //            chkBox.Font = new Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //            chkBox.Size = new Size(199, 21);
        //            chkBox.TabIndex = intLastTabIndex;
        //            gbOtherFields.Controls.Add(chkBox);
        //            break;
        //        case "RadioButton":
        //            RadioButton rb = new RadioButton();                    
        //            rb.Name = ControlName;
        //            rb.Location = new Point(108, intTextBoxLastTop);
        //            rb.Font = new Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //            rb.Size = new Size(199, 21);
        //            rb.TabIndex = intLastTabIndex;
        //            gbOtherFields.Controls.Add(rb);
        //            break;
        //    }


        //    intLabelLastTop += intTextBoxTopVariable;
        //    intTextBoxLastTop += intTextBoxTopVariable;
        //    intLastTabIndex += 1;
        //}

        //private void RemoveControl(Control ctrl)
        //{
        //    gbOtherFields.Controls.Remove(ctrl);
        //    ctrl.Dispose();
        //}

        private string ExcelConStr(string strExcelPath)
        {
            //return "Provider=Microsoft.Jet.OLEDB.4.0;Excel 8.0; Extended Properties=HDR=Yes; IMEX=1;Data Source=" + strExcelPath + "";
            return "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + strExcelPath + @"; Extended Properties=""Excel 12.0 Xml;HDR=YES""";
        }

        //private bool SelectExcelSource(string strExcelPath, string strExcelSheet)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection(ExcelConStr(strExcelPath));
        //        System.Data.OleDb.OleDbCommand cmd = default(System.Data.OleDb.OleDbCommand);
        //        cmd = new System.Data.OleDb.OleDbCommand("SELECT * FROM [" + strExcelSheet + "$]", con);
        //        cmd.CommandType = CommandType.Text;
        //        System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(cmd);
        //        da.Fill(ds, "Result");
        //        con.Open();
        //        dtSourceData = ds.Tables["Result"];
        //        con.Close();
        //        ds.Dispose();
        //        ds = null;

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + Environment.NewLine + "Failed to load excel file");
        //        return false;
        //    }
        //}

        //private void btnSourceExcel_Click(object sender, EventArgs e)
        //{            
        //    OpenFileDialog ofd = new OpenFileDialog();
        //    if(ofd.ShowDialog()==DialogResult.OK)
        //    {
        //        txtSourceData.Text = ofd.FileName;
        //        System.IO.File.WriteAllText(SourceData, string.Format("{0}|{1}", txtSourceData.Text, cboSheet.Text));
        //        BindExcelData();
        //    }
        //    ofd.Dispose();
        //    ofd = null;

        //}

        //private void BindExcelData()
        //{
        //    txtSourceData.BackColor = Color.White;

        //    if (SelectExcelSource(txtSourceData.Text, cboSheet.Text))
        //    {
        //        txtSourceData.BackColor = Color.LightGreen;

        //        if (dtSourceData.DefaultView.Count == 0)
        //        {
        //            MessageBox.Show("No record found");
        //            return;
        //        }
        //        else
        //        {
        //            linkLabel1.Visible= ValidateExcelSource();
        //            lblExcelRecords.Text = string.Format("{0} record/s", dtSourceData.DefaultView.Count.ToString());
        //        }
        //    }
        //    else
        //    {
        //        txtSourceData.BackColor = Color.OrangeRed;
        //        return;
        //    }
        //}

        //private bool ValidateExcelSource()
        //{
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    System.Text.StringBuilder sbNoID = new System.Text.StringBuilder();
        //    System.Text.StringBuilder sbDuplicate = new System.Text.StringBuilder();

        //    foreach (DataRow rw in dtSourceData.Select("ISNULL(ID,0)=0"))
        //        sbNoID.AppendLine(rw["FullName"].ToString().Trim());

        //    if (sbNoID.ToString() != "")
        //    {
        //        sb.AppendLine("");
        //        sb.AppendLine("** NO IDs **");
        //        sb.AppendLine(sbNoID.ToString());
        //    }

        //    var duplicates = dtSourceData.AsEnumerable().GroupBy(r => r["ID"]).Where(gr => gr.Count() > 1).ToList();
        //    if (duplicates.Any())
        //        foreach (var dup in duplicates.Select(dupl => dupl.Key))
        //            sbDuplicate.AppendLine(dup.ToString());

        //    if (sbDuplicate.ToString() != "")
        //    {
        //        sb.AppendLine("");
        //        sb.AppendLine("** Duplicate IDs **");
        //        sb.AppendLine(sbDuplicate.ToString());
        //    }

        //    ExcelFileExceptions = sb.ToString();
        //    if (sb.ToString() == "") return false; else return true;
        //}

        //private void txtIDNumber_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (Convert.ToInt32(e.KeyChar) == 13)
        //    {
        //        if(txtIDNumber.Text!="") BindData();
        //        lblDuplicate.Visible = CheckIfIDHaveDuplicate();
        //    }
        //}

        //private void BindData()
        //{
        //    try
        //    {
        //        int intFoundRecords = dtSourceData.Select("ID=" + txtIDNumber.Text).Length;
        //        if (intFoundRecords == 1)
        //        {
        //            DataRow rw = dtSourceData.Select("ID=" + txtIDNumber.Text)[0];
        //            txtFName.Text = rw["FullName"].ToString().Trim();
        //            txtAFPICNumber.Text = rw["NickName"].ToString().Trim();
        //            cboGender.Text = rw["Gender"].ToString().Trim();
        //            cboCivilStatus.Text = rw["CivilStatus"].ToString().Trim();
        //            if(rw["DateOfBirth"]!=null) if (!string.IsNullOrEmpty(rw["DateOfBirth"].ToString())) mtbDateOfBirth.Text = Convert.ToDateTime(rw["DateOfBirth"]).ToString("MM/dd/yyyy");
        //            txtBloodType.Text = rw["BloodType"].ToString().Trim();
        //            txtBReN.Text = rw["SSS#"].ToString().Trim();
        //            txtTINNo.Text = rw["TIN#"].ToString().Trim();
        //            txtCRN.Text = rw["PAGIBIG#"].ToString().Trim();
        //            txtPhilhealthNo.Text = rw["Philhealth#"].ToString().Trim();
        //            txtContactNos.Text = rw["Contact#"].ToString().Trim();
        //            txtEmailAddress.Text = rw["EmailAddress"].ToString().Trim();
        //            txtCompleteAddress.Text = rw["Address"].ToString().Trim();
        //            txtCompany.Text = rw["Company"].ToString().Trim();
        //            txtDepartment.Text = rw["Department"].ToString().Trim();
        //            txtDesignation.Text = rw["Designation"].ToString().Trim();
        //            if (rw["DateHired"] != null) if (!string.IsNullOrEmpty(rw["DateHired"].ToString())) mtbDateHired.Text = Convert.ToDateTime(rw["DateHired"]).ToString("MM/dd/yyyy");
        //            txtFullName_Contact.Text = rw["FullName_Contact"].ToString().Trim();
        //            cboRelationship_Contact.Text = rw["Relationship_Contact"].ToString().Trim();
        //            txtContactNos_Contact.Text = rw["ContactNos_Contact"].ToString().Trim();
        //            txtAddress_Contact.Text = rw["Address_Contact"].ToString().Trim();

        //            foreach (DataRow rwCustom in DCS_MemberInfo.Data.MemberInfo.Select("IsBuiltInControl=0"))
        //            {
        //                try
        //                {
        //                    string ControlName = rwCustom["ControlName"].ToString();
        //                    Control ctrl = FindControl(ControlName);
        //                    ctrl.Text = rw[rwCustom["Field"].ToString().Trim()].ToString().Trim();
        //                }
        //                catch { }
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show(string.Format("System found {0} record/s with same ID",intFoundRecords.ToString()), "DCS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            ResetForm();
        //        }                    
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void ResetForm()
        {
            cboAssociateType.SelectedIndex = 0;
            cboReplaceReason.SelectedIndex = 0;
            txtCIF.Clear();
            txtFName.Clear();
            txtMName.Clear();
            txtLName.Clear();
            txtSuffix.Clear();
            cboGender.SelectedIndex = 0;
            mtbDateOfBirth.Text = "";
            cboMaritalStatus.SelectedIndex = 0;
            mtbMembershipDate.Text = "";
            cboMembershipStatus.SelectedIndex = 0;
            cboMembershipType.SelectedIndex = 0;
            txtMobileNos.Clear();
            txtContactNos.Clear();
            txtIDNumber.Clear();
            cboBranchIssue.SelectedIndex = 0;
            txtAddress1.Clear();
            txtAddress2.Clear();
            txtAddress3.Clear();
            txtCity.Clear();
            txtProvince.Clear();
            cboCountry.SelectedIndex = 0;
            txtZipCode.Clear();
            txtFullName_Contact.Clear();
            txtContactNos_Contact.Clear();
            cboAssociateType.SelectedIndex = 0;
            txtCIF_PrincipalMember.Clear();
            txtPrincipalName.Clear();
            txtCCANo.Clear();

            email = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ManageDataCaptureFields frm = new ManageDataCaptureFields();
            //frm.ShowDialog();
            //CheckIfIDHaveDuplicate();
        }

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    ExcelExceptions frm = new ExcelExceptions(ExcelFileExceptions);
        //    frm.ShowDialog();
        //}

        private enum IDType : short
        {
            Officer = 1,
            EnlistedPersonnel,
            Cadet,
            CivilianEmployee,
            RetiredOfficer,
            RetiredEnlistedPersonnel,
            ReserveOfficer,
            ReserveEnlistedPersonnel,
            DirectDependent_Officer,
            DirectDependent_EnlistedPersonnel,
            DirectDependent_RetiredOfficer,
            DirectDependent_RetiredEnlistedPersonnel,
            DirectDependent_ReserveOfficer,
            DirectDependent_ReserveEnlistedPersonnel,
            LegalBeneficiary
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Setting frm = new Setting();
            frm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!IsLocalValidation()) MessageBox.Show("not ok");
        }

        private void cboPrintingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(cboPrintingType.SelectedValue.ToString()) == 2)
                {
                    cboReplaceReason.Enabled = true;
                    //chkRecapture.Visible = true;
                }
                else
                {
                    cboReplaceReason.Enabled = false;
                    cboReplaceReason.SelectedIndex = 0;
                    //chkRecapture.Visible = false;
                    //chkRecapture.Checked = false;
                }
            }
            catch { }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //IsLocalValidation();
            string err = "";
            InsertToDbase(ref err);
            //PrintImage pi = new PrintImage();
            //pi.GenerateDigitizedID_New(cboMembershipType.Text, cboAssociateType.Text, txtCIF.Text, txtFName.Text, txtMName.Text, txtLName.Text, txtSuffix.Text, mtbDateOfBirth.Text, cboGender.Text, mtbMembershipDate.Text, txtCIF_PrincipalMember.Text);            
        }

        private string DateFormat()
        {
            return "dd/MM/yyyy";
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

            //return string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
            //                     years, (years == 1) ? "" : "s",
            //                     months, (months == 1) ? "" : "s",
            //                     days, (days == 1) ? "" : "s");
            return years;
        }

        private void cboMembershipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Convert.ToInt32(cboMembershipType.SelectedValue) == 2)
            //    {
            //        cboAssociateType.Enabled = true;
            //        //txtCIF_PrincipalMember.Enabled = true;
            //        //txtPrincipalName.Enabled = true;
            //    }
            //    else
            //    {
            //        cboAssociateType.Enabled = false;
            //        cboAssociateType.SelectedIndex = 0;
            //        //txtCIF_PrincipalMember.Enabled = false;
            //        //txtPrincipalName.Enabled = false;
            //    }
            //}
            //catch { }
        }

        private void lbManageTables_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MaintenanceTable frm2 = new MaintenanceTable();
            frm2.ShowDialog();
        }

        private void lbManageRecords_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ManageRecord frm = new ManageRecord();
            frm.ShowDialog();
        }

        private void txtCIF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                if (Convert.ToInt16(cboPrintingType.SelectedValue.ToString()) > 1) if (txtCIF.Text != "") BindData();
            }
            else
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void cboAssociateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboAssociateType.SelectedValue) == 1)
                {
                    txtCIF_PrincipalMember.Enabled = true;
                    txtPrincipalName.Enabled = true;
                }
                else
                {
                    txtCIF_PrincipalMember.Enabled = false;
                    txtPrincipalName.Enabled = false;
                    txtCIF_PrincipalMember.Clear();
                    txtPrincipalName.Clear();
                }
            }
            catch { }
        }

        private void txtCIF_Leave(object sender, EventArgs e)
        {
            if (txtCIF.Text.Length != dcs_system_setting.cif_length)
            {
                lblMsg.Text = "Please enter valid CIF...";
                lblMsg.ForeColor = Color.OrangeRed;
            }
            else
            {
                lblMsg.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //DCS_MemberInfo.Data.ResetMemberInfo();
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is TextBox) ((TextBox)ctrl).Clear();
                else if (ctrl is ComboBox)
                {
                    if (((ComboBox)ctrl).Items.Count > 0) ((ComboBox)ctrl).SelectedIndex = 0;
                }
            }

            foreach (Control ctrl in groupBox2.Controls)
            {
                if (ctrl is TextBox) ((TextBox)ctrl).Clear();
                else if (ctrl is ComboBox) ((ComboBox)ctrl).SelectedIndex = 0;
            }

            foreach (Control ctrl in GroupBox3.Controls)
            {
                if (ctrl is TextBox) ((TextBox)ctrl).Clear();
                else if (ctrl is ComboBox) ((ComboBox)ctrl).SelectedIndex = 0;
            }

            foreach (Control ctrl in GroupBox4.Controls)
            {
                if (ctrl is TextBox) ((TextBox)ctrl).Clear();
                else if (ctrl is ComboBox) ((ComboBox)ctrl).SelectedIndex = 0;
            }

            mtbDateOfBirth.Value = DateTime.Now;
            mtbMembershipDate.Value = DateTime.Now;

            cboCountry.SelectedIndex = cboCountry.FindStringExact("Philippines");

            if (cboGender.Items.Count > 0) { cboGender.SelectedIndex = 0; }

            lblSupervisor.Text = "";
            lblVoidReason.Text = "";
            lblRefDataID.Text = "";

            cboPrintingType.Select();
            cboPrintingType.Focus();

            if (cboMembershipStatus.Items.Count > 3) cboMembershipStatus.SelectedIndex = 3;
        }

        private void txtMobileNos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txtContactNos_Contact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txtContactNos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txtZipCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || e.KeyChar == (char)'-');

            //string senderName = ((TextBox)sender).Name;

            //switch(senderName)
            //{
            //    case "txtFName":
            //    case "txtMName":
            //    case "txtLName":
            //    case "txtSuffix":
            //        string cardName = string.Format("{0} {1} {2} {3}", txtFName.Text, txtMName.Text, txtLName.Text, txtSuffix.Text);
            //        System.Text.RegularExpressions.RegexOptions options = System.Text.RegularExpressions.RegexOptions.None;
            //        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[ ]{2,}", options);
            //        cardName = regex.Replace(cardName, " ");
            //        txtCardName.Text = cardName;
            //        break;
            //}
        }

        private void BuildCardName()
        {
            string cardName = string.Format("{0} {1} {2} {3}", txtFName.Text, txtMName.Text, txtLName.Text, txtSuffix.Text);
            System.Text.RegularExpressions.RegexOptions options = System.Text.RegularExpressions.RegexOptions.None;
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[ ]{2,}", options);
            cardName = regex.Replace(cardName, " ");
            if (cardName.Length <= dcs_system_setting.cardname_length) txtCardName.Text = cardName.Trim();
            else txtCardName.Text = cardName.Substring(0, dcs_system_setting.cardname_length);
        }

        private void txtCIF_PrincipalMember_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txtCCANo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MiddleServerApi.ValidateLogIn(txtAddress1.Text, txtAddress2.Text, ref dcsUser);
            PopulateComboBox(MiddleServerApi.msApi.getAssociateType, ref cboAssociateType);
            PopulateComboBox(MiddleServerApi.msApi.getCivilStatus, ref cboMaritalStatus);
            PopulateComboBox(MiddleServerApi.msApi.getMembershipStatus, ref cboMembershipStatus);
            PopulateComboBox(MiddleServerApi.msApi.getMembershipType, ref cboMembershipType);
            PopulateComboBox(MiddleServerApi.msApi.getPrintType, ref cboPrintingType);
            PopulateComboBox(MiddleServerApi.msApi.getRecardReason, ref cboReplaceReason);
            PopulateComboBox(MiddleServerApi.msApi.getBranch, ref cboBranchIssue);
            PopulateComboBox(MiddleServerApi.msApi.getCountry, ref cboCountry);
        }

        private void lbSearchCIF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtCIF.Text == "")
            {
                Utilities.ShowWarningMessage("Please enter CIF to search.");
                txtCIF.Focus();
                return;
            }

            GetCBSData();
        }

        private void lbSearchRF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtReferenceNumber.Text == "")
            {
                Utilities.ShowWarningMessage("Please enter reference number to search.");
                txtReferenceNumber.Focus();
                return;
            }

            GetOnlineRegistration();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
