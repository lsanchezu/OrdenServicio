using Microsoft.AspNetCore.Mvc;
using Minsur.OrdenServicio.Application.Contract.Seguridad;
using Minsur.OrdenServicio.DTO.Seguridad;

namespace Minsur.OrdenServicio.WebAPI.Controllers
{
    [Route("api/seguridad")]
    [ApiController]
    public class SeguridadApiController : ControllerBase
    {
        private readonly ISeguridadService oISeguridadService;
        public SeguridadApiController(ISeguridadService oISeguridadService)
        {
            this.oISeguridadService = oISeguridadService;
        }

        [HttpGet("usuarios")]
        public IActionResult ObtenerUsuarios([FromQuery] PaginationRequest<FiltroUsuarioDto> oPaginationRequest)
        {
            return Ok(oISeguridadService.ObtenerUsuarios(oPaginationRequest));
        }
        [HttpPut("usuarios")]
        public IActionResult EditarUsuario(int id, [FromBody] UsuarioDto oUsuarioDto)
        {
            return Ok(oISeguridadService.EditarUsuario(id, oUsuarioDto));
        }
        [HttpPost("usuarios")]
        public IActionResult RegistrarUsuario([FromBody] UsuarioDto oUsuarioDto)
        {
            return Ok(oISeguridadService.RegistrarUsuario(oUsuarioDto));
        }
        [HttpGet("usernames")]
        public IActionResult ObtenerNombreUsuarios()
        {
            return Ok(oISeguridadService.ObtenerNombreUsuarios());
        }
        [HttpGet("usuario/{correo}")]
        public IActionResult ObtenerUsuarioPorCorreo(string correo)
        {
            return Ok(oISeguridadService.ObtenerUsuarioPorCorreo(correo));
        }
        [HttpGet("roles")]
        public IActionResult ObtenerRoles()
        {
            return Ok(oISeguridadService.ObtenerRoles());
        }
    }
}