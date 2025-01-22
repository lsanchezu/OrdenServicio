using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class Paginacion
    {

        public int Page { get; set; }
        public int RowsPerPage { get; set; }
        public int Total { get; set; }
    }
}
