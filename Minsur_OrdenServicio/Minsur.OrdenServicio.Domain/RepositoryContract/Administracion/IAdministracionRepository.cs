using Minsur.OrdenServicio.Domain.Entities;
using System.Collections.Generic;
using System.Xml;

namespace Minsur.OrdenServicio.Domain.RepositoryContract.Administracion
{
    public interface IAdministracionRepository
    {
        ListaCompania ObtenerCompanias();
        void RegistrarCompania(Compania oCompania, Usuario oUsuario);
        void EditarCompania(Compania oCompania, Usuario oUsuario);
        ListaProyecto ObtenerProyectosPorCompania(int idCompania);
        void RegistrarProyecto(Proyecto oProyecto, Usuario oUsuario);
        void EditarProyecto(Proyecto oProyecto, Usuario oUsuario);
        ListaDisciplina ObtenerDisciplinas();
        void RegistrarDisciplina(Disciplina oDisciplina, Usuario oUsuario);
        void EditarDisciplina(Disciplina oDisciplina, Usuario oUsuario);
        ListaConfiguracionGobernanza ObtenerConfiguracionGobernanzaPorProyecto(int idProyecto);
        void GuardarConfiguracionGobernanzaPorProyecto(XmlDocument oXmlDocument, Usuario oUsuario, int idProyecto);
        ListaConfiguracionUsuarioProyecto ObtenerListaConfiguracionUsuarioProyecto(int idUsuario, int idCompania);
        void GuardarConfiguracionUsuarioProyecto(XmlDocument oXmlDocument, Usuario oUsuario, int idUsuarioConfiguracion, int idRolConfiguracion, int idEstado);
        ListaRolGobernanza ObtenerDescripcionRolesPorProyecto(int idProyecto);
        ListaRolGobernanza ObtenerListaRolesGobernanzaConfigurados(int idProyecto);
        ListaRolDisciplina ObtenerDisciplinasActivas();
        ListaRolDisciplina ObtenerListaRolesDisciplinaConfigurados(int idProyecto);
        void GuardarConfiguracionRol(XmlDocument oControlProyectoProcuraXml, XmlDocument oGobernanzaProyectoUsuarioXml, XmlDocument oAreaFuncionalProyectoUsuarioXml, Usuario oUsuario, int idProyecto);
    }
}
