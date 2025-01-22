using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Minsur.OrdenServicio.ApiServiceController.Interface;
using Minsur.OrdenServicio.Common.Estructura;
using Minsur.OrdenServicio.Common.Excel;
using Minsur.OrdenServicio.Common.Recursos;
using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Body;
using Minsur.OrdenServicio.Mvc.Helpers;
using Minsur.OrdenServicio.Mvc.Models;

namespace Minsur.OrdenServicio.Mvc.Controllers
{
    //[Authorize]
    public class SolicitudOrdenServicioController : Controller
    {
        private readonly ISolicitudOrdenServicioApiServiceController oISolicitudOrdenServicioApiServiceController;
        private readonly IUserFactory oIUserFactory;
        private readonly IConfiguration oIConfiguration;

        public SolicitudOrdenServicioController(ISolicitudOrdenServicioApiServiceController oISolicitudOrdenServicioApiServiceController,
                                               IUserFactory oIUserFactory,
                                               IConfiguration oIConfiguration)
        {
            this.oISolicitudOrdenServicioApiServiceController = oISolicitudOrdenServicioApiServiceController;
            this.oIUserFactory = oIUserFactory;
            this.oIConfiguration = oIConfiguration;
        }
        [HttpGet]
        public JsonResult ObtenerNuevaSolicitud()
        {
            SolicitudOrdenServicioDto oSolicitudOrdenServicioDto = oISolicitudOrdenServicioApiServiceController.ObtenerSolicitudOrdenServicioPorId(Numeracion.Cero, oIUserFactory.UsuarioDto);
            oSolicitudOrdenServicioDto.UsuarioSolicitudDto = oIUserFactory.UsuarioDto;

            return Json(new
            {
                SolicitudOrdenServicio = oSolicitudOrdenServicioDto
            });
        }
        
        [HttpPost]
        public JsonResult RegistrarSolicitud(SolicitudOrdenServicioViewModel oSolicitudOrdenServicioViewModel)
        {
            try
            {
                SolicitudOrdenServicioTransactionRequest oSolicitudOrdenServicioTransactionRequest = new SolicitudOrdenServicioTransactionRequest();
                oSolicitudOrdenServicioTransactionRequest.SolicitudOrdenServicioDto = SolicitudHelper.ObtenerDatosSolicitudOrdenServicio(oSolicitudOrdenServicioViewModel);
                oSolicitudOrdenServicioTransactionRequest.SolicitudOrdenServicioDto.UsuarioSolicitudDto = oIUserFactory.UsuarioDto;
                TransactionResponse oTransactionResponse = oISolicitudOrdenServicioApiServiceController.RegistrarSolicitud(oSolicitudOrdenServicioTransactionRequest);
                
                return Json(new { flagError = (oTransactionResponse.Codigo != nameof(DictionaryErrors.SOL00000)), mensaje = oTransactionResponse.Mensaje });
            }
            catch (Exception ex)
            {
                return Json(new { flagError = true, mensaje = ex.Message });
            }
        }

        [HttpGet]
        public JsonResult ConsultarSolicitud(int idCompania, int idProyecto, int idFaseProyecto, int idFuenteContrato, int idAreaFuncional, int idEstado, string fechaInicio, string fechaFin, int nroPagina)
        {
            PaginationRequest<FiltroSolicitudDto> paginationRequest = new PaginationRequest<FiltroSolicitudDto>();
            paginationRequest.FiltroBusqueda = new FiltroSolicitudDto();
            paginationRequest.FiltroBusqueda.IdCompania = idCompania;
            paginationRequest.FiltroBusqueda.IdProyecto = idProyecto;
            paginationRequest.FiltroBusqueda.IdFaseProyecto = idFaseProyecto;
            paginationRequest.FiltroBusqueda.IdFuenteContrato = idFuenteContrato;
            paginationRequest.FiltroBusqueda.IdAreaFuncional = idAreaFuncional;
            paginationRequest.FiltroBusqueda.IdEstado = idEstado;
            paginationRequest.FiltroBusqueda.FechaInicio = DateTime.Parse(fechaInicio).ToString("yyyyMMdd");
            paginationRequest.FiltroBusqueda.FechaFin = DateTime.Parse(fechaFin).ToString("yyyyMMdd");
            paginationRequest.FiltroBusqueda.IdUsuario = oIUserFactory.UsuarioDto.IdUsuario;

            paginationRequest.PaginacionDto = new PaginacionDto();
            paginationRequest.PaginacionDto.Page = nroPagina;
            paginationRequest.PaginacionDto.RowsPerPage = Numeracion.Diez;

            PaginationResponse<SolicitudOrdenServicioDto> paginationResponse = oISolicitudOrdenServicioApiServiceController.Consultar(paginationRequest);

            return Json(new {
                listaSolicitudOrdenServicio = paginationResponse.Resultado,
                total = paginationResponse.PaginacionDto.Total,
                nroFilasPorpagina = paginationResponse.PaginacionDto.RowsPerPage
            });
        }

        public IActionResult ConsultarExport(int idCompania, int idProyecto, int idFaseProyecto, int idFuenteContrato, int idAreaFuncional, int idEstado, string fechaInicio, string fechaFin, int nroPagina, string token)
        {
            JwtSecurityToken oJwtSecurityToken = AuthHelper.ValidateToken(oIConfiguration, token);

            if (oJwtSecurityToken == null) { return new EmptyResult(); }

            FiltroSolicitudDto oFiltroSolicitudDto = new FiltroSolicitudDto();
            oFiltroSolicitudDto.IdCompania = idCompania;
            oFiltroSolicitudDto.IdProyecto = idProyecto;
            oFiltroSolicitudDto.IdFaseProyecto = idFaseProyecto;
            oFiltroSolicitudDto.IdFuenteContrato = idFuenteContrato;
            oFiltroSolicitudDto.IdAreaFuncional = idAreaFuncional;
            oFiltroSolicitudDto.IdEstado = idEstado;
            oFiltroSolicitudDto.FechaInicio = DateTime.Parse(fechaInicio).ToString("yyyyMMdd");
            oFiltroSolicitudDto.FechaFin = DateTime.Parse(fechaFin).ToString("yyyyMMdd");
            oFiltroSolicitudDto.IdUsuario = oIUserFactory.Deserialize(oJwtSecurityToken).IdUsuario;

            ListaSolicitudOrdenServicioExportDto oListaSolicitudOrdenServicioExportDto = oISolicitudOrdenServicioApiServiceController.ConsultarExport(oFiltroSolicitudDto);

            if (!oListaSolicitudOrdenServicioExportDto.Any())
            {
                return new EmptyResult();
            }

            List<string> listaColumna = new List<string>();
            byte[] data = ExcelHelper.ExportToExcel(oListaSolicitudOrdenServicioExportDto, "Solicitud Orden Servicio", listaColumna);
            string nombreArchivo = $"SolicitudOrdenServicio{DateTime.Now.ToString("yyyyMMdd")}.xlsx";

            return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nombreArchivo);
        }

        public IActionResult ConsultarExportPorSolicitud(int idCompania, int idProyecto, int idFaseProyecto, int idFuenteContrato, int idAreaFuncional, int idEstado, string fechaInicio, string fechaFin, int nroPagina, string token)
        {
            JwtSecurityToken oJwtSecurityToken = AuthHelper.ValidateToken(oIConfiguration, token);

            if (oJwtSecurityToken == null) { return new EmptyResult(); }

            FiltroSolicitudDto oFiltroSolicitudDto = new FiltroSolicitudDto();
            oFiltroSolicitudDto.IdCompania = idCompania;
            oFiltroSolicitudDto.IdProyecto = idProyecto;
            oFiltroSolicitudDto.IdFaseProyecto = idFaseProyecto;
            oFiltroSolicitudDto.IdFuenteContrato = idFuenteContrato;
            oFiltroSolicitudDto.IdAreaFuncional = idAreaFuncional;
            oFiltroSolicitudDto.IdEstado = idEstado;
            oFiltroSolicitudDto.FechaInicio = DateTime.Parse(fechaInicio).ToString("yyyyMMdd");
            oFiltroSolicitudDto.FechaFin = DateTime.Parse(fechaFin).ToString("yyyyMMdd");
            oFiltroSolicitudDto.IdUsuario = oIUserFactory.Deserialize(oJwtSecurityToken).IdUsuario;

            ListaSolicitudOrdenServicioExportDto oListaSolicitudOrdenServicioExportDto = oISolicitudOrdenServicioApiServiceController.ConsultarExportPorSolicitud(oFiltroSolicitudDto);

            if (!oListaSolicitudOrdenServicioExportDto.Any())
            {
                return new EmptyResult();
            }
            
            byte[] data = ExcelHelper.ExportToExcel(oListaSolicitudOrdenServicioExportDto, "Solicitud Contratación Servicio", SolicitudHelper.ObtenerColumnaExportarPorSolicitud());
            string nombreArchivo = $"SolicitudOrdenServicio{DateTime.Now.ToString("yyyyMMdd")}.xlsx";

            return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nombreArchivo);
        }

        public IActionResult ConsultarExportPorProveedor(int idCompania, int idProyecto, int idFaseProyecto, int idFuenteContrato, int idAreaFuncional, int idEstado, string fechaInicio, string fechaFin, int nroPagina, string token)
        {
            JwtSecurityToken oJwtSecurityToken = AuthHelper.ValidateToken(oIConfiguration, token);

            if (oJwtSecurityToken == null) { return new EmptyResult(); }

            FiltroSolicitudDto oFiltroSolicitudDto = new FiltroSolicitudDto();
            oFiltroSolicitudDto.IdCompania = idCompania;
            oFiltroSolicitudDto.IdProyecto = idProyecto;
            oFiltroSolicitudDto.IdFaseProyecto = idFaseProyecto;
            oFiltroSolicitudDto.IdFuenteContrato = idFuenteContrato;
            oFiltroSolicitudDto.IdAreaFuncional = idAreaFuncional;
            oFiltroSolicitudDto.IdEstado = idEstado;
            oFiltroSolicitudDto.FechaInicio = DateTime.Parse(fechaInicio).ToString("yyyyMMdd");
            oFiltroSolicitudDto.FechaFin = DateTime.Parse(fechaFin).ToString("yyyyMMdd");
            oFiltroSolicitudDto.IdUsuario = oIUserFactory.Deserialize(oJwtSecurityToken).IdUsuario;

            ListaSolicitudOrdenServicioExportDto oListaSolicitudOrdenServicioExportDto = oISolicitudOrdenServicioApiServiceController.ConsultarExportPorProveedor(oFiltroSolicitudDto);

            if (!oListaSolicitudOrdenServicioExportDto.Any())
            {
                return new EmptyResult();
            }

            byte[] data = ExcelHelper.ExportToExcel(oListaSolicitudOrdenServicioExportDto, "Solicitud Contratación Servicio", SolicitudHelper.ObtenerColumnaExportarPorProveedor());
            string nombreArchivo = $"SolicitudOrdenServicio{DateTime.Now.ToString("yyyyMMdd")}.xlsx";

            return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nombreArchivo);
        }

        [HttpGet]
        public JsonResult ObtenerSolicitudPorId(int idSolicitudOrdenServicio)
        {
            SolicitudOrdenServicioDto oSolicitudOrdenServicioDto = oISolicitudOrdenServicioApiServiceController.ObtenerSolicitudOrdenServicioPorId(idSolicitudOrdenServicio, oIUserFactory.UsuarioDto);

            return Json(new { solicitud = oSolicitudOrdenServicioDto });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult DescargarArchivo(int idSolicitudArchivoAdjunto)
        {
            SolicitudArchivoAdjuntoDto oSolicitudArchivoAdjuntoDto =  oISolicitudOrdenServicioApiServiceController.ObtenerArchivoAdjuntoPorId(idSolicitudArchivoAdjunto);

            string path = Path.Combine(oIConfiguration["Ruta:Solicitud"], oSolicitudArchivoAdjuntoDto.Directorio, oSolicitudArchivoAdjuntoDto.NombreArchivo);

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (var binaryReader = new BinaryReader(fs))
                {
                    return File(binaryReader.ReadBytes((int)fs.Length), oSolicitudArchivoAdjuntoDto.TipoContenido, oSolicitudArchivoAdjuntoDto.NombreArchivo);
                }
            }
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult DescargarTodo(string numeroSolicitud)
        {
            string zipPath = Path.Combine(oIConfiguration["Ruta:Solicitud"], numeroSolicitud, "Solicitud.zip");

            if (!System.IO.File.Exists(zipPath))
            {
                string path = Path.Combine(oIConfiguration["Ruta:Solicitud"], numeroSolicitud, Constantes.Ruta_Adjunto);
                ZipFile.CreateFromDirectory(path, zipPath);
            }
            
            using (FileStream fs = new FileStream(zipPath, FileMode.Open, FileAccess.Read))
            {
                using (var binaryReader = new BinaryReader(fs))
                {
                    return File(binaryReader.ReadBytes((int)fs.Length), System.Net.Mime.MediaTypeNames.Application.Zip, "Solicitud.zip");
                }
            }    
        }

        [HttpPost]
        public JsonResult RegistrarSolicitudValidacion([FromBody] SolicitudValidacionDto oSolicitudValidacionDto)
        {
            oSolicitudValidacionDto.UsuarioDto = oIUserFactory.UsuarioDto;
            TransactionResponse oTransactionResponse = oISolicitudOrdenServicioApiServiceController.RegistrarSolicitudvalidacion(oSolicitudValidacionDto);

            return Json(new { flagError = (oTransactionResponse.Codigo != nameof(DictionaryErrors.SOL00000)), mensaje = oTransactionResponse.Mensaje });
        }

        [HttpPost]
        public JsonResult RegistrarSolicitudRecomendacion([FromBody] SolicitudRecomendacionDto oSolicitudRecomendacionDto)
        {
            oSolicitudRecomendacionDto.UsuarioDto = oIUserFactory.UsuarioDto;
            TransactionResponse oTransactionResponse = oISolicitudOrdenServicioApiServiceController.RegistrarSolicitudRecomendacion(oSolicitudRecomendacionDto);

            return Json(new { flagError = (oTransactionResponse.Codigo != nameof(DictionaryErrors.SOL00000)), mensaje = oTransactionResponse.Mensaje });
        }

        [HttpPost]
        public JsonResult RegistrarSolicitudAutorizacion([FromBody] SolicitudAutorizacionDto oSolicitudAutorizacionDto)
        {
            oSolicitudAutorizacionDto.UsuarioDto = oIUserFactory.UsuarioDto;
            TransactionResponse oTransactionResponse = oISolicitudOrdenServicioApiServiceController.RegistrarSolicitudAutorizacion(oSolicitudAutorizacionDto);

            if (!oSolicitudAutorizacionDto.FlagAprobado || (oSolicitudAutorizacionDto.GobernanzaDto.FlagApruebaSolicitud && oSolicitudAutorizacionDto.FlagAprobado))
            {
                SolicitudOrdenServicioDto oSolicitudOrdenServicioDto = oISolicitudOrdenServicioApiServiceController.ObtenerSolicitudOrdenServicioPorId(oSolicitudAutorizacionDto.IdSolicitudOrdenServicio, oIUserFactory.UsuarioDto);
                oISolicitudOrdenServicioApiServiceController.GenerarPdf(oSolicitudOrdenServicioDto);
            }

            return Json(new { flagError = (oTransactionResponse.Codigo != nameof(DictionaryErrors.SOL00000)), mensaje = oTransactionResponse.Mensaje });
        }

        public JsonResult ObtenerDashboard(int idProyecto, int idFaseProyecto)
        {
            FiltroSolicitudDto oFiltroSolicitudDto = new FiltroSolicitudDto();
            oFiltroSolicitudDto.IdProyecto = idProyecto;
            oFiltroSolicitudDto.IdFaseProyecto = idFaseProyecto;
            oFiltroSolicitudDto.IdUsuario = oIUserFactory.UsuarioDto.IdUsuario;

            DashboardResponse oDashboardResponse = oISolicitudOrdenServicioApiServiceController.ObtenerDashboard(oFiltroSolicitudDto);

            return Json(new { dashboard = oDashboardResponse.SolicitudOrdenServicioDashboardDto,
                              listaRegularizacion = oDashboardResponse.ListaSolicitudRegularizacionDto });
        }
        
        [HttpGet]
        public JsonResult ConsultarPendientesPorUsuario()
        {
            ListaSolicitudOrdenServicioDto oListaSolicitudOrdenServicioDto = oISolicitudOrdenServicioApiServiceController.ConsultarPendientesPorUsuario(oIUserFactory.UsuarioDto.IdUsuario);

            return Json(new
            {
                listaSolicitudOrdenServicio = oListaSolicitudOrdenServicioDto
            });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult DescargarPdf(int idSolicitudOrdenServicio)
        {
            SolicitudOrdenServicioDto oSolicitudOrdenServicioDto = oISolicitudOrdenServicioApiServiceController.ObtenerSolicitudOrdenServicioPorId(idSolicitudOrdenServicio, oIUserFactory.UsuarioDto);

            if (!oSolicitudOrdenServicioDto.FlagPDFGenerado)
            {
                var response = oISolicitudOrdenServicioApiServiceController.GenerarPdf(oSolicitudOrdenServicioDto);
            }

            DirectoryInfo dir = new DirectoryInfo(Path.Combine(oIConfiguration["Ruta:Solicitud"], oSolicitudOrdenServicioDto.NumeroSolicitud));
            FileInfo oFileInfo = dir.GetFiles().Where(x => x.Name == $"{oSolicitudOrdenServicioDto.NumeroSolicitud}.pdf").FirstOrDefault();

            if (oFileInfo is null)
            {
                return new EmptyResult();
            }

            using (FileStream fs = oFileInfo.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (var binaryReader = new BinaryReader(fs))
                {
                    return File(binaryReader.ReadBytes((int)fs.Length), System.Net.Mime.MediaTypeNames.Application.Pdf, oFileInfo.Name);
                }
            }
        }
    }
}