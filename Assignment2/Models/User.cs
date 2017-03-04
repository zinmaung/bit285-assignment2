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
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="First Name is required.")]
        [Display(Name = "First Name")]   
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public bool EmailUpdates { get; set; }

        public int ProgramID { get; set; }

        public bool LoggedIn { get; set; }
        public bool UserName { get; internal set; }
        public bool PassWord { get; internal set; }


        //public bool UserName { get; internal set; }
    }
}