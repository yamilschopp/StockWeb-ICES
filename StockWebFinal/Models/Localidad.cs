using System.ComponentModel.DataAnnotations;

namespace StockWebFinal.Models
{
    public class Localidad
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(50)]
        public string? Nombre { get; set; }
        public int Provincia_Id { get; set; }
        public short CodigoPostal { get; set; }
    }
}
