using Microsoft.Reporting.WebForms;
using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Body;
using Minsur.OrdenServicio.WebAPI.NET.DataAccess;
using Minsur.OrdenServicio.WebAPI.NET.Report.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Minsur.OrdenServicio.WebAPI.NET.BusinessLogic
{
    public class ReporteSolicitudBusinessLogic
    {
        private readonly ReporteSolicitudDataAccess oReporteSolicitudDataAccess = new ReporteSolicitudDataAccess();

        public TransactionResponse GenerarPDF(SolicitudOrdenServicioDto oSolicitudOrdenServicioDto)
        {
            TransactionResponse oTransactionResponse = new TransactionResponse();
            IEnumerable<ReporteSolicitudAutorizacion> listaReporteSolicitudAutorzacion = ObtenerListaReporteSolicitudAutorizacion(oSolicitudOrdenServicioDto.ListaSolicitudAutorizacionDto);
            IEnumerable<ReporteProveedor> listaReporteProveedor = ObtenerListaReporteProveedor(oSolicitudOrdenServicioDto.ListaSolicitudProveedorContratistaDto);

            try
            {
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                ReportViewer oReportViewer = new ReportViewer();
                oReportViewer.ProcessingMode = ProcessingMode.Local;

                oReportViewer.LocalReport.ReportPath = Path.Combine(HostingEnvironment.MapPath("~/Report"), "SolicitudOrdenServicio.rdlc");

                ReportParameter[] oReportParameter = new ReportParameter[29];
                oReportParameter[0] = new ReportParameter("NumeroSolicitud", oSolicitudOrdenServicioDto.NumeroSolicitud);
                oReportParameter[1] = new ReportParameter("FechaSolicitud", oSolicitudOrdenServicioDto.FechaSolicitud);
                oReportParameter[2] = new ReportParameter("NombreSolicitante", oSolicitudOrdenServicioDto.UsuarioSolicitudDto.NombreApellido);
                oReportParameter[3] = new ReportParameter("Compania", oSolicitudOrdenServicioDto.CompaniaDto.Descripcion);
                oReportParameter[4] = new ReportParameter("FuenteContrato", oSolicitudOrdenServicioDto.FuenteContratoDto.Descripcion);
                oReportParameter[5] = new ReportParameter("Proyecto", oSolicitudOrdenServicioDto.ProyectoDto.Descripcion);
                oReportParameter[6] = new ReportParameter("FaseProyecto", oSolicitudOrdenServicioDto.FaseProyectoDto.Descripcion);
                oReportParameter[7] = new ReportParameter("Area", oSolicitudOrdenServicioDto.AreaFuncionalDto.Descripcion);
                oReportParameter[8] = new ReportParameter("Categoria", oSolicitudOrdenServicioDto.CategoriaDto.Descripcion);
                oReportParameter[9] = new ReportParameter("Moneda", string.IsNullOrEmpty(oSolicitudOrdenServicioDto.DescripcionMoneda) ? oSolicitudOrdenServicioDto.MonedaDto.Descripcion : oSolicitudOrdenServicioDto.DescripcionMoneda);
                oReportParameter[10] = new ReportParameter("MontoEstimado", oSolicitudOrdenServicioDto.MontoEstimado.ToString());
                oReportParameter[11] = new ReportParameter("FechaInicio", oSolicitudOrdenServicioDto.FechaInicio);
                oReportParameter[12] = new ReportParameter("FechaFin", oSolicitudOrdenServicioDto.FechaTermino);
                oReportParameter[13] = new ReportParameter("DiasCalendario", oSolicitudOrdenServicioDto.DiasCalendario.ToString());
                oReportParameter[14] = new ReportParameter("DenominacionServicio", oSolicitudOrdenServicioDto.DenominacionServicio);
                oReportParameter[15] = new ReportParameter("UbicacionServicio", oSolicitudOrdenServicioDto.UbicacionServicio);
                oReportParameter[16] = new ReportParameter("DescripcionServicio", oSolicitudOrdenServicioDto.DescripcionServicio);
                oReportParameter[17] = new ReportParameter("JustificacionSoleSource", oSolicitudOrdenServicioDto.JustificacionSoleSource);
                oReportParameter[18] = new ReportParameter("ValidacionNombreUsuario", oSolicitudOrdenServicioDto.SolicitudValidacionDto.UsuarioDto.NombreApellido);
                oReportParameter[19] = new ReportParameter("ValidacionFecha", oSolicitudOrdenServicioDto.SolicitudValidacionDto.FechaRegistro);
                oReportParameter[20] = new ReportParameter("ValidacionGrafo", oSolicitudOrdenServicioDto.SolicitudValidacionDto.Grafo);
                oReportParameter[21] = new ReportParameter("ValidacionPresupuestado", oSolicitudOrdenServicioDto.SolicitudValidacionDto.FlagExistePresupuesto ? "SI" : "NO");
                oReportParameter[22] = new ReportParameter("RecomendacionNombreUsuario", oSolicitudOrdenServicioDto.SolicitudRecomendacionDto.UsuarioDto.NombreApellido);
                oReportParameter[23] = new ReportParameter("RecomendacionFecha", oSolicitudOrdenServicioDto.SolicitudRecomendacionDto.FechaRegistro);
                oReportParameter[24] = new ReportParameter("RecomendacionEstado", oSolicitudOrdenServicioDto.SolicitudRecomendacionDto.Estado);
                oReportParameter[25] = new ReportParameter("RecomendacionComentario", oSolicitudOrdenServicioDto.SolicitudRecomendacionDto.Comentario);
                oReportParameter[26] = new ReportParameter("Tipo", oSolicitudOrdenServicioDto.TipoDto.Descripcion);
                oReportParameter[27] = new ReportParameter("ValidacionComentario", oSolicitudOrdenServicioDto.SolicitudValidacionDto.Comentario);
                oReportParameter[28] = new ReportParameter("ValidacionEstado", oSolicitudOrdenServicioDto.SolicitudValidacionDto.Estado);

                oReportViewer.LocalReport.SetParameters(oReportParameter);
                oReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DS_SolicitudOrdenServicio", listaReporteSolicitudAutorzacion));
                oReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DS_Proveedor", listaReporteProveedor));

                byte[] bytes = oReportViewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                string directorio = Path.Combine(ConfigurationManager.AppSettings["RutaArchivo"], oSolicitudOrdenServicioDto.NumeroSolicitud);
                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }
                
                using (FileStream fs = new FileStream(Path.Combine(directorio, $"{oSolicitudOrdenServicioDto.NumeroSolicitud}.pdf") , FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }

                oReporteSolicitudDataAccess.ActualizarPdf(oSolicitudOrdenServicioDto.IdSolicitudOrdenServicio, true);

                oTransactionResponse.Codigo = "SOL00000";
            }
            catch (Exception ex)
            {
                oReporteSolicitudDataAccess.ActualizarPdf(oSolicitudOrdenServicioDto.IdSolicitudOrdenServicio, false);
                oTransactionResponse.Codigo = "SOL99999";
                oTransactionResponse.Mensaje = ex.Message;
            }

            return oTransactionResponse;
        }

        private IEnumerable<ReporteSolicitudAutorizacion> ObtenerListaReporteSolicitudAutorizacion(ListaSolicitudAutorizacionDto oListaSolicitudAutorizacionDto)
        {
            return oListaSolicitudAutorizacionDto.Select(x => new ReporteSolicitudAutorizacion
                    {
                        IdGobernanza = x.GobernanzaDto.IdGobernanza,
                        NombreApellido = x.UsuarioDto.NombreApellido,
                        Fecha = x.FechaRegistro,
                        Estado = x.Estado,
                        Comentario = x.Comentario
                    });
        }

        private IEnumerable<ReporteProveedor> ObtenerListaReporteProveedor(ListaSolicitudProveedorContratistaDto oListaSolicitudProveedorContratistaDto)
        {
            return oListaSolicitudProveedorContratistaDto.Select(x => new ReporteProveedor
            {
                Nombre = x.DenominacionSocial,
                Procedencia = x.PaisDto.Descripcion,
                RUC = x.Documento
            });
        }
    }
}