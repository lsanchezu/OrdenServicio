using Microsoft.AspNetCore.Http;
using Minsur.OrdenServicio.DTO;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Minsur.OrdenServicio.Mvc.Helpers
{
    public interface IUserFactory
    {
        UsuarioDto UsuarioDto { get; }

        UsuarioDto Deserialize(JwtSecurityToken oJwtSecurityToken);
    }

    public class UserFactory : IUserFactory
    {
        private readonly IHttpContextAccessor oIHttpContextAccessor;

        public UserFactory(IHttpContextAccessor oIHttpContextAccessor)
        {
            this.oIHttpContextAccessor = oIHttpContextAccessor;
        }

        public UsuarioDto UsuarioDto
        {
            get
            {
                return JsonConvert.DeserializeObject<UsuarioDto>(oIHttpContextAccessor.HttpContext.User.Claims.Where(x => x.Type.Equals("UserData")).First().Value);
            }
        }

        public UsuarioDto Deserialize(JwtSecurityToken oJwtSecurityToken)
        {
            return JsonConvert.DeserializeObject<UsuarioDto>(oJwtSecurityToken.Claims.Where(x => x.Type.Equals("UserData")).First().Value);
        }
    }

}
