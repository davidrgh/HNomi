﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.Entities
{
    [Table("TurnosTrabajo")]
    public class TurnosTrabajoEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public bool EsTurnoPartido { get; set; }
        [Required]
        public DateTime HoraDesdeTurno1 { get; set; }
        [Required]
        public DateTime HoraDesdeTurno2 { get; set; }
        public DateTime? HoraHastaTurno1 { get; set; }
        public DateTime? HoraHastaTurno2 { get; set; }
    }
}
