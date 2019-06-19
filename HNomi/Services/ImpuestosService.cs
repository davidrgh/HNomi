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
    public class ImpuestosService : IImpuestosService
    {

        private readonly IImpuestosRepository _repository;
        private readonly ITipoNominaRepository _repositoryTipo;

        public ImpuestosService(IImpuestosRepository repository, ITipoNominaRepository repositoryTipo)
        {
            _repository = repository;
            _repositoryTipo = repositoryTipo;
        }

        public async Task<Impuesto> GetImpuesto(int id)
        {
            var impuestoRecuperado = await _repository.Get(id);

            var impuesto = Mapper.Map<Impuesto>(impuestoRecuperado);

            return impuesto;
        }

        public async Task<IEnumerable<Impuesto>> GetImpuestosNomina(int nominaId)
        {
            var impuestosRecuperado = await _repository.GetByNomina(nominaId);

            var impuestos = impuestosRecuperado.Select(Mapper.Map<Impuesto>);

            return impuestos;
        }

        public async Task<Impuesto> NuevoImpuesto(int nominaId, Impuesto impuesto)
        {
            var impuestoGrabar = Mapper.Map<ImpuestosEntity>(impuesto);

            if (! await _repositoryTipo.Exist(nominaId))
            {
                return null;
            }


            await _repository.Add(nominaId, impuestoGrabar);

            return impuesto;

        }
        public async Task<Impuesto> ActualizarImpuesto(int id, Impuesto impuesto)
        {
            var impuestoActualizar = Mapper.Map<ImpuestosEntity>(impuesto);

            if (! await _repository.Exist(id))
            {
                return null;
            }

            await _repository.Edit(id, impuestoActualizar);

            return impuesto;
        }

        public async Task<bool> BorrarImpuesto(int id)
        {
            var resultado = _repository.Delete(id);

            return await resultado;
        }
    }
}
