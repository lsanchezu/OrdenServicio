using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO.Email
{
    public class EmailParametroDto
    {
        public int IdEmailParametro { get; set; }
        public int IdReferencia { get; set; }
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public string Asunto { get; set; }
        public string Para { get; set; }
        public string ConCopia { get; set; }
        public string Plantilla { get; set; }
        public string MensajeHtml { get; set; }
    }
}
