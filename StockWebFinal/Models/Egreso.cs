using System.ComponentModel.DataAnnotations;

namespace StockWebFinal.Models
{
    public class Egreso
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Usuario_Id { get; set; }
        public int Categoria_Id { get; set; }
        public int Marca_Id { get; set; }
        public int Producto_Id { get; set; }
        public int Cantidad { get; set; }
    }
}
