using Microsoft.Practices.EnterpriseLibrary.Data;
using Minsur.OrdenServicio.Domain.Entities;
using Minsur.OrdenServicio.Domain.RepositoryContract.Administracion;
using Minsur.OrdenServicio.Repository.Config;
using Minsur.OrdenServicio.Repository.Helper;
using Ninject;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Xml;

namespace Minsur.OrdenServicio.Repository.Administracion
{
    public class AdministracionRepository : IAdministracionRepository
    {
        private readonly Database oDatabase;
        public AdministracionRepository([Named("Solicitud")]IDataBaseConfig oIDataBaseConfig)
        {
            oDatabase = oIDataBaseConfig.Database;
        }

        public ListaCompania ObtenerCompanias()
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Administracion.Usp_Sel_Companias);
            ListaCompania oListaCompania = new ListaCompania();
            Compania oCompania;
            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdCompania = oIDataReader.GetOrdinal("IdCompania");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");
                int indice_IdEstado = oIDataReader.GetOrdinal("IdEstado");
                int indice_Estado = oIDataReader.GetOrdinal("Estado");

                while (oIDataReader.Read())
                {
                    oCompania = new Compania();
                    oCompania.IdCompania = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdCompania]);
                    oCompania.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);
                    oCompania.IdEstado = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdEstado]);
                    oCompania.Estado = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Estado]);

                    oListaCompania.Add(oCompania);
                }
            }
            return oListaCompania;
        }
        public void RegistrarCompania(Compania oCompania, Usuario oUsuario)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Administracion.Usp_Ins_Compania);
            oDatabase.AddInParameter(oDbCommand, "@Descripcion", DbType.String, oCompania.Descripcion);
            oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, oCompania.IdEstado);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuarioRegistro", DbType.Int32, oUsuario.IdUsuario);

            oDatabase.ExecuteNonQuery(oDbCommand);
        }
        public void EditarCompania(Compania oCompania, Usuario oUsuario)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Administracion.Usp_Upd_Compania);
            oDatabase.AddInParameter(oDbCommand, "@IdCompania", DbType.Int32, oCompania.IdCompania);
            oDatabase.AddInParameter(oDbCommand, "@Descripcion", DbType.String, oCompania.Descripcion);
            oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, oCompania.IdEstado);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuarioModificacion", DbType.Int32, oUsuario.IdUsuario);

            oDatabase.ExecuteNonQuery(oDbCommand);
        }
        public ListaProyecto ObtenerProyectosPorCompania(int idCompania)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Administracion.Usp_Sel_Proyecto_Por_Compania);
            oDatabase.AddInParameter(oDbCommand, "@IdCompania", DbType.Int32, idCompania);
            ListaProyecto oListaProyecto = new ListaProyecto();
            Proyecto oProyecto;
            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdProyecto = oIDataReader.GetOrdinal("IdProyecto");
                int indice_IdCompania = oIDataReader.GetOrdinal("IdCompania");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");
                int indice_IdEstado = oIDataReader.GetOrdinal("IdEstado");
                int indice_Estado = oIDataReader.GetOrdinal("Estado");

                while (oIDataReader.Read())
                {
                    oProyecto = new Proyecto();
                    oProyecto.IdProyecto = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdProyecto]);
                    oProyecto.IdCompania = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdCompania]);
                    oProyecto.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);
                    oProyecto.IdEstado = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdEstado]);
                    oProyecto.Estado = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Estado]);

                    oListaProyecto.Add(oProyecto);
                }
            }
            return oListaProyecto;
        }
        public void RegistrarProyecto(Proyecto oProyecto, Usuario oUsuario)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Administracion.Usp_Ins_Proyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdCompania", DbType.Int32, oProyecto.IdCompania);
            oDatabase.AddInParameter(oDbCommand, "@Descripcion", DbType.String, oProyecto.Descripcion);
            oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, oProyecto.IdEstado);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuarioRegistro", DbType.Int32, oUsuario.IdUsuario);

            oDatabase.ExecuteNonQuery(oDbCommand);
        }
        public void EditarProyecto(Proyecto oProyecto, Usuario oUsuario)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Administracion.Usp_Upd_Proyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdProyecto", DbType.Int32, oProyecto.IdProyecto);
            oDatabase.AddInParameter(oDbCommand, "@Descripcion", DbType.String, oProyecto.Descripcion);
            oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, oProyecto.IdEstado);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuarioModificacion", DbType.Int32, oUsuario.IdUsuario);

            oDatabase.ExecuteNonQuery(oDbCommand);

        }
        public ListaDisciplina ObtenerDisciplinas()
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Administracion.Usp_Sel_Disciplina);
            ListaDisciplina oListaDisciplina = new ListaDisciplina();
            Disciplina oDisciplina;
            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdDisciplina = oIDataReader.GetOrdinal("IdDisciplina");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");
                int indice_IdEstado = oIDataReader.GetOrdinal("IdEstado");
                int indice_Estado = oIDataReader.GetOrdinal("Estado");

                while (oIDataReader.Read())
                {
                    oDisciplina = new Disciplina();
                    oDisciplina.IdDisciplina = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdDisciplina]);
                    oDisciplina.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);
                    oDisciplina.IdEstado = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdEstado]);
                    oDisciplina.Estado = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Estado]);

                    oListaDisciplina.Add(oDisciplina);
                }
            }
            return oListaDisciplina;
        }
        public void RegistrarDisciplina(Disciplina oDisciplina, Usuario oUsuario)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Administracion.Usp_Ins_Disciplina);
            oDatabase.AddInParameter(oDbCommand, "@Descripcion", DbType.String, oDisciplina.Descripcion);
            oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, oDisciplina.IdEstado);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuarioRegistro", DbType.Int32, oUsuario.IdUsuario);

            oDatabase.ExecuteNonQuery(oDbCommand);
        }
        public void EditarDisciplina(Disciplina oDisciplina, Usuario oUsuario)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Administracion.Usp_Upd_Disciplina);
            oDatabase.AddInParameter(oDbCommand, "@IdDisciplina", DbType.Int32, oDisciplina.IdDisciplina);
            oDatabase.AddInParameter(oDbCommand, "@Descripcion", DbType.String, oDisciplina.Descripcion);
            oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, oDisciplina.IdEstado);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuarioModificacion", DbType.Int32, oUsuario.IdUsuario);

            oDatabase.ExecuteNonQuery(oDbCommand);
        }

        public ListaConfiguracionGobernanza ObtenerConfiguracionGobernanzaPorProyecto(int idProyecto)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Administracion.Usp_Sel_ConfiguracionGobernanza_Por_Proyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdProyecto", DbType.Int32, idProyecto);
            ListaConfiguracionGobernanza oListaConfiguracionGobernanza = new ListaConfiguracionGobernanza();
            ConfiguracionGobernanza oConfiguracionGobernanza;
            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdGobernanzaProyecto = oIDataReader.GetOrdinal("IdGobernanzaProyecto");
                int indice_IdGobernanza = oIDataReader.GetOrdinal("IdGobernanza");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");
                int indice_Orden = oIDataReader.GetOrdinal("Orden");
                int indice_IdEstado = oIDataReader.GetOrdinal("IdEstado");
                int indice_FlagApruebaSolicitud = oIDataReader.GetOrdinal("FlagApruebaSolicitud");
          
                while (oIDataReader.Read())
                {
                    oConfiguracionGobernanza = new ConfiguracionGobernanza();
                    oConfiguracionGobernanza.IdConfiguracionGobernanza = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdGobernanzaProyecto]);
                    oConfiguracionGobernanza.IdEstado = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdEstado]);
                    oConfiguracionGobernanza.FlagApruebaSolicitud = DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagApruebaSolicitud]);
                    oConfiguracionGobernanza.Gobernanza = new Gobernanza();
                    oConfiguracionGobernanza.Gobernanza.IdGobernanza = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdGobernanza]);
                    oConfiguracionGobernanza.Gobernanza.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);
                    oConfiguracionGobernanza.Gobernanza.Orden = DataUtil.DbValueToDefault<int>(oIDataReader[indice_Orden]);

                    oListaConfiguracionGobernanza.Add(oConfiguracionGobernanza);
                }
            }
            return oListaConfiguracionGobernanza;
        }

        public void GuardarConfiguracionGobernanzaPorProyecto(XmlDocument oXmlDocument, Usuario oUsuario, int idProyecto)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Administracion.Usp_Guardar_ConfiguracionGobernanza);
            oDatabase.AddInParameter(oDbCommand, "@ConfiguracionGobernanzaXml", DbType.Xml, oXmlDocument.DocumentElement.InnerXml);
            oDatabase.AddInParameter(oDbCommand, "@IdProyecto", DbType.Int32, idProyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, oUsuario.IdUsuario);

            oDatabase.ExecuteNonQuery(oDbCommand);
        }

        public ListaConfiguracionUsuarioProyecto ObtenerListaConfiguracionUsuarioProyecto(int idUsuario, int idCompania)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Administracion.Usp_Sel_ConfiguracionProyecto_Por_usuario);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, idUsuario);
            oDatabase.AddInParameter(oDbCommand, "@IdCompania", DbType.Int32, idCompania);
            ListaConfiguracionUsuarioProyecto oListaConfiguracionUsuarioProyecto = new ListaConfiguracionUsuarioProyecto();
            ConfiguracionUsuarioProyecto oConfiguracionUsuarioProyecto;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdUsuarioProyecto = oIDataReader.GetOrdinal("IdUsuarioProyecto");
                int indice_IdProyecto = oIDataReader.GetOrdinal("IdProyecto");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");
                int indice_IdEstado = oIDataReader.GetOrdinal("IdEstado");
                int indice_FlagConsultaOtros = oIDataReader.GetOrdinal("FlagConsultaOtros");
                int indice_IdUsuario = oIDataReader.GetOrdinal("IdUsuario");

                while (oIDataReader.Read())
                {
                    oConfiguracionUsuarioProyecto = new ConfiguracionUsuarioProyecto();
                    oConfiguracionUsuarioProyecto.IdConfiguracionProyecto = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdUsuarioProyecto]);
                    oConfiguracionUsuarioProyecto.IdEstado = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdEstado]);
                    oConfiguracionUsuarioProyecto.FlagConsultaOtros = DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagConsultaOtros]);
                    oConfiguracionUsuarioProyecto.IdUsuario = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdUsuario]);
                    oConfiguracionUsuarioProyecto.Proyecto = new Proyecto();
                    oConfiguracionUsuarioProyecto.Proyecto.IdProyecto = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdProyecto]);
                    oConfiguracionUsuarioProyecto.Proyecto.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);

                    oListaConfiguracionUsuarioProyecto.Add(oConfiguracionUsuarioProyecto);
                }
            }

            return oListaConfiguracionUsuarioProyecto;
        }

        public void GuardarConfiguracionUsuarioProyecto(XmlDocument oXmlDocument, Usuario oUsuario,int idUsuarioConfiguracion, int idRolConfiguracion, int idEstado)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Administracion.Usp_Guardar_ConfiguracionUsuarioProyecto);
            oDatabase.AddInParameter(oDbCommand, "@ConfiguracionUsuarioProyectoXml", DbType.Xml, oXmlDocument.DocumentElement.InnerXml);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, oUsuario.IdUsuario);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuarioConfiguracion", DbType.Int32, idUsuarioConfiguracion);
            oDatabase.AddInParameter(oDbCommand, "@IdRolConfiguracion", DbType.Int32, idRolConfiguracion);
            oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, idEstado);

            oDatabase.ExecuteNonQuery(oDbCommand);
        }

        public ListaRolGobernanza ObtenerDescripcionRolesPorProyecto(int idProyecto)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Administracion.Usp_Sel_Roles_De_Gobernanza_Por_Proyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdProyecto", DbType.Int32, idProyecto);
            ListaRolGobernanza oListaRolGobernanza = new ListaRolGobernanza();
            RolGobernanza oRolGobernanza;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdRolGobernanza = oIDataReader.GetOrdinal("IdRolGobernanza");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");
                int indice_Orden = oIDataReader.GetOrdinal("Orden");
                int indice_FlagTipoProcura = oIDataReader.GetOrdinal("FlagTipoProcura");
                while (oIDataReader.Read())
                {
                    oRolGobernanza = new RolGobernanza();
                    oRolGobernanza.IdRolGobernanza = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdRolGobernanza]);
                    oRolGobernanza.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);
                    oRolGobernanza.Orden = DataUtil.DbValueToDefault<int>(oIDataReader[indice_Orden]);
                    oRolGobernanza.FlagTipoProcura = DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagTipoProcura]);
                    oListaRolGobernanza.Add(oRolGobernanza);
                }
            }
            return oListaRolGobernanza;
        }

        public ListaRolGobernanza ObtenerListaRolesGobernanzaConfigurados(int idProyecto)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Administracion.Usp_Sel_Roles_De_Gobernanza_Configurados);
            oDatabase.AddInParameter(oDbCommand, "@IdProyecto", DbType.Int32, idProyecto);
            ListaRolGobernanza oListaRolGobernanza = new ListaRolGobernanza();
            RolGobernanza oRolGobernanza;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdConfiguracionDestino = oIDataReader.GetOrdinal("IdConfiguracionDestino");
                int indice_IdUsuario = oIDataReader.GetOrdinal("IdUsuario");
                int indice_IdRolGobernanza = oIDataReader.GetOrdinal("IdRolGobernanza");
                int indice_IdEstado = oIDataReader.GetOrdinal("IdEstado");
                int indice_FlagProcuraContrato = oIDataReader.GetOrdinal("FlagProcuraContrato");
                while (oIDataReader.Read())
                {
                    oRolGobernanza = new RolGobernanza();
                    oRolGobernanza.IdConfiguracionDestino = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdConfiguracionDestino]);
                    oRolGobernanza.IdUsuario = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdUsuario]);
                    oRolGobernanza.IdRolGobernanza = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdRolGobernanza]);
                    oRolGobernanza.IdEstado = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdEstado]);
                    oRolGobernanza.FlagProcuraContrato = DataUtil.DbValueToDefault<bool>(oIDataReader[indice_FlagProcuraContrato]);

                    oListaRolGobernanza.Add(oRolGobernanza);
                }
            }
            return oListaRolGobernanza;
        }

        public ListaRolDisciplina ObtenerDisciplinasActivas()
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Administracion.Usp_Sel_Disciplinas_Activas);
            ListaRolDisciplina oListaRolDisciplina = new ListaRolDisciplina();
            RolDisciplina oRolDisciplina;
            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdDisciplina = oIDataReader.GetOrdinal("IdDisciplina");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");
    
                while (oIDataReader.Read())
                {
                    oRolDisciplina = new RolDisciplina();
                    oRolDisciplina.IdDisciplina = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdDisciplina]);
                    oRolDisciplina.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);

                    oListaRolDisciplina.Add(oRolDisciplina);
                }
            }
            return oListaRolDisciplina;
        }

        public ListaRolDisciplina ObtenerListaRolesDisciplinaConfigurados(int idProyecto)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Administracion.Usp_Sel_Roles_De_Disciplina_Configurados);
            oDatabase.AddInParameter(oDbCommand, "@IdProyecto", DbType.Int32, idProyecto);
            ListaRolDisciplina oListaRolDisciplina = new ListaRolDisciplina();
            RolDisciplina oRolDisciplina;
            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdRolDisciplina = oIDataReader.GetOrdinal("IdRolDisciplina");
                int indice_IdDisciplina = oIDataReader.GetOrdinal("IdDisciplina");
                int indice_IdProyecto = oIDataReader.GetOrdinal("IdProyecto");
                int indice_IdUsuario = oIDataReader.GetOrdinal("IdUsuario");
                int indice_IdEstado = oIDataReader.GetOrdinal("IdEstado");

                while (oIDataReader.Read())
                {
                    oRolDisciplina = new RolDisciplina();
                    oRolDisciplina.IdRolDisciplina = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdRolDisciplina]);
                    oRolDisciplina.IdDisciplina = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdDisciplina]);
                    oRolDisciplina.IdProyecto = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdProyecto]);
                    oRolDisciplina.IdUsuario = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdUsuario]);
                    oRolDisciplina.IdEstado = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdEstado]);

                    oListaRolDisciplina.Add(oRolDisciplina);
                }
            }
            return oListaRolDisciplina;
        }

        public void GuardarConfiguracionRol(XmlDocument oControlProyectoProcuraXml, XmlDocument oGobernanzaProyectoUsuarioXml, XmlDocument oAreaFuncionalProyectoUsuarioXml, Usuario oUsuario, int idProyecto)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Administracion.Usp_Guardar_ConfiguracionRol);
            oDatabase.AddInParameter(oDbCommand, "@ControlProyectoProcuraXml", DbType.Xml, oControlProyectoProcuraXml.DocumentElement.InnerXml);
            oDatabase.AddInParameter(oDbCommand, "@GobernanzaProyectoUsuarioXml", DbType.Xml, oGobernanzaProyectoUsuarioXml.DocumentElement.InnerXml);
            oDatabase.AddInParameter(oDbCommand, "@AreaFuncionalProyectoUsuarioXml", DbType.Xml, oAreaFuncionalProyectoUsuarioXml.DocumentElement.InnerXml);
            oDatabase.AddInParameter(oDbCommand, "@IdProyecto", DbType.Int32, idProyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, oUsuario.IdUsuario);

            oDatabase.ExecuteNonQuery(oDbCommand);
        }
    }
}
