using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Program
    {
        public int ProgramID { get; set; }
        [Display(Name = "Program Option")]
        public string ProgramName { get; set; }
    }
}