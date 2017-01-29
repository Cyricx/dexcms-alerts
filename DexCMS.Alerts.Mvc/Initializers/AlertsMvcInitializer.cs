using DexCMS.Alerts.Contexts;
using DexCMS.Core.Globals;
using System;
using System.Collections.Generic;

namespace DexCMS.Alerts.Mvc.Initializers
{
    public class AlertsMvcInitializer : DexCMSLibraryInitializer<IDexCMSAlertsContext>
    {
        public AlertsMvcInitializer(IDexCMSAlertsContext context) : base(context)
        {
        }

        public override List<Type> Initializers
        {
            get
            {
                return new List<Type>();
            }
        }
    }
}
