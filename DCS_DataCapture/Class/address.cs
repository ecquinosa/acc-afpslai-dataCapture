
using System;

namespace DCS_DataCapture.Class
{
    public class address
    {
        public int id { get; set; }
        public Nullable<int> member_id { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public Nullable<int> country_id { get; set; }
        public string zipcode { get; set; }
        public Nullable<System.DateTime> date_post { get; set; }
        public Nullable<System.TimeSpan> time_post { get; set; }
    }
}
