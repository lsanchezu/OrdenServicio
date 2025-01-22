using AutoMapper;
using Microsoft.Extensions.Configuration;
using Minsur.OrdenServicio.Application.Contract.Solicitud;
using Minsur.OrdenServicio.Common.Enumeracion;
using Minsur.OrdenServicio.Common.Estructura;
using Minsur.OrdenServicio.Common.Recursos;
using Minsur.OrdenServicio.Common.Xml;
using Minsur.OrdenServicio.Domain.DomainContract;
using Minsur.OrdenServicio.Domain.Entities;
using Minsur.OrdenServicio.Domain.Entities.Xml;
using Minsur.OrdenServicio.Domain.RepositoryContract.Maestro;
using Minsur.OrdenServicio.Domain.RepositoryContract.Solicitud;
using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Body;
using Minsur.OrdenServicio.DTO.Email;
using Minsur.OrdenServicio.Mail.Base;
using Minsur.OrdenServicio.Mail.Interface;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;

namespace Minsur.OrdenServicio.Application.Service.Solicitud
{
    public class SolicitudOrdenServicioService : ISolicitudOrdenServicioService
    {
        private readonly IMaestroRepository oIMaestroRepository;
        private readonly ISolicitudOrdenServicioRepository oISolicitudOrdenServicioRepository;
        private readonly ISolicitudServicioDomainService oISolicitudServicioDomainService;
        private readonly IEmailService oIEmailService;
        private readonly IViewRender oIViewRender;
        private readonly IConfiguration oIConfiguration;
        private readonly IMapper _mapper;

        public SolicitudOrdenServicioService( IMaestroRepository oIMaestroRepository,
                                             ISolicitudOrdenServicioRepository oISolicitudOrdenServicioRepository,
                                             ISolicitudServicioDomainService oISolicitudServicioDomainService,
                                             IEmailService oIEmailService,
                                             IViewRender oIViewRender,
                                             IConfiguration oIConfiguration,
                                             IMapper mapper)
        {
            this.oIMaestroRepository = oIMaestroRepository;
            this.oIConfiguration = oIConfiguration;
            this.oISolicitudOrdenServicioRepository = oISolicitudOrdenServicioRepository;
            this.oISolicitudServicioDomainService = oISolicitudServicioDomainService;
            this.oIEmailService = oIEmailService;
            this.oIViewRender = oIViewRender;
            this.oIConfiguration = oIConfiguration;
            _mapper = mapper;
        }

        public TransactionResponse RegistrarSolicitud(SolicitudOrdenServicioTransactionRequest oSolicitudOrdenServicioTransactionRequest)
        {
            TransactionResponse oTransactionResponse = new TransactionResponse();
            SolicitudOrdenServicio oSolicitudOrdenServicio = _mapper.Map<SolicitudOrdenServicioDto, SolicitudOrdenServicio>(oSolicitudOrdenServicioTransactionRequest.SolicitudOrdenServicioDto);
            oSolicitudOrdenServicio.Estado = new Estado();
            oSolicitudOrdenServicio.Estado.IdEstado = (int)  EnumSolicitudOrdenServicio.EstadoSolicitud.EnProceso;

            SolicitudOrdenServicioTransaccionXml oSolicitudOrdenServicioTransaccionXml = new SolicitudOrdenServicioTransaccionXml();
            oSolicitudOrdenServicioTransaccionXml.SolicitudOrdenServicioXml = _mapper.Map<SolicitudOrdenServicio, SolicitudOrdenServicioXml>(oSolicitudOrdenServicio);
            oSolicitudOrdenServicioTransaccionXml.ListaSolicitudProveedorContratistaXml = _mapper.Map<ListaSolicitudProveedorContratista, ListaSolicitudProveedorContratistaXml>(oSolicitudOrdenServicio.ListaSolicitudProveedorContratista);
            oSolicitudOrdenServicioTransaccionXml.ListaSolicitudDocumentoXml = _mapper.Map<ListaSolicitudDocumento, ListaSolicitudDocumentoXml>(oSolicitudOrdenServicio.ListaSolicitudDocumento);

            try
            {
                int idSolicitud = Numeracion.Cero;

                using (TransactionScope oTransactionScope = new TransactionScope())
                {
                    string numeroSolicitud = string.Empty;

                    idSolicitud = oISolicitudOrdenServicioRepository.Registrar(HelpXml.ObjectToXml(oSolicitudOrdenServicioTransaccionXml), out numeroSolicitud);
                    GuardarDocumentosAdjuntos(numeroSolicitud, oSolicitudOrdenServicio.ListaSolicitudDocumento);

                    oTransactionScope.Complete();
                }

                List<Usuario> oListaUsuario = oISolicitudOrdenServicioRepository.ObtenerListaUsuarioControlProyectoProcuraPorSolicitud(idSolicitud, false);
                SolicitudOrdenServicio SolicitudOrdenServicio = oISolicitudServicioDomainService.ObtenerSolicitudOrdenServicioPorId(idSolicitud, oSolicitudOrdenServicio.UsuarioSolicitud);
                EnviarNotificacionSolicitud(SolicitudOrdenServicio, oListaUsuario, (int)EnumSolicitudOrdenServicio.EmailParametro.ValidacionSolicitud);

                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL00000);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL00000;
                
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL99999);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL99999;
            }

            return oTransactionResponse;
        }

        private void GuardarDocumentosAdjuntos(string numeroSolicitud, ListaSolicitudDocumento oListaSolicitudDocumento)
        {
            string ruta = string.Empty;
            oListaSolicitudDocumento.ForEach(x =>
            {
                if (x.ListaSolicitudArchivoAdjunto.Any())
                {
                    ruta = Path.Combine(oIConfiguration["Ruta:Solicitud"], numeroSolicitud, x.ListaSolicitudArchivoAdjunto.FirstOrDefault().Directorio);

                    if (!Directory.Exists(ruta))
                    {
                        Directory.CreateDirectory(ruta);
                    }
                    
                    foreach (var item in x.ListaSolicitudArchivoAdjunto)
                    {
                        using (FileStream fs = new FileStream(Path.Combine(ruta, item.NombreArchivo), FileMode.Create))
                        {
                            fs.Write(item.Contenido, 0, item.Contenido.Length);
                            fs.Flush();
                            fs.Close();
                        }
                    }
                }
            });
        }

        public PaginationResponse<SolicitudOrdenServicioDto> Consultar(PaginationRequest<FiltroSolicitudDto> paginationRequest)
        {
            FiltroSolicitud oFiltroReporte = _mapper.Map<FiltroSolicitudDto, FiltroSolicitud>(paginationRequest.FiltroBusqueda);
            Paginacion oPaginacion = _mapper.Map<PaginacionDto, Paginacion>(paginationRequest.PaginacionDto);

            PaginationResponse<SolicitudOrdenServicioDto> paginationResponse = new PaginationResponse<SolicitudOrdenServicioDto>();
            paginationResponse.Resultado = _mapper.Map<ListaSolicitudOrdenServicio, ListaSolicitudOrdenServicioDto>(oISolicitudOrdenServicioRepository.Consultar(oFiltroReporte, oPaginacion));
            paginationResponse.PaginacionDto = _mapper.Map<Paginacion, PaginacionDto>(oPaginacion);

            return paginationResponse;
        }

        public SolicitudOrdenServicioDto ObtenerSolicitudOrdenServicioPorId(int idSolicitudOrdenServicio, UsuarioDto oUsuarioDto)
        {
            SolicitudOrdenServicio oSolicitudOrdenServicio = null;

            if (idSolicitudOrdenServicio == decimal.Zero)
            {
                oSolicitudOrdenServicio = oISolicitudServicioDomainService.ObtenerNuevaSolicitud();
            }
            else
            {
                Usuario oUsuario = _mapper.Map<UsuarioDto, Usuario>(oUsuarioDto);
                oSolicitudOrdenServicio = oISolicitudServicioDomainService.ObtenerSolicitudOrdenServicioPorId(idSolicitudOrdenServicio, oUsuario);
            }

            SolicitudOrdenServicioDto oSolicitudOrdenServicioDto = _mapper.Map<SolicitudOrdenServicio, SolicitudOrdenServicioDto>(oSolicitudOrdenServicio);

            return oSolicitudOrdenServicioDto;
        }
        
        public SolicitudArchivoAdjuntoDto ObtenerArchivoAdjuntoPorId(int idSolicitudArchivoAdjunto)
        {
            SolicitudArchivoAdjunto oSolicitudArchivoAdjunto = oISolicitudOrdenServicioRepository.ObtenerArchivoAdjuntoPorId(idSolicitudArchivoAdjunto);

            SolicitudArchivoAdjuntoDto oSolicitudArchivoAdjuntoDto = _mapper.Map<SolicitudArchivoAdjunto, SolicitudArchivoAdjuntoDto>(oSolicitudArchivoAdjunto);

            return oSolicitudArchivoAdjuntoDto;
        }

        public ListaSolicitudArchivoAdjuntoDto ObtenerArchivosAdjuntosPorSolicitud(int idSolicitudOrdenServicio)
        {
            ListaSolicitudArchivoAdjunto oListaSolicitudArchivoAdjunto = oISolicitudOrdenServicioRepository.ObtenerListaArchivoAdjuntoPorSolicitud(idSolicitudOrdenServicio);

            ListaSolicitudArchivoAdjuntoDto oListaSolicitudArchivoAdjuntoDto = _mapper.Map<ListaSolicitudArchivoAdjunto, ListaSolicitudArchivoAdjuntoDto>(oListaSolicitudArchivoAdjunto);

            return oListaSolicitudArchivoAdjuntoDto;
        }

        #region PROCESO VALIDACIÓN

        public TransactionResponse RegistrarSolicitudvalidacion(SolicitudValidacionDto oSolicitudValidacionDto)
        {
            TransactionResponse oTransactionResponse = new TransactionResponse();
            SolicitudValidacion oSolicitudValidacion = _mapper.Map<SolicitudValidacionDto, SolicitudValidacion>(oSolicitudValidacionDto);
            try
            {
                SolicitudOrdenServicio oSolicitudOrdenServicio = oISolicitudServicioDomainService.ObtenerSolicitudOrdenServicioPorId(oSolicitudValidacion.IdSolicitudOrdenServicio, oSolicitudValidacion.Usuario);
                oSolicitudOrdenServicio.AsignarSolicitudValidacion(oSolicitudValidacion);

                oISolicitudOrdenServicioRepository.RegistrarSolicitudValidacion(oSolicitudOrdenServicio);
                NotificarSolicitudValidacion(oSolicitudOrdenServicio);

                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL00000);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL00000;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL99999);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL99999;
            }

            return oTransactionResponse;
        }

        private void NotificarSolicitudValidacion(SolicitudOrdenServicio oSolicitudOrdenServicio)
        {
            List<Usuario> oListaUsuario = new List<Usuario>();
            int idEmailParametro = Numeracion.Cero;

            if (oSolicitudOrdenServicio.Estado.IdEstado == (int)EnumSolicitudOrdenServicio.EstadoSolicitud.Rechazado)
            {
                idEmailParametro = (int)EnumSolicitudOrdenServicio.EmailParametro.RechazoSolicitud;
                oListaUsuario.Add(oISolicitudOrdenServicioRepository.ObtenerUsuarioSolicitudPorIdSolicitudContrato(oSolicitudOrdenServicio.IdSolicitudOrdenServicio));
            }
            else
            {
                if (oSolicitudOrdenServicio.FuenteContrato.IdFuenteContrato == (int)EnumSolicitudOrdenServicio.FuenteContrato.Sole_Source)
                {
                    idEmailParametro = (int)EnumSolicitudOrdenServicio.EmailParametro.RecomedacionSolicitud;
                    oListaUsuario = oISolicitudOrdenServicioRepository.ObtenerListaUsuarioControlProyectoProcuraPorSolicitud(oSolicitudOrdenServicio.IdSolicitudOrdenServicio, true);
                }
                else
                {
                    idEmailParametro = (int)EnumSolicitudOrdenServicio.EmailParametro.AutorizacionSolicitud;
                    oListaUsuario = oISolicitudOrdenServicioRepository.ObtenerListaUsuarioAutorizacionPorSolicitud(oSolicitudOrdenServicio.IdSolicitudOrdenServicio);
                }
            }

            EnviarNotificacionSolicitud(oSolicitudOrdenServicio, oListaUsuario, idEmailParametro);
        }

        #endregion

        #region PROCESO RECOMENDACIÓN

        public TransactionResponse RegistrarSolicitudRecomendacion(SolicitudRecomendacionDto oSolicitudRecomendacionDto)
        {
            TransactionResponse oTransactionResponse = new TransactionResponse();
            SolicitudRecomendacion oSolicitudRecomendacion = _mapper.Map<SolicitudRecomendacionDto, SolicitudRecomendacion>(oSolicitudRecomendacionDto);
            try
            {
                SolicitudOrdenServicio oSolicitudOrdenServicio = oISolicitudServicioDomainService.ObtenerSolicitudOrdenServicioPorId(oSolicitudRecomendacion.IdSolicitudOrdenServicio, oSolicitudRecomendacion.Usuario);
                oISolicitudOrdenServicioRepository.RegistrarSolicitudRecomendacion(oSolicitudRecomendacion);

                List<Usuario> oListaUsuario = oISolicitudOrdenServicioRepository.ObtenerListaUsuarioAutorizacionPorSolicitud(oSolicitudRecomendacionDto.IdSolicitudOrdenServicio);
                EnviarNotificacionSolicitud(oSolicitudOrdenServicio, oListaUsuario, (int)EnumSolicitudOrdenServicio.EmailParametro.AutorizacionSolicitud);

                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL00000);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL00000;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL99999);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL99999;
            }

            return oTransactionResponse;
        }

        #endregion

        #region PROCESO AUTORIZACIÓN

        public TransactionResponse RegistrarSolicitudAutorizacion(SolicitudAutorizacionDto oSolicitudAutorizacionDto)
        {
            TransactionResponse oTransactionResponse = new TransactionResponse();

            SolicitudAutorizacion oSolicitudAutorizacion = _mapper.Map<SolicitudAutorizacionDto, SolicitudAutorizacion>(oSolicitudAutorizacionDto);
            try
            {
                SolicitudOrdenServicio oSolicitudOrdenServicio = oISolicitudServicioDomainService.ObtenerSolicitudOrdenServicioPorId(oSolicitudAutorizacion.IdSolicitudOrdenServicio, oSolicitudAutorizacion.Usuario);
                oSolicitudOrdenServicio.AsignarSolicitudAutorizacion (oISolicitudServicioDomainService.ObteneListaSolicitudAutorizacionAsignadaPorUsuarioYProyecto(oSolicitudOrdenServicio, oSolicitudAutorizacion));

                XmlDocument oXmlDocument = HelpXml.ObjectToXml(_mapper.Map<ListaSolicitudAutorizacion, ListaSolicitudAutorizacionXml>(oSolicitudOrdenServicio.ListaSolicitudAutorizacion));

                oISolicitudOrdenServicioRepository.RegistrarSolicitudAutorizacion(oSolicitudOrdenServicio, oXmlDocument);

                NotificarSolicitudAutorizacion(oSolicitudOrdenServicio);

                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL00000);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL00000;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL99999);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL99999;
            }

            return oTransactionResponse;
        }

        private void NotificarSolicitudAutorizacion(SolicitudOrdenServicio oSolicitudOrdenServicio)
        {
            List<Usuario> oListaUsuario = new List<Usuario>();
            int idSolicitudEmailParametro = Numeracion.Cero;

            if (oSolicitudOrdenServicio.Estado.IdEstado == (int)EnumSolicitudOrdenServicio.EstadoSolicitud.Aprobado)
            {
                idSolicitudEmailParametro = (int)EnumSolicitudOrdenServicio.EmailParametro.AprobacionSolicitud;
                oListaUsuario = oISolicitudOrdenServicioRepository.ObtenerListaUsuarioControlProyectoProcuraPorSolicitud(oSolicitudOrdenServicio.IdSolicitudOrdenServicio, true);
                oListaUsuario.Add(oISolicitudOrdenServicioRepository.ObtenerUsuarioSolicitudPorIdSolicitudContrato(oSolicitudOrdenServicio.IdSolicitudOrdenServicio));
            }
            else if (oSolicitudOrdenServicio.Estado.IdEstado == (int)EnumSolicitudOrdenServicio.EstadoSolicitud.Rechazado)
            {
                idSolicitudEmailParametro = (int)EnumSolicitudOrdenServicio.EmailParametro.RechazoSolicitud;
                oListaUsuario.Add(oISolicitudOrdenServicioRepository.ObtenerUsuarioSolicitudPorIdSolicitudContrato(oSolicitudOrdenServicio.IdSolicitudOrdenServicio));
            }
            else
            {
                idSolicitudEmailParametro = (int)EnumSolicitudOrdenServicio.EmailParametro.AutorizacionSolicitud;
                oListaUsuario = oISolicitudOrdenServicioRepository.ObtenerListaUsuarioAutorizacionPorSolicitud(oSolicitudOrdenServicio.IdSolicitudOrdenServicio);
            }

            EnviarNotificacionSolicitud(oSolicitudOrdenServicio, oListaUsuario, idSolicitudEmailParametro);
        }

        #endregion
        
        
        private void EnviarNotificacionSolicitud( SolicitudOrdenServicio oSolicitudOrdenServicio, List<Usuario> oListaUsuario, int idSolicitudEmailParametro)
        {
            EmailParametro oEmailParametro = oIMaestroRepository.ObtenerEmailParametro(idSolicitudEmailParametro); 

            oListaUsuario.ForEach(x => 
            {
                EmailParametroDto oEmailParametroDto = new EmailParametroDto();
                oEmailParametroDto.IdUsuario = x.IdUsuario;
                oEmailParametroDto.Para = x.Correo;
                oEmailParametroDto.IdReferencia = oSolicitudOrdenServicio.IdSolicitudOrdenServicio;

                SolicitudOrdenServicioEmailDto oSolicitudAprobacionEmailDto = _mapper.Map<SolicitudOrdenServicio, SolicitudOrdenServicioEmailDto>(oSolicitudOrdenServicio);
                oSolicitudAprobacionEmailDto.UsuarioCorreo = x.NombreApellido;
                oSolicitudAprobacionEmailDto.Enlace = oIConfiguration["Email:Enlace"];
                oEmailParametroDto.Asunto = oEmailParametro.Asunto;
                oEmailParametroDto.MensajeHtml = ObtenerMensajeCorreo(oEmailParametro.Plantilla, oSolicitudAprobacionEmailDto).Result;
                oIEmailService.SendEmailAsync(oEmailParametroDto, ActualizarFlagEnvioCorreo);
            });
        }

        private Task<string> ObtenerMensajeCorreo(string plantilla, SolicitudOrdenServicioEmailDto oSolicitudOrdenServicioEmailDto)
        {
            return oIViewRender.RenderAsync($"Mailing/{plantilla}", oSolicitudOrdenServicioEmailDto);
        }
        
        public void ActualizarFlagEnvioCorreo(EmailParametroDto oEmailParametroDto, bool flagEnvio, string mensaje)
        {
            SolicitudOrdenServicioEmail oSolicitudOrdenServicioEmail = new SolicitudOrdenServicioEmail();
            oSolicitudOrdenServicioEmail.IdSolicitudOrdenServicio = oEmailParametroDto.IdReferencia;
            oSolicitudOrdenServicioEmail.IdUsuario = oEmailParametroDto.IdUsuario;
            oSolicitudOrdenServicioEmail.Para = oEmailParametroDto.Para;
            oSolicitudOrdenServicioEmail.Asunto = oEmailParametroDto.Asunto;
            oSolicitudOrdenServicioEmail.Contenido = oEmailParametroDto.MensajeHtml;
            oSolicitudOrdenServicioEmail.FlagEnviado = flagEnvio;
            oSolicitudOrdenServicioEmail.MensajeError = mensaje;

            oISolicitudOrdenServicioRepository.RegistrarSolicitudOrdenServicioEmail(oSolicitudOrdenServicioEmail);
        }

        public ListaSolicitudOrdenServicioExportDto ConsultarExport(FiltroSolicitudDto oFiltroSolicitudDto)
        {
            FiltroSolicitud oFiltroReporte = _mapper.Map<FiltroSolicitudDto, FiltroSolicitud>(oFiltroSolicitudDto);

            return _mapper.Map<ListaSolicitudOrdenServicioExport, ListaSolicitudOrdenServicioExportDto>(oISolicitudOrdenServicioRepository.ConsultarExport(oFiltroReporte));
        }

        public ListaSolicitudOrdenServicioExportDto ConsultarExportPorSolicitud(FiltroSolicitudDto oFiltroSolicitudDto)
        {
            FiltroSolicitud oFiltroReporte = _mapper.Map<FiltroSolicitudDto, FiltroSolicitud>(oFiltroSolicitudDto);

            return _mapper.Map<ListaSolicitudOrdenServicioExport, ListaSolicitudOrdenServicioExportDto>(oISolicitudOrdenServicioRepository.ConsultarExportPorSolicitud(oFiltroReporte));
        }

        public ListaSolicitudOrdenServicioExportDto ConsultarExportPorProveedor(FiltroSolicitudDto oFiltroSolicitudDto)
        {
            FiltroSolicitud oFiltroReporte = _mapper.Map<FiltroSolicitudDto, FiltroSolicitud>(oFiltroSolicitudDto);

            return _mapper.Map<ListaSolicitudOrdenServicioExport, ListaSolicitudOrdenServicioExportDto>(oISolicitudOrdenServicioRepository.ConsultarExportPorProveedor(oFiltroReporte));
        }

        public DashboardResponse ObtenerDashboard(FiltroSolicitudDto oFiltroSolicitudDto)
        {
            DashboardResponse oDashboardResponse = new DashboardResponse();
            FiltroSolicitud oFiltroReporte = _mapper.Map<FiltroSolicitudDto, FiltroSolicitud>(oFiltroSolicitudDto);

            oDashboardResponse.SolicitudOrdenServicioDashboardDto = _mapper.Map<SolicitudOrdenServicioDashboard, SolicitudOrdenServicioDashboardDto>(oISolicitudOrdenServicioRepository.ObtenerDashboard(oFiltroReporte));
            oDashboardResponse.ListaSolicitudRegularizacionDto = _mapper.Map<ListaSolicitudRegularizacion, ListaSolicitudRegularizacionDto>(oISolicitudOrdenServicioRepository.ObtenerDashboardSolicitudRegularizacion(oFiltroReporte));

            return oDashboardResponse;
        }

        public ListaSolicitudOrdenServicioDto ConsultarPendientesPorUsuario(int idUsuario)
        {
            return _mapper.Map<ListaSolicitudOrdenServicio, ListaSolicitudOrdenServicioDto>(oISolicitudOrdenServicioRepository.ConsultarPendientesPorUsuario(idUsuario));
        }
    }
}
