using HNomi.Entities;
using HNomi.RepositoriesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.Repositories
{
    public class ImpuestosRepository : IImpuestosRepository
    {
        private readonly HNomiContext _context;

        public ImpuestosRepository(HNomiContext context)
        {
            _context = context;
        }

        public async Task<bool> Exist(int id)
        {
            var impuesto = await _context.Impuestos.FindAsync(id);

            return (impuesto != null);
        }

        public async Task<ImpuestosEntity> Get(int id)
        {
            var impuestoRecuperado = await _context.Impuestos.FindAsync(id);

            return impuestoRecuperado;
        }

        public async Task<IEnumerable<ImpuestosEntity>> GetByNomina(int nominaId)
        {
            var impuestosRecuperado = _context.Impuestos.Where(i => i.NominaId == nominaId).ToList<ImpuestosEntity>();

            return impuestosRecuperado;
        }

        public async Task<ImpuestosEntity> Add(int nominaId, ImpuestosEntity impuesto)
        {
            impuesto.NominaId = nominaId;
            _context.Impuestos.Add(impuesto);
            _context.SaveChanges();

            return impuesto;
        }

        public async Task<ImpuestosEntity> Edit(int id, ImpuestosEntity impuesto)
        {
            var impuestoOriginal = await Get(id);

            impuestoOriginal.Nombre = impuesto.Nombre;
            impuestoOriginal.Porcentaje = impuesto.Porcentaje;

            _context.Impuestos.Update(impuestoOriginal);
            _context.SaveChanges();

            return impuestoOriginal;
        }

        public async Task<bool> Delete (int id)
        {
            if (! await Exist(id))
            {
                return false;
            }

            var impuesto = await Get(id);
            _context.Impuestos.Remove(impuesto);

            return true;
        }
    }
}
