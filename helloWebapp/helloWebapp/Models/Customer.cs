using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace helloWebapp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name  { get; set; }
        [Display(Name = "BirthDay")]
        [Min18YearsIfAMember]
        public string BirthDate { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        [Display(Name ="MembershipType")]
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
} 