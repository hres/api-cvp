using System.Web.Routing;
using System.Web.Mvc;

namespace cvpWebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Root",
            //    url: "{action}",
            //    defaults: new { controller = "Home", action = "IndexEN" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "IndexEN", id = UrlParameter.Optional });
        }
    }
}