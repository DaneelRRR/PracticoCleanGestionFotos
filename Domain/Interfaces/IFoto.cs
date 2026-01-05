using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFoto
    {
        Task<IEnumerable<Foto>> All();
        // Metodo para traer fotos de un inmueble
        Task<IEnumerable<Foto>> ObtenerPorInmueble(Guid inmuebleId);
        Task<Foto> ObtenerId(Guid id);
        Task Crear(Foto foto);
        Task Actualizar(Foto foto);
    }
}
