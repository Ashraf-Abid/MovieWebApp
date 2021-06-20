using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace helloWebapp.Models
{
    public class MembershipType
    {
        public short SignUpFee { get; set; }
        public byte DurationinMonth { get; set; }
        public byte DiscountRate  { get; set ; }
        public byte ID { get; set; }

    }
}