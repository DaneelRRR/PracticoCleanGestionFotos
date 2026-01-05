using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IInmueble
    {
        Task<IEnumerable<Inmueble>> All();
        Task<Inmueble> ObtenerId(Guid id);
        Task Crear(Inmueble inmueble);
        Task Actualizar(Inmueble inmueble);
    }
}
