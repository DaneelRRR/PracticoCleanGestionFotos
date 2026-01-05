using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Foto
    {
        public Guid Id { get; set; }
        public string NombreArchivo { get; set; } = string.Empty; // Ej: sala.jpg
        public string RutaLocal { get; set; } = string.Empty;     // Ej: D:/Fotos/20001/sala.jpg
        public string Ambiente { get; set; } = string.Empty;      // Ej: Cocina

        // Estado
        public bool EsEditada { get; set; } = false;
        public bool EsSeleccionada { get; set; } = false;

        // Pertenece a un Inmueble
        public Guid InmuebleId { get; set; }
        public Inmueble Inmueble { get; set; }
    }
}
