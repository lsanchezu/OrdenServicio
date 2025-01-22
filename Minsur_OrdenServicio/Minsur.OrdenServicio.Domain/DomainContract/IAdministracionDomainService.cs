using Minsur.OrdenServicio.Domain.Entities;

namespace Minsur.OrdenServicio.Domain.DomainContract
{
    public interface IAdministracionDomainService
    {
        bool ValidarConfiguracionGobernanza(ListaConfiguracionGobernanza oListaConfiguracionGobernanza);
        void SetearFlagApruebaSolicitud(ListaConfiguracionGobernanza oListaConfiguracionGobernanza);
        bool ValidarConfiguracionUsuarioProyecto(ListaConfiguracionUsuarioProyecto oListaConfiguracionUsuarioProyecto);
        ListaConfiguracionRol ObtenerListaRolesConfigurados(int idProyecto, ListaRolGobernanza roles, ListaRolDisciplina oListaRolDisciplina);
        bool ValidarConfiguracionRol(ListaConfiguracionRol oListaConfiguracionRol);
        ListaRolGobernanza ObtenerListaProcura(ListaConfiguracionRol oListaConfiguracionRol, int idProyecto);
        ListaRolGobernanza ObtenerListaGobernanza(ListaConfiguracionRol oListaConfiguracionRol, int idProyecto);
        ListaRolDisciplina ObtenerListaDisciplina(ListaConfiguracionRol oListaConfiguracionRol, int idProyecto);
    }
}
