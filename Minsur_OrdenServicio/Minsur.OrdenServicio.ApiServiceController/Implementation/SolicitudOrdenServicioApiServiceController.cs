using Microsoft.Extensions.Configuration;
using Minsur.OrdenServicio.ApiServiceController.Base;
using Minsur.OrdenServicio.ApiServiceController.Interface;
using Minsur.OrdenServicio.ApiServiceController.Rest;
using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Body;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.ApiServiceController.Implementation
{
    public class SolicitudOrdenServicioApiServiceController : BaseApiServiceController, ISolicitudOrdenServicioApiServiceController
    {
        private readonly ISolicitudOrdenServicioService oISolicitudOrdenServicioService;
        private readonly IConfiguration oIConfiguration;

        public SolicitudOrdenServicioApiServiceController(IConfiguration configuration) : base(configuration)
        {
            this.oIConfiguration = configuration;
            oISolicitudOrdenServicioService = RestService.For<ISolicitudOrdenServicioService>(oHttpClient, new RefitSettings
            {
                ContentSerializer = new JsonContentSerializer(new JsonSerializerSettings { Converters = { new StringEnumConverter() } })
            });
        }

        public PaginationResponse<SolicitudOrdenServicioDto> Consultar(PaginationRequest<FiltroSolicitudDto> paginationRequest)
        {
            return oISolicitudOrdenServicioService.Consultar(paginationRequest).Result;
        }

        public TransactionResponse RegistrarSolicitud(SolicitudOrdenServicioTransactionRequest oSolicitudOrdenServicioTransactionRequest)
        {
            return oISolicitudOrdenServicioService.RegistrarSolicitud(oSolicitudOrdenServicioTransactionRequest).Result;
        }

        public SolicitudOrdenServicioDto ObtenerSolicitudOrdenServicioPorId(int idSolicicitudContratacion, UsuarioDto oUsuarioDto)
        {
            return oISolicitudOrdenServicioService.ObtenerSolicitudOrdenServicioPorId(idSolicicitudContratacion, oUsuarioDto).Result;
        }

        public SolicitudArchivoAdjuntoDto ObtenerArchivoAdjuntoPorId(int idArchivoAdjunto)
        {
            return oISolicitudOrdenServicioService.ObtenerArchivoAdjuntoPorId(idArchivoAdjunto).Result;
        }

        public ListaSolicitudArchivoAdjuntoDto ObtenerArchivosAdjuntosPorSolicitud(int idSolicicitudContratacion)
        {
            return oISolicitudOrdenServicioService.ObtenerArchivosAdjuntosPorSolicitud(idSolicicitudContratacion).Result;
        }

        public TransactionResponse RegistrarSolicitudvalidacion(SolicitudValidacionDto oSolicitudValidacionDto)
        {
            return oISolicitudOrdenServicioService.RegistrarSolicitudvalidacion(oSolicitudValidacionDto).Result;
        }

        public TransactionResponse RegistrarSolicitudRecomendacion(SolicitudRecomendacionDto oSolicitudRecomendacionDto)
        {
            return oISolicitudOrdenServicioService.RegistrarSolicitudRecomendacion(oSolicitudRecomendacionDto).Result;
        }
        
        public TransactionResponse RegistrarSolicitudAutorizacion(SolicitudAutorizacionDto oSolicitudAutorizacionDto)
        {
            return oISolicitudOrdenServicioService.RegistrarSolicitudAutorizacion(oSolicitudAutorizacionDto).Result;
        }

        public ListaSolicitudOrdenServicioExportDto ConsultarExport(FiltroSolicitudDto oFiltroSolicitud)
        {
            return oISolicitudOrdenServicioService.ConsultarExport(oFiltroSolicitud).Result;
        }

        public ListaSolicitudOrdenServicioExportDto ConsultarExportPorSolicitud(FiltroSolicitudDto oFiltroSolicitud)
        {
            return oISolicitudOrdenServicioService.ConsultarExportPorSolicitud(oFiltroSolicitud).Result;
        }

        public ListaSolicitudOrdenServicioExportDto ConsultarExportPorProveedor(FiltroSolicitudDto oFiltroSolicitud)
        {
            return oISolicitudOrdenServicioService.ConsultarExportPorProveedor(oFiltroSolicitud).Result;
        }

        public DashboardResponse ObtenerDashboard(FiltroSolicitudDto oFiltroSolicitud)
        {
            return oISolicitudOrdenServicioService.ObtenerDashboard(oFiltroSolicitud).Result;
        }

        public ListaSolicitudOrdenServicioDto ConsultarPendientesPorUsuario(int idUsuario)
        {
            return oISolicitudOrdenServicioService.ConsultarPendientesPorUsuario(idUsuario).Result;
        }

        public TransactionResponse GenerarPdf(SolicitudOrdenServicioDto oSolicitudOrdenServicioDto)
        {
            return RestService.For<ISolicitudOrdenServicioService>(oIConfiguration["Api:UrlReporte"]).GenerarPdf(oSolicitudOrdenServicioDto).Result;
        }
    }
}
