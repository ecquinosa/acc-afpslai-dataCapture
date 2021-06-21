using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DCS_DataCapture
{
    public class MiddleServerApi
    {
        public enum msApi
        {
            getOnlineRegByCIF = 1,
            getRole,
            getAssociateType,
            getBranch,
            getCivilStatus,
            getCountry,
            getMembershipStatus,
            getMembershipType,
            getPrintType,
            getRecardReason,
            getCard,
            getAddress,
            validateLogIn,
            addSystemUser,
            addOnlineRegistration,
            addMember,
            addCard,
            addAddress,
            addSystemRole,
            delSystemRole,
            addAssociateType,
            delAssociateType,
            addBranch,
            delBranch,
            addCivilStatus,
            delCivilStatus,
            addMembershipStatus,
            delMembershipStatus,
            addMembershipType,
            delMembershipType,
            addPrintType,
            delPrintType,
            addRecardReason,
            delRecardReason,
            checkServerDBStatus,
            getDCSSystemSetting,
            getOnlineRegistration,
            saveMemberImages,
            cancelCapture,
            addDCSSystemSettings,
            checkMemberIfCaptured
        }

        public static bool ExecuteApiRequest(string url, string soapStr, ref string soapResponse, ref string err)
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpClient client = new HttpClient();

            try
            {
                var uri = new Uri(url);
                string baseUrl = string.Format("http://{0}", uri.Authority);
                if (Properties.Settings.Default.MiddleServerUrl.Contains("https://")) baseUrl = string.Format("https://{0}", uri.Authority);
                string otherUrl = uri.LocalPath;

                client.BaseAddress = new Uri(baseUrl);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", txtToken.Text);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var buffer = System.Text.Encoding.UTF8.GetBytes(soapStr);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                byteContent.Headers.ContentLength = buffer.Length;

                HttpResponseMessage response = client.PostAsync(otherUrl, byteContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    soapResponse = response.Content.ReadAsStringAsync().Result;
                    return true;
                }
                else
                {
                    err = string.Format("{0} {1}", response.StatusCode, response.ReasonPhrase);
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("One or more errors occurred.")) err = "Unable to reach middle server api.";
                else err = ex.Message;
                return false;
            }
            finally
            {
                client.Dispose();
                myHttpWebRequest = null;
            }
        }

        public static bool ValidateLogIn(string userName, string userPass)
        {
            Class.loginRequest user = new Class.loginRequest();
            user.user_name = userName;
            user.user_pass = userPass;

            Class.requestCredential cred = new Class.requestCredential();
            cred.dateRequest = DateTime.Now.ToString();
            cred.key = Properties.Settings.Default.ApiKey;
            cred.userId = 0;
            cred.userName = userName;
            cred.userPass = userPass;
            cred.branch = Properties.Settings.Default.BranchIssue;

            Class.requestPayload reqPayload = new Class.requestPayload();            
            reqPayload.authentication = accAfpslaiEmvEncDec.Aes256CbcEncrypter.Encrypt(Newtonsoft.Json.JsonConvert.SerializeObject(cred));
            reqPayload.payload = Newtonsoft.Json.JsonConvert.SerializeObject(user);

            string soapResponse = "";
            string err = "";
                    
            string soapStr = Newtonsoft.Json.JsonConvert.SerializeObject(reqPayload);
            bool response = ExecuteApiRequest(string.Format(@"{0}/api/{1}",Properties.Settings.Default.MiddleServerUrl,System.Enum.GetName(typeof(msApi), msApi.validateLogIn)), soapStr, ref soapResponse, ref err);
            if (response)
            {
                dynamic payload = Newtonsoft.Json.JsonConvert.DeserializeObject(soapResponse);
                var result = payload.result;
                var message = payload.message;
                if (result == 0)
                {
                    var obj = payload.obj[0].ToString();
                    DataCapture.dcsUser = Newtonsoft.Json.JsonConvert.DeserializeObject<Class.user>(obj);
                    
                    return true;
                }
                else
                {
                    Class.Utilities.ShowErrorMessage(message.ToString());
                    return false;
                }
            }
            else
            {
                Class.Utilities.ShowErrorMessage(err);
                return false;
            }
        }

        public static bool GetTable(msApi api, ref object obj, string optPayload = "")
        {

            string soapResponse = "";
            string err = "";
            string soapStr = Newtonsoft.Json.JsonConvert.SerializeObject(requestPayload(optPayload));
            bool response = ExecuteApiRequest(string.Format(@"{0}/api/{1}", Properties.Settings.Default.MiddleServerUrl, System.Enum.GetName(typeof(msApi), api)), soapStr, ref soapResponse, ref err);
            if (response)
            {
                dynamic payload = Newtonsoft.Json.JsonConvert.DeserializeObject(soapResponse);
                var result = payload.result;
                var message = payload.message;
                if (result == 0)
                {
                    obj = payload.obj;

                    return true;
                }
                else
                {
                    Class.Utilities.ShowErrorMessage(message.ToString());
                    return false;
                }
            }
            else
            {
                Class.Utilities.ShowErrorMessage(err);
                return false;
            }
        }

        private static Class.requestCredential requestCredential()
        {
            Class.requestCredential cred = new Class.requestCredential();
            cred.dateRequest = DateTime.Now.ToString();
            cred.key = Properties.Settings.Default.ApiKey;
            //cred.userId = 0;
            //cred.userName = "admin";
            //cred.userPass = "eyJpdiI6InNad2RnWndKdjUvUlRkVnZFelB1UGc9PSIsInZhbHVlIjoiQ1NwWVdMbnZMcmdRSmxEUlUrczV6dz09IiwibWFjIjoiYjNhNjI1YmNjMzQ4NWRlMDdlYzhjZDRkYWE4M2M1MDRhNTdhYmI5ZTdiYjcwOGE4M2I0NjRkYjMyZGY4Njc0OCJ9";

            cred.userId = DataCapture.dcsUser.userId;
            cred.userName = DataCapture.dcsUser.userName;
            cred.userPass = DataCapture.dcsUser.userPass;
            cred.branch = Properties.Settings.Default.BranchIssue;

            return cred;
        }

        private static Class.requestPayload requestPayload(string payload)
        {
            Class.requestPayload reqPayload = new Class.requestPayload();
            //Class.requestPayload.payloadReq objPayload = new Class.requestPayload.payloadReq();
            //objPayload.obj = payload;
            reqPayload.authentication = accAfpslaiEmvEncDec.Aes256CbcEncrypter.Encrypt(Newtonsoft.Json.JsonConvert.SerializeObject(requestCredential()));
            reqPayload.payload = payload;

            return reqPayload;
        }

        public static bool GetTable2(msApi api, ref object obj)
        {    
            string soapResponse = "";   
            string err = "";
            string soapStr = Newtonsoft.Json.JsonConvert.SerializeObject(requestPayload(""));
            bool response = ExecuteApiRequest(string.Format(@"{0}/api/{1}", Properties.Settings.Default.MiddleServerUrl, System.Enum.GetName(typeof(msApi), api)), soapStr, ref soapResponse, ref err);
            if (response)
            {
                dynamic payload = Newtonsoft.Json.JsonConvert.DeserializeObject(soapResponse);
                var result = payload.result;
                var message = payload.message;
                if (result == 0)
                {
                    obj = payload.obj;

                    return true;
                }
                else
                {
                    Class.Utilities.ShowErrorMessage(message.ToString());
                    return false;
                }
            }
            else
            {
                Class.Utilities.ShowErrorMessage(err);
                return false;
            }
        }

        public static bool GetCard(ref object obj)
        {
            string soapResponse = "";
            string err = "";
            //var s = "{ value: test }";
            string soapStr = Newtonsoft.Json.JsonConvert.SerializeObject(requestPayload("{ 'value': 'test' }"));
            bool response = ExecuteApiRequest(string.Format(@"{0}/api/{1}", Properties.Settings.Default.MiddleServerUrl, System.Enum.GetName(typeof(msApi), msApi.getCard)), soapStr, ref soapResponse, ref err);
            if (response)
            {
                dynamic payload = Newtonsoft.Json.JsonConvert.DeserializeObject(soapResponse);
                var result = payload.result;
                var message = payload.message;
                if (result == 0)
                {
                    obj = payload.obj;

                    return true;
                }
                else
                {
                    Class.Utilities.ShowErrorMessage(message.ToString());
                    return false;
                }
            }
            else
            {
                Class.Utilities.ShowErrorMessage(err);
                return false;
            }
        }

        public static bool checkServerDBStatus(string url = "")
        {
            if (url == "") url = Properties.Settings.Default.MiddleServerUrl;

            string soapResponse = "";
            string err = "";
            string soapStr = "";
            bool response = ExecuteApiRequest(string.Format(@"{0}/api/{1}", url, System.Enum.GetName(typeof(msApi), msApi.checkServerDBStatus)), soapStr, ref soapResponse, ref err);
            if (response)
            {
                dynamic payload = Newtonsoft.Json.JsonConvert.DeserializeObject(soapResponse);
                var result = payload.result;
                var message = payload.message;
                if (result == 0)
                {
                    var obj = payload.obj;
                    if (obj != null) return true; else return false;
                }
                else
                {
                    Class.Utilities.ShowErrorMessage(message.ToString());
                    return false;
                }
            }
            else
            {
                Class.Utilities.ShowErrorMessage(err);
                return false;
            }
        }

        public static bool addMember(Class.member member, ref int memberId)
        {

            string soapResponse = "";
            string err = "";
            string soapStr = Newtonsoft.Json.JsonConvert.SerializeObject(requestPayload(Newtonsoft.Json.JsonConvert.SerializeObject(member)));
            
            bool response = ExecuteApiRequest(string.Format(@"{0}/api/{1}", Properties.Settings.Default.MiddleServerUrl, System.Enum.GetName(typeof(msApi), msApi.addMember)), soapStr, ref soapResponse, ref err);
            if (response)
            {
                dynamic payload = Newtonsoft.Json.JsonConvert.DeserializeObject(soapResponse);
                var result = payload.result;
                var message = payload.message;
                if (result == 0)
                {
                    var obj = payload.obj;                   

                    memberId = (int)obj;

                    return true;
                }
                else
                {
                    Class.Utilities.ShowErrorMessage(message.ToString());
                    return false;
                }
            }
            else
            {
                Class.Utilities.ShowErrorMessage(err);
                return false;
            }
        }

        public static bool addDeleteGenericTable(object inputObj, bool isAdd = true)
        {
            var obj  = (dynamic)null;
            msApi api = msApi.addAssociateType;

            if (inputObj is Class.associate_type)
            {
                obj = (Class.associate_type)inputObj;
                if (isAdd)api = msApi.addAssociateType; else api = msApi.delAssociateType;
            }
            else if (inputObj is Class.branch)
            {
                obj = (Class.branch)inputObj;               
                if (isAdd) api = msApi.addBranch; else api = msApi.delBranch;
            }
            else if (inputObj is Class.civil_status)
            {
                obj = (Class.civil_status)inputObj;                
                if (isAdd) api = msApi.addCivilStatus; else api = msApi.delCivilStatus;
            }
            else if (inputObj is Class.membership_status)
            {
                obj = (Class.membership_status)inputObj;               
                if (isAdd) api = msApi.addMembershipStatus; else api = msApi.delMembershipStatus;
            }
            else if (inputObj is Class.membership_type)
            {
                obj = (Class.membership_type)inputObj;               
                if (isAdd) api = msApi.addMembershipType; else api = msApi.delMembershipType;
            }
            else if (inputObj is Class.print_type)
            {
                obj = (Class.print_type)inputObj;            
                if (isAdd) api = msApi.addPrintType; else api = msApi.delPrintType;
            }
            else if (inputObj is Class.recard_reason)
            {
                obj = (Class.recard_reason)inputObj;               
                if (isAdd) api = msApi.addRecardReason; else api = msApi.delRecardReason;
            }
            else if (inputObj is Class.system_role)
            {
                obj = (Class.system_role)inputObj;
                if (isAdd) api = msApi.addSystemRole; else api = msApi.delSystemRole;                
            }


            string soapResponse = "";
            string err = "";
            string soapStr = Newtonsoft.Json.JsonConvert.SerializeObject(requestPayload(Newtonsoft.Json.JsonConvert.SerializeObject(obj)));

            bool response = ExecuteApiRequest(string.Format(@"{0}/api/{1}", Properties.Settings.Default.MiddleServerUrl, System.Enum.GetName(typeof(msApi), api)), soapStr, ref soapResponse, ref err);
            if (response)
            {
                dynamic payload = Newtonsoft.Json.JsonConvert.DeserializeObject(soapResponse);
                var result = payload.result;
                var message = payload.message;
                if (result == 0)
                {
                    //var obj = payload.obj;
                    Class.Utilities.ShowInformationMessage(message.ToString());

                    return true;
                }
                else
                {
                    Class.Utilities.ShowErrorMessage(message.ToString());
                    return false;
                }
            }
            else
            {
                Class.Utilities.ShowErrorMessage(err);
                return false;
            }
        }

        public static bool checkMemberIfCaptured(Class.member member)
        {

            string soapResponse = "";
            string err = "";
            string soapStr = Newtonsoft.Json.JsonConvert.SerializeObject(requestPayload(Newtonsoft.Json.JsonConvert.SerializeObject(member)));
            //string soapStr = Newtonsoft.Json.JsonConvert.SerializeObject(member);
            bool response = ExecuteApiRequest(string.Format(@"{0}/api/{1}", Properties.Settings.Default.MiddleServerUrl, System.Enum.GetName(typeof(msApi), msApi.checkMemberIfCaptured)), soapStr, ref soapResponse, ref err);
            if (response)
            {
                dynamic payload = Newtonsoft.Json.JsonConvert.DeserializeObject(soapResponse);
                var result = payload.result;
                var message = payload.message;
                if (result == 0)
                {
                    //var obj = payload.obj;
                    //dcsUser = Newtonsoft.Json.JsonConvert.DeserializeObject<Class.user>(obj);

                    //memberId = (int)obj;

                    return true;
                }
                else
                {
                    Class.Utilities.ShowErrorMessage(message.ToString());
                    return false;
                }
            }
            else
            {
                Class.Utilities.ShowErrorMessage(err);
                return false;
            }
        }

        public static bool addCard(Class.card card)
        {

            string soapResponse = "";
            string err = "";
            string soapStr = Newtonsoft.Json.JsonConvert.SerializeObject(requestPayload(Newtonsoft.Json.JsonConvert.SerializeObject(card)));           
            bool response = ExecuteApiRequest(string.Format(@"{0}/api/{1}", Properties.Settings.Default.MiddleServerUrl, System.Enum.GetName(typeof(msApi), msApi.addCard)), soapStr, ref soapResponse, ref err);
            if (response)
            {
                dynamic payload = Newtonsoft.Json.JsonConvert.DeserializeObject(soapResponse);
                var result = payload.result;
                var message = payload.message;
                if (result == 0)
                {
                    //var obj = payload.obj;
                   
                    return true;
                }
                else
                {
                    Class.Utilities.ShowErrorMessage(message.ToString());
                    return false;
                }
            }
            else
            {
                Class.Utilities.ShowErrorMessage(err);
                return false;
            }
        }

        public static bool addDCSSystemSettings(Class.dcs_system_setting dcs_system_setting)
        {

            string soapResponse = "";
            string err = "";
            string soapStr = Newtonsoft.Json.JsonConvert.SerializeObject(requestPayload(Newtonsoft.Json.JsonConvert.SerializeObject(dcs_system_setting)));
            bool response = ExecuteApiRequest(string.Format(@"{0}/api/{1}", Properties.Settings.Default.MiddleServerUrl, System.Enum.GetName(typeof(msApi), msApi.addDCSSystemSettings)), soapStr, ref soapResponse, ref err);
            if (response)
            {
                dynamic payload = Newtonsoft.Json.JsonConvert.DeserializeObject(soapResponse);
                var result = payload.result;
                var message = payload.message;
                if (result == 0)
                {
                    //var obj = payload.obj;

                    return true;
                }
                else
                {
                    Class.Utilities.ShowErrorMessage(message.ToString());
                    return false;
                }
            }
            else
            {
                Class.Utilities.ShowErrorMessage(err);
                return false;
            }
        }

        public static bool saveMemberImages(Class.memberImages memberImages)
        {

            string soapResponse = "";
            string err = "";
            //string soapStr = Newtonsoft.Json.JsonConvert.SerializeObject(memberImages);
            string soapStr = Newtonsoft.Json.JsonConvert.SerializeObject(requestPayload(Newtonsoft.Json.JsonConvert.SerializeObject(memberImages)));
            bool response = ExecuteApiRequest(string.Format(@"{0}/api/{1}", Properties.Settings.Default.MiddleServerUrl, System.Enum.GetName(typeof(msApi), msApi.saveMemberImages)), soapStr, ref soapResponse, ref err);
            if (response)
            {
                dynamic payload = Newtonsoft.Json.JsonConvert.DeserializeObject(soapResponse);
                var result = payload.result;
                var message = payload.message;
                if (result == 0)
                {
                    var obj = payload.obj;
                    //dcsUser = Newtonsoft.Json.JsonConvert.DeserializeObject<Class.user>(obj);

                    return true;
                }
                else
                {
                    Class.Utilities.ShowErrorMessage(message.ToString());
                    return false;
                }
            }
            else
            {
                Class.Utilities.ShowErrorMessage(err);
                return false;
            }
        }

        public static bool addAddress(Class.address address, ref int addressId)
        {

            string soapResponse = "";
            string err = "";
            string soapStr = Newtonsoft.Json.JsonConvert.SerializeObject(requestPayload(Newtonsoft.Json.JsonConvert.SerializeObject(address)));
            bool response = ExecuteApiRequest(string.Format(@"{0}/api/{1}", Properties.Settings.Default.MiddleServerUrl, System.Enum.GetName(typeof(msApi), msApi.addAddress)), soapStr, ref soapResponse, ref err);
            if (response)
            {
                dynamic payload = Newtonsoft.Json.JsonConvert.DeserializeObject(soapResponse);
                var result = payload.result;
                var message = payload.message;
                if (result == 0)
                {
                    var obj = payload.obj;
                    addressId = (int)obj;
                    return true;
                }
                else
                {
                    Class.Utilities.ShowErrorMessage(message.ToString());
                    return false;
                }
            }
            else
            {
                Class.Utilities.ShowErrorMessage(err);
                return false;
            }
        }

        public static bool cancelCapture(Class.cancelCapture cancelCapture)
        {

            string soapResponse = "";
            string err = "";
            string soapStr = Newtonsoft.Json.JsonConvert.SerializeObject(requestPayload(Newtonsoft.Json.JsonConvert.SerializeObject(cancelCapture)));
            bool response = ExecuteApiRequest(string.Format(@"{0}/api/{1}", Properties.Settings.Default.MiddleServerUrl, System.Enum.GetName(typeof(msApi), msApi.cancelCapture)), soapStr, ref soapResponse, ref err);
            if (response)
            {
                dynamic payload = Newtonsoft.Json.JsonConvert.DeserializeObject(soapResponse);
                var result = payload.result;
                var message = payload.message;
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    Class.Utilities.ShowErrorMessage(message.ToString());
                    return false;
                }
            }
            else
            {
                Class.Utilities.ShowErrorMessage(err);
                return false;
            }
        }

        //public static bool addCard(Class.card card)
        //{

        //    string soapResponse = "";
        //    string err = "";
        //    string soapStr = Newtonsoft.Json.JsonConvert.SerializeObject(card);
        //    bool response = ExecuteApiRequest(string.Format(@"{0}/api/{1}", Properties.Settings.Default.MiddleServerUrl, System.Enum.GetName(typeof(msApi), msApi.addCard)), soapStr, ref soapResponse, ref err);
        //    if (response)
        //    {
        //        dynamic payload = Newtonsoft.Json.JsonConvert.DeserializeObject(soapResponse);
        //        var result = payload.result;
        //        var message = payload.message;
        //        if (result == 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            Class.Utilities.ShowErrorMessage(message.ToString());
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        Class.Utilities.ShowErrorMessage(err);
        //        return false;
        //    }
        //}

    }

}
