using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HNomi.Models;
using HNomi.ServicesContracts;
using HNomi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HNomi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesTipoNominaController : ControllerBase
    {

        private readonly IDetallesTipoNominaService _detallesTipoNominaService;

        public DetallesTipoNominaController(IDetallesTipoNominaService detallesTipoNominaService)
        {
            _detallesTipoNominaService = detallesTipoNominaService;
        }

        
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var detalles = await _detallesTipoNominaService.GetDetalles(id);
            if (detalles != null)
            {
                return Ok(detalles);
            }
            else
            {
                return NotFound();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPost]
        public async Task<IActionResult> Nuevo(int nominaId, [FromBody]DetallesTipoNominaModel detallesTipoNomina)
        {
            var detalles = await _detallesTipoNominaService.NuevoDetalle(nominaId, Mapper.Map<DetallesTipoNomina>(detallesTipoNomina));

            if (detalles != null)
            {
                return Ok(detalles);
            }
            else
            {
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut]
        public async Task<IActionResult> Actualizar(int id, [FromBody]DetallesTipoNominaModel detallesTipoNomina)
        {
            var detalles = await _detallesTipoNominaService.ActualizarDetalles(id, Mapper.Map<DetallesTipoNomina>(detallesTipoNomina));

            if (detalles != null)
            {
                return Ok(detalles);
            }
            else
            {
                return NotFound();
            }
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete]
        public async Task<IActionResult> Borrar(int id)
        {
            var resultado = await _detallesTipoNominaService.BorrarDetalle(id);

            if (resultado)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}