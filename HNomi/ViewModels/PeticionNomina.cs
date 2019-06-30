using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.ViewModels
{
    public class PeticionNomina
    {
        public int TipoNomina { get; set; }
        public DateTime desdeFecha { get; set; }
        public DateTime HastaFecha { get; set; }
    }
}
