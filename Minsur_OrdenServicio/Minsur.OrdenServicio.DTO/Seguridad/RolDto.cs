using System.Collections.Generic;

namespace Minsur.OrdenServicio.DTO.Seguridad
{
    public class RolDto
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
    }
    public class ListaRolDto : List<RolDto> { }
}
