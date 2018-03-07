using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Gamezy
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // The new way of routing. See GameController for use.
            routes.MapMvcAttributeRoutes();

            /* 
             * Old Example:
             * Custom route to sort games by release date.
             * If Gamezy receives a URL with this format, it will try to treat
             * it appropriately.
             * 
             * Also, we use regex to define our param input patterns (y/m).
             * 
             * This is the old way of defining routes;
             *      Modern MVC uses MapMvcAttributeRoutes.
             */
            //routes.MapRoute(
            //    name:"GamesByReleaseDate",
            //    url:"games/released/{year}/{month}",
            //    defaults: new {controller = "Games", action = "ByReleaseDate"},
            //    constraints: new { year = @"\d{4}", month=@"\d{2}" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
