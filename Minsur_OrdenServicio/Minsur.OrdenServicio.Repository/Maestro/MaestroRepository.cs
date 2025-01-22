using Microsoft.Practices.EnterpriseLibrary.Data;
using Minsur.OrdenServicio.Domain.Entities;
using Minsur.OrdenServicio.Domain.RepositoryContract.Maestro;
using Minsur.OrdenServicio.Repository.Config;
using Minsur.OrdenServicio.Repository.Helper;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Minsur.OrdenServicio.Repository.Maestro
{
    public class MaestroRepository : IMaestroRepository
    {
        private readonly Database oDatabase;

        public MaestroRepository([Named("Solicitud")]IDataBaseConfig oIDataBaseConfig)
        {
            oDatabase = oIDataBaseConfig.Database;
        }

        public ListaTipo ListaTipo()
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Maestro.Usp_Sel_Tipo);
            ListaTipo oListaTipo = new ListaTipo();
            Tipo oTipo;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdTipo = oIDataReader.GetOrdinal("IdTipo");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");

                while (oIDataReader.Read())
                {
                    oTipo = new Tipo();
                    oTipo.IdTipo = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdTipo]);
                    oTipo.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);
                    oListaTipo.Add(oTipo);
                }
            }
            return oListaTipo;
        }

        public ListaAreaFuncional ListarAreaFuncional()
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Maestro.Usp_Sel_AreaFuncional);
            ListaAreaFuncional oListaAreaFuncional = new ListaAreaFuncional();
            AreaFuncional oAreaFuncional;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdAreaFuncional = oIDataReader.GetOrdinal("IdAreaFuncional");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");

                while (oIDataReader.Read())
                {
                    oAreaFuncional = new AreaFuncional();
                    oAreaFuncional.IdAreaFuncional = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdAreaFuncional]);
                    oAreaFuncional.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);

                    oListaAreaFuncional.Add(oAreaFuncional);
                }
            }

            return oListaAreaFuncional;
        }

        public ListaCompania ListarCompania(int idUsuario)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Maestro.Usp_Sel_Compania);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, idUsuario);

            ListaCompania oListaCompania = new ListaCompania();
            Compania oCompania;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdCompania = oIDataReader.GetOrdinal("IdCompania");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");

                while (oIDataReader.Read())
                {
                    oCompania = new Compania();
                    oCompania.IdCompania = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdCompania]);
                    oCompania.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);

                    oListaCompania.Add(oCompania);
                }
            }

            return oListaCompania;
        }

        public ListaFaseProyecto ListarFaseProyecto()
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Maestro.Usp_Sel_FaseProyecto);
            ListaFaseProyecto oListaFaseProyecto = new ListaFaseProyecto();
            FaseProyecto oFaseProyecto;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdFaseProyecto = oIDataReader.GetOrdinal("IdFaseProyecto");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");

                while (oIDataReader.Read())
                {
                    oFaseProyecto = new FaseProyecto();
                    oFaseProyecto.IdFaseProyecto = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdFaseProyecto]);
                    oFaseProyecto.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);

                    oListaFaseProyecto.Add(oFaseProyecto);
                }
            }

            return oListaFaseProyecto;
        }

        public ListaFuenteContrato ListarFuenteContrato()
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Maestro.Usp_Sel_FuenteContrato);
            ListaFuenteContrato oListaFuenteContrato = new ListaFuenteContrato();
            FuenteContrato oFuenteContrato;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdFuenteContrato = oIDataReader.GetOrdinal("IdFuenteContrato");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");

                while (oIDataReader.Read())
                {
                    oFuenteContrato = new FuenteContrato();
                    oFuenteContrato.IdFuenteContrato = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdFuenteContrato]);
                    oFuenteContrato.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);

                    oListaFuenteContrato.Add(oFuenteContrato);
                }
            }

            return oListaFuenteContrato;
        }

        public ListaMoneda ListarMoneda()
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Maestro.Usp_Sel_Moneda);
            ListaMoneda oListaMoneda = new ListaMoneda();
            Moneda oMoneda;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdMoneda = oIDataReader.GetOrdinal("IdMoneda");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");

                while (oIDataReader.Read())
                {
                    oMoneda = new Moneda();
                    oMoneda.IdMoneda = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdMoneda]);
                    oMoneda.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);

                    oListaMoneda.Add(oMoneda);
                }
            }

            return oListaMoneda;
        }

        public ListaProyecto ListarProyecto(int idCompania)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Maestro.Usp_Sel_Proyecto);
            oDatabase.AddInParameter(oDbCommand, "@IdCompania", DbType.Int32, idCompania);

            ListaProyecto oListaProyecto = new ListaProyecto();
            Proyecto oProyecto;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdProyecto = oIDataReader.GetOrdinal("IdProyecto");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");

                while (oIDataReader.Read())
                {
                    oProyecto = new Proyecto();
                    oProyecto.IdProyecto = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdProyecto]);
                    oProyecto.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);

                    oListaProyecto.Add(oProyecto);
                }
            }

            return oListaProyecto;
        }

        public ListaProyecto ListarProyectoPorUsuario(int idUsuario, int idCompania)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Maestro.Usp_Sel_Proyecto_Por_Usuario);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, idUsuario);
            oDatabase.AddInParameter(oDbCommand, "@IdCompania", DbType.Int32, idCompania);

            ListaProyecto oListaProyecto = new ListaProyecto();
            Proyecto oProyecto;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdProyecto = oIDataReader.GetOrdinal("IdProyecto");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");

                while (oIDataReader.Read())
                {
                    oProyecto = new Proyecto();
                    oProyecto.IdProyecto = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdProyecto]);
                    oProyecto.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);

                    oListaProyecto.Add(oProyecto);
                }
            }

            return oListaProyecto;
        }

        public ListaTipoDocumento ListarTipoDocumento()
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Maestro.Usp_Sel_TipoDocumento);
            ListaTipoDocumento oListaTipoDocumento = new ListaTipoDocumento();
            TipoDocumento oTipoDocumento;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdTipoDocumento = oIDataReader.GetOrdinal("IdTipoDocumento");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");

                while (oIDataReader.Read())
                {
                    oTipoDocumento = new TipoDocumento();
                    oTipoDocumento.IdTipoDocumento = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdTipoDocumento]);
                    oTipoDocumento.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);

                    oListaTipoDocumento.Add(oTipoDocumento);
                }
            }

            return oListaTipoDocumento;
        }

        public ListaPais ListarPais()
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Maestro.Usp_Sel_Pais);
            ListaPais oListaPais = new ListaPais();
            Pais oPais;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdPais = oIDataReader.GetOrdinal("IdPais");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");

                while (oIDataReader.Read())
                {
                    oPais = new Pais();
                    oPais.IdPais = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdPais]);
                    oPais.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);

                    oListaPais.Add(oPais);
                }
            }

            return oListaPais;
        }

        public ListaEstado ListarEstadoPorGrupo(int idGrupo)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Maestro.Usp_Sel_Estado_Por_IdGrupo);
            oDatabase.AddInParameter(oDbCommand, "@IdGrupoEstado", DbType.Int32, idGrupo);

            ListaEstado oListaEstado = new ListaEstado();
            Estado oEstado;

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdEstado = oIDataReader.GetOrdinal("IdEstado");
                int indice_Nombre = oIDataReader.GetOrdinal("Nombre");

                while (oIDataReader.Read())
                {
                    oEstado = new Estado();
                    oEstado.IdEstado = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdEstado]);
                    oEstado.Nombre = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Nombre]);

                    oListaEstado.Add(oEstado);
                }
            }

            return oListaEstado;
        }

        public Gobernanza ObtenerGobernanzaPorId(int idGobernanza)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Maestro.Usp_Sel_Gobernanza_Por_Id);
            oDatabase.AddInParameter(oDbCommand, "@IdGobernanza", DbType.Int32, idGobernanza);
            Gobernanza oGobernanza = new Gobernanza();

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdGobernanza = oIDataReader.GetOrdinal("IdGobernanza");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");

                if (oIDataReader.Read())
                {
                    oGobernanza.IdGobernanza = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdGobernanza]);
                    oGobernanza.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);
                }
            }

            return oGobernanza;
        }

        public EmailParametro ObtenerEmailParametro(int idEmailParametro)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.Maestro.Usp_Sel_EmailParametro_Por_Id);
            oDatabase.AddInParameter(oDbCommand, "@IdEmailParametro", DbType.Int32, idEmailParametro);
            EmailParametro oEmailParametro = new EmailParametro();

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int indice_IdEmailParametro = oIDataReader.GetOrdinal("IdEmailParametro");
                int indice_Descripcion = oIDataReader.GetOrdinal("Descripcion");
                int indice_Asunto = oIDataReader.GetOrdinal("Asunto");
                int indice_Para = oIDataReader.GetOrdinal("Para");
                int indice_ConCopia = oIDataReader.GetOrdinal("ConCopia");
                int indice_Plantilla = oIDataReader.GetOrdinal("Plantilla");

                if (oIDataReader.Read())
                {
                    oEmailParametro.IdEmailParametro = DataUtil.DbValueToDefault<int>(oIDataReader[indice_IdEmailParametro]);
                    oEmailParametro.Descripcion = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Descripcion]);
                    oEmailParametro.Asunto = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Asunto]);
                    oEmailParametro.Para = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Para]);
                    oEmailParametro.ConCopia = DataUtil.DbValueToDefault<string>(oIDataReader[indice_ConCopia]);
                    oEmailParametro.Plantilla = DataUtil.DbValueToDefault<string>(oIDataReader[indice_Plantilla]);
                }
            }

            return oEmailParametro;
        }
    }
}
