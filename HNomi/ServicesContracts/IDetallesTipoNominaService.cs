

using HNomi.Entities;
using HNomi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HNomi.ServicesContracts
{
    public interface IDetallesTipoNominaService
    {

        Task<DetallesTipoNomina> GetDetalles(int id);
        Task<IEnumerable<DetallesTipoNomina>> GetDetallesNomina(int nominaId);
        Task<DetallesTipoNomina> NuevoDetalle(int nominaId, DetallesTipoNomina detalles);
        Task<DetallesTipoNomina> ActualizarDetalles(int id, DetallesTipoNomina detalles);
        Task<bool> BorrarDetalle(int id);
    }
}
