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
    public class TurnosTrabajoController : ControllerBase
    {

        private readonly ITurnosTrabajoService _turnosService;

        public TurnosTrabajoController(ITurnosTrabajoService turnosService)
        {
            _turnosService = turnosService;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var turno = await _turnosService.GetTurno(id);
            if (turno != null)
            {
                return Ok(turno);
            }
            else
            {
                return NotFound();
            }
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPost]
        public async Task<IActionResult> Nuevo([FromBody]TurnosTrabajoModel turnoTrabajo)
        {
            var turno = await _turnosService.NuevoTurno(Mapper.Map<TurnosTrabajo>(turnoTrabajo));

            if (turno != null)
            {
                return Ok(turno);
            }
            else
            {
                return BadRequest();
            }
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody]TurnosTrabajoModel turnoTrabajo)
        {
            var turno = await _turnosService.Actualizarturno(id, Mapper.Map<TurnosTrabajo>(turnoTrabajo));

            if (turno != null)
            {
                return Ok(turno);
            }
            else
            {
                return NotFound();
            }
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Borrar(int id)
        {
            var resultado = await _turnosService.BorrarTurno(id);

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