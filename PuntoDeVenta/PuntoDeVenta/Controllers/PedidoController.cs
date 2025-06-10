using Microsoft.AspNetCore.Mvc;
using PuntoDeVenta.Data;
using PuntoDeVenta.DTO;
using PuntoDeVenta.Services;
using AutoMapper;

namespace PuntoDeVenta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _service;
        private readonly IMapper _mapper;

        public PedidoController(IPedidoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _service.GetAll();
            var dtoList = _mapper.Map<List<PedidoDTO>>(pedidos);
            return Ok(dtoList);
        }

        [HttpGet("{id}/detalles")]
        public async Task<IActionResult> GetDetalles(int id)
        {
            var detalles = await _service.GetDetalles(id);
            var detallesDTO = _mapper.Map<List<DetallePedidoDTO>>(detalles);
            return Ok(detallesDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PedidoDTO dto)
        {
            var pedido = _mapper.Map<Pedido>(dto);
            var detalles = _mapper.Map<List<DetallePedido>>(dto.Detalles);

            await _service.AddPedido(pedido, detalles);
            return Ok(dto);
        }
    }
}
