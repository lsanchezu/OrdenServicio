using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Minsur.OrdenServicio.Mvc.Helpers;
using Minsur.OrdenServicio.Mvc.Models;

namespace Minsur.OrdenServicio.Mvc.Controllers
{
    //[Authorize(AuthenticationSchemes = AuthSchemes)]
    ///[Authorize(AuthenticationSchemes = AuthSchemes)]
    public class HomeController : Controller
    {
        private readonly IUserFactory oIUserFactory;

        public HomeController(IUserFactory oIUserFactory)
        {
            this.oIUserFactory = oIUserFactory;
        }    

        private const string AuthSchemes =
        CookieAuthenticationDefaults.AuthenticationScheme + "," +
        JwtBearerDefaults.AuthenticationScheme;

        public IActionResult Index()
        {
            return View();
        }
    }
}
