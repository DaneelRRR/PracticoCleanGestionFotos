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
    public class RolController : ControllerBase
    {
        private readonly IRol _rolRepositorie;
        private readonly IMapper _mapper;
        private readonly CrearRol _crearRol;

        public RolController(IRol rolRepositorie, IMapper mapper, CrearRol crearRol)
        {
            _rolRepositorie = rolRepositorie;
            _mapper = mapper;
            _crearRol = crearRol;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _rolRepositorie.All();
            return Ok(_mapper.Map<IEnumerable<RolDTOs>>(roles));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RolDTOs dto)
        {
            try
            {
                var rol = _mapper.Map<Rol>(dto);
                await _crearRol.EjecutarAsync(rol);
                return Ok(_mapper.Map<RolDTOs>(rol));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
