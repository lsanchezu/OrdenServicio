using Minsur.OrdenServicio.Domain.DomainContract;
using Minsur.OrdenServicio.Domain.Services;
using Minsur.OrdenServicio.Seguridad.Domain.DomainContract;
using Minsur.OrdenServicio.Seguridad.Domain.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DependencyResolver
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISolicitudServicioDomainService>().To<SolicitudServicioDomainService>();
            Bind<IAdministracionDomainService>().To<AdministracionDomainService>();
            Bind<ISeguridadDomainService>().To<SeguridadDomainService>();
        }
    }
}
