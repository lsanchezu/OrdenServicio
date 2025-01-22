using Microsoft.Practices.EnterpriseLibrary.Data;
using Minsur.OrdenServicio.Repository.Config;
using Minsur.OrdenServicio.Repository.Helper;
using Minsur.OrdenServicio.Seguridad.Domain.Entities;
using Minsur.OrdenServicio.Seguridad.Domain.RepositoryContract;
using Ninject;
using System.Data;
using System.Data.Common;

namespace Minsur.OrdenServicio.Repository.Seguridad
{
    public class SeguridadRepository : ISeguridadRepository
    {
        private readonly Database oDatabase;
        public SeguridadRepository([Named("Seguridad")]IDataBaseConfig oIDataBaseConfig)
        {
            oDatabase = oIDataBaseConfig.Database;
        }

        public ListaUsuario ObtenerUsuarios(FiltroUsuario oFiltroUsuario, Paginacion oPaginacion)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Seguridad.Usp_Sel_Usuarios);
            oDatabase.AddInParameter(oDbCommand, "@Usuario", DbType.String, oFiltroUsuario.NombreUsuario ?? string.Empty);
            oDatabase.AddInParameter(oDbCommand, "@NombreApellido", DbType.String, oFiltroUsuario.NombreApellido ?? string.Empty);
            oDatabase.AddInParameter(oDbCommand, "@Page", DbType.Int32, oPaginacion.Page);
            oDatabase.AddInParameter(oDbCommand, "@RowsPerPage", DbType.Int32, oPaginacion.RowsPerPage);
            oDatabase.AddOutParameter(oDbCommand, "@RowCount", DbType.Int32, 0);
            ListaUsuario oListaUsuario = new ListaUsuario();
            Usuario oUsuario;
            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdUsuario = oIDataReader.GetOrdinal("IdUsuario");
                int indice_Usuario = oIDataReader.GetOrdinal("Usuario");
                int indice_NombreApellido = oIDataReader.GetOrdinal("NombreApellido");
                int indice_Correo = oIDataReader.GetOrdinal("Correo");
                int indice_IdEstado = oIDataReader.GetOrdinal("IdEstado");
                int indice_IdRol = oIDataReader.GetOrdinal("IdRol");

                while (oIDataReader.Read())
                {
                    oUsuario = new Usuario();
                    oUsuario.IdUsuario = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdUsuario]);
                    oUsuario.NombreUsuario = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Usuario]);
                    oUsuario.NombreApellido = DataUtil.DbValueToDefault<string>(oIDataReader[indice_NombreApellido]);
                    oUsuario.Correo = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Correo]);
                    oUsuario.IdEstado = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdEstado]);
                    oUsuario.IdRol = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdRol]);
                    oUsuario.Estado = oUsuario.IdEstado == 1 ? "ACTIVO" : "INACTIVO";

                    oListaUsuario.Add(oUsuario);
                }
            }
            oPaginacion.Total = (int)oDatabase.GetParameterValue(oDbCommand, "@RowCount");

            return oListaUsuario;
        }
        public void EditarUsuario(Usuario oUsuario)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Seguridad.Usp_Upd_Usuario);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, oUsuario.IdUsuario);
            oDatabase.AddInParameter(oDbCommand, "@Usuario", DbType.String, oUsuario.NombreUsuario);
            oDatabase.AddInParameter(oDbCommand, "@NombreApellido", DbType.String, oUsuario.NombreApellido);
            oDatabase.AddInParameter(oDbCommand, "@Correo", DbType.String, oUsuario.Correo);
            oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, oUsuario.IdEstado);

            oDatabase.ExecuteNonQuery(oDbCommand);
        }

        public void RegistrarUsuario(Usuario oUsuario)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Seguridad.Usp_Ins_Usuario);
            oDatabase.AddInParameter(oDbCommand, "@Usuario", DbType.String, oUsuario.NombreUsuario);
            oDatabase.AddInParameter(oDbCommand, "@NombreApellido", DbType.String, oUsuario.NombreApellido);
            oDatabase.AddInParameter(oDbCommand, "@Correo", DbType.String, oUsuario.Correo);
            oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, oUsuario.IdEstado);
            oDatabase.AddInParameter(oDbCommand, "@IdRol", DbType.Int32, oUsuario.IdRol);

            oDatabase.ExecuteNonQuery(oDbCommand);
        }

        public ListaUsuario ObtenerNombreUsuarios()
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Seguridad.Usp_Sel_NombreUsuarios);
            ListaUsuario oListaUsuario = new ListaUsuario();
            Usuario oUsuario;
            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdUsuario = oIDataReader.GetOrdinal("IdUsuario");
                int indice_Usuario = oIDataReader.GetOrdinal("Usuario");

                while (oIDataReader.Read())
                {
                    oUsuario = new Usuario();
                    oUsuario.IdUsuario = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdUsuario]);
                    oUsuario.NombreUsuario = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Usuario]);
                    oListaUsuario.Add(oUsuario);
                }
            }

            return oListaUsuario;
        }

        public Usuario ObtenerUsuarioPorCorreo(string correo)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Seguridad.Usp_Sel_Usuario_Por_Correo);
            oDatabase.AddInParameter(oDbCommand, "@Correo", DbType.String, correo);

            Usuario oUsuario = new Usuario();
            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdUsuario = oIDataReader.GetOrdinal("IdUsuario");
                int indice_Usuario = oIDataReader.GetOrdinal("Usuario");
                int indice_Correo= oIDataReader.GetOrdinal("Correo");

                while (oIDataReader.Read())
                {
                    oUsuario = new Usuario();
                    oUsuario.IdUsuario = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdUsuario]);
                    oUsuario.NombreUsuario = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Usuario]);
                    oUsuario.Correo = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Correo]);
                }
            }

            return oUsuario;
        }

        public Usuario ObtenerUsuarioPorCodigo(string codigoUsuario, string correo)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Seguridad.Usp_Sel_Usuario_Por_Codigo_O_Correo);
            oDatabase.AddInParameter(oDbCommand, "@CodigoUsuario", DbType.String, codigoUsuario);
            oDatabase.AddInParameter(oDbCommand, "@Correo", DbType.String, correo);

            Usuario oUsuario = new Usuario();
            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdUsuario = oIDataReader.GetOrdinal("IdUsuario");
                int indice_Usuario = oIDataReader.GetOrdinal("Usuario");
                int indice_Correo = oIDataReader.GetOrdinal("Correo");

                while (oIDataReader.Read())
                {
                    oUsuario = new Usuario();
                    oUsuario.IdUsuario = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdUsuario]);
                    oUsuario.NombreUsuario = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Usuario]);
                    oUsuario.Correo = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Correo]);
                }
            }

            return oUsuario;
        }

        public ListaRol ObtenerRoles()
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Seguridad.Usp_Sel_Roles);
            ListaRol oListaRol = new ListaRol();
            Rol oRol;
            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdRol = oIDataReader.GetOrdinal("IdRol");
                int indice_Nombre = oIDataReader.GetOrdinal("Nombre");
                while (oIDataReader.Read())
                {
                    oRol = new Rol();
                    oRol.IdRol = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdRol]);
                    oRol.Nombre = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Nombre]);

                    oListaRol.Add(oRol);
                }
            }
            return oListaRol;
        }
    }
}
