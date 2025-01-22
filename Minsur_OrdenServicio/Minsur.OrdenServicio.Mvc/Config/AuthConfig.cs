using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minsur.OrdenServicio.Mvc.Config
{
    public static class AuthConfig
    {
        public static TokenValidationParameters ObtenerParametroToken(IConfiguration Configuration)
        {
            TokenValidationParameters oTokenValidationParameters = new TokenValidationParameters()
            {
                ValidateActor = true,

                ValidateIssuer = true,
                ValidIssuer = Configuration["ApiAuth:Issuer"],
                ValidateAudience = true,
                ValidAudience = Configuration["ApiAuth:Audience"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["ApiAuth:SecretKey"])),
                ValidateLifetime = true,
                SaveSigninToken = true
            };

            return oTokenValidationParameters;
        }
    }
}
