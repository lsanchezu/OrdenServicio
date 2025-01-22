using SolicitudContext = Minsur.OrdenServicio.DTO;
using SolicitudContextBody = Minsur.OrdenServicio.DTO.Body;
using Refit;
using System.Threading.Tasks;

namespace Minsur.OrdenServicio.ApiServiceController.Rest
{
    [Headers("Accept: application/json")]
    public interface IAdministracionService
    {
        [Get("/api/administracion/companias")]
        Task<SolicitudContext.ListaCompaniaDto> ObtenerCompanias();

        [Post("/api/administracion/companias")]
        Task<SolicitudContextBody.TransactionResponse> RegistrarCompania([Body]SolicitudContextBody.TransactionRequest<SolicitudContext.CompaniaDto> oTransactionRequest);

        [Put("/api/administracion/companias/{id}")]
        Task<SolicitudContextBody.TransactionResponse> EditarCompania(int id, [Body]SolicitudContextBody.TransactionRequest<SolicitudContext.CompaniaDto> oTransactionRequest);

        [Get("/api/administracion/companias/{idCompania}/proyectos")]
        Task<SolicitudContext.ListaProyectoDto> ObtenerProyectosPorCompania(int idCompania);

        [Post("/api/administracion/proyectos")]
        Task<SolicitudContextBody.TransactionResponse> RegistrarProyecto([Body]SolicitudContextBody.TransactionRequest<SolicitudContext.ProyectoDto> oTransactionRequest);

        [Put("/api/administracion/proyectos/{id}")]
        Task<SolicitudContextBody.TransactionResponse> EditarProyecto(int id, [Body]SolicitudContextBody.TransactionRequest<SolicitudContext.ProyectoDto> oTransactionRequest);

        [Get("/api/administracion/disciplinas")]
        Task<SolicitudContext.ListaDisciplinaDto> ObtenerDisciplinas();

        [Post("/api/administracion/disciplinas")]
        Task<SolicitudContextBody.TransactionResponse> RegistrarDisciplina([Body]SolicitudContextBody.TransactionRequest<SolicitudContext.DisciplinaDto> oTransactionRequest);

        [Put("/api/administracion/disciplinas/{id}")]
        Task<SolicitudContextBody.TransactionResponse> EditarDisciplina(int id, [Body]SolicitudContextBody.TransactionRequest<SolicitudContext.DisciplinaDto> oTransactionRequest);

        [Get("/api/administracion/proyectos/{id}/gobernanzas")]
        Task<SolicitudContext.ListaConfiguracionGobernanzaDto> ObtenerConfiguracionGobernanzaPorProyecto(int id);

        [Post("/api/administracion/gobernanzas")]
        Task<SolicitudContextBody.TransactionResponse> GuardarConfiguracionGobernanzaPorProyecto(SolicitudContextBody.TransactionRequest<SolicitudContextBody.GobernanzaRequest> oTransactionRequest);

        [Get("/api/administracion/usuarios/proyectos")]
        Task<SolicitudContext.ListaConfiguracionUsuarioProyectoDto> ObtenerListaConfiguracionUsuarioProyecto([Query]SolicitudContext.FiltroConfiguracionUsuarioProyectoDto oFiltroConfiguracionUsuarioProyectoDto);

        [Post("/api/administracion/usuarios/proyectos")]
        Task<SolicitudContextBody.TransactionResponse> GuardarConfiguracionUsuarioProyecto([Body]SolicitudContextBody.TransactionRequest<SolicitudContextBody.ConfiguracionUsuarioProyectoRequest> oTransactionRequest);
        
        [Get("/api/administracion/gestionRol-por-proyecto/{idProyecto}")]
        Task<SolicitudContextBody.GestionRolResponse> ObtenerGestionRol(int idProyecto);

        [Post("/api/administracion/gestionRol")]
        Task<SolicitudContextBody.TransactionResponse> GuardarConfiguracionRol(SolicitudContextBody.TransactionRequest<SolicitudContextBody.GestionRolRequest> oTransactionRequest);
    }
}
