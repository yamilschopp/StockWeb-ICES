using System.ComponentModel.DataAnnotations;

namespace StockWebFinal.Models
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        public DateTime FechaAlta { get; set; }

        public bool Estado { get; set; }
    }
}
