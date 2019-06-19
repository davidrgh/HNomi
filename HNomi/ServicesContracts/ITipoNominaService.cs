

using HNomi.Entities;
using HNomi.Models;
using System.Threading.Tasks;

namespace HNomi.ServicesContracts
{
    public interface ITipoNominaService
    {

        Task<TipoNomina> GetNomina(int id);
        Task<EstructuraNomina> GetEstructuraNomina(int id);
        Task<TipoNomina> NuevaNomina(TipoNomina nomina);
        Task<TipoNomina> ActualizarNomina(int id, TipoNomina nomina);
        Task<bool> BorrarNomina(int id);

    }
}
