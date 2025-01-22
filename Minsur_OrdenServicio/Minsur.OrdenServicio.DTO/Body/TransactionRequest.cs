namespace Minsur.OrdenServicio.DTO.Body
{
    public class TransactionRequest<T> where T : class
    {
        public UsuarioDto Usuario { get; set; }
        public T EntidadDto { get; set; }
    }
}
