using Minsur.OrdenServicio.Domain.RepositoryContract.Administracion;
using Minsur.OrdenServicio.Domain.RepositoryContract.Maestro;
using Minsur.OrdenServicio.Domain.RepositoryContract.Solicitud;
using Minsur.OrdenServicio.Repository.Administracion;
using Minsur.OrdenServicio.Repository.Config;
using Minsur.OrdenServicio.Repository.Maestro;
using Minsur.OrdenServicio.Repository.Seguridad;
using Minsur.OrdenServicio.Repository.Solicitud;
using Minsur.OrdenServicio.Seguridad.Domain.RepositoryContract;
using Ninject.Modules;

namespace Minsur.OrdenServicio.DependencyResolver
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataBaseConfig>().To<SqlDataBaseConfig>().Named("Solicitud").WithConstructorArgument("cnsBdSolicitudOrdenServicio");
            Bind<IDataBaseConfig>().To<SqlDataBaseConfig>().Named("Seguridad").WithConstructorArgument("cnsBdSeguridad");
            Bind<IMaestroRepository>().To<MaestroRepository>();
            Bind<ISolicitudOrdenServicioRepository>().To<SolicitudOrdenServicioRepository>();
            Bind<IAdministracionRepository>().To<AdministracionRepository>();
            Bind<ISeguridadRepository>().To<SeguridadRepository>();
        }
    }
}
