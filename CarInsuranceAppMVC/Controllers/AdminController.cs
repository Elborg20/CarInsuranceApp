using CarInsuranceAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceAppMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using(CarInsuranceEntities db = new CarInsuranceEntities())
            {
                var signups = db.SignUps;
                var signUps = new List<SignUp>();
                foreach (var signup in signups)
                {
                    var signUp = new SignUp();
                    signUp.FirstName = signup.FirstName;
                    signUp.LastName = signup.LastName;
                    signUp.EmailAddress = signup.EmailAddress;
                    signUp.Quote = signup.Quote;
                    signUps.Add(signUp);
                }
                return View(signUps);
            }
        }
    }
}