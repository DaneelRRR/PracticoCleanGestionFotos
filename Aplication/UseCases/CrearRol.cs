using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Aplication.UseCases
{
    public class CrearRol
    {
        private readonly IRol _rolRepositorie;

        public CrearRol(IRol rolRepositorie)
        {
            _rolRepositorie = rolRepositorie;
        }

        public async Task EjecutarAsync(Rol rol)
        {
            if (string.IsNullOrWhiteSpace(rol.Nombre))
            {
                throw new ArgumentException("El nombre del rol es obligatorio.");
            }

            await _rolRepositorie.Crear(rol);
        }
    }
}
