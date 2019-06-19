using AutoMapper;
using HNomi.Entities;
using HNomi.Models;
using HNomi.RepositoriesContracts;
using HNomi.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.Services
{
    public class TipoNominaService : ITipoNominaService
    {

        private readonly ITipoNominaRepository _repository;

        public TipoNominaService(ITipoNominaRepository repository)
        {
            _repository = repository;
        }

        public async Task<TipoNomina> GetNomina(int id)
        {
            var nominaRecuperada = await _repository.Get(id);

            var nomina = Mapper.Map<TipoNomina>(nominaRecuperada);

            return nomina;
        }

        public async Task<EstructuraNomina> GetEstructuraNomina(int id)
        {
            var nominaRecuperada = await _repository.GetEstructura(id);

            var nomina = Mapper.Map<EstructuraNomina>(nominaRecuperada);

            return nomina;
        }
        

        public async Task<TipoNomina> NuevaNomina(TipoNomina nomina)
        {
            var nominaGrabar = Mapper.Map<TipoNominaEntity>(nomina);

            if (await _repository.Exist(nominaGrabar.Id))
            {
                return null;
            }

            await _repository.Add(nominaGrabar);

            return nomina;

        }
        public async Task<TipoNomina> ActualizarNomina(int id, TipoNomina nomina)
        {
            var nominaActualizar = Mapper.Map<TipoNominaEntity>(nomina);

            if (! await _repository.Exist(id))
            {
                return null;
            }

            await _repository.Edit(id, nominaActualizar);

            return nomina;
        }
    }
}
