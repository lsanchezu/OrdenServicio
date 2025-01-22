using AutoMapper;
using Minsur.OrdenServicio.DTO.Seguridad;
using Minsur.OrdenServicio.Seguridad.Domain.Entities;

namespace Minsur.OrdenServicio.Translator.MapperProfile
{
    public class SeguridadProfile: Profile
    {
        public SeguridadProfile()
        {
            #region ENT => DTO
            CreateMap<Usuario, UsuarioDto>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<FiltroUsuario, FiltroUsuarioDto>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<Rol, RolDto>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            
            #endregion
            #region DTO => ENT
            CreateMap<UsuarioDto, Usuario>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<FiltroUsuarioDto, FiltroUsuario>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<RolDto, Rol>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            
             CreateMap<Paginacion, PaginacionDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter().ReverseMap();
            
            #endregion
        }
    }
}
