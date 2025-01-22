using AutoMapper;
using Minsur.OrdenServicio.Translator.MapperProfile;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minsur.OrdenServicio.DependencyResolver
{
    public class AutomapperModule: NinjectModule
    {
        public override void Load()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MaestroProfile());
                cfg.AddProfile(new SeguridadProfile());
                cfg.AddProfile(new SolicitudOrdenServicioProfile());
            });

            IMapper mapper = config.CreateMapper();
            Bind<IMapper>().ToConstant(mapper).InSingletonScope();

        }
    }
}
