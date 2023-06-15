using Microsoft.EntityFrameworkCore;

namespace StockWebFinal.Data
{
    public class StockWebFinalContext : DbContext
    {
        public StockWebFinalContext(DbContextOptions<StockWebFinalContext> options) : base(options)
        {
        }

        public DbSet<StockWebFinal.Models.Provincia> Provincia { get; set; } = default!;
        public DbSet<StockWebFinal.Models.Localidad> Localidad { get; set; } = default!;
        public DbSet<StockWebFinal.Models.Proveedor> Proveedor { get; set; } = default!;
        public DbSet<StockWebFinal.Models.Usuario> Usuario { get; set; } = default!;
        public DbSet<StockWebFinal.Models.Categoria> Categoria { get; set; } = default!;
        public DbSet<StockWebFinal.Models.Marca> Marca { get; set; } = default!;
        public DbSet<StockWebFinal.Models.Producto> Producto { get; set; } = default!;
        public DbSet<StockWebFinal.Models.Ingreso> Ingreso { get; set; } = default!;
        public DbSet<StockWebFinal.Models.Egreso> Egreso { get; set; } = default!;
    }
}
