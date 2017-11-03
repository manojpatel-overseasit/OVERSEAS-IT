using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OITReporting.Models.dbClasses
{
    [Table("userMaster")]
    public class userReg
    {
        public int userId{ get; set; }

        [Display(Name ="First Name")]
        [Required(ErrorMessage = "Please enter first name", AllowEmptyStrings = false)]
        public string firstName { get; set; }

        [Display(Name ="Last Name")]
        [Required(ErrorMessage = "Please enter last name", AllowEmptyStrings = false)]
        public string lastName { get; set; }

        [Display(Name ="Date of Birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please select your date of birth", AllowEmptyStrings = false)]
        public DateTime dob { get; set; }

        [Display(Name ="Gender")]
        [Required(ErrorMessage = "Please select your gender", AllowEmptyStrings = false)]
        public string gender { get; set; }

        [Display(Name ="Address")]
        [Required(ErrorMessage = "Please enter residental address", AllowEmptyStrings = false)]
        public string address { get; set; }

        [Display(Name ="Country")]
        [Required(ErrorMessage = "Please select country", AllowEmptyStrings = false)]
        public int countryId { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "Please select state", AllowEmptyStrings = false)]
        public string state { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Please select city", AllowEmptyStrings = false)]
        public string city { get; set; }

        [Required(ErrorMessage = "Please enter contact number", AllowEmptyStrings = false)]
        [Display(Name = "Contact No.")]
        [DataType(DataType.PhoneNumber)]
        public int  contactNo { get; set; }
        
        [Display(Name ="Email")]
        [Required(ErrorMessage ="Please enter email address", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage ="Entered email address is invalid")]
        public string emailID { get; set; }

        [Display(Name ="Password")]
        [Required(ErrorMessage ="Please enter password", AllowEmptyStrings = false)]
        public string password { get; set; }

        [Display(Name ="Confirm Password")]
        [Required(ErrorMessage ="Please eneter confirm password", AllowEmptyStrings = false)]
        [Compare("password",ErrorMessage ="Entered confirm password does not match")]
        public string confirmPassword { get; set; }
    }
}
