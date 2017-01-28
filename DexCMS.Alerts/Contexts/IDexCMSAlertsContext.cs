using System.Data.Entity;
using DexCMS.Alerts.Models;
using DexCMS.Core.Contexts;

namespace DexCMS.Alerts.Contexts
{
    public interface IDexCMSAlertsContext:IDexCMSContext
    {
        DbSet<Alert> Alerts { get; set; }
    }
}
