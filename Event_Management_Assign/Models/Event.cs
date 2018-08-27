using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Event_Management_Assign.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        public string City { get; set; }

        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        public IList<EventUser> EventUsers { get; set; }

    }
}