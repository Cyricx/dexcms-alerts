using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using DexCMS.Alerts.Interfaces;

namespace DexCMS.Alerts.Mvc.Controllers
{
    public class AlertsController : Controller
    {
    	private IAlertRepository repository;

		public AlertsController(IAlertRepository repo)
		{
			repository = repo;
		}

        // GET: /Alerts/
        public JsonResult GetAlerts()
        {
            var alerts = repository.Items
                .Where(x => x.StartDate <= DateTime.Now &&
                    (!x.EndDate.HasValue || x.EndDate.Value >= DateTime.Now))
                .OrderBy(x => x.DisplayOrder)
                .ToList();

            return Json(alerts, JsonRequestBehavior.AllowGet);
        }


    }
}
