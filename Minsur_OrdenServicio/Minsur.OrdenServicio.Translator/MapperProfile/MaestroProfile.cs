using AutoMapper;
using Minsur.OrdenServicio.Domain.Entities;
using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Translator.MapperProfile
{
    public class MaestroProfile : Profile
    {
        public MaestroProfile()
        {
            #region ENT => DTO

            CreateMap<Tipo, TipoDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<Estado, EstadoDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<Categoria, CategoriaDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<Compania, CompaniaDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<FaseProyecto, FaseProyectoDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<FuenteContrato, FuenteContratoDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<Moneda, MonedaDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<Proyecto, ProyectoDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<TipoDocumento, TipoDocumentoDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<Pais, PaisDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<Usuario, UsuarioDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<Gobernanza, GobernanzaDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<EmailParametro, EmailParametroDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<Disciplina, DisciplinaDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<ConfiguracionGobernanza, ConfiguracionGobernanzaDto>()
                 .ForMember(dto => dto.GobernanzaDto, src => src.MapFrom(ent => ent.Gobernanza))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<ConfiguracionUsuarioProyecto, ConfiguracionUsuarioProyectoDto>()
                .ForMember(dto => dto.ProyectoDto, src => src.MapFrom(ent => ent.Proyecto))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<ConfiguracionRol, ConfiguracionRolDto>()
                 .ForMember(dto => dto.UsuarioDto, src => src.MapFrom(ent => ent.Usuario))
                 .ForMember(dto => dto.ListaRolGobernanzaDto, src => src.MapFrom(ent => ent.ListaRolGobernanza))
                 .ForMember(dto => dto.ListaRolDisciplinaDto, src => src.MapFrom(ent => ent.ListaRolDisciplina))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<ConfiguracionAreaFuncionalUsuarioProyecto, ConfiguracionAreaFuncionalUsuarioProyectoDto>()
                .ForMember(ent => ent.UsuarioDto, src => src.MapFrom(dto => dto.Usuario))
                .ForMember(ent => ent.ProyectoDto, src => src.MapFrom(dto => dto.Proyecto))
                .ForMember(ent => ent.AreaFuncionalDto, src => src.MapFrom(dto => dto.AreaFuncional))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<RolGobernanza, RolGobernanzaDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<RolDisciplina, RolDisciplinaDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<Paginacion, PaginacionDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            #endregion

            #region DTO => ENT

            CreateMap<TipoDto, Tipo>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<EstadoDto, Estado>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<CategoriaDto, Categoria>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<CompaniaDto, Compania>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<FaseProyectoDto, FaseProyecto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<FuenteContratoDto, FuenteContrato>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<MonedaDto, Moneda>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<ProyectoDto, Proyecto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<TipoDocumentoDto, TipoDocumento>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<PaisDto, Pais>()
              .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<UsuarioDto, Usuario>()
                 .ForMember(ent => ent.IdRol, src => src.MapFrom(dto => dto.RolDto.IdRol))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<GobernanzaDto, Gobernanza>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<DisciplinaDto, Disciplina>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<ConfiguracionGobernanzaDto, ConfiguracionGobernanza>()
                .ForMember(ent => ent.Gobernanza, src => src.MapFrom(dto => dto.GobernanzaDto))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<ConfiguracionUsuarioProyectoDto, ConfiguracionUsuarioProyecto>()
                .ForMember(ent => ent.Proyecto, src => src.MapFrom(dto => dto.ProyectoDto))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<ConfiguracionRolDto, ConfiguracionRol>()
                .ForMember(ent => ent.Usuario, src => src.MapFrom(dto => dto.UsuarioDto))
                .ForMember(ent => ent.ListaRolGobernanza, src => src.MapFrom(dto => dto.ListaRolGobernanzaDto))
                .ForMember(dto => dto.ListaRolDisciplina, src => src.MapFrom(ent => ent.ListaRolDisciplinaDto))
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<ConfiguracionAreaFuncionalUsuarioProyectoDto, ConfiguracionAreaFuncionalUsuarioProyecto>()
                .ForMember(ent => ent.Usuario, src => src.MapFrom(dto => dto.UsuarioDto))
                .ForMember(ent => ent.Proyecto, src => src.MapFrom(dto => dto.ProyectoDto))
                .ForMember(ent => ent.AreaFuncional, src => src.MapFrom(dto => dto.AreaFuncionalDto))
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<RolGobernanzaDto, RolGobernanza>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<RolDisciplinaDto, RolDisciplina>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<AreaFuncionalDto, AreaFuncional>()
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<AreaFuncional, AreaFuncionalDto>()
             .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<PaginacionDto, Paginacion>()
             .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            #endregion
        }
    }
}