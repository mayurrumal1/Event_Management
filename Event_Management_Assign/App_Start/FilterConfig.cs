﻿using System.Web;
using System.Web.Mvc;

namespace Event_Management_Assign
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
