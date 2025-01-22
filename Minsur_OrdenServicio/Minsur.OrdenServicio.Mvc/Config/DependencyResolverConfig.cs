using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minsur.OrdenServicio.ApiServiceController.Implementation;
using Minsur.OrdenServicio.ApiServiceController.Implementation.Seguridad;
using Minsur.OrdenServicio.ApiServiceController.Interface;
using Minsur.OrdenServicio.ApiServiceController.Interface.Seguridad;
using Minsur.OrdenServicio.Mvc.Helpers;
using Minsur.OrdenServicio.ServiceController.Seguridad.Implementation;
using Minsur.OrdenServicio.ServiceController.Seguridad.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minsur.OrdenServicio.Mvc.Config
{
    public static class DependencyResolverConfig
    {
        public static void Inicializar(IServiceCollection services)
        {
            services.AddTransient<ISolicitudOrdenServicioApiServiceController, SolicitudOrdenServicioApiServiceController>();
            services.AddTransient<IAdministracionApiServiceController, AdministracionApiServiceController>();
            services.AddTransient<IMaestroApiServiceController, MaestroApiServiceController>();
            services.AddTransient<ISeguridadApiServiceController, SeguridadApiServiceController>();
            services.AddTransient<ISeguridadServiceController, SeguridadServiceController>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserFactory, UserFactory>();
        }
    }
}
