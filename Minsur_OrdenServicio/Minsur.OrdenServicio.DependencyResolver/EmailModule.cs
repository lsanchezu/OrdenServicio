using Minsur.OrdenServicio.Mail.Implementation;
using Minsur.OrdenServicio.Mail.Interface;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DependencyResolver
{
    public class EmailModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEmailService>().To<EmailService>();
        }
    }
}
