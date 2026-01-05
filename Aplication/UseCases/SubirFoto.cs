using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Aplication.UseCases
{
    public class SubirFoto
    {
        private readonly IFoto _fotoRepositorie;
        private readonly IInmueble _inmuebleRepositorie;

        public SubirFoto(IFoto fotoRepositorie, IInmueble inmuebleRepositorie)
        {
            _fotoRepositorie = fotoRepositorie;
            _inmuebleRepositorie = inmuebleRepositorie;
        }

        public async Task EjecutarAsync(Foto foto)
        {
            await ValidarFoto(foto);

            // Simulacion de guardado
            if (string.IsNullOrWhiteSpace(foto.RutaLocal))
            {
                // Simulamos que se guardo en el disco D:
                foto.RutaLocal = $@"D:\FotosInmobiliaria\{foto.InmuebleId}\{foto.NombreArchivo}";
            }

            await _fotoRepositorie.Crear(foto);
        }

        public async Task ValidarFoto(Foto foto)
        {
            if (string.IsNullOrWhiteSpace(foto.NombreArchivo))
            {
                throw new ArgumentException("La foto debe tener un nombre de archivo.");
            }
            if (foto.InmuebleId == Guid.Empty)
            {
                throw new ArgumentException("La foto debe estar asociada a un inmueble.");
            }

            // Verificar que el inmueble exista
            var inmueble = await _inmuebleRepositorie.ObtenerId(foto.InmuebleId);
            if (inmueble == null)
            {
                throw new ArgumentException("El inmueble especificado no existe.");
            }
        }
    }
}
