using System.ComponentModel.DataAnnotations;

namespace SistemaAF.Areas.ActivosFijos.Models
{
    public class Nacionales
    {
        [Key]
        [Required]
        [MaxLength(255)]
        public string NoActivo { get; set; }
        public string Division { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string TextLine1 { get; set; }
        public string AcquisitionDate { get; set; }
        public string AccountingDimension2 { get; set; }
        public string AccountingDimension6 { get; set; }
        public string LifetimeInMonths { get; set; }
        public string PhysicalInventoryNo { get; set; }
        public string AcquisitionCost { get; set; }
        public string AcomulatedDeprecationLinear { get; set; }
        public string YearToDateDepreciationLinear { get; set; } // Auto calculated
        public string ForecastLinear { get; set; }
        public string Comment { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }

        // Extra 
        public string ActivationDate { get; set; }
        public string SerialNumber { get; set; }
    }
}