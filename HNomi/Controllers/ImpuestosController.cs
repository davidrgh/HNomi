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
    public class ImpuestosController : ControllerBase
    {

        private readonly IImpuestosService _impuestosService;

        public ImpuestosController(IImpuestosService impuestosService)
        {
            _impuestosService = impuestosService;
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var impuesto = await _impuestosService.GetImpuesto(id);
            if (impuesto != null)
            {
                return Ok(impuesto);
            }
            else
            {
                return NotFound();
            }
        }

        /*[ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerTodosNomina(int id)
        {
            var impuesto = await _impuestosService.GetImpuestosNomina(nominaId);
            if (impuesto != null)
            {
                return Ok(impuesto);
            }
            else
            {
                return NotFound();
            }
        }*/

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPost]
        public async Task<IActionResult> Nuevo(int nominaId, [FromBody]ImpuestosModel impuesto)
        {
            var impuestoGrabado = await _impuestosService.NuevoImpuesto(nominaId, Mapper.Map<Impuesto>(impuesto));

            if (impuestoGrabado != null)
            {
                return Ok(impuestoGrabado);
            }
            else
            {
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut]
        public async Task<IActionResult> Actualizar(int id, [FromBody]ImpuestosModel impuesto)
        {
            var impuestoActualizado = await _impuestosService.ActualizarImpuesto(id, Mapper.Map<Impuesto>(impuesto));

            if (impuestoActualizado != null)
            {
                return Ok(impuestoActualizado);
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
            var resultado = await _impuestosService.BorrarImpuesto(id);

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