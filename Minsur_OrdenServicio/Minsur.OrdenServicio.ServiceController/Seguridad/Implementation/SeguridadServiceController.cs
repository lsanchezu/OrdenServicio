using SeguridadPerfil = Komatsu.Core.Seguridad.ServicioPerfil;
using SeguridadUsuario = Komatsu.Core.Seguridad.ServicioUsuario;
using Minsur.OrdenServicio.ServiceController.Seguridad.Interface;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Microsoft.Extensions.Configuration;
using Minsur.OrdenServicio.DTO;
using System.Linq;
using Minsur.OrdenServicio.Common.Recursos;

namespace Minsur.OrdenServicio.ServiceController.Seguridad.Implementation
{
    public class SeguridadServiceController : ISeguridadServiceController
    {
        private readonly ChannelFactory<SeguridadUsuario.IServicioUsuario> ChannelFactoryUsuarioService;
        private readonly ChannelFactory<SeguridadPerfil.IServicioPerfil> ChannelFactoryPerfilService;

        public SeguridadServiceController(IConfiguration configuration)
        {
            ChannelFactoryUsuarioService = new ChannelFactory<SeguridadUsuario.IServicioUsuario>(new BasicHttpBinding(), new EndpointAddress(configuration["Service:SeguridadUsuario"]));
            ChannelFactoryPerfilService = new ChannelFactory<SeguridadPerfil.IServicioPerfil>(new BasicHttpBinding(), new EndpointAddress(configuration["Service:SeguridadPerfil"]));
        }

        public UsuarioDto AuthenticateUser(string usuario, string contrasena)
        {
            SeguridadUsuario.Usuario oUsuario = new SeguridadUsuario.Usuario();
            oUsuario.UserName = usuario;
            oUsuario.Password = contrasena;
            oUsuario.IdAplicacion = int.Parse(Constantes.IdAplicacionOrdenServicio);

            SeguridadUsuario.Usuario oUsuarioService = ChannelFactoryUsuarioService.CreateChannel().AutenticarUsuario(oUsuario);

            UsuarioDto oUsuarioDto = new UsuarioDto();

            if (oUsuarioService.IdUsuario != 0)
            {
                oUsuarioDto.IdUsuario = oUsuarioService.IdUsuario;
                oUsuarioDto.NombreUsuario = oUsuarioService.UserName;
                oUsuarioDto.NombreApellido = oUsuarioService.NombreApellido;
                oUsuarioDto.IdCargo = oUsuarioService.IdCargo;
                oUsuarioDto.NombreCargo = oUsuarioService.CargoDescripcionCorta;
                oUsuarioDto.RolDto = new RolDto();
                oUsuarioDto.RolDto.IdRol = oUsuarioService.ListaRol.FirstOrDefault().IdRol;
                oUsuarioDto.RolDto.Nombre = oUsuarioService.ListaRol.FirstOrDefault().Nombre;
            }

            return oUsuarioDto;
        }

        public SeguridadPerfil.ListaMenu ObtenerSitemapPorUsuario(string nombreUsuario, int idAplicacion, int idRol)
        {
            return ChannelFactoryPerfilService.CreateChannel().ObtenerSitemap(nombreUsuario, idAplicacion, idRol);
        }
    }
}
