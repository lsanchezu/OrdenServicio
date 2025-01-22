using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Minsur.OrdenServicio.Mvc.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Contrasena { get; set; }
        public string Mensaje { get; set; }
        public string Url { get; set; }
    }
}
