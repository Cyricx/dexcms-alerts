using System;

namespace DexCMS.Alerts.WebApi.ApiModels
{
    public class AlertApiModel
    {
        public int AlertID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string AlertText { get; set; }

        public int DisplayOrder { get; set; }
    }
}
