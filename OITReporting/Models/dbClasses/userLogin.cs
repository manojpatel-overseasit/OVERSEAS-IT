using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OITReporting.Models.dbClasses
{
    [Table("userMaster")]
    public class userLogin
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Fill the Email!", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please fill the Password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}