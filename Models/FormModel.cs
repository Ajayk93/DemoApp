using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoApp.Models
{
    public class FormModel
    {
        [Display(Name = "First Name:")]
        [MaxLength(10, ErrorMessage =("Lenght should not exceed 10 characters."))]
        [MinLength(2, ErrorMessage =("Lenght should not be less than 2 characters."))]
        [Required(ErrorMessage ="First name is a required field")]
        [CustVal(ErrorMessage ="@ is not allowed")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name:")]
        [Required(ErrorMessage = "Last name is a required field")]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        public int? Score { get; set; }

        [Required(ErrorMessage = "Password should not be blank")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Confirm password doesn't match" )]
        public string ConfirmPassword { get; set; }

    }

    public class CustVal : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if(value != null)
                return value.ToString().Contains("@") ? false : true;
            return true;
        }
    }
}