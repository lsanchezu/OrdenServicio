namespace Minsur.OrdenServicio.DTO.Body
{
    public class PaginationRequest<T> where T : class
    {
        public PaginacionDto PaginacionDto { get; set; }
        public T FiltroBusqueda { get; set; }
    }
}
