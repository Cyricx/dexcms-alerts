using DexCMS.Core.Models;
using System.Web.Routing;
using System.Web.Mvc;

namespace DexCMS.Alerts.Mvc
{
    public static class AlertsMvcRoutes
    {
        public static void CreateDefaultRoutes(RouteCollection routes, DexCMSConfiguration config)
        {
            routes.MapRoute(
                name: "Alerts",
                url: "Alerts/{action}",
                defaults: new { controller = "Alerts" });
        }
    }
}
