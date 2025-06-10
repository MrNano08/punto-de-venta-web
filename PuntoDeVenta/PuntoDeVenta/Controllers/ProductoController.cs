using Microsoft.AspNetCore.Mvc;
using PuntoDeVenta.Data;
using PuntoDeVenta.DTO;
using PuntoDeVenta.Services;
using AutoMapper;

namespace PuntoDeVenta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;
        private readonly IMapper _mapper;

        public ProductoController(IProductoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _service.Get(null);
            var productosDTO = _mapper.Map<List<ProductoDTO>>(productos);
            return Ok(productosDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var producto = (await _service.Get(new[] { id.ToString() })).FirstOrDefault();
            if (producto == null) return NotFound();

            var dto = _mapper.Map<ProductoDTO>(producto);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductoDTO dto)
        {
            var producto = _mapper.Map<Producto>(dto);
            await _service.Add(producto);
            return Ok(_mapper.Map<ProductoDTO>(producto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductoDTO dto)
        {
            if (id != dto.Id) return BadRequest("El ID no coincide.");

            var producto = _mapper.Map<Producto>(dto);
            var actualizado = await _service.Update(producto);
            if (actualizado == null) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var producto = (await _service.Get(new[] { id.ToString() })).FirstOrDefault();
            if (producto == null) return NotFound();

            await _service.Delete(producto);
            return NoContent();
        }
    }
}
