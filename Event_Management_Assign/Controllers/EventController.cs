using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Event_Management_Assign.Models;
using Event_Management_Assign.ViewModel;
using Microsoft.AspNet.Identity;

namespace Event_Management_Assign.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private ApplicationDbContext db;

        public EventController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        public ActionResult Index()
        {
            List<Event> events = db.Events.ToList();
            IList<Event> oldEvents = new List<Event>();
            IList<Event> newEvents = new List<Event>();
            foreach (var eve in events)
            {
                int res = DateTime.Compare(eve.EventDate, DateTime.Now);
                if (res < 0)
                {
                    oldEvents.Add(eve);
                }
                else
                {
                    newEvents.Add(eve);
                }
            }

            EventOldNewViewModel oldNewViewModel = new EventOldNewViewModel
            {
                NewEvent = newEvents,
                OldEvent = oldEvents
            };

            return View(oldNewViewModel);
        }

        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(u => u.Id == userId);
            bool checkregistration = false;
            bool checkpastevent = false;

            Event eEvent = db.Events.SingleOrDefault(e => e.EventId == id);

            var query = (from usr in db.Users
                from eventUser in usr.EventUsers
                where eventUser.EventId == id
                select usr).ToList();

            int res = DateTime.Compare(eEvent.EventDate, DateTime.Now);
            checkpastevent = (res < 0) ? true : false;

            checkregistration = query.Contains(currentUser) ? true : false;
            
            EventUserViewModel vm = new EventUserViewModel
            {
                Event = eEvent,
                Users = query,
                CheckRegistration = checkregistration,
                CheckPastEvent = checkpastevent
            };

            return View(vm);
        }

        public ActionResult Register(int id)
        {
            var currentUser = User.Identity.GetUserId();

            db.EventUsers.Add(new EventUser{Id = currentUser, EventId = id});
            db.SaveChanges();

            Event eEvent = db.Events.SingleOrDefault(eve => eve.EventId == id);
            return View(eEvent);
        }
    }
}