using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRol
    {
        Task<IEnumerable<Rol>> All();
        Task<Rol> ObtenerId(Guid id);
        Task Crear(Rol rol);
        Task Actualizar(Rol rol);
    }
}
