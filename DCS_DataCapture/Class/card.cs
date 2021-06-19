
using System;

namespace DCS_DataCapture.Class
{
    public class card
    {
        public int id { get; set; }
        public Nullable<int> member_id { get; set; }
        public string cardNo { get; set; }
        public Nullable<System.DateTime> date_post { get; set; }
        public Nullable<System.TimeSpan> time_post { get; set; }
    }
}
