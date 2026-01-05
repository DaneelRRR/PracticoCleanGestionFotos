using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Inmueble
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; } = string.Empty; // Ej: 20001
        public string Direccion { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public ICollection<Foto> Fotos { get; set; } = new List<Foto>();
    }
}
