using System.ComponentModel.DataAnnotations;

namespace StockWebFinal.Models
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }
        public long? CuilCuit { get; set; }

        [MaxLength(50)]
        public string? Direccion { get; set; }
        public int? Provincia_Id { get; set; }
        public int? Localidad_Id { get; set; }

        [MaxLength(20)]
        public string? Telefono { get; set; }

        [MaxLength(50)]
        public string? Correo { get; set; }

        [MaxLength(100)]
        public string? Denominacion { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Estado { get; set; }
    }
}
