using DexCMS.Alerts.Models;
using DexCMS.Alerts.Contexts;
using DexCMS.Core.Repositories;
using DexCMS.Alerts.Interfaces;
using DexCMS.Core.Contexts;

namespace DexCMS.Alerts.Repositories
{
    public class AlertRepository : AbstractRepository<Alert>, IAlertRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }
        private IDexCMSAlertsContext _ctx { get; set; }
        public AlertRepository(IDexCMSAlertsContext ctx)
        {
            _ctx = ctx;
        }
    }
}
