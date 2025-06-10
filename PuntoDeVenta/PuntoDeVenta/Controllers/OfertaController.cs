using Microsoft.AspNetCore.Mvc;
using PuntoDeVenta.Data;
using PuntoDeVenta.DTO;
using PuntoDeVenta.Services;
using AutoMapper;

namespace PuntoDeVenta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfertaController : ControllerBase
    {
        private readonly IOfertaService _service;
        private readonly IMapper _mapper;

        public OfertaController(IOfertaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _service.GetAll();
            var dtoList = _mapper.Map<List<OfertaDTO>>(lista);
            return Ok(dtoList);
        }

        [HttpPost]
        public async Task<IActionResult> Add(OfertaDTO dto)
        {
            var o = _mapper.Map<Oferta>(dto);
            await _service.Add(o);
            return Ok(_mapper.Map<OfertaDTO>(o));
        }
    }
}
