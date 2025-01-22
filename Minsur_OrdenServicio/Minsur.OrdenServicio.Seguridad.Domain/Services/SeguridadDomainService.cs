using Minsur.OrdenServicio.Seguridad.Domain.DomainContract;
using Minsur.OrdenServicio.Seguridad.Domain.Entities;
using Minsur.OrdenServicio.Seguridad.Domain.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Seguridad.Domain.Services
{
    public class SeguridadDomainService : ISeguridadDomainService
    {
        private readonly ISeguridadRepository oISeguridadRepository;
        public SeguridadDomainService(ISeguridadRepository oISeguridadRepository)
        {
            this.oISeguridadRepository = oISeguridadRepository;
        }
        public bool ValidarUsuarioExistente(Usuario usuario)
        {
            var usuarioExistente = oISeguridadRepository.ObtenerUsuarioPorCodigo(usuario.NombreUsuario,usuario.Correo);
            return usuarioExistente.IdUsuario != 0;
        }
    }
}
