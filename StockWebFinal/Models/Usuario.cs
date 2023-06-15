using System.ComponentModel.DataAnnotations;

namespace StockWebFinal.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string? NombreUsuario { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        [MaxLength(50)]
        public string? Apellido { get; set; }

        [MaxLength(50)]
        public string? Correo { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        [MaxLength(50)]
        public string? Clave { get; set; }
        public bool Administrador { get; set; }
        public DateTime? FechaAlta { get; set; }
        public bool Estado { get; set; }
    }
}
