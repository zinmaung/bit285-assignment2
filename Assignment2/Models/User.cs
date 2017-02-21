using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Assignment2.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage ="Invalid email address")]
        [Required] 
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public bool EmailUpdates { get; set; }

        public int ProgramID { get; set; }

        public bool LoggedIn { get; set; }

    }
}