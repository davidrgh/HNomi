

using HNomi.Entities;
using HNomi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HNomi.ServicesContracts
{
    public interface IImpuestosService
    {

        Task<Impuesto> GetImpuesto(int id);
        Task<IEnumerable<Impuesto>> GetImpuestosNomina(int nominaId);
        Task<Impuesto> NuevoImpuesto(int nominaId, Impuesto impuesto);
        Task<Impuesto> ActualizarImpuesto(int id, Impuesto impuesto);
        Task<bool> BorrarImpuesto(int id);

    }
}
