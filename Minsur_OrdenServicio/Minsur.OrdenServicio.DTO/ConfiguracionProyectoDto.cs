using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class ConfiguracionUsuarioProyectoDto
    {
        public int IdConfiguracionProyecto { get; set; }
        public ProyectoDto ProyectoDto { get; set; }
        public int IdEstado { get; set; }
        public bool FlagConsultaOtros { get; set; }
        public int IdUsuario { get; set; }

    }
    public class ListaConfiguracionUsuarioProyectoDto : List<ConfiguracionUsuarioProyectoDto> {}

}
