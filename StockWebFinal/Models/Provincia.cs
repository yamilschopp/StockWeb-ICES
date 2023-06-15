using System.ComponentModel.DataAnnotations;

namespace StockWebFinal.Models
{
    public class Provincia
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }
    }
}
