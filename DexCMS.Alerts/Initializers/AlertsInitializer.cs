using DexCMS.Alerts.Contexts;
using DexCMS.Core.Globals;
using System;
using System.Collections.Generic;

namespace DexCMS.Alerts.Initializers
{
    public class AlertsInitializer: DexCMSLibraryInitializer<IDexCMSAlertsContext>
    {
        public AlertsInitializer(IDexCMSAlertsContext context):base(context) { }

        public override List<Type> Initializers
        {
            get
            {
                return new List<Type>
                {
                    typeof(AlertInitializer)
                };
            }
        }
    }
}
