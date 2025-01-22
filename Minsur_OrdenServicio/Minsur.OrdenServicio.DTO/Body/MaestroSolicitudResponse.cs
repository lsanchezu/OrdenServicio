using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO.Body
{
    public class MaestroSolicitudResponse
    {
        public ListaAreaFuncionalDto ListaAreaFuncionalDto { get; set; }
        public ListaCompaniaDto ListaCompaniaDto { get; set; }
        public ListaFaseProyectoDto ListaFaseProyectoDto { get; set; }
        public ListaMonedaDto ListaMonedaDto { get; set; }
        public ListaFuenteContratoDto ListaFuenteContratoDto { get; set; }
        public ListaProyectoDto ListaProyectoDto { get; set; }
        public ListaPaisDto ListaPaisDto { get; set; }
        public ListaEstadoDto ListaEstadoDto { get; set; }
        public ListaTipoDto ListaTipoDto { get; set;}
    }
}
