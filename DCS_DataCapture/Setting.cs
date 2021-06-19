
using System;
using System.Windows.Forms;

namespace DCS_DataCapture
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            DataCapture.PopulateComboBox(MiddleServerApi.msApi.getBranch, ref cboBranchIssue);
            BindSetting();
        }

        private void BindSetting()
        {
            if (DataCapture.dcs_system_setting != null)
            {
                txtCIF.Text = DataCapture.dcs_system_setting.cif_length.ToString();
                txtMemTypeAssocAllwdYrs.Text = DataCapture.dcs_system_setting.member_type_assoc_allow_yrs.ToString();
                txtMemTypeRegularAllwdYrs.Text = DataCapture.dcs_system_setting.member_type_reg_allow_yrs.ToString();
                txtCardName_Length.Text = DataCapture.dcs_system_setting.cardname_length.ToString();
            }
            txtServer.Text = Properties.Settings.Default.MiddleServerUrl;
            cboBranchIssue.SelectedIndex = cboBranchIssue.FindStringExact(Properties.Settings.Default.BranchIssue);
        }

        private void SaveSetting()
        {           
            Class.dcs_system_setting dss = new Class.dcs_system_setting();
            dss.cif_length = Convert.ToInt16(txtCIF.Text);
            dss.member_type_assoc_allow_yrs = Convert.ToInt16(txtMemTypeAssocAllwdYrs.Text);
            dss.member_type_reg_allow_yrs = Convert.ToInt16(txtMemTypeRegularAllwdYrs.Text);
            dss.cardname_length = Convert.ToInt16(txtCardName_Length.Text);
            var response = MiddleServerApi.addDCSSystemSettings(dss);
            if (!response) Class.Utilities.ShowWarningMessage("Failed to save CIF, Member Type Associate, Member Type Regular and Cardname data.");
            else DCS_DataCapture.DataCapture.dcs_system_setting = dss;

            string url = txtServer.Text;
            if (url.Substring(url.Length - 1, 1) == "/") url = url.Substring(0, url.Length-2);
            Properties.Settings.Default.BranchIssue = cboBranchIssue.Text;
            Properties.Settings.Default.MiddleServerUrl = url;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(txtCIF.Text) == 0)
            {
                MessageBox.Show("Please enter valid number", "Data Capture System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCIF.SelectAll();
                txtCIF.Focus();
                return;
            }

            if (Convert.ToInt16(txtMemTypeAssocAllwdYrs.Text) == 0)
            {
                MessageBox.Show("Please enter valid number", "Data Capture System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemTypeAssocAllwdYrs.SelectAll();
                txtMemTypeAssocAllwdYrs.Focus();
                return;
            }

            if (Convert.ToInt16(txtMemTypeRegularAllwdYrs.Text) == 0)
            {
                MessageBox.Show("Please enter valid number", "Data Capture System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemTypeRegularAllwdYrs.SelectAll();
                txtMemTypeRegularAllwdYrs.Focus();
                return;
            }

            if (Convert.ToInt16(txtCardName_Length.Text) == 0)
            {
                MessageBox.Show("Please enter valid number", "Data Capture System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCardName_Length.SelectAll();
                txtCardName_Length.Focus();
                return;
            }

            SaveSetting();

            MessageBox.Show("Changes has been saved. Please restart application.", "Data Capture System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (MiddleServerApi.checkServerDBStatus()) Class.Utilities.ShowInformationMessage("Connection success."); else Class.Utilities.ShowWarningMessage("Connection failed.");
        }      

        private void txtCIF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txtMemTypeAssocAllwdYrs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txtMemTypeRegularAllwdYrs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
    }
}
