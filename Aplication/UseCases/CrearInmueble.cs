using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Aplication.UseCases
{
    public class CrearInmueble
    {
        private readonly IInmueble _inmuebleRepositorie;

        public CrearInmueble(IInmueble inmuebleRepositorie)
        {
            _inmuebleRepositorie = inmuebleRepositorie;
        }

        public async Task EjecutarAsync(Inmueble inmueble)
        {
            ValidarInmueble(inmueble);
            inmueble.FechaRegistro = DateTime.Now;
            await _inmuebleRepositorie.Crear(inmueble);
        }

        public void ValidarInmueble(Inmueble inmueble)
        {
            if (string.IsNullOrWhiteSpace(inmueble.Codigo))
            {
                throw new ArgumentException("El código del inmueble es obligatorio.");
            }
            if (string.IsNullOrWhiteSpace(inmueble.Direccion))
            {
                throw new ArgumentException("La dirección es obligatoria.");
            }
        }
    }
}