using Minsur.OrdenServicio.Common.Recursos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class SolicitudOrdenServicioExportDto
    {
        [Display(Name = nameof(SolicitudExport.NumeroSolicitud), ResourceType = typeof(SolicitudExport))]
        public string NumeroSolicitud { get; set; }

        [Display(Name = nameof(SolicitudExport.FuenteContrato), ResourceType = typeof(SolicitudExport))]
        public string FuenteContrato { get; set; }

        [Display(Name = nameof(SolicitudExport.Proyecto), ResourceType = typeof(SolicitudExport))]
        public string Proyecto { get; set; }

        [Display(Name = nameof(SolicitudExport.Compania), ResourceType = typeof(SolicitudExport))]
        public string Compania { get; set; }

        [Display(Name = nameof(SolicitudExport.TipoSolicitud), ResourceType = typeof(SolicitudExport))]
        public string TipoSolicitud { get; set; }

        [Display(Name = nameof(SolicitudExport.Solicitante), ResourceType = typeof(SolicitudExport))]
        public string Solicitante { get; set; }

        [Display(Name = nameof(SolicitudExport.FaseProyecto), ResourceType = typeof(SolicitudExport))]
        public string FaseProyecto { get; set; }

        [Display(Name = nameof(SolicitudExport.AreaFuncional), ResourceType = typeof(SolicitudExport))]
        public string AreaFuncional { get; set; }

        [Display(Name = nameof(SolicitudExport.FechaSolicitud), ResourceType = typeof(SolicitudExport))]
        public string FechaSolicitud { get; set; }

        [Display(Name = nameof(SolicitudExport.Categoria), ResourceType = typeof(SolicitudExport))]
        public string Categoria { get; set; }

        [Display(Name = nameof(SolicitudExport.Moneda), ResourceType = typeof(SolicitudExport))]
        public string Moneda { get; set; }

        [Display(Name = nameof(SolicitudExport.MontoEstimado), ResourceType = typeof(SolicitudExport))]
        public decimal MontoEstimado { get; set; }

        [Display(Name = nameof(SolicitudExport.FechaInicio), ResourceType = typeof(SolicitudExport))]
        public string FechaInicio { get; set; }

        [Display(Name = nameof(SolicitudExport.FechaTermino), ResourceType = typeof(SolicitudExport))]
        public string FechaTermino { get; set; }

        [Display(Name = nameof(SolicitudExport.DiasCalendario), ResourceType = typeof(SolicitudExport))]
        public string DiasCalendario { get; set; }

        [Display(Name = nameof(SolicitudExport.DenominacionServicio), ResourceType = typeof(SolicitudExport))]
        public string DenominacionServicio { get; set; }

        [Display(Name = nameof(SolicitudExport.UbicacionServicio), ResourceType = typeof(SolicitudExport))]
        public string UbicacionServicio { get; set; }

        [Display(Name = nameof(SolicitudExport.DenominacionSocial), ResourceType = typeof(SolicitudExport))]
        public string DenominacionSocial { get; set; }

        [Display(Name = nameof(SolicitudExport.Ruc), ResourceType = typeof(SolicitudExport))]
        public string Ruc { get; set; }

        [Display(Name = nameof(SolicitudExport.UsuarioValidacion), ResourceType = typeof(SolicitudExport))]
        public string UsuarioValidacion { get; set; }

        [Display(Name = nameof(SolicitudExport.Grafo), ResourceType = typeof(SolicitudExport))]
        public string Grafo { get; set; }

        [Display(Name = nameof(SolicitudExport.EstadoValidacion), ResourceType = typeof(SolicitudExport))]
        public string EstadoValidacion { get; set; }

        [Display(Name = nameof(SolicitudExport.FechaValidacion), ResourceType = typeof(SolicitudExport))]
        public string FechaValidacion { get; set; }

        [Display(Name = nameof(SolicitudExport.UsuarioRecomendacion), ResourceType = typeof(SolicitudExport))]
        public string UsuarioRecomendacion { get; set; }

        [Display(Name = nameof(SolicitudExport.EstadoRecomendacion), ResourceType = typeof(SolicitudExport))]
        public string EstadoRecomendacion { get; set; }

        [Display(Name = nameof(SolicitudExport.FechaRecomendacion), ResourceType = typeof(SolicitudExport))]
        public string FechaRecomendacion { get; set; }

        [Display(Name = nameof(SolicitudExport.UsuarioAutorizacionAreaFuncional), ResourceType = typeof(SolicitudExport))]
        public string UsuarioAutorizacionAreaFuncional { get; set; }

        [Display(Name = nameof(SolicitudExport.EstadoAutorizacionAreaFuncional), ResourceType = typeof(SolicitudExport))]
        public string EstadoAutorizacionAreaFuncional { get; set; }

        [Display(Name = nameof(SolicitudExport.FechaAutorizacionAreaFuncional), ResourceType = typeof(SolicitudExport))]
        public string FechaAutorizacionAreaFuncional { get; set; }

        [Display(Name = nameof(SolicitudExport.UsuarioAutorizacionGerenteProyecto), ResourceType = typeof(SolicitudExport))]
        public string UsuarioAutorizacionGerenteProyecto { get; set; }

        [Display(Name = nameof(SolicitudExport.EstadoAutorizacionGerenteProyecto), ResourceType = typeof(SolicitudExport))]
        public string EstadoAutorizacionGerenteProyecto { get; set; }

        [Display(Name = nameof(SolicitudExport.FechaAutorizacionGerenteProyecto), ResourceType = typeof(SolicitudExport))]
        public string FechaAutorizacionGerenteProyecto { get; set; }

        [Display(Name = nameof(SolicitudExport.UsuarioAutorizacionGerenteCorporativo), ResourceType = typeof(SolicitudExport))]
        public string UsuarioAutorizacionGerenteCorporativo { get; set; }

        [Display(Name = nameof(SolicitudExport.EstadoAutorizacionGerenteCorporativo), ResourceType = typeof(SolicitudExport))]
        public string EstadoAutorizacionGerenteCorporativo { get; set; }

        [Display(Name = nameof(SolicitudExport.FechaAutorizacionGerenteCorporativo), ResourceType = typeof(SolicitudExport))]
        public string FechaAutorizacionGerenteCorporativo { get; set; }

        [Display(Name = nameof(SolicitudExport.EstadoSolicitud), ResourceType = typeof(SolicitudExport))]
        public string EstadoSolicitud { get; set; }
    }

    public class ListaSolicitudOrdenServicioExportDto: List<SolicitudOrdenServicioExportDto> { }
}
