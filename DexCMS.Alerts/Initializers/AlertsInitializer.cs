using DexCMS.Alerts.Contexts;
using DexCMS.Core.Infrastructure.Globals;
using System;
using System.Linq;

namespace DexCMS.Alerts.Initializers
{
    public class AlertsInitializer: DexCMSInitializer<IDexCMSAlertsContext>
    {
        public AlertsInitializer(IDexCMSAlertsContext context):base(context) { }

        public override void Run()
        {
            if (Context.Alerts.Count() == 0)
            {
                Context.Alerts.Add(new Models.Alert
                {
                    AlertText = "This is a test alert!",
                    DisplayOrder = 0,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1)
                });
                Context.SaveChanges();
            }
        }
    }
}
