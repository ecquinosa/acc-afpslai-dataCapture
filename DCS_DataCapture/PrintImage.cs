
using System.Drawing;
using System.IO;

namespace DCS_DataCapture
{
    class PrintImage
    {

        private System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
        internal System.Drawing.Printing.PreviewPrintController ppc = new System.Drawing.Printing.PreviewPrintController();

        private string MembershipType="";
        private string AssociateType = "";
        private string CIF = "";
        private string FirstName = "";
        private string MiddleName = "";
        private string LastName = "";
        private string Suffix = "";
        private string DateOfBirth = "";
        private string Gender = "";
        private string MembershipDate = "";
        private string CIF_PrincipalMember = "";

        public PrintImage()
        {
            //printDoc.PrintController = ppc;
            //printDoc.PrinterSettings.PrintToFile = true;

            //printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            //printDoc.EndPrint += new System.Drawing.Printing.PrintEventHandler(printDocument1_EndPrint);
        }

        public void GenerateDigitizedID_New(string MembershipType, string AssociateType, string CIF, string FirstName, string MiddleName,
                                             string LastName, string Suffix, string DateOfBirth, string Gender, string MembershipDate,
                                             string CIF_PrincipalMember)
        {
            printDoc.PrintController = ppc;
            printDoc.PrinterSettings.PrintToFile = true;           

            if (MembershipType.Trim().ToUpper()!="-SELECT-")this.MembershipType = MembershipType;
            if (AssociateType.Trim().ToUpper() != "-SELECT-") this.AssociateType = AssociateType ;
            this.CIF = CIF;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.Suffix = Suffix;
            if (DateOfBirth.Replace("/","").Trim() != "") this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            if (MembershipDate.Replace("/", "").Trim() != "") this.MembershipDate = MembershipDate;
            this.CIF_PrincipalMember = CIF_PrincipalMember;

            printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDoc_PrintPage);
            printDoc.EndPrint += new System.Drawing.Printing.PrintEventHandler(printDoc_EndPrint);

            printDoc.Print();
        }

        private void printDoc_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Pixel;

            SolidBrush dBlack = new SolidBrush(Color.Black);

            Font fontHightlight = new Font("Arial", (float)10.5, FontStyle.Bold);
            Font fontGeneric = new Font("Arial", (float)7.5);

            //TEMPLATE
            //if (File.Exists(@"Images\digitID_New.jpg"))
            //    e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(@"Images\digitID_New.jpg"))),
            //                     40, 0, 5050, 3700);

            //PHOTO
            if (File.Exists(DCS_MemberInfo.Data.PhotoICAOFile))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.PhotoICAOFile))),
                                 4200, 430, 700, 750);

            e.Graphics.DrawString(MembershipType, fontHightlight, dBlack, 800, 950);
            e.Graphics.DrawString(AssociateType, fontHightlight, dBlack, 800, 1110);
            e.Graphics.DrawString(CIF, fontHightlight, dBlack, 90, 1370);
            e.Graphics.DrawString(LastName, fontHightlight, dBlack, 990, 1370);
            e.Graphics.DrawString(FirstName, fontHightlight, dBlack, 1740, 1370);
            e.Graphics.DrawString(Suffix, fontHightlight, dBlack, 2430, 1370);
            e.Graphics.DrawString(MiddleName, fontHightlight, dBlack, 3290, 1370);
            e.Graphics.DrawString(DateOfBirth, fontHightlight, dBlack, 90, 1660);
            e.Graphics.DrawString(Gender, fontHightlight, dBlack, 1020, 1660);
            e.Graphics.DrawString(MembershipDate, fontHightlight, dBlack, 1900, 1660);
            e.Graphics.DrawString(CIF_PrincipalMember, fontHightlight, dBlack, 2880, 1660);

            //SIGNATURES
            //#1
            if(File.Exists(DCS_MemberInfo.Data.SignatureFile))
            e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile))),
                                 300, 1980, 1150, 300);
            //#2
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff")))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff")))),
                                 300, 2360, 1150, 300);
            //#3
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff")))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff")))),
                                 2180, 1980, 1150, 300);

            //#4
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "4.tiff")))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "4.tiff")))),
                                 2180, 2360, 1150, 300);


            //BIO
            //#left thumb
            if (File.Exists(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))),
                                 260, 3000, 500, 530);
            //#right thumb
            if (File.Exists(DCS_MemberInfo.Data.BiometricRightThumbFileJPG))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightThumbFileJPG))),
                                 1160, 3000, 500, 530);
            //#left index
            if (File.Exists(DCS_MemberInfo.Data.BiometricLeftPrimaryFileJPG))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftPrimaryFileJPG))),
                                 2100, 3000, 500, 530);

            //#right index
            if (File.Exists(DCS_MemberInfo.Data.BiometricRightPrimaryFileJPG))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightPrimaryFileJPG))),
                                 3150, 3000, 500, 530);

            printDoc.PrintController = ppc;
        }

        private void printDoc_EndPrint(System.Object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //string filePath = DCS_MemberInfo.Data.SignatureFile.Substring(0,DCS_MemberInfo.Data.SignatureFile.LastIndexOf("\\")-1);
            string file = @"E:\Projects\DCS2015\DCS2015\bin\Debug\Captured Data\04252017\5555555555555\5555555555555_Signature.tiff";
            string filePath = file.Substring(0, file.LastIndexOf("\\") - 1);
            System.Drawing.Printing.PreviewPageInfo[] ppi = ppc.GetPreviewPageInfo();
            for (int x = 0; x <= ppi.Length - 1; x++)
            {
                ppi[x].Image.Save(string.Format(@"{0}\{1}_New.jpg", filePath, CIF));
            }
        }


    }
}
