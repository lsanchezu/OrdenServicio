using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class RolDisciplina
    {
        public int IdRolDisciplina { get; set; }
        public int IdDisciplina { get; set; }
        public string Descripcion { get; set; }
        public int IdProyecto { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstado { get; set; }
    }
    public class ListaRolDisciplina : List<RolDisciplina> { }
}
