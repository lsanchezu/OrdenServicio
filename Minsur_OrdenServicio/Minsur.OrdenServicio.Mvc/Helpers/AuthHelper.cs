using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Minsur.OrdenServicio.Mvc.Config;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minsur.OrdenServicio.Mvc.Helpers
{
    public static class AuthHelper
    {
        public static JwtSecurityToken ValidateToken(IConfiguration Configuration,  string token)
        {
            try
            {
                var principal = new JwtSecurityTokenHandler().ValidateToken(token, AuthConfig.ObtenerParametroToken(Configuration), out var rawValidatedToken);
                
                return (JwtSecurityToken)rawValidatedToken;
            }
            catch (SecurityTokenValidationException)
            {
                return null;
            }

        }
    }
}
