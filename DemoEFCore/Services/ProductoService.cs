using AutoMapper;
using DemoEFCore.DTOs;
using DemoEFCore.Models;
using DemoEFCore.Repositories;

namespace DemoEFCore.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repo;
        private readonly IMapper _mapper;

        public ProductoService(IProductoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductoDTO>> ObtenerTodos()
        {
            var productos = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductoDTO>>(productos);
        }

     
        public async Task<ProductoDTO?> ObtenerPorId(int id)
        {
            // Simulamos un error cuando el id es -1
            if (id == -1)
                throw new Exception("Error forzado");

            var producto = await _repo.GetByIdAsync(id);
            return _mapper.Map<ProductoDTO?>(producto);
        }

        public async Task<bool> Crear(ProductoDTO dto)
        {
            var producto = _mapper.Map<Producto>(dto);
            await _repo.AddAsync(producto);
            return true;
        }

        public async Task<bool> Actualizar(int id, ProductoDTO dto)
        {
            var producto = await _repo.GetByIdAsync(id);
            if (producto == null) return false;

            _mapper.Map(dto, producto);
            await _repo.UpdateAsync(producto);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _repo.DeleteAsync(id);
            return true;
        }
    }
}
