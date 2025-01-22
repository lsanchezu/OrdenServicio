using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO.Seguridad
{
    public class PaginationResponse<T> where T : class
    {
        public PaginacionDto PaginacionDto { get; set; }
        public IEnumerable<T> Resultado { get; set; }
    }
}
