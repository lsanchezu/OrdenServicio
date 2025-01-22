using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class SolicitudOrdenServicioDto
    {
        public int IdSolicitudOrdenServicio { get; set; }
        public string NumeroSolicitud { get; set; }
        public AreaFuncionalDto AreaFuncionalDto { get; set; }
        public CategoriaDto CategoriaDto { get; set; }
        public CompaniaDto CompaniaDto { get; set; }
        public TipoDto TipoDto { get; set; }
        public FaseProyectoDto FaseProyectoDto { get; set; }
        public FuenteContratoDto FuenteContratoDto { get; set; }
        public MonedaDto MonedaDto { get; set; }
        public string DescripcionMoneda { get; set; }
        public ProyectoDto ProyectoDto { get; set; }
        public UsuarioDto UsuarioSolicitudDto { get; set; }
        public EstadoDto EstadoDto { get; set; }
        public SolicitudRecomendacionDto SolicitudRecomendacionDto { get; set; }
        public SolicitudValidacionDto SolicitudValidacionDto { get; set; }
        public ListaSolicitudProveedorContratistaDto ListaSolicitudProveedorContratistaDto { get; set; }
        public ListaSolicitudDocumentoDto ListaSolicitudDocumentoDto { get; set; }
        public ListaSolicitudAutorizacionDto ListaSolicitudAutorizacionDto { get; set; }
        public SolicitudAutorizacionDto SolicitudAutorizacionDto { get; set; }      
        public string FechaSolicitud { get; set; }
        public string FechaHoraSolicitud { get; set; }
        public decimal? MontoEstimado { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }
        public int DiasCalendario { get; set; }
        public string DenominacionServicio { get; set; }
        public string DescripcionServicio { get; set; }
        public string UbicacionServicio { get; set; }
        public string JustificacionSoleSource { get; set; }
        public bool FlagRegistrarValidacion { get; set; }
        public bool FlagRegistrarRecomendacion { get; set; }
        public bool FlagRegistrarAutorizacion { get; set; }
        public bool FlagPDFGenerado { get; set; }
        public string UsuarioRevision { get; set; }
    }

    public class ListaSolicitudOrdenServicioDto : List<SolicitudOrdenServicioDto> { }
}
