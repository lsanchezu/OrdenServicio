using Minsur.OrdenServicio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.RepositoryContract.Maestro
{
    public interface IMaestroRepository
    {
        ListaTipo ListaTipo();
        ListaAreaFuncional ListarAreaFuncional();
        ListaCompania ListarCompania(int idUsuario);
        ListaFaseProyecto ListarFaseProyecto();
        ListaFuenteContrato ListarFuenteContrato();
        ListaMoneda ListarMoneda();
        ListaProyecto ListarProyecto(int idCompania);
        ListaProyecto ListarProyectoPorUsuario(int idUsuario, int idCompania);
        ListaTipoDocumento ListarTipoDocumento();
        ListaPais ListarPais();
        ListaEstado ListarEstadoPorGrupo(int idGrupo);
        Gobernanza ObtenerGobernanzaPorId(int idGobernanza);
        EmailParametro ObtenerEmailParametro(int idEmailParametro);
    }
}
