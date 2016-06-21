using Ninject;
using DexCMS.Alerts.Contexts;
using DexCMS.Alerts.Repositories;
using DexCMS.Alerts.Interfaces;

namespace DexCMS.Alerts.Globals
{
    public static class AlertsRegister<T> where T : IDexCMSAlertsContext
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAlertRepository>().To<AlertRepository>();
            kernel.Bind<IDexCMSAlertsContext>().To<T>();
        }
    }
}
