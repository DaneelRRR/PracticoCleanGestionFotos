using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aplication.DTOs;
using Aplication.UseCases;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InmuebleController : ControllerBase
    {
        private readonly IInmueble _inmuebleRepositorie;
        private readonly IMapper _mapper;
        private readonly CrearInmueble _crearInmueble;

        public InmuebleController(IInmueble inmuebleRepositorie, IMapper mapper, CrearInmueble crearInmueble)
        {
            _inmuebleRepositorie = inmuebleRepositorie;
            _mapper = mapper;
            _crearInmueble = crearInmueble;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var inmuebles = await _inmuebleRepositorie.All();
            var inmueblesDto = _mapper.Map<IEnumerable<InmuebleDTOs>>(inmuebles);
            return Ok(inmueblesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var inmueble = await _inmuebleRepositorie.ObtenerId(id);
            if (inmueble == null)
                return NotFound(new { mensaje = "Inmueble no encontrado" });

            var dto = _mapper.Map<InmuebleDTOs>(inmueble);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InmuebleDTOs dto)
        {
            try
            {
                var inmueble = _mapper.Map<Inmueble>(dto);
                await _crearInmueble.EjecutarAsync(inmueble);
                return CreatedAtAction(nameof(GetById), new { id = inmueble.Id }, dto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
