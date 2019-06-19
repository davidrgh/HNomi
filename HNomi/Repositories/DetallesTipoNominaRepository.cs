using HNomi.Entities;
using HNomi.RepositoriesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.Repositories
{
    public class DetallesTipoNominaRepository : IDetallesTipoNominaRepository
    {
        private readonly HNomiContext _context;

        public DetallesTipoNominaRepository(HNomiContext context)
        {
            _context = context;
        }

        public async Task<bool> Exist(int id)
        {
            var detalles = await _context.DetallesTipoNomina.FindAsync(id);

            return (detalles != null);
        }

        public async Task<DetallesTipoNominaEntity> Get(int id)
        {
            var detallesRecuperados = await _context.DetallesTipoNomina.FindAsync(id);

            return detallesRecuperados;
        }

        public async Task<IEnumerable<DetallesTipoNominaEntity>> GetByNomina(int idNomina)
        {
            var detallesNomina = _context.DetallesTipoNomina.Where(d => d.NominaId == idNomina).ToList<DetallesTipoNominaEntity>();

            return detallesNomina;
        }

        public async Task<DetallesTipoNominaEntity> Add(int nominaId, DetallesTipoNominaEntity detalles)
        {
            detalles.NominaId = nominaId;
            _context.DetallesTipoNomina.Add(detalles);
            _context.SaveChanges();

            return detalles;
        }

        public async Task<DetallesTipoNominaEntity> Edit(int id, DetallesTipoNominaEntity detalles)
        {
            var detallesOriginales = await Get(id);

            detallesOriginales.Nombre = detalles.Nombre;
            detallesOriginales.TieneRetencion = detalles.TieneRetencion;
            detallesOriginales.EsPorUnidad = detalles.EsPorUnidad;
            detallesOriginales.Precio = detalles.Precio;


            _context.DetallesTipoNomina.Update(detallesOriginales);
            _context.SaveChanges();

            return detallesOriginales;
        }

        public async Task<bool> Delete(int id)
        {
            if (!await Exist(id))
            {
                return false;
            }

            var detalle = await Get(id);
            _context.DetallesTipoNomina.Remove(detalle);

            return true;
        }
    }
}
