
using Microsoft.Reporting.WinForms;
using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Body;
using Minsur.OrdenServicio.WebAPI.NET.BusinessLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Description;

namespace Minsur.OrdenServicio.WebAPI.NET.Controllers
{
    [RoutePrefix("api/solicitud-ordenservicio/reportes")]
    public class ReporteApiController : ApiController
    {
        private readonly ReporteSolicitudBusinessLogic oReporteSolicitudBusinessLogic = new ReporteSolicitudBusinessLogic();

        [HttpPost]
        [ResponseType(typeof(TransactionResponse))]
        [Route("generar")]
        public IHttpActionResult GenerarPDF([FromBody] SolicitudOrdenServicioDto oSolicitudOrdenServicioDto)
        {
            TransactionResponse oTransactionResponse = oReporteSolicitudBusinessLogic.GenerarPDF(oSolicitudOrdenServicioDto);
            return Ok(oTransactionResponse);
        }
    }
}
