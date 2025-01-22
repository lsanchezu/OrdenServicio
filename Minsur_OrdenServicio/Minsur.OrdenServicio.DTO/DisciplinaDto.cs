using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class DisciplinaDto
    {
        public int IdDisciplina { get; set; }
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
    }
    public class ListaDisciplinaDto : List<DisciplinaDto> { }

}
