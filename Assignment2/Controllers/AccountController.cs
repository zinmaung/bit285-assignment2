using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


 /**
  * Store temporary user in Session during account creation
  */
        private User GetTempUser()
        {
            if (Session["tempUser"] == null)
            {
                Session["tempUser"] = new User();
            }
            return (User)Session["tempUser"];
        }

        private void FlushTempUser()
        {
            Session.Remove("tempUser");
        }
    }
}