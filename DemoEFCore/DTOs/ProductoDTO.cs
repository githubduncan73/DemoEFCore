//namespace DemoEFCore.DTOs
//{
//    public class ProductoDTO
//    {
//        public string Nombre { get; set; }
//        public decimal Precio { get; set; }
//        public int Stock { get; set; }
//        public int CategoriaId { get; set; }
//    }
//}

using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;

namespace DemoEFCore.DTOs
{
    public class ProductoDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; }

        [Range(1, 10000, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        [Range(0, 1000, ErrorMessage = "El stock debe estar entre 0 y 1000")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una categoría")]
        public int CategoriaId { get; set; }
    }
}


