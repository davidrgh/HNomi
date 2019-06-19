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
    public class TipoNominaController : ControllerBase
    {

        private readonly ITipoNominaService _tipoNominaService;

        public TipoNominaController(ITipoNominaService tipoNominaService)
        {
            _tipoNominaService = tipoNominaService;
        }

        
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var nomina = await _tipoNominaService.GetNomina(id);
            if (nomina != null)
            {
                return Ok(nomina);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet("Todo/{id}")]
        public async Task<IActionResult> ObtenerEstructuraNomina(int id)
        {
            var nomina = await _tipoNominaService.GetEstructuraNomina(id);
            if (nomina != null)
            {
                return Ok(nomina);
            }
            else
            {
                return NotFound();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPost]
        public async Task<IActionResult> Nuevo([FromBody]TipoNominaModel tipoNomina)
        {
            var nomina = await _tipoNominaService.NuevaNomina(Mapper.Map<TipoNomina>(tipoNomina));

            if (nomina != null)
            {
                return Ok(nomina);
            }
            else
            {
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut]
        public async Task<IActionResult> Actualizar(int id, [FromBody]TipoNominaModel tipoNomina)
        {
            var nomina = await _tipoNominaService.ActualizarNomina(id, Mapper.Map<TipoNomina>(tipoNomina));

            if (nomina != null)
            {
                return Ok(nomina);
            }
            else
            {
                return NotFound();
            }
        }

    }
}