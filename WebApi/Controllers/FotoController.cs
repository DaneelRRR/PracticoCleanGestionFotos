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
    public class FotoController : ControllerBase
    {
        private readonly IFoto _fotoRepositorie;
        private readonly IMapper _mapper;
        private readonly SubirFoto _subirFoto;
        private readonly SeleccionarFoto _seleccionarFoto;

        public FotoController(IFoto fotoRepositorie, IMapper mapper, SubirFoto subirFoto, SeleccionarFoto seleccionarFoto)
        {
            _fotoRepositorie = fotoRepositorie;
            _mapper = mapper;
            _subirFoto = subirFoto;
            _seleccionarFoto = seleccionarFoto;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var fotos = await _fotoRepositorie.All();
            return Ok(_mapper.Map<IEnumerable<FotoDTOs>>(fotos));
        }

        [HttpGet("PorInmueble/{inmuebleId}")]
        public async Task<IActionResult> GetByInmueble(Guid inmuebleId)
        {
            var fotos = await _fotoRepositorie.ObtenerPorInmueble(inmuebleId);
            return Ok(_mapper.Map<IEnumerable<FotoDTOs>>(fotos));
        }

        [HttpPost]
        public async Task<IActionResult> Subir([FromBody] FotoDTOs dto)
        {
            try
            {
                var foto = _mapper.Map<Foto>(dto);
                await _subirFoto.EjecutarAsync(foto);
                // Devolvemos el objeto con el ID generado y la ruta simulada
                return Ok(_mapper.Map<FotoDTOs>(foto));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("Seleccionar/{id}")]
        public async Task<IActionResult> Seleccionar(Guid id, [FromQuery] bool esFavorita)
        {
            try
            {
                await _seleccionarFoto.EjecutarAsync(id, esFavorita);
                return Ok(new { message = esFavorita ? "Foto marcada como favorita" : "Foto desmarcada" });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
