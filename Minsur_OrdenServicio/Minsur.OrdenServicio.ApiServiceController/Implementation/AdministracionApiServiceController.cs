using Microsoft.Extensions.Configuration;
using Minsur.OrdenServicio.ApiServiceController.Base;
using Minsur.OrdenServicio.ApiServiceController.Interface;
using Minsur.OrdenServicio.ApiServiceController.Rest;
using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Body;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Refit;

namespace Minsur.OrdenServicio.ApiServiceController.Implementation
{
    public class AdministracionApiServiceController : BaseApiServiceController, IAdministracionApiServiceController
    {
        private readonly IAdministracionService oIAdministracionService;
        private readonly IConfiguration oIConfiguration;

        public AdministracionApiServiceController(IConfiguration configuration) : base(configuration)
        {
            this.oIConfiguration = configuration;
            oIAdministracionService = RestService.For<IAdministracionService>(oHttpClient, new RefitSettings
            {
                ContentSerializer = new JsonContentSerializer(new JsonSerializerSettings { Converters = { new StringEnumConverter() } })
            });
        }

        public ListaCompaniaDto ObtenerCompanias()
        {
            return oIAdministracionService.ObtenerCompanias().Result;
        }
        public TransactionResponse RegistrarCompania(TransactionRequest<CompaniaDto> oTransactionRequest)
        {
            return oIAdministracionService.RegistrarCompania(oTransactionRequest).Result;
        }
        public TransactionResponse EditarCompania(int id, TransactionRequest<CompaniaDto> oTransactionRequest)
        {
            return oIAdministracionService.EditarCompania(id, oTransactionRequest).Result;
        }
        public ListaProyectoDto ObtenerProyectosPorCompania(int idCompania)
        {
            return oIAdministracionService.ObtenerProyectosPorCompania(idCompania).Result;
        }
        public TransactionResponse RegistrarProyecto(TransactionRequest<ProyectoDto> oTransactionRequest)
        {
            return oIAdministracionService.RegistrarProyecto(oTransactionRequest).Result;
        }
        public TransactionResponse EditarProyecto(int id, TransactionRequest<ProyectoDto> oTransactionRequest)
        {
            return oIAdministracionService.EditarProyecto(id, oTransactionRequest).Result;
        }
        public ListaDisciplinaDto ObtenerDisciplinas()
        {
            return oIAdministracionService.ObtenerDisciplinas().Result;
        }
        public TransactionResponse RegistrarDisciplina(TransactionRequest<DisciplinaDto> oTransactionRequest)
        {
            return oIAdministracionService.RegistrarDisciplina(oTransactionRequest).Result;
        }
        public TransactionResponse EditarDisciplina(int id, TransactionRequest<DisciplinaDto> oTransactionRequest)
        {
            return oIAdministracionService.EditarDisciplina(id, oTransactionRequest).Result;
        }
        public ListaConfiguracionGobernanzaDto ObtenerConfiguracionGobernanzaPorProyecto(int id)
        {
            return oIAdministracionService.ObtenerConfiguracionGobernanzaPorProyecto(id).Result;
        }
        public TransactionResponse GuardarConfiguracionGobernanzaPorProyecto(TransactionRequest<GobernanzaRequest> oTransactionRequest)
        {
            return oIAdministracionService.GuardarConfiguracionGobernanzaPorProyecto(oTransactionRequest).Result;
        }
        public ListaConfiguracionUsuarioProyectoDto ObtenerListaConfiguracionUsuarioProyecto(FiltroConfiguracionUsuarioProyectoDto oFiltroConfiguracionUsuarioProyectoDto)
        {
            return oIAdministracionService.ObtenerListaConfiguracionUsuarioProyecto(oFiltroConfiguracionUsuarioProyectoDto).Result;
        }
        public TransactionResponse GuardarConfiguracionUsuarioProyecto(TransactionRequest<ConfiguracionUsuarioProyectoRequest> oTransactionRequest)
        {
            return oIAdministracionService.GuardarConfiguracionUsuarioProyecto(oTransactionRequest).Result;
        }
        public GestionRolResponse ObtenerGestionRol(int idProyecto)
        {
            return oIAdministracionService.ObtenerGestionRol(idProyecto).Result;
        }
        public TransactionResponse GuardarConfiguracionRol(TransactionRequest<GestionRolRequest> oTransactionRequest)
        {
            return oIAdministracionService.GuardarConfiguracionRol(oTransactionRequest).Result;
        }
    }
}
