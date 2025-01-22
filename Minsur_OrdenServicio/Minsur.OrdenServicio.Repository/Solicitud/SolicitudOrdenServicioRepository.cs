using Microsoft.Practices.EnterpriseLibrary.Data;
using Minsur.OrdenServicio.Common.Estructura;
using Minsur.OrdenServicio.Common.ExtensionMethod;
using Minsur.OrdenServicio.Common.Recursos;
using Minsur.OrdenServicio.Domain.Entities;
using Minsur.OrdenServicio.Domain.RepositoryContract.Solicitud;
using Minsur.OrdenServicio.Repository.Config;
using Minsur.OrdenServicio.Repository.Helper;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Xml;

namespace Minsur.OrdenServicio.Repository.Solicitud
{
    public class SolicitudOrdenServicioRepository : ISolicitudOrdenServicioRepository
    {
        private readonly Database oDatabase;

        public SolicitudOrdenServicioRepository([Named("Solicitud")]IDataBaseConfig oIDataBaseConfig)
        {
            oDatabase = oIDataBaseConfig.Database;
        }

        public int Registrar(XmlDocument oXmlDocument, out string codigoSolicitud)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Ins_SolicitudOrdenServicio);
            oDatabase.AddInParameter(oDbCommand, "@SolicitudOrdenServicioXml", DbType.Xml, oXmlDocument.DocumentElement.InnerXml);
            oDatabase.AddOutParameter(oDbCommand, "@CodigoSolicitud", DbType.String, Numeracion.Doce);

            int id = (int)oDatabase.ExecuteScalar(oDbCommand);
            codigoSolicitud = (string)oDatabase.GetParameterValue(oDbCommand, "@CodigoSolicitud");

            return id;
        }

        public ListaSolicitudOrdenServicio Consultar(FiltroSolicitud oFiltroReporte, Paginacion oPaginacion)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Consultar_SolicitudOrdenServicio);
            oDatabase.AddInParameter(oDbCommand, "@IdFuenteContrato", DbType.Int32, oFiltroReporte.IdFuenteContrato);
            oDatabase.AddInParameter(oDbCommand, "@IdProyecto", DbType.Int32, oFiltroReporte.IdProyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdCompania", DbType.Int32, oFiltroReporte.IdCompania);
            oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, oFiltroReporte.IdEstado);
            oDatabase.AddInParameter(oDbCommand, "@IdAreaFuncional", DbType.Int32, oFiltroReporte.IdAreaFuncional);
            oDatabase.AddInParameter(oDbCommand, "@IdFaseProyecto", DbType.Int32, oFiltroReporte.IdFaseProyecto);
            oDatabase.AddInParameter(oDbCommand, "@FechaInicio", DbType.String, oFiltroReporte.FechaInicio);
            oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.String, oFiltroReporte.FechaFin);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, oFiltroReporte.IdUsuario);
            oDatabase.AddInParameter(oDbCommand, "@Page", DbType.Int32, oPaginacion.Page);
            oDatabase.AddInParameter(oDbCommand, "@RowsPerPage", DbType.Int32, oPaginacion.RowsPerPage);
            oDatabase.AddOutParameter(oDbCommand, "@RowCount", DbType.Int32, 0);
            ListaSolicitudOrdenServicio oListaSolicitudOrdenServicio = new ListaSolicitudOrdenServicio();
            SolicitudOrdenServicio oSolicitudOrdenServicio;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdSolicitudOrdenServicio = oIDataReader.GetOrdinal("IdSolicitudOrdenServicio");
                int indice_NumeroSolicitud = oIDataReader.GetOrdinal("NumeroSolicitud");
                int indice_FuenteContrato = oIDataReader.GetOrdinal("FuenteContrato");
                int indice_Proyecto = oIDataReader.GetOrdinal("Proyecto");
                int indice_Compania = oIDataReader.GetOrdinal("Compania");
                int indice_AreaFuncional = oIDataReader.GetOrdinal("AreaFuncional");
                int indice_FaseProyecto = oIDataReader.GetOrdinal("FaseProyecto");
                int indice_FechaSolicitud = oIDataReader.GetOrdinal("FechaSolicitud");
                int indice_Estado = oIDataReader.GetOrdinal("Estado");
                int indice_NombreUsuario = oIDataReader.GetOrdinal("NombreUsuario");
                int indice_UsuarioRevision = oIDataReader.GetOrdinal("UsuarioRevision");

                while (oIDataReader.Read())
                {
                    oSolicitudOrdenServicio = new SolicitudOrdenServicio();
                    oSolicitudOrdenServicio.FuenteContrato = new FuenteContrato();
                    oSolicitudOrdenServicio.Proyecto = new Proyecto();
                    oSolicitudOrdenServicio.Compania = new Compania();
                    oSolicitudOrdenServicio.AreaFuncional = new AreaFuncional();
                    oSolicitudOrdenServicio.FaseProyecto = new FaseProyecto();
                    oSolicitudOrdenServicio.Estado = new Estado();
                    oSolicitudOrdenServicio.UsuarioSolicitud = new Usuario();

                    oSolicitudOrdenServicio.IdSolicitudOrdenServicio = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdSolicitudOrdenServicio]);
                    oSolicitudOrdenServicio.NumeroSolicitud = DataUtil.DbValueToDefault<string>(oIDataReader[indice_NumeroSolicitud]);
                    oSolicitudOrdenServicio.FuenteContrato.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_FuenteContrato]);
                    oSolicitudOrdenServicio.Proyecto.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Proyecto]);
                    oSolicitudOrdenServicio.Compania.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Compania]);
                    oSolicitudOrdenServicio.AreaFuncional.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_AreaFuncional]);
                    oSolicitudOrdenServicio.FaseProyecto.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_FaseProyecto]);
                    oSolicitudOrdenServicio.FechaSolicitud = DataUtil.DbValueToDefault<DateTime>(oIDataReader[indice_FechaSolicitud]);
                    oSolicitudOrdenServicio.Estado.Nombre = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Estado]);
                    oSolicitudOrdenServicio.UsuarioSolicitud.NombreApellido = DataUtil.DbValueToDefault<string>(oIDataReader[indice_NombreUsuario]);
                    oSolicitudOrdenServicio.UsuarioRevision = DataUtil.DbValueToDefault<string>(oIDataReader[indice_UsuarioRevision]);

                    oListaSolicitudOrdenServicio.Add(oSolicitudOrdenServicio);
                }
            }

            oPaginacion.Total = (int)oDatabase.GetParameterValue(oDbCommand, "@RowCount");

            return oListaSolicitudOrdenServicio;
        }

        public ListaSolicitudOrdenServicioExport ConsultarExport(FiltroSolicitud oFiltroSolicitud)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Consultar_SolicitudOrdenServicio_Export);
            oDatabase.AddInParameter(oDbCommand, "@IdFuenteContrato", DbType.Int32, oFiltroSolicitud.IdFuenteContrato);
            oDatabase.AddInParameter(oDbCommand, "@IdProyecto", DbType.Int32, oFiltroSolicitud.IdProyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdCompania", DbType.Int32, oFiltroSolicitud.IdCompania);
            oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, oFiltroSolicitud.IdEstado);
            oDatabase.AddInParameter(oDbCommand, "@IdAreaFuncional", DbType.Int32, oFiltroSolicitud.IdAreaFuncional);
            oDatabase.AddInParameter(oDbCommand, "@IdFaseProyecto", DbType.Int32, oFiltroSolicitud.IdFaseProyecto);
            oDatabase.AddInParameter(oDbCommand, "@FechaInicio", DbType.String, oFiltroSolicitud.FechaInicio);
            oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.String, oFiltroSolicitud.FechaFin);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, oFiltroSolicitud.IdUsuario);

            ListaSolicitudOrdenServicioExport oListaSolicitudOrdenServicioExport = new ListaSolicitudOrdenServicioExport();
            SolicitudOrdenServicioExport oSolicitudOrdenServicioExport;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_NumeroSolicitud = oIDataReader.GetOrdinal("NumeroSolicitud");
                int indice_FuenteContrato = oIDataReader.GetOrdinal("FuenteContrato");
                int indice_Proyecto = oIDataReader.GetOrdinal("Proyecto");
                int indice_Compania = oIDataReader.GetOrdinal("Compania");
                int indice_Solicitante = oIDataReader.GetOrdinal("Solicitante");
                int indice_FaseProyecto = oIDataReader.GetOrdinal("FaseProyecto");
                int indice_AreaFuncional = oIDataReader.GetOrdinal("AreaFuncional");
                int indice_FechaSolicitud = oIDataReader.GetOrdinal("FechaSolicitud");
                int indice_Categoria = oIDataReader.GetOrdinal("Categoria");
                int indice_Moneda = oIDataReader.GetOrdinal("Moneda");
                int indice_MontoEstimado = oIDataReader.GetOrdinal("MontoEstimado");
                int indice_FechaInicio = oIDataReader.GetOrdinal("FechaInicio");
                int indice_FechaTermino = oIDataReader.GetOrdinal("FechaTermino");
                int indice_DiasCalendario = oIDataReader.GetOrdinal("DiasCalendario");
                int indice_DescripcionServicio = oIDataReader.GetOrdinal("DescripcionServicio");
                int indice_DenominacionServicio = oIDataReader.GetOrdinal("DenominacionServicio");
                int indice_UbicacionServicio = oIDataReader.GetOrdinal("UbicacionServicio");
                int indice_JustificacionSoleSource = oIDataReader.GetOrdinal("JustificacionSoleSource");
                int indice_DenominacionSocial = oIDataReader.GetOrdinal("DenominacionSocial");
                int indice_EstadoSolicitud = oIDataReader.GetOrdinal("EstadoSolicitud");
                int indice_RUC = oIDataReader.GetOrdinal("RUC");
                int indice_UsuarioValidacion = oIDataReader.GetOrdinal("UsuarioValidacion");
                int indice_Grafo = oIDataReader.GetOrdinal("Grafo");
                int indice_ComentarioValidacion = oIDataReader.GetOrdinal("ComentarioValidacion");
                int indice_FlagValidado = oIDataReader.GetOrdinal("FlagValidado");
                int indice_FechaValidacion = oIDataReader.GetOrdinal("FechaValidacion");

                while (oIDataReader.Read())
                {
                    oSolicitudOrdenServicioExport = new SolicitudOrdenServicioExport();
                    oSolicitudOrdenServicioExport.NumeroSolicitud = DataUtil.DbValueToDefault<string>(oIDataReader[indice_NumeroSolicitud]);
                    oSolicitudOrdenServicioExport.FuenteContrato = DataUtil.DbValueToDefault<string>(oIDataReader[indice_FuenteContrato]);
                    oSolicitudOrdenServicioExport.Proyecto = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Proyecto]);
                    oSolicitudOrdenServicioExport.Compania = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Compania]);
                    oSolicitudOrdenServicioExport.Solicitante = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Solicitante]);
                    oSolicitudOrdenServicioExport.FaseProyecto = DataUtil.DbValueToDefault<string>(oIDataReader[indice_FaseProyecto]);
                    oSolicitudOrdenServicioExport.AreaFuncional = DataUtil.DbValueToDefault<string>(oIDataReader[indice_AreaFuncional]);
                    oSolicitudOrdenServicioExport.FechaSolicitud = DataUtil.DbValueToDefault<DateTime>(oIDataReader[indice_FechaSolicitud]).ToString("dd/MM/yyyy hh:mm:ss");
                    oSolicitudOrdenServicioExport.Categoria = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Categoria]);
                    oSolicitudOrdenServicioExport.Moneda = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Moneda]);
                    oSolicitudOrdenServicioExport.MontoEstimado = DataUtil.DbValueToDefault<decimal>(oIDataReader[indice_MontoEstimado]);
                    oSolicitudOrdenServicioExport.FechaInicio = DataUtil.DbValueToDefault<DateTime>(oIDataReader[indice_FechaInicio]).ToString("dd/MM/yyyy");
                    oSolicitudOrdenServicioExport.FechaTermino = DataUtil.DbValueToDefault<DateTime>(oIDataReader[indice_FechaTermino]).ToString("dd/MM/yyyy");
                    oSolicitudOrdenServicioExport.DiasCalendario = DataUtil.DbValueToDefault<int>(oIDataReader[indice_DiasCalendario]);
                    oSolicitudOrdenServicioExport.DenominacionServicio = DataUtil.DbValueToDefault<string>(oIDataReader[indice_DenominacionServicio]);
                    oSolicitudOrdenServicioExport.UbicacionServicio = DataUtil.DbValueToDefault<string>(oIDataReader[indice_UbicacionServicio]);
                    oSolicitudOrdenServicioExport.JustificacionSoleSource = DataUtil.DbValueToDefault<string>(oIDataReader[indice_JustificacionSoleSource]);
                    oSolicitudOrdenServicioExport.DenominacionSocial = DataUtil.DbValueToDefault<string>(oIDataReader[indice_DenominacionSocial]);
                    oSolicitudOrdenServicioExport.EstadoSolicitud = DataUtil.DbValueToDefault<string>(oIDataReader[indice_EstadoSolicitud]);
                    oSolicitudOrdenServicioExport.UsuarioValidacion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_UsuarioValidacion]);
                    oSolicitudOrdenServicioExport.Grafo = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Grafo]);
                    oSolicitudOrdenServicioExport.ComentarioValidacion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_ComentarioValidacion]);
                    oSolicitudOrdenServicioExport.EstadoValidacion = string.IsNullOrEmpty(oSolicitudOrdenServicioExport.UsuarioValidacion) ? string.Empty : DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagValidado]) ? Constantes.Validado : Constantes.NoValidado;
                    oSolicitudOrdenServicioExport.FechaValidacion = DataUtil.DbValueToDefault<DateTime?>(oIDataReader[indice_FechaValidacion]).ToStringDateTimeNullFormat("dd/MM/yyyy hh:mm:ss");

                    oListaSolicitudOrdenServicioExport.Add(oSolicitudOrdenServicioExport);
                }
            }

            return oListaSolicitudOrdenServicioExport;
        }

        public ListaSolicitudOrdenServicioExport ConsultarExportPorSolicitud(FiltroSolicitud oFiltroSolicitud)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Export_SolicitudOrdenServicio);
            oDatabase.AddInParameter(oDbCommand, "@IdFuenteContrato", DbType.Int32, oFiltroSolicitud.IdFuenteContrato);
            oDatabase.AddInParameter(oDbCommand, "@IdProyecto", DbType.Int32, oFiltroSolicitud.IdProyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdCompania", DbType.Int32, oFiltroSolicitud.IdCompania);
            oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, oFiltroSolicitud.IdEstado);
            oDatabase.AddInParameter(oDbCommand, "@IdAreaFuncional", DbType.Int32, oFiltroSolicitud.IdAreaFuncional);
            oDatabase.AddInParameter(oDbCommand, "@IdFaseProyecto", DbType.Int32, oFiltroSolicitud.IdFaseProyecto);
            oDatabase.AddInParameter(oDbCommand, "@FechaInicio", DbType.String, oFiltroSolicitud.FechaInicio);
            oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.String, oFiltroSolicitud.FechaFin);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, oFiltroSolicitud.IdUsuario);

            ListaSolicitudOrdenServicioExport oListaSolicitudOrdenServicioExport = new ListaSolicitudOrdenServicioExport();
            SolicitudOrdenServicioExport oSolicitudOrdenServicioExport;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_NumeroSolicitud = oIDataReader.GetOrdinal("NumeroSolicitud");
                int indice_Compania = oIDataReader.GetOrdinal("Compania");
                int indice_FuenteContrato = oIDataReader.GetOrdinal("FuenteContrato");
                int indice_Proyecto = oIDataReader.GetOrdinal("Proyecto");
                int indice_Solicitante = oIDataReader.GetOrdinal("Solicitante");
                int indice_FaseProyecto = oIDataReader.GetOrdinal("FaseProyecto");
                int indice_AreaFuncional = oIDataReader.GetOrdinal("AreaFuncional");
                int indice_FechaSolicitud = oIDataReader.GetOrdinal("FechaSolicitud");
                int indice_Categoria = oIDataReader.GetOrdinal("Categoria");
                int indice_TipoSolicitud = oIDataReader.GetOrdinal("TipoSolicitud");
                int indice_Moneda = oIDataReader.GetOrdinal("Moneda");
                int indice_MontoEstimado = oIDataReader.GetOrdinal("MontoEstimado");
                int indice_FechaInicio = oIDataReader.GetOrdinal("FechaInicio");
                int indice_FechaTermino = oIDataReader.GetOrdinal("FechaTermino");
                int indice_DiasCalendario = oIDataReader.GetOrdinal("DiasCalendario");
                int indice_DenominacionServicio = oIDataReader.GetOrdinal("DenominacionServicio");
                int indice_UbicacionServicio = oIDataReader.GetOrdinal("UbicacionServicio");
                int indice_Proveedor = oIDataReader.GetOrdinal("Proveedor");
                int indice_UsuarioValidacion = oIDataReader.GetOrdinal("UsuarioValidacion");
                int indice_Grafo = oIDataReader.GetOrdinal("Grafo");
                int indice_FlagValidado = oIDataReader.GetOrdinal("FlagValidado");
                int indice_FechaValidacion = oIDataReader.GetOrdinal("FechaValidacion");
                int indice_UsuarioRecomendacion = oIDataReader.GetOrdinal("UsuarioRecomendacion");
                int indice_FlagRecomendado = oIDataReader.GetOrdinal("FlagRecomendado");
                int indice_FechaRecomendacion = oIDataReader.GetOrdinal("FechaRecomendacion");
                int indice_UsuarioAutorizacionAreaFuncional = oIDataReader.GetOrdinal("UsuarioAutorizacionAreaFuncional");
                int indice_FlagAprobadoAreaFuncional = oIDataReader.GetOrdinal("FlagAprobadoAreaFuncional");
                int indice_FechaAutorizacionAreaFuncional = oIDataReader.GetOrdinal("FechaAutorizacionAreaFuncional");
                int indice_UsuarioAutorizacionGerenteProyecto = oIDataReader.GetOrdinal("UsuarioAutorizacionGerenteProyecto");
                int indice_FlagAprobadoGerenteProyecto = oIDataReader.GetOrdinal("FlagAprobadoGerenteProyecto");
                int indice_FechaAutorizacionGerenteProyecto = oIDataReader.GetOrdinal("FechaAutorizacionGerenteProyecto");
                int indice_UsuarioAutorizacionGerenteCorporativo = oIDataReader.GetOrdinal("UsuarioAutorizacionGerenteCorporativo");
                int indice_FlagAprobadoGerenteCorporativo = oIDataReader.GetOrdinal("FlagAprobadoGerenteCorporativo");
                int indice_FechaAutorizacionGerenteCorporativo = oIDataReader.GetOrdinal("FechaAutorizacionGerenteCorporativo");
                int indice_EstadoSolicitud = oIDataReader.GetOrdinal("EstadoSolicitud");
                
                while (oIDataReader.Read())
                {
                    oSolicitudOrdenServicioExport = new SolicitudOrdenServicioExport();
                    oSolicitudOrdenServicioExport.NumeroSolicitud = DataUtil.DbValueToDefault<string>(oIDataReader[indice_NumeroSolicitud]);
                    oSolicitudOrdenServicioExport.Compania = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Compania]);
                    oSolicitudOrdenServicioExport.FuenteContrato = DataUtil.DbValueToDefault<string>(oIDataReader[indice_FuenteContrato]);
                    oSolicitudOrdenServicioExport.Proyecto = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Proyecto]);
                    oSolicitudOrdenServicioExport.Solicitante = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Solicitante]);
                    oSolicitudOrdenServicioExport.FaseProyecto = DataUtil.DbValueToDefault<string>(oIDataReader[indice_FaseProyecto]);
                    oSolicitudOrdenServicioExport.AreaFuncional = DataUtil.DbValueToDefault<string>(oIDataReader[indice_AreaFuncional]);
                    oSolicitudOrdenServicioExport.FechaSolicitud = DataUtil.DbValueToDefault<DateTime>(oIDataReader[indice_FechaSolicitud]).ToString("dd/MM/yyyy");
                    oSolicitudOrdenServicioExport.Categoria = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Categoria]);
                    oSolicitudOrdenServicioExport.TipoSolicitud = DataUtil.DbValueToDefault<string>(oIDataReader[indice_TipoSolicitud]);
                    oSolicitudOrdenServicioExport.Moneda = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Moneda]);
                    oSolicitudOrdenServicioExport.MontoEstimado = DataUtil.DbValueToDefault<decimal>(oIDataReader[indice_MontoEstimado]);
                    oSolicitudOrdenServicioExport.FechaInicio = DataUtil.DbValueToDefault<DateTime>(oIDataReader[indice_FechaInicio]).ToString("dd/MM/yyyy");
                    oSolicitudOrdenServicioExport.FechaTermino = DataUtil.DbValueToDefault<DateTime>(oIDataReader[indice_FechaTermino]).ToString("dd/MM/yyyy");
                    oSolicitudOrdenServicioExport.DiasCalendario = DataUtil.DbValueToDefault<int>(oIDataReader[indice_DiasCalendario]);
                    oSolicitudOrdenServicioExport.DenominacionServicio = DataUtil.DbValueToDefault<string>(oIDataReader[indice_DenominacionServicio]);
                    oSolicitudOrdenServicioExport.UbicacionServicio = DataUtil.DbValueToDefault<string>(oIDataReader[indice_UbicacionServicio]);
                    oSolicitudOrdenServicioExport.DenominacionSocial = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Proveedor]);
                    oSolicitudOrdenServicioExport.UsuarioValidacion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_UsuarioValidacion]);
                    oSolicitudOrdenServicioExport.Grafo = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Grafo]);
                    oSolicitudOrdenServicioExport.EstadoValidacion = string.IsNullOrEmpty(oSolicitudOrdenServicioExport.UsuarioValidacion) ? string.Empty : DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagValidado]) ? Constantes.Validado : Constantes.NoValidado;
                    oSolicitudOrdenServicioExport.FechaValidacion = DataUtil.DbValueToDefault<DateTime?>(oIDataReader[indice_FechaValidacion]).ToStringDateTimeNullFormat("dd/MM/yyyy hh:mm:ss");

                    oSolicitudOrdenServicioExport.UsuarioRecomendacion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_UsuarioRecomendacion]);
                    oSolicitudOrdenServicioExport.EstadoRecomendacion = string.IsNullOrEmpty(oSolicitudOrdenServicioExport.UsuarioRecomendacion) ? string.Empty : DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagRecomendado]) ? Constantes.Recomienda : Constantes.NoRecomienda;
                    oSolicitudOrdenServicioExport.FechaRecomendacion = DataUtil.DbValueToDefault<DateTime?>(oIDataReader[indice_FechaRecomendacion]).ToStringDateTimeNullFormat("dd/MM/yyyy hh:mm:ss");

                    oSolicitudOrdenServicioExport.UsuarioAutorizacionAreaFuncional = DataUtil.DbValueToDefault<string>(oIDataReader[indice_UsuarioAutorizacionAreaFuncional]);
                    oSolicitudOrdenServicioExport.EstadoAutorizacionAreaFuncional = string.IsNullOrEmpty(oSolicitudOrdenServicioExport.UsuarioAutorizacionAreaFuncional) ? string.Empty : DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagAprobadoAreaFuncional]) ? Constantes.Aprobado : Constantes.Rechazado;
                    oSolicitudOrdenServicioExport.FechaAutorizacionAreaFuncional = DataUtil.DbValueToDefault<DateTime?>(oIDataReader[indice_FechaAutorizacionAreaFuncional]).ToStringDateTimeNullFormat("dd/MM/yyyy hh:mm:ss");

                    oSolicitudOrdenServicioExport.UsuarioAutorizacionGerenteProyecto = DataUtil.DbValueToDefault<string>(oIDataReader[indice_UsuarioAutorizacionGerenteProyecto]);
                    oSolicitudOrdenServicioExport.EstadoAutorizacionGerenteProyecto = string.IsNullOrEmpty(oSolicitudOrdenServicioExport.UsuarioAutorizacionGerenteProyecto) ? string.Empty : DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagAprobadoGerenteProyecto]) ? Constantes.Aprobado : Constantes.Rechazado;
                    oSolicitudOrdenServicioExport.FechaAutorizacionGerenteProyecto = DataUtil.DbValueToDefault<DateTime?>(oIDataReader[indice_FechaAutorizacionGerenteProyecto]).ToStringDateTimeNullFormat("dd/MM/yyyy hh:mm:ss");

                    oSolicitudOrdenServicioExport.UsuarioAutorizacionGerenteCorporativo = DataUtil.DbValueToDefault<string>(oIDataReader[indice_UsuarioAutorizacionGerenteCorporativo]);
                    oSolicitudOrdenServicioExport.EstadoAutorizacionGerenteCorporativo = string.IsNullOrEmpty(oSolicitudOrdenServicioExport.UsuarioAutorizacionGerenteCorporativo) ? string.Empty : DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagAprobadoGerenteCorporativo]) ? Constantes.Aprobado : Constantes.Rechazado;
                    oSolicitudOrdenServicioExport.FechaAutorizacionGerenteCorporativo = DataUtil.DbValueToDefault<DateTime?>(oIDataReader[indice_FechaAutorizacionGerenteCorporativo]).ToStringDateTimeNullFormat("dd/MM/yyyy hh:mm:ss");



                    oSolicitudOrdenServicioExport.EstadoSolicitud = DataUtil.DbValueToDefault<string>(oIDataReader[indice_EstadoSolicitud]);


                    oListaSolicitudOrdenServicioExport.Add(oSolicitudOrdenServicioExport);
                }
            }

            return oListaSolicitudOrdenServicioExport;
        }

        public ListaSolicitudOrdenServicioExport ConsultarExportPorProveedor(FiltroSolicitud oFiltroSolicitud)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Export_SolicitudOrdenServicio_Por_Proveedor);
            oDatabase.AddInParameter(oDbCommand, "@IdFuenteContrato", DbType.Int32, oFiltroSolicitud.IdFuenteContrato);
            oDatabase.AddInParameter(oDbCommand, "@IdProyecto", DbType.Int32, oFiltroSolicitud.IdProyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdCompania", DbType.Int32, oFiltroSolicitud.IdCompania);
            oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, oFiltroSolicitud.IdEstado);
            oDatabase.AddInParameter(oDbCommand, "@IdAreaFuncional", DbType.Int32, oFiltroSolicitud.IdAreaFuncional);
            oDatabase.AddInParameter(oDbCommand, "@IdFaseProyecto", DbType.Int32, oFiltroSolicitud.IdFaseProyecto);
            oDatabase.AddInParameter(oDbCommand, "@FechaInicio", DbType.String, oFiltroSolicitud.FechaInicio);
            oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.String, oFiltroSolicitud.FechaFin);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, oFiltroSolicitud.IdUsuario);

            ListaSolicitudOrdenServicioExport oListaSolicitudOrdenServicioExport = new ListaSolicitudOrdenServicioExport();
            SolicitudOrdenServicioExport oSolicitudOrdenServicioExport;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_RUC= oIDataReader.GetOrdinal("RUC");
                int indice_DenominacionSocial = oIDataReader.GetOrdinal("DenominacionSocial");
                int indice_NumeroSolicitud	 = oIDataReader.GetOrdinal("NumeroSolicitud");
                int indice_Compania	 = oIDataReader.GetOrdinal("Compania");
                int indice_FuenteContrato = oIDataReader.GetOrdinal("FuenteContrato");
                int indice_Proyecto = oIDataReader.GetOrdinal("Proyecto");
                int indice_Solicitante = oIDataReader.GetOrdinal("Solicitante");
                int indice_FaseProyecto = oIDataReader.GetOrdinal("FaseProyecto");
                int indice_AreaFuncional = oIDataReader.GetOrdinal("AreaFuncional");
                int indice_FechaSolicitud = oIDataReader.GetOrdinal("FechaSolicitud");
                int indice_Categoria = oIDataReader.GetOrdinal("Categoria");
                int indice_TipoSolicitud = oIDataReader.GetOrdinal("TipoSolicitud");
                int indice_UsuarioValidacion = oIDataReader.GetOrdinal("UsuarioValidacion");
                int indice_FlagValidado = oIDataReader.GetOrdinal("FlagValidado");
                int indice_FechaValidacion = oIDataReader.GetOrdinal("FechaValidacion");
                int indice_UsuarioRecomendacion = oIDataReader.GetOrdinal("UsuarioRecomendacion");
                int indice_FlagRecomendado = oIDataReader.GetOrdinal("FlagRecomendado");
                int indice_FechaRecomendacion = oIDataReader.GetOrdinal("FechaRecomendacion");
                int indice_UsuarioAutorizacionAreaFuncional = oIDataReader.GetOrdinal("UsuarioAutorizacionAreaFuncional");
                int indice_FlagAprobadoAreaFuncional = oIDataReader.GetOrdinal("FlagAprobadoAreaFuncional");
                int indice_FechaAutorizacionAreaFuncional = oIDataReader.GetOrdinal("FechaAutorizacionAreaFuncional");
                int indice_UsuarioAutorizacionGerenteProyecto = oIDataReader.GetOrdinal("UsuarioAutorizacionGerenteProyecto");
                int indice_FlagAprobadoGerenteProyecto = oIDataReader.GetOrdinal("FlagAprobadoGerenteProyecto");
                int indice_FechaAutorizacionGerenteProyecto = oIDataReader.GetOrdinal("FechaAutorizacionGerenteProyecto");
                int indice_UsuarioAutorizacionGerenteCorporativo = oIDataReader.GetOrdinal("UsuarioAutorizacionGerenteCorporativo");
                int indice_FlagAprobadoGerenteCorporativo = oIDataReader.GetOrdinal("FlagAprobadoGerenteCorporativo");
                int indice_FechaAutorizacionGerenteCorporativo = oIDataReader.GetOrdinal("FechaAutorizacionGerenteCorporativo");
                int indice_EstadoSolicitud = oIDataReader.GetOrdinal("EstadoSolicitud");
               
                
                while (oIDataReader.Read())
                {
                    oSolicitudOrdenServicioExport = new SolicitudOrdenServicioExport();
                    oSolicitudOrdenServicioExport.Ruc = DataUtil.DbValueToDefault<string>(oIDataReader[indice_RUC]);
                    oSolicitudOrdenServicioExport.DenominacionSocial = DataUtil.DbValueToDefault<string>(oIDataReader[indice_DenominacionSocial]);
                    oSolicitudOrdenServicioExport.NumeroSolicitud = DataUtil.DbValueToDefault<string>(oIDataReader[indice_NumeroSolicitud]);
                    oSolicitudOrdenServicioExport.NumeroSolicitud = DataUtil.DbValueToDefault<string>(oIDataReader[indice_NumeroSolicitud]);
                    oSolicitudOrdenServicioExport.Compania = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Compania]);
                    oSolicitudOrdenServicioExport.FuenteContrato = DataUtil.DbValueToDefault<string>(oIDataReader[indice_FuenteContrato]);
                    oSolicitudOrdenServicioExport.Proyecto = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Proyecto]);
                    oSolicitudOrdenServicioExport.Solicitante = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Solicitante]);
                    oSolicitudOrdenServicioExport.FaseProyecto = DataUtil.DbValueToDefault<string>(oIDataReader[indice_FaseProyecto]);
                    oSolicitudOrdenServicioExport.AreaFuncional = DataUtil.DbValueToDefault<string>(oIDataReader[indice_AreaFuncional]);
                    oSolicitudOrdenServicioExport.FechaSolicitud = DataUtil.DbValueToDefault<DateTime>(oIDataReader[indice_FechaSolicitud]).ToString("dd/MM/yyyy");
                    oSolicitudOrdenServicioExport.Categoria = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Categoria]);
                    oSolicitudOrdenServicioExport.TipoSolicitud = DataUtil.DbValueToDefault<string>(oIDataReader[indice_TipoSolicitud]);
                    
                    oSolicitudOrdenServicioExport.UsuarioValidacion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_UsuarioValidacion]);
                    oSolicitudOrdenServicioExport.EstadoValidacion = string.IsNullOrEmpty(oSolicitudOrdenServicioExport.UsuarioValidacion) ? string.Empty : DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagValidado]) ? Constantes.Validado : Constantes.NoValidado;
                    oSolicitudOrdenServicioExport.FechaValidacion = DataUtil.DbValueToDefault<DateTime?>(oIDataReader[indice_FechaValidacion]).ToStringDateTimeNullFormat("dd/MM/yyyy hh:mm:ss");

                    oSolicitudOrdenServicioExport.UsuarioRecomendacion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_UsuarioRecomendacion]);
                    oSolicitudOrdenServicioExport.EstadoRecomendacion = string.IsNullOrEmpty(oSolicitudOrdenServicioExport.UsuarioRecomendacion) ? string.Empty : DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagRecomendado]) ? Constantes.Recomienda : Constantes.NoRecomienda;
                    oSolicitudOrdenServicioExport.FechaRecomendacion = DataUtil.DbValueToDefault<DateTime?>(oIDataReader[indice_FechaRecomendacion]).ToStringDateTimeNullFormat("dd/MM/yyyy hh:mm:ss");

                    oSolicitudOrdenServicioExport.UsuarioAutorizacionAreaFuncional = DataUtil.DbValueToDefault<string>(oIDataReader[indice_UsuarioAutorizacionAreaFuncional]);
                    oSolicitudOrdenServicioExport.EstadoAutorizacionAreaFuncional = string.IsNullOrEmpty(oSolicitudOrdenServicioExport.UsuarioAutorizacionAreaFuncional) ? string.Empty : DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagAprobadoAreaFuncional]) ? Constantes.Aprobado : Constantes.Rechazado;
                    oSolicitudOrdenServicioExport.FechaAutorizacionAreaFuncional = DataUtil.DbValueToDefault<DateTime?>(oIDataReader[indice_FechaAutorizacionAreaFuncional]).ToStringDateTimeNullFormat("dd/MM/yyyy hh:mm:ss");

                    oSolicitudOrdenServicioExport.UsuarioAutorizacionGerenteProyecto = DataUtil.DbValueToDefault<string>(oIDataReader[indice_UsuarioAutorizacionGerenteProyecto]);
                    oSolicitudOrdenServicioExport.EstadoAutorizacionGerenteProyecto = string.IsNullOrEmpty(oSolicitudOrdenServicioExport.UsuarioAutorizacionGerenteProyecto) ? string.Empty : DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagAprobadoGerenteProyecto]) ? Constantes.Aprobado : Constantes.Rechazado;
                    oSolicitudOrdenServicioExport.FechaAutorizacionGerenteProyecto = DataUtil.DbValueToDefault<DateTime?>(oIDataReader[indice_FechaAutorizacionGerenteProyecto]).ToStringDateTimeNullFormat("dd/MM/yyyy hh:mm:ss");

                    oSolicitudOrdenServicioExport.UsuarioAutorizacionGerenteCorporativo = DataUtil.DbValueToDefault<string>(oIDataReader[indice_UsuarioAutorizacionGerenteCorporativo]);
                    oSolicitudOrdenServicioExport.EstadoAutorizacionGerenteCorporativo = string.IsNullOrEmpty(oSolicitudOrdenServicioExport.UsuarioAutorizacionGerenteCorporativo) ? string.Empty : DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagAprobadoGerenteCorporativo]) ? Constantes.Aprobado : Constantes.Rechazado;
                    oSolicitudOrdenServicioExport.FechaAutorizacionGerenteCorporativo = DataUtil.DbValueToDefault<DateTime?>(oIDataReader[indice_FechaAutorizacionGerenteCorporativo]).ToStringDateTimeNullFormat("dd/MM/yyyy hh:mm:ss");



                    oSolicitudOrdenServicioExport.EstadoSolicitud = DataUtil.DbValueToDefault<string>(oIDataReader[indice_EstadoSolicitud]);


                    oListaSolicitudOrdenServicioExport.Add(oSolicitudOrdenServicioExport);
                }
            }

            return oListaSolicitudOrdenServicioExport;
        }


        public SolicitudOrdenServicio ObtenerSolicitudPorId(int idSolicitudOrdenServicio)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Sel_SolicitudOrdenServicio_Por_Id);
            oDatabase.AddInParameter(oDbCommand, "@IdSolicitudOrdenServicio", DbType.Int32, idSolicitudOrdenServicio);
            SolicitudOrdenServicio oSolicitudOrdenServicio = new SolicitudOrdenServicio();

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdSolicitudOrdenServicio = oIDataReader.GetOrdinal("IdSolicitudOrdenServicio");
                int indice_NumeroSolicitud = oIDataReader.GetOrdinal("NumeroSolicitud");
                int indice_IdCompania = oIDataReader.GetOrdinal("IdCompania");
                int indice_DescripcionCompania	= oIDataReader.GetOrdinal("DescripcionCompania");
                int indice_IdFuenteContrato = oIDataReader.GetOrdinal("IdFuenteContrato");
                int indice_DescripcionFuenteContrato = oIDataReader.GetOrdinal("DescripcionFuenteContrato");
                int indice_IdProyecto = oIDataReader.GetOrdinal("IdProyecto");
                int indice_DescripcionProyecto = oIDataReader.GetOrdinal("DescripcionProyecto");
                int indice_IdFaseProyecto = oIDataReader.GetOrdinal("IdFaseProyecto");
                int indice_DescripcionFaseProyecto = oIDataReader.GetOrdinal("DescripcionFaseProyecto");
                int indice_IdAreaFuncional = oIDataReader.GetOrdinal("IdAreaFuncional");
                int indice_DescripcionAreaFuncional = oIDataReader.GetOrdinal("DescripcionAreaFuncional");
                int indice_IdCategoria = oIDataReader.GetOrdinal("IdCategoria");
                int indice_DescripcionCategoria = oIDataReader.GetOrdinal("DescripcionCategoria");
                int indice_IdTipo = oIDataReader.GetOrdinal("IdTipo");
                int indice_DescripcionTipo = oIDataReader.GetOrdinal("DescripcionTipo");            
                int indice_IdMoneda = oIDataReader.GetOrdinal("IdMoneda");
                int indice_DescripcionMoneda = oIDataReader.GetOrdinal("DescripcionMoneda");
                int indice_FechaSolicitud = oIDataReader.GetOrdinal("FechaSolicitud");
                int indice_MontoEstimado = oIDataReader.GetOrdinal("MontoEstimado");
                int indice_FechaInicio = oIDataReader.GetOrdinal("FechaInicio");
                int indice_FechaTermino = oIDataReader.GetOrdinal("FechaTermino");
                int indice_DiasCalendario = oIDataReader.GetOrdinal("DiasCalendario");
                int indice_DenominacionServicio = oIDataReader.GetOrdinal("DenominacionServicio");
                int indice_DescripcionServicio = oIDataReader.GetOrdinal("DescripcionServicio");
                int indice_UbicacionServicio = oIDataReader.GetOrdinal("UbicacionServicio");
                int indice_JustificacionSoleSource = oIDataReader.GetOrdinal("JustificacionSoleSource");
                int indice_IdEstado = oIDataReader.GetOrdinal("IdEstado");
                int indice_DescripcionEstado = oIDataReader.GetOrdinal("DescripcionEstado");
                int indice_IdUsuarioSolicitante = oIDataReader.GetOrdinal("IdUsuarioSolicitante");
                int indice_NombreUsuarioSolicitante = oIDataReader.GetOrdinal("NombreUsuarioSolicitante");

                int indice_IdUsuarioValidacion = oIDataReader.GetOrdinal("IdUsuarioValidacion");
                int indice_UsuarioValidacion = oIDataReader.GetOrdinal("UsuarioValidacion");
                int indice_FlagExistePresupuesto = oIDataReader.GetOrdinal("FlagExistePresupuesto");
                int indice_Grafo = oIDataReader.GetOrdinal("Grafo");
                int indice_ComentarioValidacion = oIDataReader.GetOrdinal("ComentarioValidacion");
                int indice_FlagValidado = oIDataReader.GetOrdinal("FlagValidado");
                int indice_FechaRegistroValidacion = oIDataReader.GetOrdinal("FechaRegistroValidacion");

                int indice_IdUsuarioRecomendacion = oIDataReader.GetOrdinal("IdUsuarioRecomendacion");
                int indice_UsuarioRecomendacion = oIDataReader.GetOrdinal("UsuarioRecomendacion");
                int indice_ComentarioRecomendacion = oIDataReader.GetOrdinal("ComentarioRecomendacion");
                int indice_FlagRecomendado = oIDataReader.GetOrdinal("FlagRecomendado");
                int indice_FechaRecomendacion = oIDataReader.GetOrdinal("FechaRecomendacion");
                int indice_FlagPDFGenerado = oIDataReader.GetOrdinal("FlagPDFGenerado");

                if (oIDataReader.Read())
                {
                    oSolicitudOrdenServicio.Compania = new Compania();
                    oSolicitudOrdenServicio.FuenteContrato = new FuenteContrato();
                    oSolicitudOrdenServicio.Proyecto = new Proyecto();
                    oSolicitudOrdenServicio.FaseProyecto = new FaseProyecto();
                    oSolicitudOrdenServicio.AreaFuncional = new AreaFuncional();
                    oSolicitudOrdenServicio.Categoria = new Categoria();
                    oSolicitudOrdenServicio.Tipo = new Tipo();
                    oSolicitudOrdenServicio.Moneda = new Moneda();
                    oSolicitudOrdenServicio.Estado = new Estado();
                    oSolicitudOrdenServicio.UsuarioSolicitud = new Usuario();

                    oSolicitudOrdenServicio.SolicitudValidacion = new SolicitudValidacion();
                    oSolicitudOrdenServicio.SolicitudValidacion.Usuario = new Usuario();

                    oSolicitudOrdenServicio.SolicitudRecomendacion = new SolicitudRecomendacion();
                    oSolicitudOrdenServicio.SolicitudRecomendacion.Usuario = new Usuario();
                   

                    oSolicitudOrdenServicio.IdSolicitudOrdenServicio = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdSolicitudOrdenServicio]);
                    oSolicitudOrdenServicio.NumeroSolicitud = DataUtil.DbValueToDefault<string>(oIDataReader[indice_NumeroSolicitud]);
                    oSolicitudOrdenServicio.Compania.IdCompania = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdCompania]);
                    oSolicitudOrdenServicio.Compania.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_DescripcionCompania]);
                    oSolicitudOrdenServicio.FuenteContrato.IdFuenteContrato = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdFuenteContrato]);
                    oSolicitudOrdenServicio.FuenteContrato.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_DescripcionFuenteContrato]);
                    oSolicitudOrdenServicio.Proyecto.IdProyecto = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdProyecto]);
                    oSolicitudOrdenServicio.Proyecto.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_DescripcionProyecto]);
                    oSolicitudOrdenServicio.FaseProyecto.IdFaseProyecto = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdFaseProyecto]);
                    oSolicitudOrdenServicio.FaseProyecto.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_DescripcionFaseProyecto]);
                    oSolicitudOrdenServicio.AreaFuncional.IdAreaFuncional = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdAreaFuncional]);
                    oSolicitudOrdenServicio.AreaFuncional.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_DescripcionAreaFuncional]);
                    oSolicitudOrdenServicio.Categoria.IdCategoria = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdCategoria]);
                    oSolicitudOrdenServicio.Categoria.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_DescripcionCategoria]);
                    oSolicitudOrdenServicio.Tipo.IdTipo = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdTipo]);
                    oSolicitudOrdenServicio.Tipo.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_DescripcionTipo]);
                    oSolicitudOrdenServicio.Moneda.IdMoneda = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdMoneda]);
                    oSolicitudOrdenServicio.Moneda.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_DescripcionMoneda]);
                    oSolicitudOrdenServicio.FechaSolicitud = DataUtil.DbValueToDefault<DateTime>(oIDataReader[indice_FechaSolicitud]);
                    oSolicitudOrdenServicio.MontoEstimado = DataUtil.DbValueToDefault<decimal>(oIDataReader[indice_MontoEstimado]);
                    oSolicitudOrdenServicio.FechaInicio = DataUtil.DbValueToDefault<DateTime>(oIDataReader[indice_FechaInicio]);
                    oSolicitudOrdenServicio.FechaTermino = DataUtil.DbValueToDefault<DateTime>(oIDataReader[indice_FechaTermino]);
                    oSolicitudOrdenServicio.DiasCalendario = DataUtil.DbValueToDefault<int>(oIDataReader[indice_DiasCalendario]);
                    oSolicitudOrdenServicio.DenominacionServicio = DataUtil.DbValueToDefault<string>(oIDataReader[indice_DenominacionServicio]);
                    oSolicitudOrdenServicio.DescripcionServicio = DataUtil.DbValueToDefault<string>(oIDataReader[indice_DescripcionServicio]);
                    oSolicitudOrdenServicio.UbicacionServicio = DataUtil.DbValueToDefault<string>(oIDataReader[indice_UbicacionServicio]);
                    oSolicitudOrdenServicio.JustificacionSoleSource = DataUtil.DbValueToDefault<string>(oIDataReader[indice_JustificacionSoleSource]);
                    oSolicitudOrdenServicio.Estado.IdEstado = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdEstado]);
                    oSolicitudOrdenServicio.Estado.Nombre = DataUtil.DbValueToDefault<string>(oIDataReader[indice_DescripcionEstado]);
                    oSolicitudOrdenServicio.UsuarioSolicitud.IdUsuario = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdUsuarioSolicitante]);
                    oSolicitudOrdenServicio.UsuarioSolicitud.NombreApellido = DataUtil.DbValueToDefault<string>(oIDataReader[indice_NombreUsuarioSolicitante]);

                    oSolicitudOrdenServicio.SolicitudValidacion.Usuario.IdUsuario = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdUsuarioValidacion]);
                    oSolicitudOrdenServicio.SolicitudValidacion.Usuario.NombreApellido = DataUtil.DbValueToDefault<string>(oIDataReader[indice_UsuarioValidacion]);
                    oSolicitudOrdenServicio.SolicitudValidacion.FlagExistePresupuesto = DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagExistePresupuesto]);
                    oSolicitudOrdenServicio.SolicitudValidacion.Grafo = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Grafo]);
                    oSolicitudOrdenServicio.SolicitudValidacion.Comentario = DataUtil.DbValueToDefault<string>(oIDataReader[indice_ComentarioValidacion]);
                    oSolicitudOrdenServicio.SolicitudValidacion.FlagValidado = DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagValidado]);
                    oSolicitudOrdenServicio.SolicitudValidacion.FechaRegistro = DataUtil.DbValueToDefault<DateTime?>(oIDataReader[indice_FechaRegistroValidacion]);

                    oSolicitudOrdenServicio.SolicitudRecomendacion.Usuario.IdUsuario = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdUsuarioRecomendacion]);
                    oSolicitudOrdenServicio.SolicitudRecomendacion.Usuario.NombreApellido = DataUtil.DbValueToDefault<string>(oIDataReader[indice_UsuarioRecomendacion]);
                    oSolicitudOrdenServicio.SolicitudRecomendacion.Comentario = DataUtil.DbValueToDefault<string>(oIDataReader[indice_ComentarioRecomendacion]);
                    oSolicitudOrdenServicio.SolicitudRecomendacion.FlagRecomendado = DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagRecomendado]);
                    oSolicitudOrdenServicio.SolicitudRecomendacion.FechaRegistro = DataUtil.DbValueToDefault<DateTime?>(oIDataReader[indice_FechaRecomendacion]);
                    oSolicitudOrdenServicio.FlagPDFGenerado = DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagPDFGenerado]);
                }
            }

            return oSolicitudOrdenServicio;
        }

        public ListaSolicitudProveedorContratista ObtenerListaSolicitudProveedorContratistaPorIdSolicitud(int idSolicitudOrdenServicio)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Sel_SolicitudProveedorContratista);
            oDatabase.AddInParameter(oDbCommand, "@IdSolicitudOrdenServicio", DbType.Int32, idSolicitudOrdenServicio);

            ListaSolicitudProveedorContratista oListaSolicitudProveedorContratista = new ListaSolicitudProveedorContratista();
            SolicitudProveedorContratista oSolicitudProveedorContratista;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdSolicitudProveedorContratista = oIDataReader.GetOrdinal("IdSolicitudProveedorContratista");
                int indice_DenominacionSocial = oIDataReader.GetOrdinal("DenominacionSocial");
                int indice_Documento = oIDataReader.GetOrdinal("Documento");
                int indice_Pais = oIDataReader.GetOrdinal("Pais");

                while (oIDataReader.Read())
                {
                    oSolicitudProveedorContratista = new SolicitudProveedorContratista();
                    oSolicitudProveedorContratista.Pais = new Pais();

                    oSolicitudProveedorContratista.IdSolicitudProveedorContratista = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdSolicitudProveedorContratista]);
                    oSolicitudProveedorContratista.DenominacionSocial = DataUtil.DbValueToDefault<string>(oIDataReader[indice_DenominacionSocial]);
                    oSolicitudProveedorContratista.Documento = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Documento]);
                    oSolicitudProveedorContratista.Pais.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Pais]);

                    oListaSolicitudProveedorContratista.Add(oSolicitudProveedorContratista);
                }
            }

            return oListaSolicitudProveedorContratista;
        }

        public ListaSolicitudDocumento ObtenerListaSolicitudDocumentoPorIdSolicitud(int idSolicitudOrdenServicio)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Sel_SolicitudDocumento);
            oDatabase.AddInParameter(oDbCommand, "@IdSolicitudOrdenServicio", DbType.Int32, idSolicitudOrdenServicio);
            ListaSolicitudDocumento oListaSolicitudDocumento = new ListaSolicitudDocumento();
            SolicitudDocumento oSolicitudDocumento;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdSolicitudDocumento = oIDataReader.GetOrdinal("IdSolicitudDocumento");
                int indice_TipoDocumento = oIDataReader.GetOrdinal("TipoDocumento");

                while (oIDataReader.Read())
                {
                    oSolicitudDocumento = new SolicitudDocumento();
                    oSolicitudDocumento.TipoDocumento = new TipoDocumento();

                    oSolicitudDocumento.IdSolicitudDocumento = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdSolicitudDocumento]);
                    oSolicitudDocumento.TipoDocumento.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_TipoDocumento]);
                    oListaSolicitudDocumento.Add(oSolicitudDocumento);
                }
            }
            
            return oListaSolicitudDocumento;
        }

        public ListaSolicitudArchivoAdjunto ObtenerListaSolicitudArchivoAdjunto(int idSolicitudDocumento)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Sel_SolicitudArchivoAdjunto_Por_IdSolicitudDocumento);
            oDatabase.AddInParameter(oDbCommand, "@IdSolicitudDocumento", DbType.Int32, idSolicitudDocumento);
            ListaSolicitudArchivoAdjunto oListaSolicitudArchivoAdjunto = new ListaSolicitudArchivoAdjunto();
            SolicitudArchivoAdjunto oSolicitudArchivoAdjunto;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdSolicitudArchivoAdjunto = oIDataReader.GetOrdinal("IdSolicitudArchivoAdjunto");
                int indice_Directorio = oIDataReader.GetOrdinal("Directorio");
                int indice_NombreArchivo = oIDataReader.GetOrdinal("NombreArchivo");
                int indice_Extension = oIDataReader.GetOrdinal("Extension");
                int indice_Tamanio = oIDataReader.GetOrdinal("Tamanio");

                while (oIDataReader.Read())
                {
                    oSolicitudArchivoAdjunto = new SolicitudArchivoAdjunto();
                    oSolicitudArchivoAdjunto.IdSolicitudArchivoAdjunto = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdSolicitudArchivoAdjunto]);
                    oSolicitudArchivoAdjunto.Directorio = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Directorio]);
                    oSolicitudArchivoAdjunto.NombreArchivo = DataUtil.DbValueToDefault<string>(oIDataReader[indice_NombreArchivo]);
                    oSolicitudArchivoAdjunto.Extension= DataUtil.DbValueToDefault<string>(oIDataReader[indice_Extension]);
                    oSolicitudArchivoAdjunto.Tamanio= DataUtil.DbValueToDefault<int>(oIDataReader[indice_Tamanio]);

                    oListaSolicitudArchivoAdjunto.Add(oSolicitudArchivoAdjunto);
                }
            }

            return oListaSolicitudArchivoAdjunto;
        }
        
        public SolicitudArchivoAdjunto ObtenerArchivoAdjuntoPorId(int idSolicitudArchivoAdjunto)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Sel_SolicitudArchivoAdjunto_Por_Id);
            oDatabase.AddInParameter(oDbCommand, "@IdSolicitudArchivoAdjunto", DbType.Int32, idSolicitudArchivoAdjunto);
            SolicitudArchivoAdjunto oSolicitudArchivoAdjunto = new SolicitudArchivoAdjunto();

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdSolicitudArchivoAdjunto = oIDataReader.GetOrdinal("IdSolicitudArchivoAdjunto");
                int indice_Directorio = oIDataReader.GetOrdinal("Directorio");
                int indice_NombreArchivo = oIDataReader.GetOrdinal("NombreArchivo");
                int indice_Extension = oIDataReader.GetOrdinal("Extension");
                int indice_Tamanio = oIDataReader.GetOrdinal("Tamanio");
                int indice_TipoContenido = oIDataReader.GetOrdinal("TipoContenido");

                if (oIDataReader.Read())
                {
                    oSolicitudArchivoAdjunto.IdSolicitudArchivoAdjunto = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdSolicitudArchivoAdjunto]);
                    oSolicitudArchivoAdjunto.Directorio = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Directorio]);
                    oSolicitudArchivoAdjunto.NombreArchivo = DataUtil.DbValueToDefault<string>(oIDataReader[indice_NombreArchivo]);
                    oSolicitudArchivoAdjunto.Extension = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Extension]);
                    oSolicitudArchivoAdjunto.Tamanio = DataUtil.DbValueToDefault<int>(oIDataReader[indice_Tamanio]);
                    oSolicitudArchivoAdjunto.TipoContenido = DataUtil.DbValueToDefault<string>(oIDataReader[indice_TipoContenido]);
                }
            }

            return oSolicitudArchivoAdjunto;
        }

        public ListaSolicitudArchivoAdjunto ObtenerListaArchivoAdjuntoPorSolicitud(int idSolicitudOrdenServicio)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Sel_SolicitudArchivoAdjunto_Por_IdSolicitudOrdenServicio);
            oDatabase.AddInParameter(oDbCommand, "@IdSolicitudOrdenServicio", DbType.Int32, idSolicitudOrdenServicio);
            ListaSolicitudArchivoAdjunto oListaSolicitudArchivoAdjunto = new ListaSolicitudArchivoAdjunto();
            SolicitudArchivoAdjunto oSolicitudArchivoAdjunto;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_TipoDocumento = oIDataReader.GetOrdinal("TipoDocumento");
                int indice_Directorio = oIDataReader.GetOrdinal("Directorio");
                int indice_NombreArchivo = oIDataReader.GetOrdinal("NombreArchivo");
                int indice_Extension = oIDataReader.GetOrdinal("Extension");
                int indice_Tamanio = oIDataReader.GetOrdinal("Tamanio");
                int indice_TipoContenido = oIDataReader.GetOrdinal("TipoContenido");

                while (oIDataReader.Read())
                {
                    oSolicitudArchivoAdjunto = new SolicitudArchivoAdjunto();
                    oSolicitudArchivoAdjunto.Tipo = DataUtil.DbValueToDefault<string>(oIDataReader[indice_TipoDocumento]);
                    oSolicitudArchivoAdjunto.Directorio = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Directorio]);
                    oSolicitudArchivoAdjunto.NombreArchivo = DataUtil.DbValueToDefault<string>(oIDataReader[indice_NombreArchivo]);
                    oSolicitudArchivoAdjunto.Extension = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Extension]);
                    oSolicitudArchivoAdjunto.Tamanio = DataUtil.DbValueToDefault<int>(oIDataReader[indice_Tamanio]);
                    oSolicitudArchivoAdjunto.TipoContenido = DataUtil.DbValueToDefault<string>(oIDataReader[indice_TipoContenido]);

                    oListaSolicitudArchivoAdjunto.Add(oSolicitudArchivoAdjunto);
                }
            }

            return oListaSolicitudArchivoAdjunto;
        }

        public ListaSolicitudAutorizacion obtenerListaSolicitudAutorizacion(int idSolicitudOrdenServicio)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Sel_SolicitudAutorizacion);
            oDatabase.AddInParameter(oDbCommand, "@IdSolicitudOrdenServicio", DbType.Int32, idSolicitudOrdenServicio);
            ListaSolicitudAutorizacion oListaSolicitudAutorizacion = new ListaSolicitudAutorizacion();
            SolicitudAutorizacion oSolicitudAutorizacion;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indiceIdGobernanza = oIDataReader.GetOrdinal("IdGobernanza");
                int indiceDescripcionGobernanza = oIDataReader.GetOrdinal("DescripcionGobernanza");
                int indiceNombreApellido = oIDataReader.GetOrdinal("NombreApellido");
                int indiceFechaRegistro = oIDataReader.GetOrdinal("FechaRegistro");
                int indiceComentario = oIDataReader.GetOrdinal("Comentario");
                int indiceFlagAprobado = oIDataReader.GetOrdinal("FlagAprobado");

                while (oIDataReader.Read())
                {
                    oSolicitudAutorizacion = new SolicitudAutorizacion();
                    oSolicitudAutorizacion.Gobernanza = new Gobernanza();
                    oSolicitudAutorizacion.Usuario = new Usuario();

                    oSolicitudAutorizacion.Gobernanza.IdGobernanza = DataUtil.DbValueToDefault<int>(oIDataReader[indiceIdGobernanza]);
                    oSolicitudAutorizacion.Gobernanza.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indiceDescripcionGobernanza]);
                    oSolicitudAutorizacion.Usuario.NombreApellido = DataUtil.DbValueToDefault<string>(oIDataReader[indiceNombreApellido]);
                    oSolicitudAutorizacion.FechaRegistro = DataUtil.DbValueToDefault<DateTime>(oIDataReader[indiceFechaRegistro]);
                    oSolicitudAutorizacion.Comentario = DataUtil.DbValueToDefault<string>(oIDataReader[indiceComentario]);
                    oSolicitudAutorizacion.FlagAprobado = DataUtil.DbValueToDefault<bool>(oIDataReader[indiceFlagAprobado]);

                    oListaSolicitudAutorizacion.Add(oSolicitudAutorizacion);
                }
            }

            return oListaSolicitudAutorizacion;
        }


        public void RegistrarSolicitudValidacion(SolicitudOrdenServicio oSolicitudOrdenServicio)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Ins_SolicitudValidacion);
            oDatabase.AddInParameter(oDbCommand, "@IdSolicitudOrdenServicio", DbType.Int32, oSolicitudOrdenServicio.IdSolicitudOrdenServicio);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, oSolicitudOrdenServicio.SolicitudValidacion.Usuario.IdUsuario);
            oDatabase.AddInParameter(oDbCommand, "@FlagExistePresupuesto", DbType.Boolean, oSolicitudOrdenServicio.SolicitudValidacion.FlagExistePresupuesto);
            oDatabase.AddInParameter(oDbCommand, "@Grafo", DbType.String, oSolicitudOrdenServicio.SolicitudValidacion.Grafo);
            oDatabase.AddInParameter(oDbCommand, "@Comentario", DbType.String, oSolicitudOrdenServicio.SolicitudValidacion.Comentario);
            oDatabase.AddInParameter(oDbCommand, "@FlagValidado", DbType.Boolean, oSolicitudOrdenServicio.SolicitudValidacion.FlagValidado);
            oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, oSolicitudOrdenServicio.Estado.IdEstado);
            oDatabase.AddInParameter(oDbCommand, "@FlagCierreReporte", DbType.Boolean, oSolicitudOrdenServicio.FlagCierreSolicitud);

            oDatabase.ExecuteNonQuery(oDbCommand);
        }

        public void RegistrarSolicitudRecomendacion(SolicitudRecomendacion oSolicitudRecomendacion)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Ins_SolicitudRecomendacion);
            oDatabase.AddInParameter(oDbCommand, "@IdSolicitudOrdenServicio", DbType.Int32, oSolicitudRecomendacion.IdSolicitudOrdenServicio);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, oSolicitudRecomendacion.Usuario.IdUsuario);
            oDatabase.AddInParameter(oDbCommand, "@Comentario", DbType.String, oSolicitudRecomendacion.Comentario);
            oDatabase.AddInParameter(oDbCommand, "@FlagRecomendado", DbType.Boolean, oSolicitudRecomendacion.FlagRecomendado);

            oDatabase.ExecuteNonQuery(oDbCommand);
        }
        
        public void RegistrarSolicitudAutorizacion(SolicitudOrdenServicio oSolicitudOrdenServicio, XmlDocument SolicitudOrdenServicioXml)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Ins_SolicitudAutorizacion);
            oDatabase.AddInParameter(oDbCommand, "@SolicitudOrdenServicioXml", DbType.Xml, SolicitudOrdenServicioXml.DocumentElement.InnerXml);
            oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, oSolicitudOrdenServicio.Estado.IdEstado);
            oDatabase.AddInParameter(oDbCommand, "@FlagCierreReporte", DbType.Boolean, oSolicitudOrdenServicio.FlagCierreSolicitud);

            oDatabase.ExecuteNonQuery(oDbCommand);
        }

        public bool ValidarAreaFuncionalProyecto(int idAreaFuncional, int idProyecto,  int idUsuario)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Validar_Area_Funcional_Proyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdAreaFuncional", DbType.Int32, idAreaFuncional);
            oDatabase.AddInParameter(oDbCommand, "@IdProyecto", DbType.Int32, idProyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, idUsuario);

            return (bool)oDatabase.ExecuteScalar(oDbCommand);
        }

        public bool ValidarControlProyecto(int idProyecto, int idUsuario, bool flagProcura)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Validar_Control_Proyecto);
            
            oDatabase.AddInParameter(oDbCommand, "@IdProyecto", DbType.Int32, idProyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, idUsuario);
            oDatabase.AddInParameter(oDbCommand, "@FlagProcuraContrato", DbType.Boolean, flagProcura);

            return (bool)oDatabase.ExecuteScalar(oDbCommand);
        }

        public Gobernanza ObtenerGobernanzaAprobacionPorSolicitud(int IdSolicitudOrdenServicio)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Sel_Gobernaza_Aprobacion_Por_Solicitud);
            oDatabase.AddInParameter(oDbCommand, "@IdSolicitudOrdenServicio", DbType.Int32, IdSolicitudOrdenServicio);

            Gobernanza oGobernanza = new Gobernanza();

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdGobernanza = oIDataReader.GetOrdinal("IdGobernanza");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");
                int indice_FlagApruebaSolicitud = oIDataReader.GetOrdinal("FlagApruebaSolicitud");
                int indice_Orden = oIDataReader.GetOrdinal("Orden");

                if (oIDataReader.Read())
                {
                    oGobernanza.IdGobernanza = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdGobernanza]);
                    oGobernanza.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);
                    oGobernanza.FlagApruebaSolicitud = DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagApruebaSolicitud]);
                    oGobernanza.Orden = DataUtil.DbValueToDefault<int>(oIDataReader[indice_Orden]);
                }
            }

            return oGobernanza;
        }

        public ListaGobernanza ListarGobernanzaPorProyecto(int idProyecto)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Sel_Gobernanza_Por_Proyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdProyecto", DbType.Int32, idProyecto);
            ListaGobernanza oListaGobernanza = new ListaGobernanza();
            Gobernanza oGobernanza;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdGobernanza = oIDataReader.GetOrdinal("IdGobernanza");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");
                int indice_FlagApruebaSolicitud = oIDataReader.GetOrdinal("FlagApruebaSolicitud");
                int indice_Orden = oIDataReader.GetOrdinal("Orden");

                while (oIDataReader.Read())
                {
                    oGobernanza = new Gobernanza();
                    oGobernanza.IdGobernanza = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdGobernanza]);
                    oGobernanza.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);
                    oGobernanza.FlagApruebaSolicitud = DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagApruebaSolicitud]);
                    oGobernanza.Orden = DataUtil.DbValueToDefault<int>(oIDataReader[indice_Orden]);

                    oListaGobernanza.Add(oGobernanza);
                }
            }

            return oListaGobernanza;
        }

        public bool ValidarGobernanzaProyectoUsuario(int idProyecto, int idGobernaza,int idUsuario)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Validar_GobernanzaProyectoUsuario);
            oDatabase.AddInParameter(oDbCommand, "@IdProyecto", DbType.Int32, idProyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdGobernanza", DbType.Int32, idGobernaza);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, idUsuario);

            return (bool)oDatabase.ExecuteScalar(oDbCommand);
        }

        public Usuario ObtenerUsuarioSolicitudPorIdSolicitudContrato(int idSolicitudContratoServicio)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Sel_Usuario_SolicitudContrato);
            oDatabase.AddInParameter(oDbCommand, "@IdSolicitudOrdenServicio", DbType.Int32, idSolicitudContratoServicio);
            Usuario oUsuario = new Usuario();

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdUsuario = oIDataReader.GetOrdinal("IdUsuario");
                int indice_NombreApellido = oIDataReader.GetOrdinal("NombreApellido");
                int indice_Sexo = oIDataReader.GetOrdinal("Sexo");
                int indice_Correo = oIDataReader.GetOrdinal("Correo");

                if (oIDataReader.Read())
                {
                    oUsuario.IdUsuario = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdUsuario]);
                    oUsuario.NombreApellido = DataUtil.DbValueToDefault<string>(oIDataReader[indice_NombreApellido]);
                    oUsuario.Sexo = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Sexo]);
                    oUsuario.Correo = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Correo]);
                }
            }

            return oUsuario;
        }

        public List<Usuario> ObtenerListaUsuarioControlProyectoProcuraPorSolicitud(int idSolicitudContratoServicio, bool FlagProcuraContrato)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Sel_Usuario_ControlProyecto_Procura_Por_Solicitud);
            oDatabase.AddInParameter(oDbCommand, "@IdSolicitudOrdenServicio", DbType.Int32, idSolicitudContratoServicio);
            oDatabase.AddInParameter(oDbCommand, "@FlagProcuraContrato", DbType.Boolean, FlagProcuraContrato);
            List<Usuario> oListaUsuario = new List<Usuario>();
            Usuario oUsuario;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdUsuario = oIDataReader.GetOrdinal("IdUsuario");
                int indice_NombreApellido = oIDataReader.GetOrdinal("NombreApellido");
                int indice_Sexo = oIDataReader.GetOrdinal("Sexo");
                int indice_Correo = oIDataReader.GetOrdinal("Correo");

                while (oIDataReader.Read())
                {
                    oUsuario = new Usuario();
                    oUsuario.IdUsuario = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdUsuario]);
                    oUsuario.NombreApellido = DataUtil.DbValueToDefault<string>(oIDataReader[indice_NombreApellido]);
                    oUsuario.Sexo = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Sexo]);
                    oUsuario.Correo = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Correo]);

                    oListaUsuario.Add(oUsuario);
                }
            }

            return oListaUsuario;
        }

        public List<Usuario> ObtenerListaUsuarioAutorizacionPorSolicitud(int idSolicitudContratoServicio)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Sel_Usuario_Autorizacion_Por_Solicitud);
            oDatabase.AddInParameter(oDbCommand, "@IdSolicitudOrdenServicio", DbType.Int32, idSolicitudContratoServicio);
            List<Usuario> oListaUsuario = new List<Usuario>();
            Usuario oUsuario;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdUsuario = oIDataReader.GetOrdinal("IdUsuario");
                int indice_NombreApellido = oIDataReader.GetOrdinal("NombreApellido");
                int indice_Sexo = oIDataReader.GetOrdinal("Sexo");
                int indice_Correo = oIDataReader.GetOrdinal("Correo");

                while (oIDataReader.Read())
                {
                    oUsuario = new Usuario();
                    oUsuario.IdUsuario = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdUsuario]);
                    oUsuario.NombreApellido = DataUtil.DbValueToDefault<string>(oIDataReader[indice_NombreApellido]);
                    oUsuario.Sexo = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Sexo]);
                    oUsuario.Correo = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Correo]);

                    oListaUsuario.Add(oUsuario);
                }
            }

            return oListaUsuario;
        }
        
        public int RegistrarSolicitudOrdenServicioEmail(SolicitudOrdenServicioEmail oSolicitudOrdenServicioEmail)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Ins_SolicitudOrdenServicioEmail);
            oDatabase.AddInParameter(oDbCommand, "@IdSolicitudOrdenServicio", DbType.Int32, oSolicitudOrdenServicioEmail.IdSolicitudOrdenServicio);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, oSolicitudOrdenServicioEmail.IdUsuario);
            oDatabase.AddInParameter(oDbCommand, "@Para", DbType.String, oSolicitudOrdenServicioEmail.Para);
            oDatabase.AddInParameter(oDbCommand, "@Asunto", DbType.String, oSolicitudOrdenServicioEmail.Asunto);
            oDatabase.AddInParameter(oDbCommand, "@Contenido", DbType.String, oSolicitudOrdenServicioEmail.Contenido);
            oDatabase.AddInParameter(oDbCommand, "@FlagEnviado", DbType.Boolean, oSolicitudOrdenServicioEmail.FlagEnviado);
            oDatabase.AddInParameter(oDbCommand, "@MensajeError", DbType.String, oSolicitudOrdenServicioEmail.MensajeError);

            return (int)oDatabase.ExecuteScalar(oDbCommand);
        }
        
        public SolicitudOrdenServicioDashboard ObtenerDashboard(FiltroSolicitud oFiltroSolicitud)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Dashboard_SolicitudOrdenServicio);
            oDatabase.AddInParameter(oDbCommand, "@IdProyecto", DbType.Int32, oFiltroSolicitud.IdProyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdFaseProyecto", DbType.Int32, oFiltroSolicitud.IdFaseProyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, oFiltroSolicitud.IdUsuario);

            SolicitudOrdenServicioDashboard oSolicitudOrdenServicioDashboard = new SolicitudOrdenServicioDashboard();

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_TotalPedienteAprobacion = oIDataReader.GetOrdinal("TotalPedienteAprobacion");
                int indice_TotalRegularizacion = oIDataReader.GetOrdinal("TotalRegularizacion");
                int indice_TotalFuenteLicitacionConcurso = oIDataReader.GetOrdinal("TotalFuenteLicitacionConcurso");
                int indice_TotalFuentePreferente = oIDataReader.GetOrdinal("TotalFuentePreferente");
                int indice_TotalFuenteSoleSource = oIDataReader.GetOrdinal("TotalFuenteSoleSource");

                if (oIDataReader.Read())
                {
                    oSolicitudOrdenServicioDashboard.TotalPedienteAprobacion = DataUtil.DbValueToDefault<int>(oIDataReader[indice_TotalPedienteAprobacion]);
                    oSolicitudOrdenServicioDashboard.TotalRegularizacion = DataUtil.DbValueToDefault<int>(oIDataReader[indice_TotalRegularizacion]);
                    oSolicitudOrdenServicioDashboard.TotalFuenteLicitacionConcurso = DataUtil.DbValueToDefault<int>(oIDataReader[indice_TotalFuenteLicitacionConcurso]);
                    oSolicitudOrdenServicioDashboard.TotalFuentePreferente = DataUtil.DbValueToDefault<int>(oIDataReader[indice_TotalFuentePreferente]);
                    oSolicitudOrdenServicioDashboard.TotalFuenteSoleSource = DataUtil.DbValueToDefault<int>(oIDataReader[indice_TotalFuenteSoleSource]);
                }
            }

            return oSolicitudOrdenServicioDashboard;
        }

        public ListaSolicitudRegularizacion ObtenerDashboardSolicitudRegularizacion(FiltroSolicitud oFiltroSolicitud)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Dashboard_Regularizacion);
            oDatabase.AddInParameter(oDbCommand, "@IdProyecto", DbType.Int32, oFiltroSolicitud.IdProyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdFaseProyecto", DbType.Int32, oFiltroSolicitud.IdFaseProyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, oFiltroSolicitud.IdUsuario);

            ListaSolicitudRegularizacion oListaSolicitudRegularizacion = new ListaSolicitudRegularizacion();
            SolicitudRegularizacion oSolicitudRegularizacion;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_Anio = oIDataReader.GetOrdinal("Anio");
                int indice_Mes = oIDataReader.GetOrdinal("Mes");
                int indice_ValorRegularizacion = oIDataReader.GetOrdinal("ValorRegularizacion");
                int indice_ValorNormal = oIDataReader.GetOrdinal("ValorNormal");

                while (oIDataReader.Read())
                {
                    oSolicitudRegularizacion = new SolicitudRegularizacion();
                    oSolicitudRegularizacion.Anio = DataUtil.DbValueToDefault<int>(oIDataReader[indice_Anio]);
                    oSolicitudRegularizacion.Mes = DataUtil.DbValueToDefault<int>(oIDataReader[indice_Mes]);
                    oSolicitudRegularizacion.ValorRegularizacion = DataUtil.DbValueToDefault<decimal>(oIDataReader[indice_ValorRegularizacion]);
                    oSolicitudRegularizacion.ValorNormal = DataUtil.DbValueToDefault<decimal>(oIDataReader[indice_ValorNormal]);

                    oListaSolicitudRegularizacion.Add(oSolicitudRegularizacion);
                }
            }

            return oListaSolicitudRegularizacion;
        }

        public ListaSolicitudOrdenServicio ConsultarPendientesPorUsuario(int idUsuario)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Solicitud.Usp_Consultar_Pendientes_Por_Usuario);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, idUsuario);
            ListaSolicitudOrdenServicio oListaSolicitudOrdenServicio = new ListaSolicitudOrdenServicio();
            SolicitudOrdenServicio oSolicitudOrdenServicio;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdSolicitudOrdenServicio = oIDataReader.GetOrdinal("IdSolicitudOrdenServicio");
                int indice_NumeroSolicitud = oIDataReader.GetOrdinal("NumeroSolicitud");
                int indice_FuenteContrato = oIDataReader.GetOrdinal("FuenteContrato");
                int indice_Proyecto = oIDataReader.GetOrdinal("Proyecto");
                int indice_Compania = oIDataReader.GetOrdinal("Compania");
                int indice_AreaFuncional = oIDataReader.GetOrdinal("AreaFuncional");
                int indice_FaseProyecto = oIDataReader.GetOrdinal("FaseProyecto");
                int indice_FechaSolicitud = oIDataReader.GetOrdinal("FechaSolicitud");
                int indice_Estado = oIDataReader.GetOrdinal("Estado");
                int indice_NombreUsuario = oIDataReader.GetOrdinal("NombreUsuario");

                while (oIDataReader.Read())
                {
                    oSolicitudOrdenServicio = new SolicitudOrdenServicio();
                    oSolicitudOrdenServicio.FuenteContrato = new FuenteContrato();
                    oSolicitudOrdenServicio.Proyecto = new Proyecto();
                    oSolicitudOrdenServicio.Compania = new Compania();
                    oSolicitudOrdenServicio.AreaFuncional = new AreaFuncional();
                    oSolicitudOrdenServicio.FaseProyecto = new FaseProyecto();
                    oSolicitudOrdenServicio.Estado = new Estado();
                    oSolicitudOrdenServicio.UsuarioSolicitud = new Usuario();

                    oSolicitudOrdenServicio.IdSolicitudOrdenServicio = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdSolicitudOrdenServicio]);
                    oSolicitudOrdenServicio.NumeroSolicitud = DataUtil.DbValueToDefault<string>(oIDataReader[indice_NumeroSolicitud]);
                    oSolicitudOrdenServicio.FuenteContrato.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_FuenteContrato]);
                    oSolicitudOrdenServicio.Proyecto.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Proyecto]);
                    oSolicitudOrdenServicio.Compania.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Compania]);
                    oSolicitudOrdenServicio.AreaFuncional.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_AreaFuncional]);
                    oSolicitudOrdenServicio.FaseProyecto.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_FaseProyecto]);
                    oSolicitudOrdenServicio.FechaSolicitud = DataUtil.DbValueToDefault<DateTime>(oIDataReader[indice_FechaSolicitud]);
                    oSolicitudOrdenServicio.Estado.Nombre = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Estado]);
                    oSolicitudOrdenServicio.UsuarioSolicitud.NombreApellido = DataUtil.DbValueToDefault<string>(oIDataReader[indice_NombreUsuario]);

                    oListaSolicitudOrdenServicio.Add(oSolicitudOrdenServicio);
                }
            }

            return oListaSolicitudOrdenServicio;
        }
    }
}
