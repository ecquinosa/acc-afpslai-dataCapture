using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCS_DataCapture
{
    public partial class Preview : UserControl
    {
        public Preview()
        {
            InitializeComponent();
        }

        private void Preview_Load(object sender, EventArgs e)
        {
            string[] IDs = DCS_MemberInfo.Data.MemberInfo.Select("Field='IDs'")[0][1].ToString().Split(',');

            //if regular
            if (IDs[4] == "1") lblRegular.Visible = true;

            //if associate
            if (IDs[4] == "2") lblAssociate.Visible = true;

            //if dependent
            if (IDs[6] == "1") lblDependent.Visible = true;

            //if pvao
            if (IDs[6] == "2") lblPVAO.Visible = true;

            //if cadet
            if (IDs[6] == "3") lblCadet.Visible = true;

            //if male
            if (DCS_MemberInfo.Data.MemberInfo.Select("Field='Gender'")[0][1].ToString().Trim().ToUpper().Substring(0, 1) == "M")
                lblMale.Visible = true;
            else //if female
                lblFemale.Visible = true;

            lblDate.Text = DateTime.Now.ToString("MMMM dd");
            lblYear.Text = DateTime.Now.ToString("yyyy");

            lblCIF.Text = DataCapture.CIF;
            lblLastName.Text = DataCapture.LName.ToUpper();
            lblFirstName.Text = DataCapture.FName.ToUpper();
            lblSuffix.Text = DCS_MemberInfo.Data.MemberInfo.Select("Field='Suffix'")[0]["Value"].ToString().ToUpper();
            lblMiddleName.Text = DataCapture.MName.ToUpper();

            lblMembershipDate.Text = DCS_MemberInfo.Data.MemberInfo.Select("Field='MembershipDate'")[0]["Value"].ToString().ToString().Replace("/", "-");
            lblDOB.Text = DCS_MemberInfo.Data.MemberInfo.Select("Field='DateOfBirth'")[0]["Value"].ToString().Replace("/","-");
            lblPrincipalCIF.Text = DCS_MemberInfo.Data.MemberInfo.Select("Field='CIF_ID_PrincipalMember'")[0]["Value"].ToString().Replace("/", "-");

            lblCCANo.Text = DCS_MemberInfo.Data.MemberInfo.Select("Field='CCANo'")[0]["Value"].ToString().ToUpper();
            txtOperator.Text = DCS_MemberInfo.Data.OperatorID.ToUpper();

            lblLeftCode.Text = DCS_MemberInfo.Data.LeftThumbCode;
            lblRightCode.Text = DCS_MemberInfo.Data.RightThumbCode;            

            if (System.IO.File.Exists(DCS_MemberInfo.Data.PhotoICAOFile))
                picPhoto.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.PhotoICAOFile)));

            if (System.IO.File.Exists(DCS_MemberInfo.Data.SignatureFile))
            {
                picBio1_1.Visible = false;
                picSign1.BringToFront();
                picSign1.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile)));
                picSign1.Visible = true;
            }
            else
            {
                if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))
                {
                    picBio1_1.Visible = true;
                    picBio1_1.BringToFront();
                    picBio1_1.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG)));
                    picSign1.Visible = false;
                }
            }

            if (System.IO.File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff")))
            {                
                picSign2.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff"))));
            }

            if (System.IO.File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff")))
            {
                picSign3.Visible = true;
                picSign3.BringToFront();
                picBio2_2.Visible = false;
                picSign3.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff"))));                
            }
            else
            {
                if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightThumbFileJPG))
                {
                    picSign3.Visible = false;
                    picBio2_2.Visible = true;
                    picBio2_2.BringToFront();
                    picBio2_2.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightThumbFileJPG)));
                }
            }

            if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))
                picBio1.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG)));

            if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightThumbFileJPG))
                picBio2.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightThumbFileJPG)));

            lblCardName.Text = DataCapture.CardName.ToUpper();
        }

        private string FormatDataWithCharLength(string value, short intCharLength)
        {
            string space = " ";

            System.Text.StringBuilder sbOld = new System.Text.StringBuilder();
            sbOld.Append(value);

            System.Text.StringBuilder sbNew = new System.Text.StringBuilder();

            while (!string.IsNullOrEmpty(sbOld.ToString()))
            {
                short intSpaceLastIndex = 0;
                if (sbOld.ToString().Length > intCharLength)
                {
                    if (sbOld.ToString().Substring(intCharLength - 1, 1) == space)
                    {
                        sbNew.AppendLine((sbOld.ToString().Substring(0, intCharLength)).Trim());
                        sbOld.Remove(0, intCharLength);
                    }
                    else if (sbOld.ToString().Substring(intCharLength - 1, 1) != space & sbOld.ToString().Substring(intCharLength, 1) != space)
                    {
                        intSpaceLastIndex = (short)sbOld.ToString().Substring(0, intCharLength).LastIndexOf(space);
                        sbNew.AppendLine((sbOld.ToString().Substring(0, intSpaceLastIndex)).Trim());
                        sbOld.Remove(0, intSpaceLastIndex);
                    }
                    else
                    {
                        sbNew.AppendLine((sbOld.ToString().Substring(0, intCharLength)).Trim());
                        sbOld.Remove(0, intCharLength);
                    }
                }
                else
                {
                    sbNew.Append((sbOld.ToString().Substring(0)).Trim());
                    sbOld.Clear();
                }
            }

            return sbNew.ToString();
        }

        private void picPreview_Paint(object sender, PaintEventArgs e)
        {
            //int intFrontLeft = 220;
            //int intBackLeft1 = 627;
            //int intBackLeft2 = 782;

            //if (System.IO.File.Exists(DCS_MemberInfo.Data.SignatureFile))
            //{
            //    Bitmap myBitmap = new Bitmap(DCS_MemberInfo.Data.SignatureFile);
            //    myBitmap.MakeTransparent();                
            //    e.Graphics.DrawImage(myBitmap, intFrontLeft, 180, 234, 47);
            //}
            
            //e.Graphics.DrawString(DataCapture.MemberName, new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), intFrontLeft, 218);
            //e.Graphics.DrawString(DataCapture.CIF, new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Black), intFrontLeft, 240);

            //e.Graphics.DrawString(FormatDataWithCharLength(DataCapture.CompleteAddress, 30), new Font("Arial", 7, FontStyle.Regular), new SolidBrush(Color.Black), intBackLeft1, 164);
            //e.Graphics.DrawString(DataCapture.ContactNos, new Font("Arial", 8, FontStyle.Regular), new SolidBrush(Color.Black), intBackLeft1, 205);
            //e.Graphics.DrawString(DataCapture.Name_Contact, new Font("Arial", 8, FontStyle.Regular), new SolidBrush(Color.Black), intBackLeft1, 238);
            //e.Graphics.DrawString(DataCapture.ContactNos_Contact, new Font("Arial", 8, FontStyle.Regular), new SolidBrush(Color.Black), intBackLeft1, 250);

            //e.Graphics.DrawString(Convert.ToDateTime(DataCapture.DOI).ToString("MMMM d, yyyy"), new Font("Arial", 8, FontStyle.Regular), new SolidBrush(Color.Black), intBackLeft2, 167);
            //e.Graphics.DrawString(DataCapture.IDNumber, new Font("Arial", 8, FontStyle.Regular), new SolidBrush(Color.Black), intBackLeft2, 205);
            //e.Graphics.DrawString(DataCapture.Branch, new Font("Arial", 8, FontStyle.Regular), new SolidBrush(Color.Black), intBackLeft2, 244);         
        }      

        private void button1_Click(object sender, EventArgs e)
        {
            picPreview.Refresh();
        }
    }
}
