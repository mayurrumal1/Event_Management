using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Event_Management_Assign.Models;

namespace Event_Management_Assign.ViewModel
{
    public class EventOldNewViewModel
    {
        public IList<Event> OldEvent { get; set; }

        public IList<Event> NewEvent { get; set; }
    }
}