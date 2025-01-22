using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class ConfiguracionUsuarioProyecto
    {
        public int IdConfiguracionProyecto { get; set; }
        public Proyecto Proyecto { get; set; }
        public int IdEstado { get; set; }
        public bool FlagConsultaOtros { get; set; }
        public int IdUsuario { get; set; }
    }
    public class ListaConfiguracionUsuarioProyecto : List<ConfiguracionUsuarioProyecto> { }
}
