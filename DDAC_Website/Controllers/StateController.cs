using DDAC_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDAC_Website.Controllers
{
    public class StateController : Controller
    {
        AssignmentDB db = new AssignmentDB();
        // GET: State
        public ActionResult Index()
        {
            return View();
        }


        public IEnumerable<State> getStateRooms()
        {
            IEnumerable<State> sRooms = db.State.ToList();

            return sRooms;
        }

        public IEnumerable<SelectListItem> stateRooms_()
        {
            IEnumerable<State> sRooms = getStateRooms();

            IEnumerable<SelectListItem> stateRooms = sRooms.Select(x =>
                                              new SelectListItem()
                                              {
                                                  Text = x.stateRoomType
                                              });

            return stateRooms;

        }

        public List<SelectListItem> getNumPeople()
        {
            List<SelectListItem> numPeople = new List<SelectListItem>();
            //number of people in room
            for (int i = 1; i < 5; i++)
            {
                numPeople.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }


            return numPeople;
        }

        
        public PartialViewResult StateRooms()
        {
            IEnumerable<State> sRooms = getStateRooms();
            List<SelectListItem> numPeople = getNumPeople();
            
            ViewBag.numOfGuest = numPeople;
            
            return PartialView("_StateRooms",sRooms);
        }

        public PartialViewResult UpdateStateRooms(string numOfGuest)
        {

            IEnumerable<State> sRooms = db.State.ToList();
            IEnumerable<Double> new_objects;

            if (numOfGuest == " " || numOfGuest == "")
            {
                new_objects = from s in sRooms select (s.stateRoomPrice /1);

            }else
            {
                new_objects = from s in sRooms select (s.stateRoomPrice / Int32.Parse(numOfGuest));

            }


            return PartialView("_UpdatePrice",new_objects);

        }


    }
}