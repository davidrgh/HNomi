using AutoMapper;
using HNomi.Entities;
using HNomi.Models;
using HNomi.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HNomiTest
{
    public class TipoNominaServiceFake : ITipoNominaService
    {

        private MySqlDbFake _mysql;

        public TipoNominaServiceFake()
        {
            _mysql = new MySqlDbFake();
            using (var context = _mysql.GetDBContext())
            {
                context.TiposNomina.Add(new TipoNominaEntity { Nombre = "Nomina 1", Nocturnidad = new DateTime(2019, 6, 30, 0, 0, 0, 0) });
                context.TiposNomina.Add(new TipoNominaEntity { Nombre = "Nomina 2", Nocturnidad = new DateTime(2019, 6, 30, 23, 0, 0, 0) });
                context.TiposNomina.Add(new TipoNominaEntity { Nombre = "Nomina 3", Nocturnidad = new DateTime(2019, 6, 30, 23, 30, 0, 0) });
            }
        }

        public Task<TipoNomina> ActualizarNomina(int id, TipoNomina nomina)
        {
            throw new NotImplementedException();
        }

        public Task<bool> BorrarNomina(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EstructuraNomina> GetEstructuraNomina(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TipoNomina> GetNomina(int id)
        {
            using (var context = _mysql.GetDBContext())
            {
                var tipoNomina = context.TiposNomina.Find(id);
                TipoNomina nomina = Mapper.Map<TipoNomina>(tipoNomina);

                return nomina;
            }
        }

        public Task<TipoNomina> NuevaNomina(TipoNomina nomina)
        {
            throw new NotImplementedException();
        }
    }
}
