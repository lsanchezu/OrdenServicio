using Microsoft.Extensions.Configuration;
using Minsur.OrdenServicio.ApiServiceController.Base;
using Minsur.OrdenServicio.ApiServiceController.Interface;
using Minsur.OrdenServicio.ApiServiceController.Rest;
using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Body;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.ApiServiceController.Implementation
{
    public class MaestroApiServiceController : BaseApiServiceController, IMaestroApiServiceController
    {
        private readonly IMaestroRestService oIMaestroRestService;

        public MaestroApiServiceController(IConfiguration configuration) : base(configuration)
        {
            oIMaestroRestService = RestService.For<IMaestroRestService>(oHttpClient, new RefitSettings
            {
                ContentSerializer = new JsonContentSerializer(new JsonSerializerSettings { Converters = { new StringEnumConverter() } })
            });
        }

        public MaestroSolicitudResponse ObtenerMaestroSolicitud(int idUsuario)
        {
            return oIMaestroRestService.ObtenerMaestroSolicitud(idUsuario).Result;
        }

        public ListaProyectoDto ListarProyectoPorUsuario(int idUsuario, int idCompania)
        {
            return oIMaestroRestService.ListarProyectoPorUsuario(idUsuario, idCompania).Result;
        }
    }
}
