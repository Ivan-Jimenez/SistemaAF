using System.ComponentModel.DataAnnotations;

namespace SistemaAF.Areas.ActivosFijos.Models
{
    public class Extranjeros
    {
        [Key]
        [Required]
        [MaxLength(255)]
        public string NoParte { get; set; }
        public string NoFactura { get; set; }
        public string Fecha { get; set; }
        public string Cantidad { get; set; }
        public string CostoUnit { get; set; }
        public string TipoMcia { get; set; }
        public string DescEsp { get; set; }
        public string DescIng { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string Pedimento { get; set; }
        public string Proveedor { get; set; }
        public string Placas { get; set; }
        public string NoPacking { get; set; }
        public string Comment1 { get; set; }
        public string Test1 { get; set; }
        public string Division { get; set; }
        public string NoZEM { get; set; }
        public string NoExt { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
        //public string Cuadrante { get; set; }
    }
}