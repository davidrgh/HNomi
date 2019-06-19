using HNomi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.ServicesContracts
{
    public interface ITurnosTrabajoService
    {
        Task<TurnosTrabajo> GetTurno(int id);
        Task<IEnumerable<TurnosTrabajo>> GetTurnosEntreFechas(DateTime desdeFecha, DateTime hastaFecha);
        Task<TurnosTrabajo> NuevoTurno(TurnosTrabajo turno);
        Task<TurnosTrabajo> Actualizarturno(int id, TurnosTrabajo turno);
        Task<bool> BorrarTurno(int id);
    }
}
