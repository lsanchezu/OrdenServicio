﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class SolicitudArchivoAdjuntoDto
    {
        public string Tipo { get; set; }
        public int IdSolicitudArchivoAdjunto { get; set; }
        public string Directorio { get; set; }
        public string NombreArchivo { get; set; }
        public string Extension { get; set; }
        public string TipoContenido { get; set; }
        public int Tamanio { get; set; }
        public byte[] Contenido { get; set; }
    }

    public class ListaSolicitudArchivoAdjuntoDto : List<SolicitudArchivoAdjuntoDto> {}
}
