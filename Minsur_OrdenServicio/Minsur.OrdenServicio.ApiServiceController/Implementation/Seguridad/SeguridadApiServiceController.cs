using Microsoft.Extensions.Configuration;
using Minsur.OrdenServicio.ApiServiceController.Base;
using Minsur.OrdenServicio.ApiServiceController.Interface.Seguridad;
using Minsur.OrdenServicio.ApiServiceController.Rest;
using Minsur.OrdenServicio.DTO.Seguridad;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Refit;

namespace Minsur.OrdenServicio.ApiServiceController.Implementation.Seguridad
{
    public class SeguridadApiServiceController : BaseApiServiceController, ISeguridadApiServiceController
    {
        private readonly ISeguridadService oISeguridadService;
        private readonly IConfiguration oIConfiguration;

        public SeguridadApiServiceController(IConfiguration configuration) : base(configuration)
        {
            this.oIConfiguration = configuration;
            oISeguridadService = RestService.For<ISeguridadService>(oHttpClient, new RefitSettings
            {
                ContentSerializer = new JsonContentSerializer(new JsonSerializerSettings { Converters = { new StringEnumConverter() } })
            });
        }

        public PaginationResponse<UsuarioDto> ObtenerUsuarios(PaginationRequest<FiltroUsuarioDto> oPaginationRequest)
        {
            return oISeguridadService.ObtenerUsuarios(oPaginationRequest).Result;
        }
        public TransactionResponse EditarUsuario(int id, UsuarioDto oUsuarioDto)
        {
            return oISeguridadService.EditarUsuario(id, oUsuarioDto).Result;
        }

        public TransactionResponse RegistrarUsuario(UsuarioDto oUsuarioDto)
        {
            return oISeguridadService.RegistrarUsuario(oUsuarioDto).Result;
        }

        public ListaUsuarioDto ObtenerNombreUsuarios()
        {
            return oISeguridadService.ObtenerNombreUsuarios().Result;
        }

        public UsuarioDto ObtenerUsuarioPorCorreo(string correo)
        {
            return oISeguridadService.ObtenerUsuarioPorCorreo(correo).Result;
        }

        public ListaRolDto ObtenerRoles()
        {
            return oISeguridadService.ObtenerRoles().Result;
        }
    }
}
