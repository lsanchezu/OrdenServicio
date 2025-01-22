using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Minsur.OrdenServicio.ApiServiceController.Interface;
using Minsur.OrdenServicio.Common.Estructura;
using Minsur.OrdenServicio.Common.Recursos;
using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Body;
using Minsur.OrdenServicio.Mvc.Helpers;

namespace Minsur.OrdenServicio.Mvc.Controllers
{
    [Authorize]
    public class MaestroController : Controller
    {
        private readonly IMaestroApiServiceController oIMaestroApiServiceController;
        private readonly IUserFactory oIUserFactory;

        public MaestroController(IMaestroApiServiceController oIMaestroApiServiceController,
                                 IUserFactory oIUserFactory)
        {
            this.oIMaestroApiServiceController = oIMaestroApiServiceController;
            this.oIUserFactory = oIUserFactory;
        }

        [HttpGet]
        public JsonResult ObtenerMaestroSolicitud()
        {
            MaestroSolicitudResponse oMaestroSolicitudResponse = oIMaestroApiServiceController.ObtenerMaestroSolicitud(oIUserFactory.UsuarioDto.IdUsuario);
            oMaestroSolicitudResponse.ListaFuenteContratoDto.Insert(0, new FuenteContratoDto { IdFuenteContrato = Numeracion.Cero, Descripcion = Constantes.Seleccione });
            oMaestroSolicitudResponse.ListaCompaniaDto.Insert(0, new CompaniaDto { IdCompania = Numeracion.Cero, Descripcion = Constantes.Seleccione });
            oMaestroSolicitudResponse.ListaFaseProyectoDto.Insert(0, new FaseProyectoDto { IdFaseProyecto = Numeracion.Cero, Descripcion = Constantes.Seleccione });
            oMaestroSolicitudResponse.ListaAreaFuncionalDto.Insert(0, new AreaFuncionalDto { IdAreaFuncional = Numeracion.Cero, Descripcion = Constantes.Seleccione });
            oMaestroSolicitudResponse.ListaMonedaDto.Insert(0, new MonedaDto { IdMoneda = Numeracion.Cero, Descripcion = Constantes.Seleccione });
            oMaestroSolicitudResponse.ListaTipoDto.Insert(0, new TipoDto { IdTipo = Numeracion.Cero, Descripcion = Constantes.Seleccione });

            return Json(new { maestro = oMaestroSolicitudResponse });
        }

        [HttpGet]
        public JsonResult ObtenerMaestroConsulta()
        {
            MaestroSolicitudResponse oMaestroSolicitudResponse = oIMaestroApiServiceController.ObtenerMaestroSolicitud(oIUserFactory.UsuarioDto.IdUsuario);
            oMaestroSolicitudResponse.ListaProyectoDto = oIMaestroApiServiceController.ListarProyectoPorUsuario(oIUserFactory.UsuarioDto.IdUsuario, Numeracion.Cero);
            oMaestroSolicitudResponse.ListaFuenteContratoDto.Insert(0, new FuenteContratoDto { IdFuenteContrato = Numeracion.Cero, Descripcion = Constantes.Todos });
            oMaestroSolicitudResponse.ListaCompaniaDto.Insert(0, new CompaniaDto { IdCompania = Numeracion.Cero, Descripcion = Constantes.Todos });
            oMaestroSolicitudResponse.ListaFaseProyectoDto.Insert(0, new FaseProyectoDto { IdFaseProyecto = Numeracion.Cero, Descripcion = Constantes.Todos });
            oMaestroSolicitudResponse.ListaAreaFuncionalDto.Insert(0, new AreaFuncionalDto { IdAreaFuncional = Numeracion.Cero, Descripcion = Constantes.Todos });
            oMaestroSolicitudResponse.ListaMonedaDto.Insert(0, new MonedaDto { IdMoneda = Numeracion.Cero, Descripcion = Constantes.Todos });
            oMaestroSolicitudResponse.ListaEstadoDto.Insert(0, new EstadoDto { IdEstado = Numeracion.Cero, Nombre = Constantes.Todos });

            return Json(new
            {
                maestro = oMaestroSolicitudResponse,
                fechaInicio = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy"),
                fechaFin = DateTime.Now.ToString("dd/MM/yyyy")
            });
        }

        [HttpGet]
        public JsonResult ListarProyectoPorUsuario(int idCompania)
        {
            return Json(new
            {
                listaProyecto = oIMaestroApiServiceController.ListarProyectoPorUsuario(oIUserFactory.UsuarioDto.IdUsuario, idCompania)
            });
        }
    }
}