using Minsur.OrdenServicio.Domain.DomainContract;
using Minsur.OrdenServicio.Domain.Entities;
using Minsur.OrdenServicio.Domain.RepositoryContract.Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Services
{
    public class AdministracionDomainService : IAdministracionDomainService
    {
        private readonly IAdministracionRepository oIAdministracionRepository;

        public AdministracionDomainService(IAdministracionRepository oIAdministracionRepository)
        {
            this.oIAdministracionRepository = oIAdministracionRepository;
        }

        public bool ValidarConfiguracionGobernanza(ListaConfiguracionGobernanza oListaConfiguracionGobernanza)
        {
            var gobernanzasSeleccionadas = oListaConfiguracionGobernanza.Where(x => x.IdEstado == 1).ToList();
            if (gobernanzasSeleccionadas.Count() == 0)
                return true;
            if (gobernanzasSeleccionadas[0].Gobernanza.Orden != 1)
                return false;
            bool existenOrdenesConsecutivos = ValidarGobernanzasConOrdenesConsecutivos(gobernanzasSeleccionadas);
            return existenOrdenesConsecutivos;
        }

        private bool ValidarGobernanzasConOrdenesConsecutivos(List<ConfiguracionGobernanza> gobernanzas)
        {
            return !gobernanzas.Select((x, index) => x.Gobernanza.Orden - index).Distinct().Skip(1).Any();
        }
        public void SetearFlagApruebaSolicitud(ListaConfiguracionGobernanza oListaConfiguracionGobernanza)
        {
            var maximoOrdenGobernanzaSeleccionada = oListaConfiguracionGobernanza.Where(x => x.IdEstado == 1).OrderByDescending(x => x.Gobernanza.Orden).FirstOrDefault();

            foreach (var item in oListaConfiguracionGobernanza)
            {
                if (maximoOrdenGobernanzaSeleccionada == null)
                {
                    item.FlagApruebaSolicitud = false;
                }
                else
                {
                    item.SetearFlagApruebaSolicitud(maximoOrdenGobernanzaSeleccionada.Gobernanza.Orden);
                }
            }

        }
        public bool ValidarConfiguracionUsuarioProyecto(ListaConfiguracionUsuarioProyecto oListaConfiguracionUsuarioProyecto)
        {
            foreach (var item in oListaConfiguracionUsuarioProyecto)
            {
                if (item.IdEstado != 1 && item.FlagConsultaOtros)
                    return false;
            }
            return true;
        }

        public ListaConfiguracionRol ObtenerListaRolesConfigurados(int idProyecto, ListaRolGobernanza roles, ListaRolDisciplina disciplinas)
        {
            ListaRolGobernanza oListaRolGobernanza = oIAdministracionRepository.ObtenerListaRolesGobernanzaConfigurados(idProyecto);
            ListaRolDisciplina oListaRolDisciplina = oIAdministracionRepository.ObtenerListaRolesDisciplinaConfigurados(idProyecto);

            var usuariosGobernanza = oListaRolGobernanza.GroupBy(x => x.IdUsuario).Select(grupo => new { IdUsuario = grupo.Key });
            var usuariosDisciplina = oListaRolDisciplina.GroupBy(x => x.IdUsuario).Select(grupo => new { IdUsuario = grupo.Key });

            var usuarios = usuariosGobernanza.Union(usuariosDisciplina);

            ListaConfiguracionRol oListaConfiguracionRol = new ListaConfiguracionRol();
            ConfiguracionRol oConfiguracionRol;
            RolGobernanza oRolGobernanza;
            RolDisciplina oRolDisciplina;

            foreach (var usuario in usuarios)
            {
                oConfiguracionRol = new ConfiguracionRol();
                oConfiguracionRol.Usuario = new Usuario { IdUsuario = usuario.IdUsuario };
                oConfiguracionRol.ListaRolGobernanza = new ListaRolGobernanza();
                oConfiguracionRol.ListaRolDisciplina = new ListaRolDisciplina();
                #region DISCIPLINAS
                foreach (var disciplina in disciplinas)
                {
                    oRolDisciplina = new RolDisciplina();
                    oRolDisciplina.IdUsuario = usuario.IdUsuario;
                    oRolDisciplina.IdProyecto = idProyecto;
                    oRolDisciplina.IdDisciplina = disciplina.IdDisciplina;
                    oRolDisciplina.Descripcion = disciplina.Descripcion;
                    var configuracion = oListaRolDisciplina.FirstOrDefault(x => x.IdDisciplina == oRolDisciplina.IdDisciplina && x.IdUsuario == oRolDisciplina.IdUsuario);
                    oRolDisciplina.IdEstado = configuracion == null ? 0 : configuracion.IdEstado;
                    oRolDisciplina.IdRolDisciplina = configuracion == null ? 0 : configuracion.IdRolDisciplina;

                    oConfiguracionRol.ListaRolDisciplina.Add(oRolDisciplina);
                }
                #endregion
                #region ROLES
                foreach (var rol in roles)
                {
                    oRolGobernanza = new RolGobernanza();
                    oRolGobernanza.IdUsuario = usuario.IdUsuario;
                    oRolGobernanza.IdRolGobernanza = rol.IdRolGobernanza;
                    oRolGobernanza.Orden = rol.Orden;

                    var configuraciones = oListaRolGobernanza.Where(x => x.IdRolGobernanza == rol.IdRolGobernanza && x.IdUsuario == oRolGobernanza.IdUsuario);
                    if (rol.IdRolGobernanza == 0)
                    {
                        if (configuraciones.Count() > 0)
                        {
                            oRolGobernanza.IdConfiguracionDestino = configuraciones.FirstOrDefault().IdConfiguracionDestino;
                            if (configuraciones.FirstOrDefault().IdEstado == 0)
                            {
                                oRolGobernanza.FlagTipoProcura = rol.FlagTipoProcura;
                            }
                            else
                            {
                                if (rol.FlagTipoProcura)
                                {
                                    oRolGobernanza.IdEstado = Convert.ToInt32(configuraciones.FirstOrDefault().FlagProcuraContrato);
                                    oRolGobernanza.FlagTipoProcura = true;
                                }
                                else
                                {
                                    oRolGobernanza.IdEstado = Convert.ToInt32(!configuraciones.FirstOrDefault().FlagProcuraContrato);
                                }
                            }
                        }
                        else
                        {
                            if (rol.FlagTipoProcura)
                                oRolGobernanza.FlagTipoProcura = true;
                        }
                    }
                    else if (rol.Orden == 1)
                    {
                        bool usuarioTieneDisciplinasConfiguradas = oListaRolDisciplina.Any(x => x.IdUsuario == usuario.IdUsuario && x.IdEstado == 1);
                        oRolGobernanza.IdEstado = Convert.ToInt32(usuarioTieneDisciplinasConfiguradas);
                    }
                    else
                    {
                        if (configuraciones.Count() > 0)
                        {
                            oRolGobernanza.IdEstado = configuraciones.FirstOrDefault().IdEstado;
                            oRolGobernanza.IdConfiguracionDestino = configuraciones.FirstOrDefault().IdConfiguracionDestino;
                        }
                    }
                    oConfiguracionRol.ListaRolGobernanza.Add(oRolGobernanza);
                }
                #endregion
                oListaConfiguracionRol.Add(oConfiguracionRol);
            }
            return oListaConfiguracionRol;
        }

        public bool ValidarConfiguracionRol(ListaConfiguracionRol oListaConfiguracionRol)
        {
            foreach (var configuracion in oListaConfiguracionRol)
            {
                var procuraYControl = configuracion.ListaRolGobernanza.Where(x => x.IdRolGobernanza == 0 && x.IdEstado == 1);
                if (procuraYControl.Count() > 1)
                    return false;
            }
            return true;
        }

        public ListaRolDisciplina ObtenerListaDisciplina(ListaConfiguracionRol oListaConfiguracionRol, int idProyecto)
        {
            ListaRolDisciplina oListaRolDisciplina = new ListaRolDisciplina();
            RolDisciplina oRolDisciplina;
            foreach (var configuracion in oListaConfiguracionRol)
            {
                var gerenteDisciplinaActivo = configuracion.ListaRolGobernanza.Any(x => x.Orden == 1);
                if (gerenteDisciplinaActivo)
                {
                    foreach (var item in configuracion.ListaRolDisciplina)
                    {
                        oRolDisciplina = new RolDisciplina();
                        oRolDisciplina.IdRolDisciplina = item.IdRolDisciplina;
                        oRolDisciplina.IdDisciplina = item.IdDisciplina;
                        oRolDisciplina.IdProyecto = idProyecto;
                        oRolDisciplina.IdUsuario = configuracion.Usuario.IdUsuario;
                        oRolDisciplina.IdEstado = item.IdEstado;

                        oListaRolDisciplina.Add(oRolDisciplina);
                    }
                }
            }
            return oListaRolDisciplina;
        }

        public ListaRolGobernanza ObtenerListaGobernanza(ListaConfiguracionRol oListaConfiguracionRol, int idProyecto)
        {
            ListaRolGobernanza oListaRolGobernanza = new ListaRolGobernanza();
            RolGobernanza oRolGobernanza;
            foreach(var configuracion in oListaConfiguracionRol)
            {
                foreach(var item in configuracion.ListaRolGobernanza.Where(x => x.Orden != 1 && x.IdRolGobernanza != 0))
                {
                    oRolGobernanza = new RolGobernanza();
                    oRolGobernanza.IdConfiguracionDestino = item.IdConfiguracionDestino;
                    oRolGobernanza.IdRolGobernanza = item.IdRolGobernanza;
                    oRolGobernanza.IdUsuario = configuracion.Usuario.IdUsuario;
                    oRolGobernanza.IdEstado = item.IdEstado;

                    oListaRolGobernanza.Add(oRolGobernanza);
                }
            }
            return oListaRolGobernanza;
        }
        public ListaRolGobernanza ObtenerListaProcura(ListaConfiguracionRol oListaConfiguracionRol, int idProyecto)
        {
            ListaRolGobernanza oListaRolGobernanza = new ListaRolGobernanza();
            RolGobernanza oRolGobernanza;
            foreach (var configuracion in oListaConfiguracionRol)
            {
                oRolGobernanza = new RolGobernanza();
                bool procuraOControlSeleccionados = configuracion.ListaRolGobernanza.Any(x => x.IdRolGobernanza == 0 && x.IdEstado == 1);
                var procura = configuracion.ListaRolGobernanza.Where(x => x.IdRolGobernanza == 0 && x.FlagTipoProcura).FirstOrDefault();

                oRolGobernanza.IdConfiguracionDestino = procura.IdConfiguracionDestino;
                oRolGobernanza.IdProyecto = idProyecto;
                oRolGobernanza.IdUsuario = configuracion.Usuario.IdUsuario;
                if (procuraOControlSeleccionados)
                {
                    oRolGobernanza.IdEstado = 1;
                    oRolGobernanza.FlagProcuraContrato = Convert.ToBoolean(procura.IdEstado);
                }
                else
                {
                    oRolGobernanza.IdEstado = 0;
                    oRolGobernanza.FlagProcuraContrato = false;
                }
                oListaRolGobernanza.Add(oRolGobernanza);
            }

            return oListaRolGobernanza;
        }

    }
}
