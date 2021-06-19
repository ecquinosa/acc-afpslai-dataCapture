
using System;
using System.Text;
using System.Xml;
using System.Data;

namespace DCS_DataCapture
{
    class XMLMemberData
    {

        private string _ErrorMessage;

        public string ErrorMessage
        {
            get { return _ErrorMessage; }
        }

        public bool Create(DataTable dt, string OutputFile)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(OutputFile, System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.WriteStartElement("MemberData");

                foreach (DataRow rw in dt.Rows)
                {
                    createNode(writer, rw[0].ToString(), rw[1].ToString());
                }

                createNode(writer, "LeftPrimaryFingerCode", DCS_MemberInfo.Data.LeftPrimaryCode);
                createNode(writer, "LeftThumbFingerCode", DCS_MemberInfo.Data.LeftThumbCode);
                createNode(writer, "RightPrimaryFingerCode", DCS_MemberInfo.Data.RightPrimaryCode);
                createNode(writer, "RightThumbFingerCode", DCS_MemberInfo.Data.RightThumbCode);

                createNode(writer, "PhotoOverride", DCS_MemberInfo.Data.PhotoOverride.ToString());
                createNode(writer, "SignatureOverride", DCS_MemberInfo.Data.SignatureOverride.ToString());
                createNode(writer, "PhotoICAO", DCS_MemberInfo.Data.IsICAO.ToString());
                createNode(writer, "PhotoScore", DCS_MemberInfo.Data.PhotoScore.ToString());

                //add reference session from captured terminal
                createNode(writer, "SessionReference", DCS_MemberInfo.Data.SessionReference);
                //createNode(writer, "Timestamp", DateTime.Now.ToString());
                //createNode(writer, "OperatorID", Properties.Settings.Default.Operator);
                //createNode(writer, "TerminalName", Properties.Settings.Default.StationReference);

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                return true;
            }
            catch (Exception ex)
            {
                CreateBakFile(dt, OutputFile);
                _ErrorMessage = string.Format("Creation of xml failed. Error {0}", ex.Message);
                //Utilities.SaveToErrorLog(Utilities.TimeStamp() + _ErrorMessage);
                return false;
            }
        }

        public bool Create2(DataTable dt, string OutputFile, string xmlFile)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(OutputFile, System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.WriteStartElement("MemberData");

                foreach (DataRow rw in dt.Rows)
                {
                    createNode(writer, rw[0].ToString(), rw[1].ToString());
                }

                createNode(writer, "LeftPrimaryFingerCode", GetXMLValue(xmlFile, "LeftPrimaryFingerCode"));
                createNode(writer, "LeftThumbFingerCode", GetXMLValue(xmlFile, "LeftThumbFingerCode"));
                createNode(writer, "RightPrimaryFingerCode", GetXMLValue(xmlFile, "RightPrimaryFingerCode"));
                createNode(writer, "RightThumbFingerCode", GetXMLValue(xmlFile, "RightThumbFingerCode"));

                createNode(writer, "PhotoOverride", GetXMLValue(xmlFile, "PhotoOverride"));
                createNode(writer, "SignatureOverride", GetXMLValue(xmlFile, "SignatureOverride"));
                createNode(writer, "PhotoICAO", GetXMLValue(xmlFile, "PhotoICAO"));
                createNode(writer, "PhotoScore", GetXMLValue(xmlFile, "PhotoScore"));

                //add reference session from captured terminal
                createNode(writer, "SessionReference", GetXMLValue(xmlFile, "SessionReference"));
                createNode(writer, "Timestamp", DateTime.Now.ToString());
                createNode(writer, "OperatorID", DCS_MemberInfo.Data.OperatorID);
                createNode(writer, "TerminalName", DCS_MemberInfo.Data.TerminalName);

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                return true;
            }
            catch (Exception ex)
            {
                CreateBakFile(dt, OutputFile);
                _ErrorMessage = string.Format("Creation of xml failed. Error {0}", ex.Message);
                //Utilities.SaveToErrorLog(Utilities.TimeStamp() + _ErrorMessage);
                return false;
            }
        }

        private string GetXMLValue(string xmlFile, string xmlElement)
        {
            string[] strLines = System.IO.File.ReadAllLines(xmlFile);
            foreach (string strLine in strLines)
            {
                if (strLine.Trim().Contains("<" + xmlElement + ">"))
                {
                    return strLine.Trim().Replace("<LeftPrimaryFingerCode>", "").Replace("</LeftPrimaryFingerCode>", "")
                                             .Replace("<LeftThumbFingerCode>", "").Replace("</LeftThumbFingerCode>", "")
                                             .Replace("<RightPrimaryFingerCode>", "").Replace("</RightPrimaryFingerCode>", "")
                                             .Replace("<RightThumbFingerCode>", "").Replace("</RightThumbFingerCode>", "")
                                             .Replace("<PhotoOverride>", "").Replace("</PhotoOverride>", "")
                                             .Replace("<SignatureOverride>", "").Replace("</SignatureOverride>", "")
                                             .Replace("<PhotoICAO>", "").Replace("</PhotoICAO>", "")
                                             .Replace("<PhotoScore>", "").Replace("</PhotoScore>", "")
                                             .Replace("<SessionReference>", "").Replace("</SessionReference>", "");
                }
            }

            return "";
        }

        public void CreateBakFile(DataTable dt, string OutputFile)
        {
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(OutputFile);
                
                foreach (DataRow rw in dt.Rows)
                {                 
                    sw.WriteLine(rw[0].ToString(), rw[1].ToString());
                }

                sw.Dispose();
                sw.Close();
                sw = null;
            }
            catch (Exception ex)
            {
                _ErrorMessage = string.Format("Creation of bak file failed. Error {0}", ex.Message);
                //Utilities.SaveToErrorLog(Utilities.TimeStamp() + _ErrorMessage);                
            }
        }

        private void createNode(XmlTextWriter writer, string Element, string Value)
        {
            writer.WriteStartElement(Element);
            writer.WriteString(Value);
            writer.WriteEndElement();         
        }

    }    
}
