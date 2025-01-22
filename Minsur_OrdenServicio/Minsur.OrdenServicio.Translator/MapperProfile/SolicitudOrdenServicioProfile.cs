using AutoMapper;
using Minsur.OrdenServicio.Common.Recursos;
using Minsur.OrdenServicio.Common.ExtensionMethod;
using Minsur.OrdenServicio.Common.Recursos;
using Minsur.OrdenServicio.Domain.Entities;
using Minsur.OrdenServicio.Domain.Entities.Xml;
using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Translator.MapperProfile
{
    public class SolicitudOrdenServicioProfile : Profile
    {
        public SolicitudOrdenServicioProfile()
        {
            #region ENT => DTO

            CreateMap<SolicitudOrdenServicioDashboard, SolicitudOrdenServicioDashboardDto>()
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudRegularizacion, SolicitudRegularizacionDto>()
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudOrdenServicioExport, SolicitudOrdenServicioExportDto>()
           .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudArchivoAdjunto, SolicitudArchivoAdjuntoDto>()
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudDocumento, SolicitudDocumentoDto>()
                .ForMember(dto => dto.TipoDocumentoDto, src => src.MapFrom(ent => ent.TipoDocumento))
                .ForMember(dto => dto.ListaSolicitudArchivoAdjuntoDto, src => src.MapFrom(ent => ent.ListaSolicitudArchivoAdjunto))
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudProveedorContratista, SolicitudProveedorContratistaDto>()
                .ForMember(dto => dto.PaisDto, src => src.MapFrom(ent => ent.Pais))
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudAutorizacion, SolicitudAutorizacionDto>()
                .ForMember(dto => dto.GobernanzaDto, src => src.MapFrom(ent => ent.Gobernanza))
                .ForMember(dto => dto.UsuarioDto, src => src.MapFrom(ent => ent.Usuario))
                .ForMember(dto => dto.Estado, src => src.MapFrom(ent => ent.FlagAprobado ? Constantes.Aprobado : Constantes.Rechazado))
                .ForMember(dto => dto.FechaRegistro, src => src.MapFrom(ent => ent.FechaRegistro.ToString("dd/MM/yyyy hh:mm:ss")))
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudRecomendacion, SolicitudRecomendacionDto>()
                .ForMember(dto => dto.UsuarioDto, src => src.MapFrom(ent => ent.Usuario))
                .ForMember(dto => dto.FechaRegistro, src => src.MapFrom(ent => ent.FechaRegistro.HasValue ? ent.FechaRegistro.Value.ToString("dd/MM/yyyy hh:mm:ss") : string.Empty ))
                .ForMember(dto => dto.Estado, src => src.MapFrom(ent => !ent.FechaRegistro.HasValue ? string.Empty : ent.FlagRecomendado ? Constantes.Recomienda : Constantes.NoRecomienda))
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudValidacion, SolicitudValidacionDto>()
                .ForMember(dto => dto.UsuarioDto, src => src.MapFrom(ent => ent.Usuario))
                .ForMember(dto => dto.FechaRegistro, src => src.MapFrom(ent => ent.FechaRegistro.HasValue ? ent.FechaRegistro.Value.ToString("dd/MM/yyyy hh:mm:ss") : string.Empty))
                .ForMember(dto => dto.Estado, src => src.MapFrom(ent => !ent.FechaRegistro.HasValue ? string.Empty : ent.FlagValidado ? Constantes.Validado : Constantes.NoValidado))
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudOrdenServicio, SolicitudOrdenServicioDto>()
                 .ForMember(dto => dto.FaseProyectoDto, src => src.MapFrom(ent => ent.FaseProyecto))
                 .ForMember(dto => dto.FuenteContratoDto, src => src.MapFrom(ent => ent.FuenteContrato))
                 .ForMember(dto => dto.CompaniaDto, src => src.MapFrom(ent => ent.Compania))
                 .ForMember(dto => dto.AreaFuncionalDto, src => src.MapFrom(ent => ent.AreaFuncional))
                 .ForMember(dto => dto.CategoriaDto, src => src.MapFrom(ent => ent.Categoria))
                 .ForMember(dto => dto.MonedaDto, src => src.MapFrom(ent => ent.Moneda))
                 .ForMember(dto => dto.TipoDto, src => src.MapFrom(ent => ent.Tipo))
                 .ForMember(dto => dto.ProyectoDto, src => src.MapFrom(ent => ent.Proyecto))
                 .ForMember(dto => dto.ListaSolicitudDocumentoDto, src => src.MapFrom(ent => ent.ListaSolicitudDocumento))
                 .ForMember(dto => dto.ListaSolicitudProveedorContratistaDto, src => src.MapFrom(ent => ent.ListaSolicitudProveedorContratista))
                 .ForMember(dto => dto.FechaSolicitud, src => src.MapFrom(ent => ent.FechaSolicitud.ToString("dd/MM/yyyy")))
                 .ForMember(dto => dto.FechaHoraSolicitud, src => src.MapFrom(ent => ent.FechaSolicitud.ToString("dd/MM/yyyy HH:mm:ss")))
                 .ForMember(dto => dto.FechaInicio, src => src.MapFrom(ent => ent.FechaInicio.ToString("dd/MM/yyyy")))
                 .ForMember(dto => dto.FechaTermino, src => src.MapFrom(ent => ent.FechaTermino.ToString("dd/MM/yyyy")))
                 .ForMember(dto => dto.UsuarioSolicitudDto, src => src.MapFrom(ent => ent.UsuarioSolicitud))
                 .ForMember(dto => dto.SolicitudValidacionDto, src => src.MapFrom(ent => ent.SolicitudValidacion))
                 .ForMember(dto => dto.SolicitudRecomendacionDto, src => src.MapFrom(ent => ent.SolicitudRecomendacion))
                 .ForMember(dto => dto.ListaSolicitudAutorizacionDto, src => src.MapFrom(ent => ent.ListaSolicitudAutorizacion))
                 .ForMember(dto => dto.EstadoDto, src => src.MapFrom(ent => ent.Estado))
                 .ForMember(dto => dto.SolicitudAutorizacionDto, src => src.MapFrom(ent => ent.SolicitudAutorizacion))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();


            CreateMap<SolicitudOrdenServicio, SolicitudOrdenServicioEmailDto>()
                 .ForMember(dto => dto.NumeroSolicitud, src => src.MapFrom(ent => ent.NumeroSolicitud))
                 .ForMember(dto => dto.FechaSolicitud, src => src.MapFrom(ent => ent.FechaSolicitud.ToString("dd/MM/yyyy")))
                 .ForMember(dto => dto.NombreSolicitante, src => src.MapFrom(ent => ent.UsuarioSolicitud.NombreApellido))
                 .ForMember(dto => dto.Compania, src => src.MapFrom(ent => ent.Compania.Descripcion))
                 .ForMember(dto => dto.FuenteContrato, src => src.MapFrom(ent => ent.FuenteContrato.Descripcion))
                 .ForMember(dto => dto.Proyecto, src => src.MapFrom(ent => ent.Proyecto.Descripcion))
                 .ForMember(dto => dto.FaseProyecto, src => src.MapFrom(ent => ent.FaseProyecto.Descripcion))
                 .ForMember(dto => dto.Area, src => src.MapFrom(ent => ent.AreaFuncional.Descripcion))
                 .ForMember(dto => dto.Categoria, src => src.MapFrom(ent => ent.Categoria.Descripcion))
                 .ForMember(dto => dto.DenomominacionServicio, src => src.MapFrom(ent => ent.DenominacionServicio))
                 .ForMember(dto => dto.Moneda, src => src.MapFrom(ent => ent.Moneda.Descripcion))
                 .ForMember(dto => dto.Monto, src => src.MapFrom(ent => ent.MontoEstimado))
                 .ForMember(dto => dto.TipoSolicitud, src => src.MapFrom(ent => ent.Tipo.Descripcion))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            #endregion

            #region DTO => ENT

            CreateMap<FiltroSolicitudDto, FiltroSolicitud>()
           .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudArchivoAdjuntoDto, SolicitudArchivoAdjunto>()
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudDocumentoDto, SolicitudDocumento>()
                .ForMember(ent => ent.TipoDocumento, src => src.MapFrom(dto => dto.TipoDocumentoDto))
                .ForMember(ent => ent.ListaSolicitudArchivoAdjunto, src => src.MapFrom(dto => dto.ListaSolicitudArchivoAdjuntoDto))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudProveedorContratistaDto, SolicitudProveedorContratista>()
                .ForMember(ent => ent.Pais, src => src.MapFrom(dto => dto.PaisDto))
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudAutorizacionDto, SolicitudAutorizacion>()
                .ForMember(ent => ent.Gobernanza, src => src.MapFrom(dto => dto.GobernanzaDto))
                .ForMember(ent => ent.Usuario, src => src.MapFrom(dto => dto.UsuarioDto))
                .ForMember(ent => ent.FlagAprobado, src => src.MapFrom(dto => dto.FlagAprobado))
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudRecomendacionDto, SolicitudRecomendacion>()
                .ForMember(ent => ent.Usuario, src => src.MapFrom(dto => dto.UsuarioDto))
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudValidacionDto, SolicitudValidacion>()
                .ForMember(ent => ent.Usuario, src => src.MapFrom(dto => dto.UsuarioDto))
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudOrdenServicioDto, SolicitudOrdenServicio>()
                 .ForMember(ent => ent.FaseProyecto, src => src.MapFrom(dto => dto.FaseProyectoDto))
                 .ForMember(ent => ent.FuenteContrato, src => src.MapFrom(dto => dto.FuenteContratoDto))
                 .ForMember(ent => ent.Compania, src => src.MapFrom(dto => dto.CompaniaDto))
                 .ForMember(ent => ent.AreaFuncional, src => src.MapFrom(dto => dto.AreaFuncionalDto))
                 .ForMember(ent => ent.Categoria, src => src.MapFrom(dto => dto.CategoriaDto))
                 .ForMember(ent => ent.Moneda, src => src.MapFrom(dto => dto.MonedaDto))
                 .ForMember(ent => ent.Tipo, src => src.MapFrom(dto => dto.TipoDto))
                 .ForMember(ent => ent.Proyecto, src => src.MapFrom(dto => dto.ProyectoDto))
                 .ForMember(ent => ent.ListaSolicitudDocumento, src => src.MapFrom(dto => dto.ListaSolicitudDocumentoDto))
                 .ForMember(ent => ent.ListaSolicitudProveedorContratista, src => src.MapFrom(dto => dto.ListaSolicitudProveedorContratistaDto))
                 .ForMember(ent => ent.FechaSolicitud, src => src.MapFrom(dto => DateTime.Parse(dto.FechaSolicitud)))
                 .ForMember(ent => ent.FechaInicio, src => src.MapFrom(dto => DateTime.Parse(dto.FechaInicio)))
                 .ForMember(ent => ent.FechaTermino, src => src.MapFrom(dto => DateTime.Parse(dto.FechaTermino)))
                 .ForMember(ent => ent.UsuarioSolicitud, src => src.MapFrom(dto => dto.UsuarioSolicitudDto))
                 .ForMember(ent => ent.SolicitudValidacion, src => src.MapFrom(dto => dto.SolicitudValidacionDto))
                 .ForMember(ent => ent.SolicitudRecomendacion, src => src.MapFrom(dto => dto.SolicitudRecomendacionDto))
                 .ForMember(ent => ent.ListaSolicitudAutorizacion, src => src.MapFrom(dto => dto.ListaSolicitudAutorizacionDto))
                 .ForMember(ent => ent.Estado, src => src.MapFrom(dto => dto.EstadoDto))
                 .ForMember(ent => ent.SolicitudAutorizacion, src => src.MapFrom(dto => dto.SolicitudAutorizacionDto))
                 .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            #endregion

            #region ENT => XML

            CreateMap<SolicitudArchivoAdjunto, SolicitudArchivoAdjuntoXml>()
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudDocumento, SolicitudDocumentoXml>()
                .ForMember(xml => xml.IdTipoDocumento, src => src.MapFrom(ent => ent.TipoDocumento.IdTipoDocumento))
                .ForMember(xml => xml.ListaSolicitudArchivoAdjuntoXml, src => src.MapFrom(ent => ent.ListaSolicitudArchivoAdjunto))
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudProveedorContratista, SolicitudProveedorContratistaXml>()
                .ForMember(xml =>xml.IdPais, src => src.MapFrom(ent => ent.Pais.IdPais))
                .ForMember(xml =>xml.DenominacionSocial, src => src.MapFrom(ent => ent.DenominacionSocial))
                .ForMember(xml =>xml.Documento, src => src.MapFrom(ent => ent.Documento))
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudAutorizacion, SolicitudAutorizacionXml>()
                .ForMember(xml => xml.IdSolicitudOrdenServicio, src => src.MapFrom(ent => ent.IdSolicitudOrdenServicio))
                .ForMember(xml => xml.IdGobernanza, src => src.MapFrom(ent => ent.Gobernanza.IdGobernanza))
                .ForMember(xml => xml.IdUsuario, src => src.MapFrom(ent => ent.Usuario.IdUsuario))
                .ForMember(xml => xml.Comentario, src => src.MapFrom(ent => ent.Comentario))
                .ForMember(xml => xml.FlagAprobado, src => src.MapFrom(ent => ent.FlagAprobado))
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<SolicitudOrdenServicio, SolicitudOrdenServicioXml>()
                 .ForMember(xml => xml.IdUsuarioSolicitante, src => src.MapFrom(ent => ent.UsuarioSolicitud.IdUsuario))
                 .ForMember(xml => xml.IdCompania, src => src.MapFrom(ent => ent.Compania.IdCompania))
                 .ForMember(xml => xml.IdFuenteContrato, src => src.MapFrom(ent => ent.FuenteContrato.IdFuenteContrato))
                 .ForMember(xml => xml.IdProyecto, src => src.MapFrom(ent => ent.Proyecto.IdProyecto))
                 .ForMember(xml => xml.IdTipo, src => src.MapFrom(ent => ent.Tipo.IdTipo))
                 .ForMember(xml => xml.IdFaseProyecto, src => src.MapFrom(ent => ent.FaseProyecto.IdFaseProyecto))
                 .ForMember(xml => xml.IdAreaFuncional, src => src.MapFrom(ent => ent.AreaFuncional.IdAreaFuncional))
                 .ForMember(xml => xml.IdCategoria, src => src.MapFrom(ent => ent.Categoria.IdCategoria))
                 .ForMember(xml => xml.IdMoneda, src => src.MapFrom(ent => ent.Moneda.IdMoneda))
                 .ForMember(xml => xml.FechaSolicitud, src => src.MapFrom(ent => ent.FechaSolicitud))
                 .ForMember(xml => xml.FechaSolicitudCorto, src => src.MapFrom(ent => ent.FechaSolicitud.ToString("yyyyMMdd")))
                 .ForMember(xml => xml.MontoEstimado, src => src.MapFrom(ent => ent.MontoEstimado))
                 .ForMember(xml => xml.FechaInicio, src => src.MapFrom(ent => ent.FechaInicio))
                 .ForMember(xml => xml.FechaTermino, src => src.MapFrom(ent => ent.FechaTermino))
                 .ForMember(xml => xml.IdEstado, src => src.MapFrom(ent => ent.Estado.IdEstado))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            #endregion

        }
    }
}
