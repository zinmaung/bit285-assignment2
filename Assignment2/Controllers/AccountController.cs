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
            using (VisitorLogContext db = new VisitorLogContext())
            {
                return View(db.Users.ToList());
            }
        }

        public ActionResult NewAccount()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult NewAccount(User newAcct)
        {
            if (ModelState.IsValid)
            {
                using (VisitorLogContext db = new VisitorLogContext())
                {
                    db.Users.Add(newAcct);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = newAcct.FirstName + " " + newAcct.LastName + ", You just registered";
            }
            return View("~/Views/Login/Login.cshtml");
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