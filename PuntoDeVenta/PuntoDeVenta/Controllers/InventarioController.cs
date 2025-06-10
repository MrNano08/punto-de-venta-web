using Microsoft.AspNetCore.Mvc;
using PuntoDeVenta.Data;
using PuntoDeVenta.DTO;
using PuntoDeVenta.Services;
using AutoMapper;

namespace PuntoDeVenta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : ControllerBase
    {
        private readonly IInventarioService _service;
        private readonly IMapper _mapper;

        public InventarioController(IInventarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _service.GetAll();
            var dtoList = _mapper.Map<List<InventarioDTO>>(lista);
            return Ok(dtoList);
        }

        [HttpPost]
        public async Task<IActionResult> Add(InventarioDTO dto)
        {
            var inv = _mapper.Map<Inventario>(dto);
            await _service.Add(inv);
            return Ok(_mapper.Map<InventarioDTO>(inv));
        }
    }
}
