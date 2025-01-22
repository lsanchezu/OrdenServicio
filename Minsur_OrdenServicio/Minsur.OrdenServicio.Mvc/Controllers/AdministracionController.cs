using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Minsur.OrdenServicio.ApiServiceController.Interface;
using Minsur.OrdenServicio.Common.Recursos;
using Minsur.OrdenServicio.DTO;
using SeguridadContext = Minsur.OrdenServicio.DTO.Seguridad;
using Minsur.OrdenServicio.DTO.Body;
using Minsur.OrdenServicio.Mvc.Helpers;
using Minsur.OrdenServicio.ApiServiceController.Interface.Seguridad;
using Minsur.OrdenServicio.Common.Estructura;
using System.Linq;

namespace Minsur.OrdenServicio.Mvc.Controllers
{
    [Authorize]
    public class AdministracionController : Controller
    {
        private readonly IAdministracionApiServiceController oIAdministracionApiServiceController;
        private readonly ISeguridadApiServiceController oISeguridadApiServiceController;
        private readonly IUserFactory oIUserFactory;
        public AdministracionController(IAdministracionApiServiceController oIAdministracionApiServiceController, ISeguridadApiServiceController oISeguridadApiServiceController, IUserFactory oIUserFactory)
        {
            this.oIAdministracionApiServiceController = oIAdministracionApiServiceController;
            this.oISeguridadApiServiceController = oISeguridadApiServiceController;
            this.oIUserFactory = oIUserFactory;
        }
        #region COMPAÑÍAS Y PROYECTOS
        [HttpGet]
        public JsonResult ObtenerCompanias()
        {
            ListaCompaniaDto oListaCompaniaDTO = oIAdministracionApiServiceController.ObtenerCompanias();
            return Json(new { listaCompanias = oListaCompaniaDTO });
        }
        [HttpPost]
        public JsonResult RegistrarCompania([FromBody] CompaniaDto oCompaniaDto)
        {
            TransactionRequest<CompaniaDto> oTransactionRequest = new TransactionRequest<CompaniaDto> { Usuario = oIUserFactory.UsuarioDto, EntidadDto = oCompaniaDto };
            TransactionResponse oTransactionResponse = oIAdministracionApiServiceController.RegistrarCompania(oTransactionRequest);
            return Json(new { flagError = (oTransactionResponse.Codigo != nameof(DictionaryErrors.SOL00000)), mensaje = oTransactionResponse.Mensaje });
        }
        [HttpPut]
        public JsonResult EditarCompania(int id, [FromBody] CompaniaDto oCompaniaDto)
        {
            TransactionRequest<CompaniaDto> oTransactionRequest = new TransactionRequest<CompaniaDto> { Usuario = oIUserFactory.UsuarioDto, EntidadDto = oCompaniaDto };
            TransactionResponse oTransactionResponse = oIAdministracionApiServiceController.EditarCompania(id, oTransactionRequest);
            return Json(new { flagError = (oTransactionResponse.Codigo != nameof(DictionaryErrors.SOL00000)), mensaje = oTransactionResponse.Mensaje });
        }
        [HttpGet]
        public JsonResult ObtenerProyectosPorCompania(int idCompania)
        {
            ListaProyectoDto oListaProyectoDto = oIAdministracionApiServiceController.ObtenerProyectosPorCompania(idCompania);
            return Json(new { listaProyectos = oListaProyectoDto });
        }
        [HttpPost]
        public JsonResult RegistrarProyecto([FromBody] ProyectoDto oProyectoDto)
        {
            TransactionRequest<ProyectoDto> oTransactionRequest = new TransactionRequest<ProyectoDto> { Usuario = oIUserFactory.UsuarioDto, EntidadDto = oProyectoDto };
            TransactionResponse oTransactionResponse = oIAdministracionApiServiceController.RegistrarProyecto(oTransactionRequest);
            return Json(new { flagError = (oTransactionResponse.Codigo != nameof(DictionaryErrors.SOL00000)), mensaje = oTransactionResponse.Mensaje });
        }

        [HttpPut]
        public JsonResult EditarProyecto(int id, [FromBody] ProyectoDto oProyectoDto)
        {
            TransactionRequest<ProyectoDto> oTransactionRequest = new TransactionRequest<ProyectoDto> { Usuario = oIUserFactory.UsuarioDto, EntidadDto = oProyectoDto };
            TransactionResponse oTransactionResponse = oIAdministracionApiServiceController.EditarProyecto(id, oTransactionRequest);
            return Json(new { flagError = (oTransactionResponse.Codigo != nameof(DictionaryErrors.SOL00000)), mensaje = oTransactionResponse.Mensaje });
        }
        [HttpGet]
        public JsonResult ObtenerDisciplinas()
        {
            ListaDisciplinaDto oListaDisciplinaDto = oIAdministracionApiServiceController.ObtenerDisciplinas();
            return Json(new { listaDisciplinas = oListaDisciplinaDto });
        }

        [HttpPost]
        public JsonResult RegistrarDisciplina([FromBody] DisciplinaDto oDisciplinaDto)
        {
            TransactionRequest<DisciplinaDto> oTransactionRequest = new TransactionRequest<DisciplinaDto> { Usuario = oIUserFactory.UsuarioDto, EntidadDto = oDisciplinaDto };
            TransactionResponse oTransactionResponse = oIAdministracionApiServiceController.RegistrarDisciplina(oTransactionRequest);
            return Json(new { flagError = (oTransactionResponse.Codigo != nameof(DictionaryErrors.SOL00000)), mensaje = oTransactionResponse.Mensaje });
        }

        [HttpPut]
        public JsonResult EditarDisciplina(int id, [FromBody] DisciplinaDto oDisciplinaDto)
        {
            TransactionRequest<DisciplinaDto> oTransactionRequest = new TransactionRequest<DisciplinaDto> { Usuario = oIUserFactory.UsuarioDto, EntidadDto = oDisciplinaDto };
            TransactionResponse oTransactionResponse = oIAdministracionApiServiceController.EditarDisciplina(id, oTransactionRequest);
            return Json(new { flagError = (oTransactionResponse.Codigo != nameof(DictionaryErrors.SOL00000)), mensaje = oTransactionResponse.Mensaje });
        }
        #endregion
        #region GOBERNANZA
        [HttpGet]
        public JsonResult ObtenerConfiguracionGobernanzaPorProyecto(int idProyecto)
        {
            ListaConfiguracionGobernanzaDto oListaConfiguracionGobernanzaDto = oIAdministracionApiServiceController.ObtenerConfiguracionGobernanzaPorProyecto(idProyecto);
            return Json(new { listaConfiguracionGobernanza = oListaConfiguracionGobernanzaDto });
        }
        [HttpPost]
        public JsonResult GuardarConfiguracionGobernanzaPorProyecto([FromBody] GobernanzaRequest oGobernanzaRequest)
        {
            TransactionRequest<GobernanzaRequest> oTransactionRequest = new TransactionRequest<GobernanzaRequest> { Usuario = oIUserFactory.UsuarioDto, EntidadDto = oGobernanzaRequest };
            TransactionResponse oTransactionResponse = oIAdministracionApiServiceController.GuardarConfiguracionGobernanzaPorProyecto(oTransactionRequest);
            return Json(new { flagError = (oTransactionResponse.Codigo != nameof(DictionaryErrors.SOL00000)), mensaje = oTransactionResponse.Mensaje });
        }
        #endregion
        #region USUARIOS
        [HttpGet]
        public JsonResult ObtenerUsuarios(string usuario, string nombre, int nroPagina)
        {
            SeguridadContext.PaginationRequest<SeguridadContext.FiltroUsuarioDto> oPaginationRequest = new SeguridadContext.PaginationRequest<SeguridadContext.FiltroUsuarioDto>();
            oPaginationRequest.FiltroBusqueda = new SeguridadContext.FiltroUsuarioDto();
            oPaginationRequest.FiltroBusqueda.NombreUsuario = usuario ?? string.Empty;
            oPaginationRequest.FiltroBusqueda.NombreApellido = nombre ?? string.Empty;
            oPaginationRequest.PaginacionDto = new SeguridadContext.PaginacionDto();
            oPaginationRequest.PaginacionDto.Page = nroPagina;
            oPaginationRequest.PaginacionDto.RowsPerPage = Numeracion.Diez;

            SeguridadContext.PaginationResponse<SeguridadContext.UsuarioDto> oPaginationResponse = oISeguridadApiServiceController.ObtenerUsuarios(oPaginationRequest);

            return Json(new
            {
                listaUsuarios = oPaginationResponse.Resultado,
                total = oPaginationResponse.PaginacionDto.Total,
                nroFilasPorpagina = oPaginationResponse.PaginacionDto.RowsPerPage
            });
        }
        [HttpPut]
        public JsonResult EditarUsuario(int id, [FromBody] SeguridadContext.UsuarioDto oUsuarioDto)
        {
            SeguridadContext.TransactionResponse oTransactionResponse = oISeguridadApiServiceController.EditarUsuario(id, oUsuarioDto);
            return Json(new { flagError = (oTransactionResponse.Codigo != nameof(DictionaryErrors.SOL00000)), mensaje = oTransactionResponse.Mensaje });
        }
        [HttpGet]
        public JsonResult ObtenerListaConfiguracionUsuarioProyecto(int idCompania, int idUsuario)
        {
            FiltroConfiguracionUsuarioProyectoDto oFiltroConfiguracionUsuarioProyectoDto = new FiltroConfiguracionUsuarioProyectoDto();
            oFiltroConfiguracionUsuarioProyectoDto.IdCompania = idCompania;
            oFiltroConfiguracionUsuarioProyectoDto.IdUsuario = idUsuario;

            ListaConfiguracionUsuarioProyectoDto oListaConfiguracionProyectoDto = oIAdministracionApiServiceController.ObtenerListaConfiguracionUsuarioProyecto(oFiltroConfiguracionUsuarioProyectoDto);
            return Json(new { listaConfiguracionUsuarioProyecto = oListaConfiguracionProyectoDto });
        }
        [HttpPost]
        public JsonResult RegistrarUsuario([FromBody] SeguridadContext.UsuarioDto oUsuarioDto)
        {
            SeguridadContext.TransactionResponse oTransactionResponse = oISeguridadApiServiceController.RegistrarUsuario(oUsuarioDto);
            return Json(new { flagError = (oTransactionResponse.Codigo != nameof(DictionaryErrors.SOL00000)), mensaje = oTransactionResponse.Mensaje });
        }
        [HttpGet]
        public JsonResult ObtenerRoles()
        {
            SeguridadContext.ListaRolDto oListaRol = oISeguridadApiServiceController.ObtenerRoles();
            return Json(new { listaRoles = oListaRol });
        }
        
        [HttpPost]
        public JsonResult GuardarConfiguracionUsuarioProyecto([FromBody] ConfiguracionUsuarioProyectoRequest oConfiguracionUsuarioProyectoRequest)
        {
            TransactionRequest<ConfiguracionUsuarioProyectoRequest> oTransactionRequest = new TransactionRequest<ConfiguracionUsuarioProyectoRequest> { Usuario = oIUserFactory.UsuarioDto, EntidadDto = oConfiguracionUsuarioProyectoRequest };
            TransactionResponse oTransactionResponse = oIAdministracionApiServiceController.GuardarConfiguracionUsuarioProyecto(oTransactionRequest);
            return Json(new { flagError = (oTransactionResponse.Codigo != nameof(DictionaryErrors.SOL00000)), mensaje = oTransactionResponse.Mensaje });
        }
        #endregion
        #region ROLES
        [HttpGet]
        public JsonResult ObtenerListaConfiguracionRol(int idProyecto)
        {
            SeguridadContext.ListaUsuarioDto oListaUsuarioDto = oISeguridadApiServiceController.ObtenerNombreUsuarios();

            GestionRolResponse oGestionRolResponse = oIAdministracionApiServiceController.ObtenerGestionRol(idProyecto);
            foreach (var item in oGestionRolResponse.ListaConfiguracionRolDto)
            {
                item.UsuarioDto.NombreUsuario = oListaUsuarioDto.FirstOrDefault(x => x.IdUsuario == item.UsuarioDto.IdUsuario)?.NombreUsuario;
            }

            return Json(new { gestionRolResponse = oGestionRolResponse });
        }
        [HttpGet]
        public JsonResult ObtenerUsuarioPorCorreo(string correo)
        {
            SeguridadContext.UsuarioDto oUsuarioDto = oISeguridadApiServiceController.ObtenerUsuarioPorCorreo(correo);
            return Json(new { usuario = oUsuarioDto });
        }

        [HttpPost]
        public JsonResult GuardarConfiguracionRol([FromBody] GestionRolRequest oGestionRolRequest)
        {
            TransactionRequest<GestionRolRequest> oTransactionRequest = new TransactionRequest<GestionRolRequest> { Usuario = oIUserFactory.UsuarioDto, EntidadDto = oGestionRolRequest };
            TransactionResponse oTransactionResponse = oIAdministracionApiServiceController.GuardarConfiguracionRol(oTransactionRequest);
            return Json(new { flagError = (oTransactionResponse.Codigo != nameof(DictionaryErrors.SOL00000)), mensaje = oTransactionResponse.Mensaje });
        }
        #endregion
    }
}