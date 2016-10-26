using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoardofPardons.Entity
{
    public class Register
    {

        [Required(ErrorMessage = "Enter User name")]

        public string username { get; set; }
        [Required(ErrorMessage = "Enter EmailID")]

        public string EmailID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]

        public string password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        public string Confirmpassword { get; set; }




        [Required(ErrorMessage = "Enter Suffix")]
        public string suffix { get; set; }

        
        
        [Required(ErrorMessage = "Enter First Name")]
        public string FirstName { get; set; }


        public string MiddleName { get; set; }
        public string LastName{ get; set; }
        public string Birthdate { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Gender { get; set; }
        public string SSNumber { get; set; }
        
    }
}