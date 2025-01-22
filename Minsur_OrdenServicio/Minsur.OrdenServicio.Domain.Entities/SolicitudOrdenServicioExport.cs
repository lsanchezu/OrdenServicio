using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class SolicitudOrdenServicioExport
    {
        public string NumeroSolicitud { get; set; }
        public string FuenteContrato { get; set; }
        public string Proyecto { get; set; }
        public string Compania { get; set; }
        public string Solicitante { get; set; }
        public string FaseProyecto { get; set; }
        public string AreaFuncional { get; set; }
        public string FechaSolicitud { get; set; }
        public string Categoria { get; set; }
        public string TipoSolicitud { get; set; }
        public string Moneda { get; set; }
        public decimal MontoEstimado { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }
        public int DiasCalendario { get; set; }
        public string DenominacionServicio { get; set; }
        public string UbicacionServicio { get; set; }
        public string JustificacionSoleSource { get; set; }
        public string DenominacionSocial { get; set; }
        public string Ruc { get; set; }
        public string UsuarioValidacion { get; set; }
        public string Grafo { get; set; }
        public string ComentarioValidacion { get; set; }
        public string EstadoValidacion { get; set; }
        public string FechaValidacion { get; set; }
        public string UsuarioRecomendacion { get; set; }
        public string EstadoRecomendacion { get; set; }
        public string FechaRecomendacion { get; set; }
        public string UsuarioAutorizacionAreaFuncional { get; set; }
        public string EstadoAutorizacionAreaFuncional { get; set; }
        public string FechaAutorizacionAreaFuncional { get; set; }
        public string UsuarioAutorizacionGerenteProyecto { get; set; }
        public string EstadoAutorizacionGerenteProyecto { get; set; }
        public string FechaAutorizacionGerenteProyecto { get; set; }
        public string UsuarioAutorizacionGerenteCorporativo { get; set; }
        public string EstadoAutorizacionGerenteCorporativo { get; set; }
        public string FechaAutorizacionGerenteCorporativo { get; set; }
        public string EstadoSolicitud { get; set; }
    }

    public class ListaSolicitudOrdenServicioExport : List<SolicitudOrdenServicioExport> { }
}
