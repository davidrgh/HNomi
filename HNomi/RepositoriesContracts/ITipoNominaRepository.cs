using HNomi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.RepositoriesContracts
{
    public interface ITipoNominaRepository
    {
        Task<TipoNominaEntity> Get(int id);
        Task<TipoNominaEntity> GetEstructura(int id);
        Task<TipoNominaEntity> Add(TipoNominaEntity tipoNomina);
        Task<TipoNominaEntity> Edit(int id, TipoNominaEntity tipoNomina);
        Task<bool> Delete(int id);
        Task<bool> Exist(int id);
    }
}
