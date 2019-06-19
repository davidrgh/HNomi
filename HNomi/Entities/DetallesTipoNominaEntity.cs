using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.Entities
{
    public class DetallesTipoNominaEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool TieneRetencion { get; set; }
        public bool EsPorUnidad { get; set; }
        public double Precio { get; set; }
        public int? NominaId { get; set; }


        public virtual TipoNominaEntity Nomina { get; set; }
    }
}
