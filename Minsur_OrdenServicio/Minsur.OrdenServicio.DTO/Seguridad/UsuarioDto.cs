﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO.Seguridad
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreApellido { get; set; }
        public string Correo { get; set; }
        public string Estado { get; set; }
        public int IdEstado { get; set; }
        public int IdRol { get; set; }
    }
    public class ListaUsuarioDto : List<UsuarioDto> { }
}
