using Minsur.OrdenServicio.Common.Enumeracion;
using Minsur.OrdenServicio.Common.Estructura;
using Minsur.OrdenServicio.Domain.DomainContract;
using Minsur.OrdenServicio.Domain.Entities;
using Minsur.OrdenServicio.Domain.RepositoryContract.Maestro;
using Minsur.OrdenServicio.Domain.RepositoryContract.Solicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minsur.OrdenServicio.Domain.Services
{
    public class SolicitudServicioDomainService : ISolicitudServicioDomainService
    {
        private readonly ISolicitudOrdenServicioRepository oISolicitudOrdenServicioRepository;
        private readonly IMaestroRepository oIMaestroRepository;

        public SolicitudServicioDomainService(ISolicitudOrdenServicioRepository oISolicitudOrdenServicioRepository,
                                              IMaestroRepository oIMaestroRepository)
        {
            this.oISolicitudOrdenServicioRepository = oISolicitudOrdenServicioRepository;
            this.oIMaestroRepository = oIMaestroRepository;
        }

        public SolicitudOrdenServicio ObtenerNuevaSolicitud()
        {
            SolicitudOrdenServicio oSolicitudOrdenServicio = new SolicitudOrdenServicio();
            oSolicitudOrdenServicio.CrearNuevaSolicitud(oIMaestroRepository.ListarTipoDocumento());

            return oSolicitudOrdenServicio;
        }

        public SolicitudOrdenServicio ObtenerSolicitudOrdenServicioPorId(int idSolicitudOrdenServicio, Usuario oUsuario)
        {
            SolicitudOrdenServicio oSolicitudOrdenServicio = oISolicitudOrdenServicioRepository.ObtenerSolicitudPorId(idSolicitudOrdenServicio);

            Parallel.Invoke(
                () => oSolicitudOrdenServicio.ListaSolicitudProveedorContratista = oISolicitudOrdenServicioRepository.ObtenerListaSolicitudProveedorContratistaPorIdSolicitud(idSolicitudOrdenServicio),
                () => {
                    oSolicitudOrdenServicio.ListaSolicitudDocumento = oISolicitudOrdenServicioRepository.ObtenerListaSolicitudDocumentoPorIdSolicitud(idSolicitudOrdenServicio);
                    oSolicitudOrdenServicio.ListaSolicitudDocumento.ForEach(x => x.ListaSolicitudArchivoAdjunto = oISolicitudOrdenServicioRepository.ObtenerListaSolicitudArchivoAdjunto(x.IdSolicitudDocumento));
                },
                () => oSolicitudOrdenServicio.ListaSolicitudAutorizacion = oISolicitudOrdenServicioRepository.obtenerListaSolicitudAutorizacion(idSolicitudOrdenServicio)
            );

            ValidarSolicitudUsuario(oSolicitudOrdenServicio, oUsuario);

            return oSolicitudOrdenServicio;
        }

        private void ValidarSolicitudUsuario(SolicitudOrdenServicio oSolicitudOrdenServicio, Usuario oUsuario)
        {
            if (oSolicitudOrdenServicio.Estado.IdEstado != (int)EnumSolicitudOrdenServicio.EstadoSolicitud.EnProceso)
            {
                return;
            }

            if (oSolicitudOrdenServicio.SolicitudValidacion.Usuario.IdUsuario == Numeracion.Cero)
            {
                if (oISolicitudOrdenServicioRepository.ValidarControlProyecto(oSolicitudOrdenServicio.Proyecto.IdProyecto, oUsuario.IdUsuario, false))
                {
                    oSolicitudOrdenServicio.SolicitudValidacion.Usuario = oUsuario;
                    oSolicitudOrdenServicio.SolicitudValidacion.FechaRegistro = DateTime.Now;
                    oSolicitudOrdenServicio.SolicitudValidacion.FlagExistePresupuesto = true;
                    oSolicitudOrdenServicio.FlagRegistrarValidacion = true;

                    return;
                }

                return;
            }

            if (oSolicitudOrdenServicio.FuenteContrato.IdFuenteContrato == (int)EnumSolicitudOrdenServicio.FuenteContrato.Sole_Source && oSolicitudOrdenServicio.SolicitudValidacion.FlagValidado && oSolicitudOrdenServicio.SolicitudRecomendacion.Usuario.IdUsuario == Numeracion.Cero)
            {
                if (oISolicitudOrdenServicioRepository.ValidarControlProyecto(oSolicitudOrdenServicio.Proyecto.IdProyecto, oUsuario.IdUsuario, true))
                {
                    oSolicitudOrdenServicio.SolicitudRecomendacion.Usuario = oUsuario;
                    oSolicitudOrdenServicio.SolicitudRecomendacion.FechaRegistro = DateTime.Now;
                    oSolicitudOrdenServicio.FlagRegistrarRecomendacion = true;
                    return;
                }

                return;
            }

            ValidacionGobernaza(oSolicitudOrdenServicio, oUsuario);
        }

        private void ValidacionGobernaza(SolicitudOrdenServicio oSolicitudOrdenServicio, Usuario oUsuario)
        {
            if (oSolicitudOrdenServicio.SolicitudValidacion.Usuario.IdUsuario == Numeracion.Cero) return;

            if (oSolicitudOrdenServicio.FuenteContrato.IdFuenteContrato == (int)EnumSolicitudOrdenServicio.FuenteContrato.Sole_Source && oSolicitudOrdenServicio.SolicitudRecomendacion.Usuario.IdUsuario == Numeracion.Cero) return;

            Gobernanza oGobernanza = oISolicitudOrdenServicioRepository.ObtenerGobernanzaAprobacionPorSolicitud(oSolicitudOrdenServicio.IdSolicitudOrdenServicio);

            if (oGobernanza.IdGobernanza == Numeracion.Cero) return;

            if (ValidarAutorizacionGobernanza(oSolicitudOrdenServicio, oUsuario, oGobernanza.IdGobernanza))
            {
                SolicitudAutorizacion oSolicitudAutorizacion = new SolicitudAutorizacion();
                oSolicitudAutorizacion.Usuario = oUsuario;
                oSolicitudAutorizacion.Gobernanza = oGobernanza;
                oSolicitudAutorizacion.Gobernanza.FlagApruebaSolicitud = oGobernanza.FlagApruebaSolicitud;
                oSolicitudAutorizacion.FechaRegistro = DateTime.Now;

                var listaAutorizacionAsignadaPorUsuario = ObteneListaSolicitudAutorizacionAsignadaPorUsuarioYProyecto(oSolicitudOrdenServicio, oSolicitudAutorizacion);

                if (listaAutorizacionAsignadaPorUsuario.Count  > Numeracion.Uno)
                {
                    oSolicitudAutorizacion.Gobernanza.Descripcion = string.Join(" / ", listaAutorizacionAsignadaPorUsuario.Select(x => x.Gobernanza.Descripcion));
                }

                oSolicitudOrdenServicio.SolicitudAutorizacion = oSolicitudAutorizacion;

                oSolicitudOrdenServicio.FlagRegistrarAutorizacion = true;
            }
        }

        private bool ValidarAutorizacionGobernanza(SolicitudOrdenServicio oSolicitudOrdenServicio, Usuario oUsuario, int idGobernanza)
        {
            if (idGobernanza == (int)EnumSolicitudOrdenServicio.Gobernanza.GerenteArea)
            {
                return oISolicitudOrdenServicioRepository.ValidarAreaFuncionalProyecto(oSolicitudOrdenServicio.AreaFuncional.IdAreaFuncional, oSolicitudOrdenServicio.Proyecto.IdProyecto, oUsuario.IdUsuario);
            }

            return oISolicitudOrdenServicioRepository.ValidarGobernanzaProyectoUsuario(oSolicitudOrdenServicio.Proyecto.IdProyecto, idGobernanza, oUsuario.IdUsuario);
        }
        
        public ListaSolicitudAutorizacion ObteneListaSolicitudAutorizacionAsignadaPorUsuarioYProyecto(SolicitudOrdenServicio oSolicitudOrdenServicio, SolicitudAutorizacion oSolicitudAutorizacion)
        {
            ListaSolicitudAutorizacion oListaSolicitudAutorizacion = new ListaSolicitudAutorizacion();
            oListaSolicitudAutorizacion.Add(oSolicitudAutorizacion);

            SolicitudAutorizacion solicitudAutorizacionAsignado;

            IEnumerable<Gobernanza> listarGobernanzaPorProyecto = oISolicitudOrdenServicioRepository.ListarGobernanzaPorProyecto(oSolicitudOrdenServicio.Proyecto.IdProyecto)
                                                                                                    .Where(x => x.Orden > oSolicitudAutorizacion.Gobernanza.Orden)
                                                                                                    .OrderBy(y => y.Orden);
            if (!listarGobernanzaPorProyecto.Any())
            {
                return oListaSolicitudAutorizacion;
            }

            bool validarSiguienteGobernanza = true;

            foreach (var item in listarGobernanzaPorProyecto)
            {
                if (validarSiguienteGobernanza && ValidarAutorizacionGobernanza(oSolicitudOrdenServicio, oSolicitudAutorizacion.Usuario, item.IdGobernanza))
                {
                    solicitudAutorizacionAsignado = new SolicitudAutorizacion();
                    solicitudAutorizacionAsignado.IdSolicitudOrdenServicio = oSolicitudAutorizacion.IdSolicitudOrdenServicio;
                    solicitudAutorizacionAsignado.Usuario = oSolicitudAutorizacion.Usuario;
                    solicitudAutorizacionAsignado.Gobernanza = item;
                    solicitudAutorizacionAsignado.Comentario = string.Empty;
                    solicitudAutorizacionAsignado.FlagAprobado = oSolicitudAutorizacion.FlagAprobado;
                    oListaSolicitudAutorizacion.Add(solicitudAutorizacionAsignado);
                }
                else
                {
                    validarSiguienteGobernanza = false;
                }
            }
            
            return oListaSolicitudAutorizacion;
        }
    }
}
