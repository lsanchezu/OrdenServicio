using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Repository.Config
{
    public interface IDataBaseConfig
    {
        Database Database { get; }
    }
}
