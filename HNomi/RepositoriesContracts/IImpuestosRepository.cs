using HNomi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.RepositoriesContracts
{
    public interface IImpuestosRepository
    {
        Task<ImpuestosEntity> Get(int id);
        Task<IEnumerable<ImpuestosEntity>> GetByNomina(int nominaId);
        Task<ImpuestosEntity> Add(int nominaId, ImpuestosEntity impuesto);
        Task<ImpuestosEntity> Edit(int id, ImpuestosEntity impuesto);
        Task<bool> Delete(int id);
        Task<bool> Exist(int id);
    }
}
