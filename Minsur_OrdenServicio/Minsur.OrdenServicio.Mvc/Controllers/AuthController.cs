using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Minsur.OrdenServicio.Common.Recursos;
using Newtonsoft.Json;
using SeguridadUsuario = Komatsu.Core.Seguridad.ServicioUsuario;
using SeguridadPerfil = Komatsu.Core.Seguridad.ServicioPerfil;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.Mvc.Helpers;
using Minsur.OrdenServicio.Mvc.Models;
using Minsur.OrdenServicio.ServiceController.Seguridad.Interface;

namespace Minsur.OrdenServicio.Mvc.Controllers
{
    [Authorize]
    public class AuthController : Controller
    {
        private readonly ISeguridadServiceController oISeguridadServiceController;
        private readonly IConfiguration oIConfiguration;
        private readonly IUserFactory oIUserFactory;

        public AuthController(ISeguridadServiceController oISeguridadServiceController,
                              IConfiguration oIConfiguration,
                              IUserFactory oIUserFactory)
        {
            this.oISeguridadServiceController = oISeguridadServiceController;
            this.oIConfiguration = oIConfiguration;
            this.oIUserFactory = oIUserFactory;
        }

        [HttpGet("SolicitudOrdenServicio/Login")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            LoginViewModel oLoginViewModel = new LoginViewModel();
            return View(oLoginViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Autenticar(LoginViewModel oLoginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { mensaje = DictionaryErrors.SOL00001 });
            }

            UsuarioDto oUsuarioDto = oISeguridadServiceController.AuthenticateUser(oLoginViewModel.Usuario, oLoginViewModel.Contrasena);

            if (oUsuarioDto.IdUsuario == default(int))
            {
                return Json(new { mensaje = DictionaryErrors.SOL00002 });
            }

            var claims = new[]
            {
                new Claim("UserData", JsonConvert.SerializeObject(oUsuarioDto)),
                new Claim("Usuario", oUsuarioDto.NombreUsuario),
                new Claim("NombreApellido", oUsuarioDto.NombreApellido),
                new Claim("Rol", oUsuarioDto.RolDto.Nombre),
                new Claim("Cargo", oUsuarioDto.NombreCargo)
            };

            var token = new JwtSecurityToken
            (
                issuer: oIConfiguration["ApiAuth:Issuer"],
                audience: oIConfiguration["ApiAuth:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(oIConfiguration["ApiAuth:SecretKey"])), SecurityAlgorithms.HmacSha256)
            );

            return Json(new { token = new JwtSecurityTokenHandler().WriteToken(token), url = "/SolicitudOrdenServicio/Index" });

        }

        [HttpGet]
        public JsonResult ObtenerSitemap()
        {
            UsuarioDto oUsuarioDto = oIUserFactory.UsuarioDto;

            SeguridadPerfil.ListaMenu oListaMenu = oISeguridadServiceController.ObtenerSitemapPorUsuario(oUsuarioDto.NombreUsuario,
                                                                                                        int.Parse(Constantes.IdAplicacionOrdenServicio),
                                                                                                        oUsuarioDto.RolDto.IdRol);

            return Json(new { listaMenu = oListaMenu });
        }
    }
}