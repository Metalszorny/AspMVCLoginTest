using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspMVCLoginTest
{
	/// <summary>
    /// Sets the route configurations.
    /// </summary>
    public class RouteConfig
    {
		/// <summary>
        /// Registers the route mapping.
        /// </summary>
		/// <param name="routes">Collection of routes.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
			// Sets ignored path parameters.
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			// Sets path parameters to be mapped.
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
