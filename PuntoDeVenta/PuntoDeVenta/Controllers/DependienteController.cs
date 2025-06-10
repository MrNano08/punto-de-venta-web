using Microsoft.AspNetCore.Mvc;
using PuntoDeVenta.Data;
using PuntoDeVenta.DTO;
using PuntoDeVenta.Services;
using AutoMapper;

namespace PuntoDeVenta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DependienteController : ControllerBase
    {
        private readonly IDependienteService _service;
        private readonly IMapper _mapper;

        public DependienteController(IDependienteService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()   
        {
            var lista = await _service.GetAll();
            var dtoList = _mapper.Map<List<DependienteDTO>>(lista);
            return Ok(dtoList);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DependienteDTO dto)
        {
            var dependiente = _mapper.Map<Dependiente>(dto);
            await _service.Add(dependiente);
            return Ok(_mapper.Map<DependienteDTO>(dependiente));
        }
    }
}
