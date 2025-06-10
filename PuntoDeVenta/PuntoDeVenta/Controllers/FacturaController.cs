using Microsoft.AspNetCore.Mvc;
using PuntoDeVenta.Data;
using PuntoDeVenta.DTO;
using PuntoDeVenta.Services;
using AutoMapper;

namespace PuntoDeVenta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _service;
        private readonly IMapper _mapper;

        public FacturaController(IFacturaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var facturas = await _service.GetAll();
            var facturasDTO = _mapper.Map<List<FacturaDTO>>(facturas);
            return Ok(facturasDTO);
        }

        [HttpGet("{id}/detalles")]
        public async Task<IActionResult> GetDetalles(int id)
        {
            var detalles = await _service.GetDetalles(id);
            var detallesDTO = _mapper.Map<List<DetalleFacturaDTO>>(detalles);
            return Ok(detallesDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FacturaDTO dto)
        {
            var factura = _mapper.Map<Factura>(dto);
            var detalles = _mapper.Map<List<DetalleFactura>>(dto.Detalles);

            await _service.AddFactura(factura, detalles);
            return Ok(dto);
        }
    }
}
