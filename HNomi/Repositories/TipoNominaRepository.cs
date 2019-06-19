using HNomi.Entities;
using HNomi.RepositoriesContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.Repositories
{
    public class TipoNominaRepository : ITipoNominaRepository
    {
        private readonly HNomiContext _context;

        public TipoNominaRepository(HNomiContext context)
        {
            _context = context;
        }

        public async Task<bool> Exist(int id)
        {
            var tipoNomina = await _context.TiposNomina.FindAsync(id);

            return (tipoNomina != null);
        }

        public async Task<TipoNominaEntity> Get(int id)
        {
            var nominaRecuperada = await _context.TiposNomina.FindAsync(id);

            return nominaRecuperada;
        }

        public async Task<TipoNominaEntity> GetEstructura(int id)
        {
            var nominaRecuperada = _context.TiposNomina.Where(n => n.Id == id).Include(n => n.Detalles).Include(n=>n.Impuestos).FirstOrDefault();

            return nominaRecuperada;
        }

        public async Task<TipoNominaEntity> Add(TipoNominaEntity tipoNomina)
        {
            _context.TiposNomina.Add(tipoNomina);
            _context.SaveChanges();

            return tipoNomina;
        }

        public async Task<TipoNominaEntity> Edit(int id, TipoNominaEntity tipoNomina)
        {
            var nominaOriginal = await Get(id);

            nominaOriginal.Nombre = tipoNomina.Nombre;
            nominaOriginal.Nocturnidad = tipoNomina.Nocturnidad;

            _context.TiposNomina.Update(nominaOriginal);
            _context.SaveChanges();

            return nominaOriginal;
        }
    }
}
