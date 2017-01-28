using DexCMS.Alerts.Contexts;
using DexCMS.Core.Infrastructure.Globals;
using System;
using System.Linq;

namespace DexCMS.Alerts.Initializers
{
    public class AlertInitializer : DexCMSInitializer<IDexCMSAlertsContext>
    {
        public AlertInitializer(IDexCMSAlertsContext context) : base(context) { }

        public override void Run(bool addDemoContent = true)
        {
            if (addDemoContent)
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
}
