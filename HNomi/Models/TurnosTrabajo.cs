using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.Models
{
    public class TurnosTrabajo
    {
        public DateTime Fecha { get; set; }
        public bool EsTurnoPartido { get; set; }
        public DateTime HoraDesdeTurno1 { get; set; }
        public DateTime HoraDesdeTurno2 { get; set; }
        public DateTime HoraHastaTurno1 { get; set; }
        public DateTime HoraHastaTurno2 { get; set; }
    }
}
