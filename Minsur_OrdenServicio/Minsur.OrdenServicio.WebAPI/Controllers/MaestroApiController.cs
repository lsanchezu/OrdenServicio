using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minsur.OrdenServicio.Application.Contract.Maestro;

namespace Minsur.OrdenServicio.WebAPI.Controllers
{
    [Route("api/maestro")]
    [ApiController]
    public class MaestroApiController : ControllerBase
    {
        private readonly IMaestroService oIMaestroService;

        public MaestroApiController(IMaestroService oIMaestroService)
        {
            this.oIMaestroService = oIMaestroService;
        }

        [HttpGet("solicitud/{idUsuario}")]
        public IActionResult ObtenerMaestroSolicitud(int idUsuario)
        {
            return Ok(
                    oIMaestroService.ObtenerMaestroSolicitud(idUsuario)
                );
        }

        [HttpGet("proyectos")]
        public IActionResult ListarProyectoPorUsuario([FromQuery] int idUsuario, [FromQuery] int idCompania)
        {
            return Ok(
                    oIMaestroService.ListarProyectoPorUsuario(idUsuario, idCompania)
                );
        }
    }
}