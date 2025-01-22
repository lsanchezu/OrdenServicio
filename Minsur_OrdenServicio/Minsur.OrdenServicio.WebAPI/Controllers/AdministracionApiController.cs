using Microsoft.AspNetCore.Mvc;
using Minsur.OrdenServicio.Application.Contract.Administracion;
using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Body;

namespace Minsur.OrdenServicio.WebAPI.Controllers
{
    [Route("api/administracion")]
    [ApiController]
    public class AdministracionApiController : ControllerBase
    {
        private readonly IAdministracionService oIAdministracionService;

        public AdministracionApiController(IAdministracionService oIAdministracionService)
        {
            this.oIAdministracionService = oIAdministracionService;
        }

        [HttpGet("companias")]
        public IActionResult ObtenerCompanias()
        {
            return Ok(oIAdministracionService.ObtenerCompanias());
        }
        [HttpPost("companias")]
        public IActionResult RegistrarCompania([FromBody]TransactionRequest<CompaniaDto> oTransactionRequest)
        {
            return Ok(oIAdministracionService.RegistrarCompania(oTransactionRequest));
        }
        [HttpPut("companias/{id}")]
        public IActionResult EditarCompania(int id, [FromBody] TransactionRequest<CompaniaDto> oTransactionRequest)
        {
            return Ok(oIAdministracionService.EditarCompania(id, oTransactionRequest));
        }
        [HttpGet("companias/{idCompania}/proyectos")]
        public IActionResult ObtenerProyectosPorCompania(int idCompania)
        {
            return Ok(oIAdministracionService.ObtenerProyectosPorCompania(idCompania));
        }
        [HttpPost("proyectos")]
        public IActionResult RegistrarProyecto([FromBody] TransactionRequest<ProyectoDto> oTransactionRequest)
        {
            return Ok(oIAdministracionService.RegistrarProyecto(oTransactionRequest));
        }
        [HttpPut("proyectos/{id}")]
        public IActionResult EditarProyecto(int id, [FromBody] TransactionRequest<ProyectoDto> oTransactionRequest)
        {
            return Ok(oIAdministracionService.EditarProyecto(id, oTransactionRequest));
        }
        [HttpGet("disciplinas")]
        public IActionResult ObtenerDisciplinas()
        {
            return Ok(oIAdministracionService.ObtenerDisciplinas());
        }
        [HttpPost("disciplinas")]
        public IActionResult RegistrarDisciplinas([FromBody] TransactionRequest<DisciplinaDto> oTransactionRequest)
        {
            return Ok(oIAdministracionService.RegistrarDisciplina(oTransactionRequest));
        }
        [HttpPut("disciplinas/{id}")]
        public IActionResult EditarDisciplinas(int id, [FromBody] TransactionRequest<DisciplinaDto> oTransactionRequest)
        {
            return Ok(oIAdministracionService.EditarDisciplina(id, oTransactionRequest));
        }

        [HttpGet("proyectos/{id}/gobernanzas")]
        public IActionResult ObtenerConfiguracionGobernanzaPorProyecto(int id)
        {
            return Ok(oIAdministracionService.ObtenerConfiguracionGobernanzaPorProyecto(id));
        }

        [HttpPost("gobernanzas")]
        public IActionResult GuardarConfiguracionGobernanzaPorProyecto([FromBody] TransactionRequest<GobernanzaRequest> oTransactionRequest)
        {
            return Ok(oIAdministracionService.GuardarConfiguracionGobernanzaPorProyecto(oTransactionRequest));
        }

        [HttpGet("usuarios/proyectos")]
        public IActionResult ObtenerListaConfiguracionUsuarioProyecto([FromQuery]FiltroConfiguracionUsuarioProyectoDto oFiltroConfiguracionUsuarioProyectoDto)
        {
            return Ok(oIAdministracionService.ObtenerListaConfiguracionUsuarioProyecto(oFiltroConfiguracionUsuarioProyectoDto));
        }
        [HttpPost("usuarios/proyectos")]
        public IActionResult GuardarConfiguracionUsuarioProyecto([FromBody] TransactionRequest<ConfiguracionUsuarioProyectoRequest> oTransactionRequest)
        {
            return Ok(oIAdministracionService.GuardarConfiguracionUsuarioProyecto(oTransactionRequest));
        }

        [HttpGet("gestionRol-por-proyecto/{idProyecto}")]
        public IActionResult ObtenerGestionRol(int idProyecto)
        {
            return Ok(oIAdministracionService.ObtenerGestionRol(idProyecto));
        }

        [HttpPost("gestionRol")]
        public IActionResult GuardarConfiguracionRol([FromBody] TransactionRequest<GestionRolRequest> oTransactionRequest)
        {
            return Ok(oIAdministracionService.GuardarConfiguracionRol(oTransactionRequest));
        }
    }
}