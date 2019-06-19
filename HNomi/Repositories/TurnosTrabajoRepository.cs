using AutoMapper;
using HNomi.Entities;
using HNomi.Models;
using HNomi.RepositoriesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.Repositories
{
    public class TurnosTrabajoRepository : ITurnosTrabajoRepository
    {

        private readonly HNomiContext _context;

        public TurnosTrabajoRepository(HNomiContext context)
        {
            _context = context;
        }

        public async Task<TurnosTrabajoEntity> Add(TurnosTrabajo turno)
        {

            var turnoEntity = Mapper.Map<TurnosTrabajoEntity>(turno);
            _context.TurnosTrabajo.Add(turnoEntity);
            _context.SaveChanges();

            return turnoEntity;
        }

        public async Task<bool> Delete(int id)
        {
            if (! await Exist(id))
            {
                return false;
            }

            var turnoBorrar = _context.TurnosTrabajo.Find(id);
            _context.TurnosTrabajo.Remove(turnoBorrar);
            _context.SaveChanges();

            return true;
        }

        public async Task<TurnosTrabajoEntity> Edit(int id, TurnosTrabajo turno)
        {
            if (!await Exist(id))
            {
                return null;
            }

            var turnoActualizar = _context.TurnosTrabajo.Find(id);
            turnoActualizar.EsTurnoPartido = turno.EsTurnoPartido;
            turnoActualizar.Fecha = turno.Fecha;
            turnoActualizar.HoraDesdeTurno1 = turno.HoraDesdeTurno1;
            turnoActualizar.HoraDesdeTurno2 = turno.HoraDesdeTurno2;
            turnoActualizar.HoraHastaTurno1 = turno.HoraHastaTurno1;
            turnoActualizar.HoraHastaTurno2 = turno.HoraHastaTurno2;
            _context.SaveChanges();

            return turnoActualizar;
        }

        public async Task<bool> Exist(int id)
        {
            return (_context.TurnosTrabajo.Find(id) != null);
        }

        public async Task<TurnosTrabajoEntity> Get(int id)
        {
            var turno = _context.TurnosTrabajo.Find(id);

            return turno;
        }

        public async Task<IEnumerable<TurnosTrabajoEntity>> GetEntreFechas(DateTime desdeFecha, DateTime hastaFecha)
        {
            var turnos = _context.TurnosTrabajo.Where(t => ((t.Fecha >= desdeFecha) && (t.Fecha <= hastaFecha)));
            return turnos.ToList();
        }
    }
}
