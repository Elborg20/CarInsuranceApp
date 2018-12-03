using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsuranceAppMVC.Models;

namespace CarInsuranceApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string firstName, string lastName, string emailAddress, DateTime dateOfBirth, int carYear, string carMake, string carModel, string dUI, int speedingTickets, string fullCoverage)
        {            
            decimal quote = 50;

            var signup = new SignUp();
            using (CarInsuranceEntities db = new CarInsuranceEntities())
            {
                signup.FirstName = firstName;
                signup.LastName = lastName;
                signup.EmailAddress = emailAddress;
                signup.DateOfBirth = dateOfBirth;
                signup.CarYear = carYear;
                signup.CarMake = carMake;
                signup.CarModel = carModel;
                signup.DUI = dUI;
                signup.SpeedingTickets = speedingTickets;
                signup.FullCoverage = fullCoverage;

              
                if ((DateTime.Now - dateOfBirth).Days < 6570) quote += 100;

                else if ((DateTime.Now - dateOfBirth).Days < 9125 || (DateTime.Now - dateOfBirth).Days > 36500) quote += 25;

                if (carYear < 2000 || carYear > 2015) quote += 25;

                if (carMake.ToLower() == "porsche") quote += 25;

                if (carModel == "911 Carrera" || carModel == "911 carrera" || carModel == "911Carrera" || carModel == "911carrera") quote += 25;

                quote += (speedingTickets * 10);

                if (dUI.ToLower() == "yes") quote = quote + (quote / 4);

                if (fullCoverage.ToLower() == "yes") quote = quote + (quote / 2);

                signup.Quote = Math.Round(quote , 2);
                db.SignUps.Add(signup);
                db.SaveChanges();
            }

            return Content("Your Quote total is: $" + signup.Quote + ".  Follow up with us for more information today!");
        }
    }
}