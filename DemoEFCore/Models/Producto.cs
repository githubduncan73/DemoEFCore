using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace DemoEFCore.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Range(0, 99999.99)]
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public int CategoriaId { get; set; }         // Clave foránea

        [JsonIgnore]
        public Categoria? Categoria { get; set; } // Navegación // ← el signo ? permite null
    }
}

