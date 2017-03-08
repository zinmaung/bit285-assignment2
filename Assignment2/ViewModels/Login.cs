using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.ViewModels
{
    public class Login
    {
        [Key]
        public int UserID { get; set; }
          
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string PassWord { get; set; }
    }
}