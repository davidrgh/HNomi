using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.Models
{
    public class EstructuraNomina
    {
        public string Nombre { get; set; }
        public DateTime Nocturnidad { get; set; }

        public IEnumerable<DetallesTipoNomina> Detalles { get; set; }
        public IEnumerable<Impuesto> Impuestos { get; set; } 

    }
}
