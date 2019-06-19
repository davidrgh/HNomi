using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.Entities
{
    public class TipoNominaEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Nocturnidad { get; set; }

        public virtual IEnumerable<DetallesTipoNominaEntity> Detalles { get; set; }
        public virtual IEnumerable<ImpuestosEntity> Impuestos { get; set; }
    }
}
