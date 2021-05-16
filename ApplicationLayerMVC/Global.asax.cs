﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ApplicationLayerMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {            
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
