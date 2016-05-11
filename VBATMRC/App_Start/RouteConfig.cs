#region Copyright Syncfusion Inc. 2001 - 2013
// Copyright Syncfusion Inc. 2001 - 2013. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VBATMRC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{dev}",
                defaults: new { controller = "Home", action = "Index", dev = false}//UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Download",
                url: "{controller}/{action}/{dev}/{filename}",
                defaults: new { controller = "Home", action = "Index", dev = false, filename=""}//UrlParameter.Optional }
            );
        }
    }
}