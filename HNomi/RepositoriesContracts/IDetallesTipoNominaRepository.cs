using HNomi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.RepositoriesContracts
{
    public interface IDetallesTipoNominaRepository
    {
        Task<DetallesTipoNominaEntity> Get(int id);
        Task<IEnumerable<DetallesTipoNominaEntity>> GetByNomina(int idNomina);
        Task<DetallesTipoNominaEntity> Add(int nominaId, DetallesTipoNominaEntity tipoNomina);
        Task<DetallesTipoNominaEntity> Edit(int id, DetallesTipoNominaEntity tipoNomina);
        Task<bool> Delete(int id);
        Task<bool> Exist(int id);
    }
}
