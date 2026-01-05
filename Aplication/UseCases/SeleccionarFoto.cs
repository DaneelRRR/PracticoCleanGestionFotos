using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Aplication.UseCases
{
    public class SeleccionarFoto
    {
        private readonly IFoto _fotoRepositorie;

        public SeleccionarFoto(IFoto fotoRepositorie)
        {
            _fotoRepositorie = fotoRepositorie;
        }

        // Recibimos el ID y el estado
        public async Task EjecutarAsync(Guid fotoId, bool seleccionada)
        {
            var foto = await _fotoRepositorie.ObtenerId(fotoId);

            if (foto == null)
            {
                throw new ArgumentException("La foto no existe.");
            }

            foto.EsSeleccionada = seleccionada;

            await _fotoRepositorie.Actualizar(foto);
        }
    }
}
