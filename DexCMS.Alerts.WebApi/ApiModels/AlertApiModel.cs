using DexCMS.Alerts.Models;
using DexCMS.Core.Globals;
using System;

namespace DexCMS.Alerts.WebApi.ApiModels
{
    public class AlertApiModel: DexCMSViewModel<AlertApiModel, Alert>
    {
        public int AlertID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string AlertText { get; set; }

        public int DisplayOrder { get; set; }
    }
}
