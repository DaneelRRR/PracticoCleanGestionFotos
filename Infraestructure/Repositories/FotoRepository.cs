using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class FotoRepository : IFoto
    {
        private readonly AppDbContext _context;

        public FotoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Foto>> All()
        {
            return await _context.Fotos.ToListAsync();
        }

        public async Task<IEnumerable<Foto>> ObtenerPorInmueble(Guid inmuebleId)
        {
            return await _context.Fotos
                                 .Where(f => f.InmuebleId == inmuebleId)
                                 .ToListAsync();
        }

        public async Task<Foto> ObtenerId(Guid id)
        {
            return await _context.Fotos.FindAsync(id);
        }

        public async Task Crear(Foto foto)
        {
            _context.Fotos.Add(foto);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Foto foto)
        {
            _context.Fotos.Update(foto);
            await _context.SaveChangesAsync();
        }
    }
}