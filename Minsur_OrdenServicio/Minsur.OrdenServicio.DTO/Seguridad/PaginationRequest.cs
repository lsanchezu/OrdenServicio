using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO.Seguridad
{
    public class PaginationRequest<T> where T : class
    {
        public PaginacionDto PaginacionDto { get; set; }
        public T FiltroBusqueda { get; set; }
    }
}
