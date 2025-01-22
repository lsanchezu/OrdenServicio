using Minsur.OrdenServicio.Application.Contract.Administracion;
using Minsur.OrdenServicio.Application.Contract.Maestro;
using Minsur.OrdenServicio.Application.Contract.Seguridad;
using Minsur.OrdenServicio.Application.Contract.Solicitud;
using Minsur.OrdenServicio.Application.Service.Administracion;
using Minsur.OrdenServicio.Application.Service.Maestro;
using Minsur.OrdenServicio.Application.Service.Seguridad;
using Minsur.OrdenServicio.Application.Service.Solicitud;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DependencyResolver
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMaestroService>().To<MaestroService>();
            Bind<ISolicitudOrdenServicioService>().To<SolicitudOrdenServicioService>();
            Bind<IAdministracionService>().To<AdministracionService>();
            Bind<ISeguridadService>().To<SeguridadService>();

        }
        
    }
}
