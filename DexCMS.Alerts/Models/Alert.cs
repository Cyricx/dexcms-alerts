using System;
using System.ComponentModel.DataAnnotations;
using DexCMS.Core.Infrastructure.Attributes;

namespace DexCMS.Alerts.Models
{
    public class Alert
    {
        [Key]
        public int AlertID { get; set; }

        [Required]
        [IsDateBeforeDate("EndDate")]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        [StringLength(250)]
        public string AlertText { get; set; }

        [Required]
        public int DisplayOrder { get; set; }
    }
}
