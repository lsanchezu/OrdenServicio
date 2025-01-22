using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO.Email
{
    public class SolicitudOrdenServicioEmailDto
    {
        public string UsuarioCorreo { get; set; }
        public string NumeroSolicitud { get; set; }
        public string FechaSolicitud { get; set; }
        public string NombreSolicitante { get; set; }
        public string Compania { get; set; }
        public string FuenteContrato { get; set; }
        public string Proyecto { get; set; }
        public string FaseProyecto { get; set; }
        public string Area { get; set; }
        public string Categoria { get; set; }
        public string Enlace { get; set; }
        public string DenomominacionServicio { get; set; }
        public string Moneda { get; set; }
        public decimal  Monto { get; set; }
        public string TipoSolicitud { get; set; }

    }
}
