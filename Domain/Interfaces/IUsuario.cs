using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsuario
    {
        Task<IEnumerable<Usuario>> All();
        Task<Usuario> ObtenerId(Guid id);
        Task<Usuario> ObtenerPorEmail(string email); // Extra util
        Task Crear(Usuario usuario);
        Task Actualizar(Usuario usuario);
    }
}
