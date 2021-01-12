using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Product_Management_System
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Product", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Products",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Products", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EditProduct",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "EditProduct", id = UrlParameter.Optional }
             );

            routes.MapRoute(
                name: "DeleteProduct",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "DeleteProduct", id = UrlParameter.Optional }
             );

            routes.MapRoute(
                    name: "AjaxMethod",
                    url: "{controller}/{action}",
                    defaults: new { Controller = "Home", action = "AjaxMethod" }
            );

            routes.MapRoute(
                    name: "ClearSession",
                    url: "{controller}/{action}",
                    defaults: new { Controller = "Home", action = "ClearSession" }
            );
        }
    }
}
