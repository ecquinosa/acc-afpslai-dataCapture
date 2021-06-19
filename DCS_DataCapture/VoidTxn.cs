
using System;
using System.Windows.Forms;

namespace DCS_DataCapture
{
    public partial class VoidTxn : Form
    {
        public VoidTxn()
        {
            InitializeComponent();
        }

        public bool IsApproved = false;
        private string _UserID = "";
        private string _voidReason = "";

        public string UserID()
        {
            return _UserID;
        }
        
        public string VoidReason()
        {
            return _voidReason;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtReason.Text == "") return;

            _UserID = txtUsername.Text;
            _voidReason = txtReason.Text;
            
            IsApproved = true;
            Close();
        }

        private void VoidTxn_Load(object sender, EventArgs e)
        {
            txtUsername.SelectAll();
            txtUsername.Focus();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                if (txtUsername.Text != "")
                {
                    if (txtPassword.Text != "")
                    {
                        bool bln = ValidateLogIN_Offline();
                        if (bln)
                        {
                            txtReason.ReadOnly = !bln;
                            btnSubmit.Visible = bln;
                            btnSubmit.Enabled = bln;
                            txtReason.SelectAll();
                            txtReason.Focus();
                        }
                        else
                        {
                            txtPassword.SelectAll();
                            txtPassword.Focus();
                            MessageBox.Show("Please enter valid approver credential", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        txtPassword.SelectAll();
                        txtPassword.Focus();
                        MessageBox.Show("Please enter valid approver credential", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    txtUsername.SelectAll();
                    txtUsername.Focus();
                    MessageBox.Show("Please enter valid approver credential", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateLogIN_Offline()
        {
            //try
            //{
            //    OfflineLogInAuth ola = new OfflineLogInAuth();

            //    if (ola.ErrorMessage != "")
            //    {                    
            //        MessageBox.Show(ola.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txtUsername.Focus();
            //        return false;
            //    }
            //    else
            //    {
            //        if (ola.UserAndRoleTable.Select(string.Format("Username='{0}' AND Password='{1}' AND Role='DCS_Approver'", txtUsername.Text, txtPassword.Text)).Length > 0)
            //        {                        
            //            return true;
            //        }
            //        else
            //        {                       
            //            return false;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}

            return true;
        }
    }
}
