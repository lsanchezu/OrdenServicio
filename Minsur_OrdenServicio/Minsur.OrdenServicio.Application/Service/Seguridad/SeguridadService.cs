using AutoMapper;
using Minsur.OrdenServicio.Application.Contract.Seguridad;
using Minsur.OrdenServicio.Common.Recursos;
using Minsur.OrdenServicio.DTO.Seguridad;
using Minsur.OrdenServicio.Seguridad.Domain.DomainContract;
using Minsur.OrdenServicio.Seguridad.Domain.Entities;
using Minsur.OrdenServicio.Seguridad.Domain.RepositoryContract;
using Serilog;
using System;

namespace Minsur.OrdenServicio.Application.Service.Seguridad
{
    public class SeguridadService : ISeguridadService
    {
        private readonly ISeguridadRepository oISeguridadRepository;
        private readonly ISeguridadDomainService oISeguridadDomainService;
        private readonly IMapper _mapper;

        public SeguridadService(ISeguridadRepository oISeguridadRepository, ISeguridadDomainService oISeguridadDomainService, IMapper mapper)
        {
            this.oISeguridadDomainService = oISeguridadDomainService;
            this.oISeguridadRepository = oISeguridadRepository;
            _mapper = mapper;
        }

        public PaginationResponse<UsuarioDto> ObtenerUsuarios(PaginationRequest<FiltroUsuarioDto> oPaginationRequest)
        {
            FiltroUsuario oFiltroUsuario = _mapper.Map<FiltroUsuarioDto, FiltroUsuario>(oPaginationRequest.FiltroBusqueda);
            Paginacion oPaginacion = _mapper.Map<PaginacionDto, Paginacion>(oPaginationRequest.PaginacionDto);

            PaginationResponse<UsuarioDto> oPaginationResponse = new PaginationResponse<UsuarioDto>();
            oPaginationResponse.Resultado = _mapper.Map<ListaUsuario, ListaUsuarioDto>(oISeguridadRepository.ObtenerUsuarios(oFiltroUsuario, oPaginacion));

            oPaginationResponse.PaginacionDto = _mapper.Map<Paginacion, PaginacionDto>(oPaginacion);

            return oPaginationResponse;

        }
        public TransactionResponse EditarUsuario(int id, UsuarioDto oUsuarioDto)
        {
            Usuario oUsuario = _mapper.Map<UsuarioDto, Usuario>(oUsuarioDto);
            oUsuario.IdUsuario = id;
            TransactionResponse oTransactionResponse = new TransactionResponse();
            try
            {
                oISeguridadRepository.EditarUsuario(oUsuario);
                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL00000);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL00000;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL99999);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL99999;
            }
            return oTransactionResponse;

        }

        public TransactionResponse RegistrarUsuario(UsuarioDto oUsuarioDto)
        {
            Usuario oUsuario = _mapper.Map<UsuarioDto, Usuario>(oUsuarioDto);
            TransactionResponse oTransactionResponse = new TransactionResponse();
            if (oISeguridadDomainService.ValidarUsuarioExistente(oUsuario))
            {
                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL00006);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL00006;
                return oTransactionResponse;
            }
            try
            {
                oISeguridadRepository.RegistrarUsuario(oUsuario);
                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL00000);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL00000;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL99999);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL99999;
            }
            return oTransactionResponse;

        }

        public ListaUsuarioDto ObtenerNombreUsuarios()
        {
            return _mapper.Map<ListaUsuario, ListaUsuarioDto>(oISeguridadRepository.ObtenerNombreUsuarios());
        }

        public UsuarioDto ObtenerUsuarioPorCorreo(string correo)
        {
            return _mapper.Map<Usuario, UsuarioDto>(oISeguridadRepository.ObtenerUsuarioPorCorreo(correo));
        }

        public ListaRolDto ObtenerRoles()
        {
            return _mapper.Map<ListaRol, ListaRolDto>(oISeguridadRepository.ObtenerRoles());
        }
    }
}
