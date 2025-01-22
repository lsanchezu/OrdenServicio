using Microsoft.Practices.EnterpriseLibrary.Data;
using Minsur.OrdenServicio.WebAPI.NET.DataAccess.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Minsur.OrdenServicio.WebAPI.NET.DataAccess
{
    public class ReporteSolicitudDataAccess
    {
        protected readonly DatabaseProviderFactory oDatabaseProviderFactory = new DatabaseProviderFactory();
        private Database oDatabase;

        public ReporteSolicitudDataAccess()
        {
            oDatabase = oDatabaseProviderFactory.Create(Conexion.CN_SOL_CONTRATACION);
        }
        
        public void ActualizarPdf(int idSolicitudOrdenServicio, bool flagGenerado)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Usp_Upd_SolicitudOrdenServicio_PDFGenerado);
            oDatabase.AddInParameter(oDbCommand, "@IdSolicitudOrdenServicio", DbType.Int32, idSolicitudOrdenServicio);
            oDatabase.AddInParameter(oDbCommand, "@FlagPDFGenerado", DbType.Boolean, flagGenerado);

            oDatabase.ExecuteNonQuery(oDbCommand);
        }
    }
}