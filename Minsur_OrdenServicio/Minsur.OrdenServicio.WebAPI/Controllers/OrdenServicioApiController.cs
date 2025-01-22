using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minsur.OrdenServicio.Application.Contract.Solicitud;
using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Body;

namespace Minsur.OrdenServicio.WebAPI.Controllers
{
    [Route("api/solicitud-ordenservicio")]
    [ApiController]
    public class SolicitudOrdenServicioApiController : ControllerBase
    {
        private readonly ISolicitudOrdenServicioService oISolicitudOrdenServicioService;

        public SolicitudOrdenServicioApiController(ISolicitudOrdenServicioService oISolicitudOrdenServicioService)
        {
            this.oISolicitudOrdenServicioService = oISolicitudOrdenServicioService;
        }

        [HttpGet("solicitudes")]
        public IActionResult Consultar([FromQuery] PaginationRequest<FiltroSolicitudDto> paginationRequest)
        {
            return Ok(
                    oISolicitudOrdenServicioService.Consultar(paginationRequest)
                );
        }

        [HttpPost("solicitudes")]
        public IActionResult RegistrarSolicitud([FromBody] SolicitudOrdenServicioTransactionRequest oSolicitudOrdenServicioTransactionRequest)
        {
            return Ok(
                    oISolicitudOrdenServicioService.RegistrarSolicitud(oSolicitudOrdenServicioTransactionRequest)
                );
        }

        [HttpGet("solicitudes/{id}")]
        public IActionResult ObtenerSolicitudOrdenServicioPorId(int id, [FromQuery] UsuarioDto oUsuarioDto)
        {
            return Ok(
                    oISolicitudOrdenServicioService.ObtenerSolicitudOrdenServicioPorId(id, oUsuarioDto)
                );
        }
        
        [HttpGet("solicitudes/archivos/{id}")]
        public IActionResult ObtenerArchivoAdjuntoPorId(int id)
        {
            return Ok(
                    oISolicitudOrdenServicioService.ObtenerArchivoAdjuntoPorId(id)
                );
        }

        [HttpGet("solicitudes/{id}/archivos")]
        public IActionResult ObtenerArchivosAdjuntosPorSolicitud(int id)
        {
            return Ok(
                    oISolicitudOrdenServicioService.ObtenerArchivosAdjuntosPorSolicitud(id)
                );
        }

        [HttpPost("solicitudes/validacion")]
        public IActionResult RegistrarSolicitudvalidacion([FromBody] SolicitudValidacionDto oSolicitudValidacionDto)
        {
            return Ok(
                    oISolicitudOrdenServicioService.RegistrarSolicitudvalidacion(oSolicitudValidacionDto)
                );
        }

        [HttpPost("solicitudes/recomendacion")]
        public IActionResult RegistrarSolicitudRecomendacion([FromBody] SolicitudRecomendacionDto oSolicitudRecomendacionDto)
        {
            return Ok(
                    oISolicitudOrdenServicioService.RegistrarSolicitudRecomendacion(oSolicitudRecomendacionDto)
                );
        }

        [HttpPost("solicitudes/autorizacion")]
        public IActionResult RegistrarSolicitudAutorizacion([FromBody] SolicitudAutorizacionDto oSolicitudAutorizacionDto)
        {
            return Ok(
                    oISolicitudOrdenServicioService.RegistrarSolicitudAutorizacion(oSolicitudAutorizacionDto)
                );
        }


        [HttpGet("solicitudes/export")]
        public IActionResult ConsultarExport([FromQuery] FiltroSolicitudDto oFiltroSolicitudDto)
        {
            return Ok(
                    oISolicitudOrdenServicioService.ConsultarExport(oFiltroSolicitudDto)
                );
        }

        [HttpGet("solicitudes/export-por-solicitud")]
        public IActionResult ConsultarExportPorSolicitud([FromQuery] FiltroSolicitudDto oFiltroSolicitudDto)
        {
            return Ok(
                    oISolicitudOrdenServicioService.ConsultarExportPorSolicitud(oFiltroSolicitudDto)
                );
        }


        [HttpGet("solicitudes/export-por-proveedor")]
        public IActionResult ConsultarExportPorProveedor([FromQuery] FiltroSolicitudDto oFiltroSolicitudDto)
        {
            return Ok(
                    oISolicitudOrdenServicioService.ConsultarExportPorProveedor(oFiltroSolicitudDto)
                );
        }

        [HttpGet("solicitudes/dashboard")]
        public IActionResult ObtenerDashboard([FromQuery] FiltroSolicitudDto oFiltroSolicitudDto)
        {
            return Ok(
                    oISolicitudOrdenServicioService.ObtenerDashboard(oFiltroSolicitudDto)
                );
        }

        [HttpGet("solicitudes/{idUsuario}/pendientes")]
        public IActionResult ConsultarPendientesPorUsuario(int idUsuario)
        {
            return Ok(
                    oISolicitudOrdenServicioService.ConsultarPendientesPorUsuario(idUsuario)
                );
        }
    }
}