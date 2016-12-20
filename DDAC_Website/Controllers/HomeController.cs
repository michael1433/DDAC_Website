using DDAC_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDAC_Website.Controllers
{
    public class HomeController : Controller
    {
        AssignmentDB db = new AssignmentDB();
        public ActionResult Index()
        {
            //Creating a list
            List<SelectListItem> year = new List<SelectListItem>();
            List<SelectListItem> destination = new List<SelectListItem>();
            List<SelectListItem> port = new List<SelectListItem>();
            List<SelectListItem> duration = new List<SelectListItem>();



            //Adding options to be added to the drop down list
            year.Add(new SelectListItem { Text = "November 2016", Value = "0"});
            year.Add(new SelectListItem { Text = "December 2016", Value = "1" });
            year.Add(new SelectListItem { Text = "January 2017", Value = "2" });
            year.Add(new SelectListItem { Text = "February 2017", Value = "3" });
            year.Add(new SelectListItem { Text = "March 2017", Value = "4" });



            destination.Add(new SelectListItem { Text = "Asia", Value = "0"});
            destination.Add(new SelectListItem { Text = "Australia & New Zealand", Value = "1"});
            destination.Add(new SelectListItem { Text = "Hawaii", Value = "2"});

            port.Add(new SelectListItem { Text = "Singapore", Value = "0" });
            port.Add(new SelectListItem { Text = "Adelaide,Australia", Value = "1" });
            port.Add(new SelectListItem { Text = "Auckland,New Zealand", Value = "2" });


            duration.Add(new SelectListItem { Text = "1-5", Value = "0" });
            duration.Add(new SelectListItem { Text = "6-8", Value = "0" });
            duration.Add(new SelectListItem { Text = "9-15", Value = "0" });

            

            ViewBag.Year = year;
            ViewBag.Destination = destination;
            ViewBag.Port = port;
            ViewBag.Duration = duration;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult Search(string Year, string Destination, string Port, string Duration)
        {

            List<Cruise> cruise = db.Cruise.ToList();
            return PartialView("_Cruise", cruise);

        }


    }
}