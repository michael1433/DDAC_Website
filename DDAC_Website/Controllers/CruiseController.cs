using DDAC_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DDAC_Website.Classes;

namespace DDAC_Website.Controllers

{
    public class CruiseController : Controller
    {
        AssignmentDB db = new AssignmentDB();
        // GET: Cruise
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ViewCruise(int id)
        {
            Cruise c = null;
            RetryHelper.RetryOnException(3, TimeSpan.FromSeconds(1), () =>
            {
                c = db.Cruise.Find(id);
            });
            return View(c);
        }

     
        public PartialViewResult ViewItinerary(int id)
        {
            List<Images> img = db.Images.ToList();
            Cruise cruise = db.Cruise.Find(id);

            List<byte[]> imageData = (from i in img
                                      where i.cruise_id.Equals(id) && i.imageName.Equals("Map.Jpg")
                                      select i.Image).ToList();

            ViewBag.Cruise_Name = cruise.cruise_name;
            return PartialView("_CruiseItinerary", imageData);

        }

        public PartialViewResult Schedule(int id)
        {
            IEnumerable<Location> location = db.Location.ToList().Where(s=> s.cruise_id == id);
            
            return PartialView("_Schedule",location);
        }

        public ActionResult Compare(int id)
        {

            Cruise cruise = db.Cruise.Find(id);
            ViewBag.ID = id;
            IEnumerable<Cruise> other_Cruises = db.Cruise.Where(s => s.id != id);
            IEnumerable<Location> location = db.Location.ToList().Where(s=> s.cruise_id == id);
            ViewBag.Cruise_Location = location;
            ViewBag.OtherCruise = other_Cruises;
            return View(cruise);
        }

        public PartialViewResult Compare_New(int id,int selectedID)
        {

            ViewBag.selectedID = selectedID;
            ViewBag.ID = id;
            IEnumerable<Cruise> other_Cruises = db.Cruise.Where(s => s.id != selectedID);
            ViewBag.OtherCruise = other_Cruises;
            return PartialView("_AllCruise");
        }


        public PartialViewResult CompareSchedule(int id,int selectedID)
        {
            IEnumerable<Location> location = db.Location.ToList().Where(s => s.cruise_id == id);
            ViewBag.selectedID = selectedID;
            ViewBag.ID = id; 
            Cruise cruise = db.Cruise.Find(id);
            ViewBag.Location = location;

            return PartialView("_CompareCruise", cruise);
        }


        public PartialViewResult CruiseLocation(int id)
        {
            IEnumerable<Location> location = db.Location.ToList().Where(s => s.cruise_id == id && 
            s.Location_Name != "At Sea");

            return PartialView("_CruiseLocations",location);




        }

        
        public PartialViewResult Location(string locationName)
        {


            IEnumerable<Location> loc = db.Location.ToList();
            Location location = loc.First(l => l.Location_Name == locationName);


            ViewBag.Coordinate = location.location_coordinate;


           return PartialView("_StreetView");
        }



        public FileResult ShowGoogleStreetViewPhoto(string googleStreetViewAddress)
        {

            Task<byte[]> result = GetStreetViewImage(googleStreetViewAddress, "500x500");

            //Quick check to see if we have an image
            if (result == null)
                return null;



            var file = result.Result;

            return File(file,"image/jpeg");
        }


        public async Task<byte[]> GetStreetViewImage(string location, string size)
        {
            string API_KEY = "AIzaSyAkxJuxS_l9BkTUlyf5ZOjAEKAGizEXdcM";
            if (string.IsNullOrEmpty(location))
            {
                return null;
            }

            try
            {
                var streetViewApiUrl = "http://maps.googleapis.com/maps/api/streetview?";
                var formattedImageUrl = string.Format("{0}&location={1}&key={2}", string.Format("{0}&size={1}", streetViewApiUrl, size), location, API_KEY);
                var httpClient = new HttpClient();

                var imageTask = httpClient.GetAsync(formattedImageUrl);
                HttpResponseMessage response = imageTask.Result;

                response.EnsureSuccessStatusCode();
                await response.Content.LoadIntoBufferAsync();

                return await response.Content.ReadAsByteArrayAsync();


            }
            catch
            {
                return null;
            }
        }

        [Authorize]
        public ActionResult bookCruise(int id)
        {

            Cruise cruise = db.Cruise.Find(id);
            List<SelectListItem> s = new StateController().stateRooms_().ToList();
            var q = new StateController().getNumPeople();


            ViewBag.cruiseName = cruise.cruise_name;
            ViewBag.cruiseDeparture = cruise.cruise_start_date;
            ViewBag.stateRooms = s;
            ViewBag.quantity = q;
            return View();
        }

        public ActionResult ErrorView()
        {
            return View();
        }

    }
}