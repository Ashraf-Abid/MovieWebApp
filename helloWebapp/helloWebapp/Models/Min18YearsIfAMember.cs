using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace helloWebapp.Models
{
    public class Min18YearsIfAMember:ValidationAttribute

    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
          var customer =(Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 1) return ValidationResult.Success;
            if (customer.BirthDate == null) return new ValidationResult("Birthdate is required");
         
            return (customer.BirthDate != null) ? ValidationResult.Success : new ValidationResult("You have a birthdate, enter pls");            
        }


    }
}