
using System;

namespace DCS_DataCapture.Class
{
    public class online_registration
    {
        public int id { get; set; }
        public string cif { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string suffix { get; set; }
        public string gender { get; set; }
        public Nullable<System.DateTime> date_birth { get; set; }
        public string mobile_nos { get; set; }
        public string email { get; set; }
        public string cca_no { get; set; }
        public string reference_number { get; set; }
        public string qr_code { get; set; }
        public Nullable<System.DateTime> date_schedule { get; set; }
        public Nullable<System.TimeSpan> time_schedule { get; set; }
        public Nullable<System.DateTime> date_post { get; set; }
        public Nullable<System.TimeSpan> time_post { get; set; }
    }
}
