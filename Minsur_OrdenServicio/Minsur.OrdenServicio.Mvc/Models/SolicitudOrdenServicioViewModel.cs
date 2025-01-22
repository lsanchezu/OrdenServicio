using Microsoft.AspNetCore.Http;
using Minsur.OrdenServicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minsur.OrdenServicio.Mvc.Models
{
    public class SolicitudOrdenServicioViewModel
    {
        public SolicitudOrdenServicioDto SolicitudOrdenServicio { get; set; }
        public List<IFormFile> ListaArchivo_TipoDocumento_1 { get; set; }
        public List<IFormFile> ListaArchivo_TipoDocumento_2 { get; set; }
        public List<IFormFile> ListaArchivo_TipoDocumento_3 { get; set; }
        public List<IFormFile> ListaArchivo_TipoDocumento_4 { get; set; }
    }

}
