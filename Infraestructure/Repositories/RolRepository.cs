using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class RolRepository : IRol
    {
        private readonly AppDbContext _context;

        public RolRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rol>> All()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Rol> ObtenerId(Guid id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task Crear(Rol rol)
        {
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Rol rol)
        {
            _context.Roles.Update(rol);
            await _context.SaveChangesAsync();
        }
    }
}
