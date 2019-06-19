using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.Entities
{
    public class ImpuestosEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Porcentaje { get; set; }
        public int NominaId { get; set; }


        public virtual TipoNominaEntity Nomina { get; set; }
    }
}
