using HNomi.Entities;
using HNomi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.RepositoriesContracts
{
    public interface ITurnosTrabajoRepository
    {
        Task<TurnosTrabajoEntity> Get(int id);
        Task<IEnumerable<TurnosTrabajoEntity>> GetEntreFechas(DateTime desdeFecha, DateTime hastaFecha);
        Task<TurnosTrabajoEntity> Add(TurnosTrabajo turno);
        Task<TurnosTrabajoEntity> Edit(int id, TurnosTrabajo turno);
        Task<bool> Delete(int id);
        Task<bool> Exist(int id);
    }
}
