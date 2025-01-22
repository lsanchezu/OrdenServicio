using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Body;

namespace Minsur.OrdenServicio.Application.Contract.Administracion
{
    public interface IAdministracionService
    {
        ListaCompaniaDto ObtenerCompanias();
        TransactionResponse RegistrarCompania(TransactionRequest<CompaniaDto> oTransactionRequest);
        TransactionResponse EditarCompania(int id,TransactionRequest<CompaniaDto> oTransactionRequest);
        ListaProyectoDto ObtenerProyectosPorCompania(int idCompania);
        TransactionResponse RegistrarProyecto(TransactionRequest<ProyectoDto> oTransactionRequest);
        TransactionResponse EditarProyecto(int id, TransactionRequest<ProyectoDto> oTransactionRequest);
        ListaDisciplinaDto ObtenerDisciplinas();
        TransactionResponse RegistrarDisciplina(TransactionRequest<DisciplinaDto> oTransactionRequest);
        TransactionResponse EditarDisciplina(int id, TransactionRequest<DisciplinaDto> oTransactionRequest);
        ListaConfiguracionGobernanzaDto ObtenerConfiguracionGobernanzaPorProyecto(int idProyecto);
        TransactionResponse GuardarConfiguracionGobernanzaPorProyecto(TransactionRequest<GobernanzaRequest> oTransactionRequest);
        ListaConfiguracionUsuarioProyectoDto ObtenerListaConfiguracionUsuarioProyecto(FiltroConfiguracionUsuarioProyectoDto oFiltroConfiguracionUsuarioProyectoDto);
        TransactionResponse GuardarConfiguracionUsuarioProyecto(TransactionRequest<ConfiguracionUsuarioProyectoRequest> oTransactionRequest);
        GestionRolResponse ObtenerGestionRol(int idProyecto);
        TransactionResponse GuardarConfiguracionRol(TransactionRequest<GestionRolRequest> oTransactionRequest);
    }
}
