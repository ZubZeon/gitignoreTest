using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Receptbok
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Receptbok",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Kategori", action = "Start", id = UrlParameter.Optional }
            );
        }
    }
}
