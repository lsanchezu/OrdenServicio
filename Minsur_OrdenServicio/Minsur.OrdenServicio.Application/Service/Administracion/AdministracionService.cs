using AutoMapper;
using Minsur.OrdenServicio.Application.Contract.Administracion;
using Minsur.OrdenServicio.Application.Helper;
using Minsur.OrdenServicio.Common.Recursos;
using Minsur.OrdenServicio.Common.Xml;
using Minsur.OrdenServicio.Domain.DomainContract;
using Minsur.OrdenServicio.Domain.Entities;
using Minsur.OrdenServicio.Domain.Entities.Xml;
using Minsur.OrdenServicio.Domain.RepositoryContract.Administracion;
using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Body;
using Minsur.OrdenServicio.Seguridad.Domain.RepositoryContract;

namespace Minsur.OrdenServicio.Application.Service.Administracion
{
    public class AdministracionService : IAdministracionService
    {
        private readonly IAdministracionRepository oIAdministracionRepository;
        private readonly IAdministracionDomainService oIAdministracionDomainService;
        private readonly ISeguridadRepository oISeguridadRepository;
        private readonly IMapper _mapper;

        public AdministracionService(IAdministracionRepository oIAdministracionRepository, IAdministracionDomainService oIAdministracionDomainService, ISeguridadRepository oISeguridadRepository, IMapper mapper)
        {
            this.oIAdministracionRepository = oIAdministracionRepository;
            this.oIAdministracionDomainService = oIAdministracionDomainService;
            this.oISeguridadRepository = oISeguridadRepository;
            _mapper = mapper;
        }
        public ListaCompaniaDto ObtenerCompanias()
        {
            return _mapper.Map<ListaCompania, ListaCompaniaDto>(oIAdministracionRepository.ObtenerCompanias());
        }
        public TransactionResponse RegistrarCompania(TransactionRequest<CompaniaDto> oTransactionRequest)
        {
            Compania oCompania = _mapper.Map<CompaniaDto, Compania>(oTransactionRequest.EntidadDto);
            Usuario oUsuario = _mapper.Map<UsuarioDto, Usuario>(oTransactionRequest.Usuario);
            TransactionResponse oTransactionResponse = TransaccionHelper.RegistrarTransaccion(() => oIAdministracionRepository.RegistrarCompania(oCompania, oUsuario));
            return oTransactionResponse;
        }
        public TransactionResponse EditarCompania(int id, TransactionRequest<CompaniaDto> oTransactionRequest)
        {
            Compania oCompania = _mapper.Map<CompaniaDto, Compania>(oTransactionRequest.EntidadDto);
            Usuario oUsuario = _mapper.Map<UsuarioDto, Usuario>(oTransactionRequest.Usuario);
            oCompania.IdCompania = id;
            TransactionResponse oTransactionResponse = TransaccionHelper.RegistrarTransaccion(() => oIAdministracionRepository.EditarCompania(oCompania, oUsuario));
            return oTransactionResponse;
        }
        public ListaProyectoDto ObtenerProyectosPorCompania(int idCompania)
        {
            return _mapper.Map<ListaProyecto, ListaProyectoDto>(oIAdministracionRepository.ObtenerProyectosPorCompania(idCompania));
        }
        public TransactionResponse RegistrarProyecto(TransactionRequest<ProyectoDto> oTransactionRequest)
        {
            Proyecto oProyecto = _mapper.Map<ProyectoDto, Proyecto>(oTransactionRequest.EntidadDto);
            Usuario oUsuario = _mapper.Map<UsuarioDto, Usuario>(oTransactionRequest.Usuario);
            TransactionResponse oTransactionResponse = TransaccionHelper.RegistrarTransaccion(() => oIAdministracionRepository.RegistrarProyecto(oProyecto, oUsuario));
            return oTransactionResponse;
        }
        public TransactionResponse EditarProyecto(int id, TransactionRequest<ProyectoDto> oTransactionRequest)
        {
            Proyecto oProyecto = _mapper.Map<ProyectoDto, Proyecto>(oTransactionRequest.EntidadDto);
            Usuario oUsuario = _mapper.Map<UsuarioDto, Usuario>(oTransactionRequest.Usuario);
            oProyecto.IdProyecto = id;
            TransactionResponse oTransactionResponse = TransaccionHelper.RegistrarTransaccion(() => oIAdministracionRepository.EditarProyecto(oProyecto, oUsuario));
            return oTransactionResponse;
        }
        public ListaDisciplinaDto ObtenerDisciplinas()
        {
            return _mapper.Map<ListaDisciplina, ListaDisciplinaDto>(oIAdministracionRepository.ObtenerDisciplinas());
        }
        public TransactionResponse RegistrarDisciplina(TransactionRequest<DisciplinaDto> oTransactionRequest)
        {
            Disciplina oDisciplina = _mapper.Map<DisciplinaDto, Disciplina>(oTransactionRequest.EntidadDto);
            Usuario oUsuario = _mapper.Map<UsuarioDto, Usuario>(oTransactionRequest.Usuario);
            TransactionResponse oTransactionResponse = TransaccionHelper.RegistrarTransaccion(() => oIAdministracionRepository.RegistrarDisciplina(oDisciplina, oUsuario));
            return oTransactionResponse;
        }
        public TransactionResponse EditarDisciplina(int id, TransactionRequest<DisciplinaDto> oTransactionRequest)
        {
            Disciplina oDisciplina = _mapper.Map<DisciplinaDto, Disciplina>(oTransactionRequest.EntidadDto);
            Usuario oUsuario = _mapper.Map<UsuarioDto, Usuario>(oTransactionRequest.Usuario);
            oDisciplina.IdDisciplina = id;
            TransactionResponse oTransactionResponse = TransaccionHelper.RegistrarTransaccion(() => oIAdministracionRepository.EditarDisciplina(oDisciplina, oUsuario));
            return oTransactionResponse;
        }
        public ListaConfiguracionGobernanzaDto ObtenerConfiguracionGobernanzaPorProyecto(int idProyecto)
        {
            return _mapper.Map<ListaConfiguracionGobernanza, ListaConfiguracionGobernanzaDto>(oIAdministracionRepository.ObtenerConfiguracionGobernanzaPorProyecto(idProyecto));
        }
        public TransactionResponse GuardarConfiguracionGobernanzaPorProyecto(TransactionRequest<GobernanzaRequest> oTransactionRequest)
        {
            ListaConfiguracionGobernanza oListaConfiguracionGobernanza = _mapper.Map<ListaConfiguracionGobernanzaDto, ListaConfiguracionGobernanza>(oTransactionRequest.EntidadDto.ListaConfiguracionGobernanzaDto);
            Usuario oUsuario = _mapper.Map<UsuarioDto, Usuario>(oTransactionRequest.Usuario);
            int idProyecto = oTransactionRequest.EntidadDto.IdProyecto;

            TransactionResponse oTransactionResponse = new TransactionResponse();
            if (!oIAdministracionDomainService.ValidarConfiguracionGobernanza(oListaConfiguracionGobernanza))
            {
                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL00003);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL00003;
                return oTransactionResponse;
            }
            oIAdministracionDomainService.SetearFlagApruebaSolicitud(oListaConfiguracionGobernanza);

            ConfiguracionGobernanzaXml oConfiguracionGobernanzaXml = new ConfiguracionGobernanzaXml { ListaConfiguracionGobernanza = oListaConfiguracionGobernanza };
            oTransactionResponse = TransaccionHelper.RegistrarTransaccion(() => oIAdministracionRepository.GuardarConfiguracionGobernanzaPorProyecto(HelpXml.ObjectToXml(oConfiguracionGobernanzaXml), oUsuario, idProyecto));

            return oTransactionResponse;
        }

        public ListaConfiguracionUsuarioProyectoDto ObtenerListaConfiguracionUsuarioProyecto(FiltroConfiguracionUsuarioProyectoDto oFiltroConfiguracionUsuarioProyectoDto)
        {
            return _mapper.Map<ListaConfiguracionUsuarioProyecto, ListaConfiguracionUsuarioProyectoDto>(oIAdministracionRepository.ObtenerListaConfiguracionUsuarioProyecto(oFiltroConfiguracionUsuarioProyectoDto.IdUsuario, oFiltroConfiguracionUsuarioProyectoDto.IdCompania));

        }

        public TransactionResponse GuardarConfiguracionUsuarioProyecto(TransactionRequest<ConfiguracionUsuarioProyectoRequest> oTransactionRequest)
        {
            ListaConfiguracionUsuarioProyecto oListaConfiguracionUsuarioProyecto = _mapper.Map<ListaConfiguracionUsuarioProyectoDto, ListaConfiguracionUsuarioProyecto>(oTransactionRequest.EntidadDto.ListaConfiguracionUsuarioProyectoDto);
            Usuario oUsuario = _mapper.Map<UsuarioDto, Usuario>(oTransactionRequest.Usuario);

            TransactionResponse oTransactionResponse = new TransactionResponse();
            if (!oIAdministracionDomainService.ValidarConfiguracionUsuarioProyecto(oListaConfiguracionUsuarioProyecto))
            {
                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL00004);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL00004;
                return oTransactionResponse;
            }
            int idUsuarioConfiguracion = oTransactionRequest.EntidadDto.IdUsuario;
            int idRolConfiguracion = oTransactionRequest.EntidadDto.IdRol;
            int idEstado = oTransactionRequest.EntidadDto.IdEstado;
            ConfiguracionUsuarioProyectoXml oConfiguracionUsuarioProyectoXml = new ConfiguracionUsuarioProyectoXml { ListaConfiguracionUsuarioProyecto = oListaConfiguracionUsuarioProyecto };
            oTransactionResponse = TransaccionHelper.RegistrarTransaccion(() => oIAdministracionRepository.GuardarConfiguracionUsuarioProyecto(HelpXml.ObjectToXml(oConfiguracionUsuarioProyectoXml), oUsuario, idUsuarioConfiguracion, idRolConfiguracion, idEstado));

            return oTransactionResponse;
        }

        public GestionRolResponse ObtenerGestionRol(int idProyecto)
        {
            ListaRolGobernanza oListaRolGobernanza = oIAdministracionRepository.ObtenerDescripcionRolesPorProyecto(idProyecto);
            ListaRolDisciplina oListaRolDisciplina = oIAdministracionRepository.ObtenerDisciplinasActivas();

            GestionRolResponse oGestionRolResponse = new GestionRolResponse();
            oGestionRolResponse.ListaRoles = _mapper.Map<ListaRolGobernanza, ListaRolGobernanzaDto>(oListaRolGobernanza);
            oGestionRolResponse.ListaDisciplinas = _mapper.Map<ListaRolDisciplina, ListaRolDisciplinaDto>(oListaRolDisciplina);
            oGestionRolResponse.ListaConfiguracionRolDto = _mapper.Map<ListaConfiguracionRol, ListaConfiguracionRolDto>(oIAdministracionDomainService.ObtenerListaRolesConfigurados(idProyecto, oListaRolGobernanza, oListaRolDisciplina));

            return oGestionRolResponse;
        }

        public TransactionResponse GuardarConfiguracionRol(TransactionRequest<GestionRolRequest> oTransactionRequest)
        {
            ListaRolGobernanza oListaRolGobernanza = _mapper.Map<ListaRolGobernanzaDto, ListaRolGobernanza>(oTransactionRequest.EntidadDto.ListaRoles);
            ListaRolDisciplina oListaRolDisciplina = _mapper.Map<ListaRolDisciplinaDto, ListaRolDisciplina>(oTransactionRequest.EntidadDto.ListaDisciplinas);
            ListaConfiguracionRol oListaConfiguracionRol = _mapper.Map<ListaConfiguracionRolDto, ListaConfiguracionRol>(oTransactionRequest.EntidadDto.ListaConfiguracionRolDto);
            Usuario oUsuario = _mapper.Map<UsuarioDto, Usuario>(oTransactionRequest.Usuario);
            int idProyecto = oTransactionRequest.EntidadDto.IdProyecto;

            TransactionResponse oTransactionResponse = new TransactionResponse();
            if (!oIAdministracionDomainService.ValidarConfiguracionRol(oListaConfiguracionRol))
            {
                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL00005);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL00005;
                return oTransactionResponse;
            }

            AreaFuncionalProyectoUsuarioXml oAreaFuncionalProyectoUsuarioXml = new AreaFuncionalProyectoUsuarioXml {
                ListaRolDisciplina = oIAdministracionDomainService.ObtenerListaDisciplina(oListaConfiguracionRol, idProyecto) 
            };
            GobernanzaProyectoUsuarioXml oGobernanzaProyectoUsuarioXml = new GobernanzaProyectoUsuarioXml { 
                ListaRolGobernanza = oIAdministracionDomainService.ObtenerListaGobernanza(oListaConfiguracionRol, idProyecto) 
            };
            ControlProyectoProcuraXml oControlProyectoProcuraXml = new ControlProyectoProcuraXml { 
                ListaRolGobernanza = oIAdministracionDomainService.ObtenerListaProcura(oListaConfiguracionRol, idProyecto) 
            };

            oTransactionResponse = TransaccionHelper.RegistrarTransaccion(
                () => oIAdministracionRepository.GuardarConfiguracionRol(
                    HelpXml.ObjectToXml(oControlProyectoProcuraXml),
                    HelpXml.ObjectToXml(oGobernanzaProyectoUsuarioXml),
                    HelpXml.ObjectToXml(oAreaFuncionalProyectoUsuarioXml),
                    oUsuario,
                    idProyecto)
                );

            return oTransactionResponse;
        }
    }
}
