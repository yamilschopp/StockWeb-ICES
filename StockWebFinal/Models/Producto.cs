using System.ComponentModel.DataAnnotations;

namespace StockWebFinal.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public int Marca_Id { get; set; }
        public int Categoria_Id { get; set; }
        public int Proveedor_Id { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        [MaxLength(50)]
        public string? Descripcion { get; set; }

        [MaxLength(30)]
        public string? CodigoSerie { get; set; }
        public decimal PrecioCompra { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public bool Estado { get; set; }
        public DateTime? FechaAlta { get; set; }
    }
}
