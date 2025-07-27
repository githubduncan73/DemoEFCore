using DemoEFCore.DTOs;
using DemoEFCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoEFCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductoController(IProductoService service)
        {
            _service = service;
        }

        // GET: api/Producto
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productos = await _service.ObtenerTodos();
            return Ok(productos);
        }

        // GET: api/Producto/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var producto = await _service.ObtenerPorId(id);
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        // POST: api/Producto
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _service.Crear(dto);

            if (!creado)
                return BadRequest("No se pudo crear el producto."); // Si el servicio retorna false

            return Ok(creado); // También puedes usar CreatedAtAction si deseas retornar 201
        }

        // PUT: api/Producto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = await _service.Actualizar(id, dto);

            if (!actualizado)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Producto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _service.Eliminar(id);

            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}

