using System.Collections.Generic;

namespace DemoEFCore.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Relación: una categoría tiene muchos productos
        public ICollection<Producto> Productos { get; set; }
    }
}
