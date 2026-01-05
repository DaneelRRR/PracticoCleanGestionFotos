using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class InmuebleRepository : IInmueble
    {
        private readonly AppDbContext _context;

        public InmuebleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inmueble>> All()
        {
            // Incluimos las fotos para verlas junto al inmueble
            return await _context.Inmuebles.Include(i => i.Fotos).ToListAsync();
        }

        public async Task<Inmueble> ObtenerId(Guid id)
        {
            return await _context.Inmuebles.Include(i => i.Fotos).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task Crear(Inmueble inmueble)
        {
            _context.Inmuebles.Add(inmueble);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Inmueble inmueble)
        {
            _context.Inmuebles.Update(inmueble);
            await _context.SaveChangesAsync();
        }
    }
}