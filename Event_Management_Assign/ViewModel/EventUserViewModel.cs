using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Event_Management_Assign.Models;

namespace Event_Management_Assign.ViewModel
{
    public class EventUserViewModel
    {
        public Event Event { get; set; }
        
        public IList<ApplicationUser> Users { get; set; }

        public bool CheckRegistration { get; set; }

        public bool CheckPastEvent { get; set; }
    }
}