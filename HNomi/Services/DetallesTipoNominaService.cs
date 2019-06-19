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
    public class DetallesTipoNominaService : IDetallesTipoNominaService
    {

        private readonly IDetallesTipoNominaRepository _repository;
        private readonly ITipoNominaRepository _repositoryTipo;

        public DetallesTipoNominaService(IDetallesTipoNominaRepository repository, ITipoNominaRepository repositoryTipo)
        {
            _repository = repository;
            _repositoryTipo = repositoryTipo;
        }

        public async Task<DetallesTipoNomina> GetDetalles(int id)
        {
            var detallesRecuperados = await _repository.Get(id);

            var detalles = Mapper.Map<DetallesTipoNomina>(detallesRecuperados);

            return detalles;
        }

        public async Task<IEnumerable<DetallesTipoNomina>> GetDetallesNomina(int nominaId)
        {
            var detallesRecuperados = await _repository.GetByNomina(nominaId);

            var detalles = detallesRecuperados.Select(Mapper.Map<DetallesTipoNomina>);

            return detalles;
        }

        public async Task<DetallesTipoNomina> NuevoDetalle(int nominaId, DetallesTipoNomina detalles)
        {
            var detallesGrabar = Mapper.Map<DetallesTipoNominaEntity>(detalles);

            if (! await _repositoryTipo.Exist(nominaId))
            {
                return null;
            }

            await _repository.Add(nominaId, detallesGrabar);

            return detalles;

        }
        public async Task<DetallesTipoNomina> ActualizarDetalles(int id, DetallesTipoNomina detalles)
        {
            var detallesActualizar = Mapper.Map<DetallesTipoNominaEntity>(detalles);

            if (! await _repository.Exist(id))
            {
                return null;
            }

            await _repository.Edit(id, detallesActualizar);

            return detalles;
        }

        public async Task<bool> BorrarDetalle(int id)
        {
            var resultado = _repository.Delete(id);

            return await resultado;
        }
    }
}
