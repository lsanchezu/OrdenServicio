using Minsur.OrdenServicio.Common.Enumeracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class SolicitudOrdenServicio
    {
        public int IdSolicitudOrdenServicio { get; set; }
        public string NumeroSolicitud { get; set; }
        public Compania Compania { get; set; }
        public FuenteContrato FuenteContrato { get; set; }
        public Proyecto Proyecto { get; set; }
        public FaseProyecto FaseProyecto { get; set; }
        public Tipo Tipo { get; set; }
        public AreaFuncional AreaFuncional { get; set; }
        public Categoria Categoria { get; set; }
        public Moneda Moneda { get; set; }
        public Estado Estado { get; set; }
        public string DescripcionMoneda { get; set; }
        public Usuario UsuarioSolicitud { get; set; }
        public ListaSolicitudProveedorContratista ListaSolicitudProveedorContratista { get; set; }
        public ListaSolicitudDocumento ListaSolicitudDocumento { get; set; }
        public SolicitudValidacion SolicitudValidacion { get; set; }
        public SolicitudRecomendacion SolicitudRecomendacion { get; set; }
        public ListaSolicitudAutorizacion ListaSolicitudAutorizacion { get; set; }
        public SolicitudAutorizacion SolicitudAutorizacion { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public decimal? MontoEstimado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }
        public int DiasCalendario { get; set; }
        public string DenominacionServicio { get; set; }
        public string DescripcionServicio { get; set; }
        public string UbicacionServicio { get; set; }
        public string JustificacionSoleSource { get; set; }

        public bool FlagRegistrarValidacion { get; set; }
        public bool FlagRegistrarRecomendacion { get; set; }
        public bool FlagRegistrarAutorizacion { get; set; }
        public bool FlagPDFGenerado { get; set; }
        public bool FlagCierreSolicitud { get; set; }
        public string UsuarioRevision { get; set; }

        public SolicitudOrdenServicio()
        {

        }

        public void CrearNuevaSolicitud(ListaTipoDocumento oListaTipoDocumento)
        {
            Compania = new Compania();
            FuenteContrato = new FuenteContrato();
            Proyecto = new Proyecto();
            FaseProyecto = new FaseProyecto();
            AreaFuncional = new AreaFuncional();
            Categoria = new Categoria();
            Moneda = new Moneda();
            Tipo = new Tipo();
            FechaSolicitud = DateTime.Now;
            FechaInicio = DateTime.Now;
            FechaTermino = DateTime.Now.AddDays(1);
            MontoEstimado = decimal.Zero;
            ListaSolicitudDocumento = new ListaSolicitudDocumento();
            ListaSolicitudProveedorContratista = new ListaSolicitudProveedorContratista();

            oListaTipoDocumento.ForEach( x => {
                ListaSolicitudDocumento.Add(new SolicitudDocumento { TipoDocumento = x , ListaSolicitudArchivoAdjunto = new ListaSolicitudArchivoAdjunto ()});
            });
        }

        public void AsignarSolicitudValidacion(SolicitudValidacion oSolicitudValidacion)
        {
            this.SolicitudValidacion = oSolicitudValidacion;
            

            Estado.IdEstado = oSolicitudValidacion.FlagValidado ? (int)EnumSolicitudOrdenServicio.EstadoSolicitud.EnProceso : (int)EnumSolicitudOrdenServicio.EstadoSolicitud.Rechazado;
            ValidarCierreSolicitud();
        }

        public void AsignarSolicitudRecomendacion(SolicitudRecomendacion oSolicitudRecomendacion)
        {
            this.SolicitudRecomendacion = oSolicitudRecomendacion;
        }

        public void AsignarSolicitudAutorizacion(ListaSolicitudAutorizacion oListaSolicitudAutorizacion)
        {
            this.ListaSolicitudAutorizacion = oListaSolicitudAutorizacion;
            this.Estado.IdEstado = !oListaSolicitudAutorizacion.First().FlagAprobado ? (int)EnumSolicitudOrdenServicio.EstadoSolicitud.Rechazado
                                                                   : oListaSolicitudAutorizacion.Any(x => x.Gobernanza.FlagApruebaSolicitud) ? (int)EnumSolicitudOrdenServicio.EstadoSolicitud.Aprobado 
                                                                                                                                             : (int)EnumSolicitudOrdenServicio.EstadoSolicitud.EnProceso;
            ValidarCierreSolicitud();
        }

        private void ValidarCierreSolicitud()
        {
            this.FlagCierreSolicitud = (this.Estado.IdEstado == (int)EnumSolicitudOrdenServicio.EstadoSolicitud.Rechazado || this.Estado.IdEstado == (int)EnumSolicitudOrdenServicio.EstadoSolicitud.Aprobado);
        }
    }

    public class ListaSolicitudOrdenServicio : List<SolicitudOrdenServicio> { }
}
