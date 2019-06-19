using AutoMapper;
using HNomi.Entities;
using HNomi.Models;
using HNomi.RepositoriesContracts;
using HNomi.ServicesContracts;
using Serilog;
using Serilog.Formatting.Compact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.Services
{
    public class TurnosTrabajoService : ITurnosTrabajoService
    {

        private readonly ITurnosTrabajoRepository _repository;

        public TurnosTrabajoService(ITurnosTrabajoRepository repository)
        {
            _repository = repository;
        }

        public async Task<TurnosTrabajo> GetTurno(int id)
        {
            var turnoRecuperado = await _repository.Get(id);

            var turno = Mapper.Map<TurnosTrabajo>(turnoRecuperado);

            return turno;
        }

        public async Task<IEnumerable<TurnosTrabajo>> GetTurnosEntreFechas(DateTime desdeFecha, DateTime hastaFecha)
        {
            var turnosRecuperados = await _repository.GetEntreFechas(desdeFecha, hastaFecha);

            var turnos = turnosRecuperados.Select(Mapper.Map<TurnosTrabajo>);

            return turnos;
        }
        

        public async Task<TurnosTrabajo> NuevoTurno(TurnosTrabajo turno)
        {
            var turnoGrabar = Mapper.Map<TurnosTrabajoEntity>(turno);

            if (await _repository.Exist(turnoGrabar.Id))
            {
                return null;
            }

            await _repository.Add(turno);

            return turno;

        }
        public async Task<TurnosTrabajo> Actualizarturno(int id, TurnosTrabajo turno)
        {
            var turnoActualizar = Mapper.Map<TipoNominaEntity>(turno);

            if (!await _repository.Exist(id))
            {
                return null;
            }

            await _repository.Edit(id, turno);

            return turno;
        }

        public async Task<bool> BorrarTurno(int id)
        {

            if (!await _repository.Exist(id))
            {
                return false;
            }

            await _repository.Delete(id);

            return true;
        }
    }
}
