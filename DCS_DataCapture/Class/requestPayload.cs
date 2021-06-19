
using System;

namespace DCS_DataCapture.Class
{
    public class requestPayload
    {

        public string system { get; set; }
        public string authentication { get; set; }
        public string payload { get; set; }

        public requestPayload()
        {
            system = "DCS";
        }

        //public class payloadReq
        //{
        //    public object obj { get; set; }
        //}

    }
}
