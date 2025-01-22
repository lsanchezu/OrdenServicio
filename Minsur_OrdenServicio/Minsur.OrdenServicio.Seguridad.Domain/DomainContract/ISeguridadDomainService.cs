using Minsur.OrdenServicio.Seguridad.Domain.Entities;

namespace Minsur.OrdenServicio.Seguridad.Domain.DomainContract
{
    public interface ISeguridadDomainService
    {
        bool ValidarUsuarioExistente(Usuario usuario);
    }
}
