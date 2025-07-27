using DemoEFCore.DTOs;

namespace DemoEFCore.Services
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoDTO>> ObtenerTodos();
        Task<ProductoDTO?> ObtenerPorId(int id);
        Task<bool> Crear(ProductoDTO dto);
        Task<bool> Actualizar(int id, ProductoDTO dto);
        Task<bool> Eliminar(int id);
    }
}