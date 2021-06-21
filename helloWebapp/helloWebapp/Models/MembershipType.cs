using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace helloWebapp.Models
{
    public class MembershipType
    
    {
        
        
        [StringLength(255)]
        public string  Name  { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationinMonth { get; set; }
        public byte DiscountRate  { get; set ; }
        public byte ID { get; set; }

    }
}