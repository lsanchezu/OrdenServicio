using AutoMapper;
using Minsur.OrdenServicio.Application.Contract.Maestro;
using Minsur.OrdenServicio.Common.Enumeracion;
using Minsur.OrdenServicio.Common.Estructura;
using Minsur.OrdenServicio.Domain.Entities;
using Minsur.OrdenServicio.Domain.RepositoryContract.Maestro;
using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Body;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Minsur.OrdenServicio.Application.Service.Maestro
{
    public class MaestroService : IMaestroService
    {
        private readonly IMaestroRepository oIMaestroRepository;
        private readonly IMapper _mapper;

        public MaestroService(IMaestroRepository oIMaestroRepository, IMapper mapper)
        {
            this.oIMaestroRepository = oIMaestroRepository;
            _mapper = mapper;
        }

        public MaestroSolicitudResponse ObtenerMaestroSolicitud(int idUsuario)
        {
            MaestroSolicitudResponse oMaestroSolicitudResponse = new MaestroSolicitudResponse();
            oMaestroSolicitudResponse.ListaProyectoDto = new ListaProyectoDto();

            Parallel.Invoke(
                () => oMaestroSolicitudResponse.ListaTipoDto = ListaTipo(),
                () => oMaestroSolicitudResponse.ListaAreaFuncionalDto = ListarAreaFuncional(),
                () => oMaestroSolicitudResponse.ListaCompaniaDto = ListarCompania(idUsuario),
                () => oMaestroSolicitudResponse.ListaFaseProyectoDto = ListarFaseProyecto(),
                () => oMaestroSolicitudResponse.ListaFuenteContratoDto = ListarFuenteContrato(),
                () => oMaestroSolicitudResponse.ListaMonedaDto = ListarMoneda(),
                () => oMaestroSolicitudResponse.ListaPaisDto = ListarPais(),
                () => oMaestroSolicitudResponse.ListaEstadoDto = ListarEstado((int)EnumSolicitudOrdenServicio.GrupoEstado.Solicitud));

            return oMaestroSolicitudResponse;
        }

        public ListaTipoDto ListaTipo()
        {
            return _mapper.Map<ListaTipo, ListaTipoDto>(oIMaestroRepository.ListaTipo());
        }
        public ListaAreaFuncionalDto ListarAreaFuncional()
        {
            return _mapper.Map<ListaAreaFuncional, ListaAreaFuncionalDto>(oIMaestroRepository.ListarAreaFuncional());
        }

        public ListaCompaniaDto ListarCompania(int idUsuario)
        {
             return _mapper.Map<ListaCompania, ListaCompaniaDto>(oIMaestroRepository.ListarCompania(idUsuario));
        }

        public ListaFaseProyectoDto ListarFaseProyecto()
        {
            return _mapper.Map<ListaFaseProyecto, ListaFaseProyectoDto>(oIMaestroRepository.ListarFaseProyecto());
        }

        public ListaFuenteContratoDto ListarFuenteContrato()
        {
            return _mapper.Map<ListaFuenteContrato, ListaFuenteContratoDto>(oIMaestroRepository.ListarFuenteContrato());
        }

        public ListaMonedaDto ListarMoneda()
        {
            return _mapper.Map<ListaMoneda, ListaMonedaDto>(oIMaestroRepository.ListarMoneda());
        }

        public ListaPaisDto ListarPais()
        {
            return _mapper.Map<ListaPais, ListaPaisDto>(oIMaestroRepository.ListarPais());
        }

        public ListaProyectoDto ListarProyectoPorUsuario(int idUsuario, int idCompania)
        {
            if(idUsuario == Numeracion.Cero)
            {
                return _mapper.Map<ListaProyecto, ListaProyectoDto>(oIMaestroRepository.ListarProyecto(idCompania));
            }

            return _mapper.Map<ListaProyecto, ListaProyectoDto>(oIMaestroRepository.ListarProyectoPorUsuario(idUsuario, idCompania));
        }

        public ListaEstadoDto ListarEstado(int idGruoEstado)
        {
            return _mapper.Map<ListaEstado, ListaEstadoDto>(oIMaestroRepository.ListarEstadoPorGrupo(idGruoEstado));
        }
    }
}
