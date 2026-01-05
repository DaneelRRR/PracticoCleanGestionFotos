using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    public class FotoDTOs
    {
        public string NombreArchivo { get; set; } = string.Empty;
        public string RutaLocal { get; set; } = string.Empty;
        public string Ambiente { get; set; } = string.Empty;
        public bool EsEditada { get; set; }
        public bool EsSeleccionada { get; set; }
        public Guid InmuebleId { get; set; }
    }
}
