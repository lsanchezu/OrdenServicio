using System.Collections.Generic;

namespace Minsur.OrdenServicio.DTO.Body
{
    public class PaginationResponse<T> where T : class
    {
        public PaginacionDto PaginacionDto { get; set; }
        public IEnumerable<T> Resultado { get; set; }
    }
}
