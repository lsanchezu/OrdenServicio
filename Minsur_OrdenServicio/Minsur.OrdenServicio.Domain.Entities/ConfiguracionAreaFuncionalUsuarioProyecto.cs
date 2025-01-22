using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class ConfiguracionAreaFuncionalUsuarioProyecto
    {
        public int IdAreaFuncionalProyectoUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public Proyecto Proyecto { get; set; }
        public AreaFuncional AreaFuncional { get; set; }
        public int IdEstado { get; set; }


    }
    public class ListaConfiguracionAreaFuncionalUsuarioProyecto : List<ConfiguracionAreaFuncionalUsuarioProyecto> { }
}
