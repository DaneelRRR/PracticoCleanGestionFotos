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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuarioRepositorie;
        private readonly IMapper _mapper;
        private readonly RegistrarUsuario _registrarUsuario;

        public UsuarioController(IUsuario usuarioRepositorie, IMapper mapper, RegistrarUsuario registrarUsuario)
        {
            _usuarioRepositorie = usuarioRepositorie;
            _mapper = mapper;
            _registrarUsuario = registrarUsuario;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioRepositorie.All();
            return Ok(_mapper.Map<IEnumerable<UsuarioDTOs>>(usuarios));
        }

        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] UsuarioDTOs dto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(dto);
                await _registrarUsuario.EjecutarAsync(usuario);
                return CreatedAtAction(nameof(GetAll), new { id = usuario.Id }, dto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
