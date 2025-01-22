using Microsoft.Extensions.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Repository.Config
{
    public class SqlDataBaseConfig : IDataBaseConfig
    {
        public Database Database { get; }
        public SqlDataBaseConfig(IConfiguration configuration,string cadenaConexion)
        {
            Database = new SqlDatabase(configuration.GetConnectionString(cadenaConexion));
        }
       
    }
}
