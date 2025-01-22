using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class ConfiguracionAreaFuncionalUsuarioProyectoDto
    {
        public int IdAreaFuncionalProyectoUsuario { get; set; }
        public UsuarioDto UsuarioDto { get; set; }
        public ProyectoDto ProyectoDto { get; set; }
        public AreaFuncionalDto AreaFuncionalDto { get; set; }
        public int IdEstado { get; set; }
    }
    public class ListaConfiguracionAreaFuncionalUsuarioProyectoDto : List<ConfiguracionAreaFuncionalUsuarioProyectoDto> { }
}
