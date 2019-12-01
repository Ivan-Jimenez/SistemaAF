using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAF.Areas.ActivosFijos.Models
{
    public class ExtranjeroDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string DocumentType { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string DocumentName { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string NoAsset { get; set; }
    }
}