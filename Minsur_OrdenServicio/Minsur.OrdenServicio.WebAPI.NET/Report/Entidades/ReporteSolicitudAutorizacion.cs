using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minsur.OrdenServicio.WebAPI.NET.Report.Entidades
{
    public class ReporteSolicitudAutorizacion
    {
        public int IdGobernanza { get; set; }
        public string NombreApellido { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
        public string Comentario { get; set; }
    }

    public class ListaReporteSolicitudAutorizacion : List<ReporteSolicitudAutorizacion> { }
}