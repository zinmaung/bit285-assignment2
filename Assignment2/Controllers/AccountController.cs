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

        //Post new account info to database
        [HttpPost]
        public ActionResult NewAccount(User newAcct)    //passing  to newAcct paramater
        {
            if (ModelState.IsValid)                     //Checking a model is valid or not.
            {
                using (VisitorLogContext db = new VisitorLogContext())
                {
                    db.Users.Add(newAcct);
                    db.SaveChanges();
                }
                //Create message to user once it's succeded.
                ModelState.Clear();
                ViewBag.Message = newAcct.FirstName + " " + newAcct.LastName + ", You just registered"; 
            }
            return View();
        }

        //Password
        //public ActionResult Password()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public ActionResult Password(User ranPass)
        //{
        //    Random ran = new Random();
        //    string[] result = new string[2];
        //    result[0] = "Email";
        //    result[1] = "FirstName";
        //    result[2] = "LastName";

        //    for (int i = 0; i < 5; ++i)
        //    {
        //        string Rdam = "";
        //        Rdam += result[0].Substring(ran.Next(0, result[0].Length)).ToString();
        //        Rdam += result[1].Substring(ran.Next(0, result[1].Length)).ToString();
        //        Rdam += result[2].Substring(ran.Next(0, result[2].Length)).ToString();

                
        //    }
        //    return View(ran);

        //}

        //Login 
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            using (VisitorLogContext db = new VisitorLogContext())
            {
                var usr = db.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    return RedirectToAction("LoggedIn");
                }

                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong");
                }
            }
            return View();
        }
            //Method for loggedIn page
        public ActionResult LoggedIn()
        {
            if(Session["UserID"] != null)
            {
                return View();
            }

            else
            {
                return RedirectToAction("Login");
            }
        }


        private MultiSelectList GetPrograms(string[] selectedValues)
        {
            List<Program> Programs = new List<Program>()
            {
                new Program { ProgramID=1, ProgramName="Web Developer Degree" },
                new Program { ProgramID=2, ProgramName="Associate In Business" },
                new Program { ProgramID=3, ProgramName="Assiciate In Pre-Nursing" },
                new Program { ProgramID=4, ProgramName="Assiciate In Global Studies" }
            }.ToList();
            return new MultiSelectList(Programs, "ProgramID", "ProgramName", selectedValues);
        }
        public ActionResult MultiSelectProgram()
        {
            ViewBag.Promgramlist = GetPrograms(null);
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