using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities.Xml
{
    public class SolicitudAutorizacionXml
    {
        public int IdSolicitudOrdenServicio { get; set; }
        public int IdGobernanza { get; set; }
        public int IdUsuario { get; set; }
        public string Comentario { get; set; }
        public string FlagAprobado { get; set; }
    }

    public class ListaSolicitudAutorizacionXml : List<SolicitudAutorizacionXml> { }
}
